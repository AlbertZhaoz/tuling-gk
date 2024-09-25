using HslCommunication;
using HslCommunication.Core.Net;
using HslCommunication.LogNet;
using HslCommunication.MQTT;
using Microsoft.Extensions.Configuration;
using SqlSugar;
using System.Text;
using System.Text.Json;
using VOL.Albert.Edge.Mqtt;

object _locker = new object();

ILogNet lognet = new LogNetSingle("");
lognet.ConsoleOutput = true;
lognet.SetMessageDegree(HslMessageDegree.INFO);

if (HslCommunication.Authorization.SetAuthorizationCode("66634f11-68dc-45d5-9638-fccb9f6b8fed"))
{
    lognet.WriteInfo("Hsl actived");
}
else
{
    lognet.WriteError("Hsl not actived");
}

var mqttEntity = new ConfigurationBuilder()
    .AddJsonFile("appsettings.mqtt.json", false, true)
    .Build()
    .Get<MqttEntity>();

var db = new SqlSugarClient(new ConnectionConfig()
{
    ConnectionString = mqttEntity.SqlSugarConnect.DbConnectStr,
    DbType = DbType.SqlServer,
    IsAutoCloseConnection = true,
});

// 发布订阅模式 MQTT
var mqttClient = new MqttClient(new MqttConnectionOptions()
{
    IpAddress = mqttEntity.MqttClientInfo.IpAddress,
    Port = mqttEntity.MqttClientInfo.Port,
    // 增加用户名密码确认
    Credentials = new MqttCredential(mqttEntity.Credentials.User, mqttEntity.Credentials.Password),  
    // 通信加密
    UseRSAProvider = true,                                
});

var webApi = new NetworkWebApiBase(mqttEntity.WebApiInfo.IpAddress, mqttEntity.WebApiInfo.Port
    , mqttEntity.Credentials.User, mqttEntity.Credentials.Password);

// 绑定事件显示
mqttClient.OnMqttMessageReceived += MqttClient_OnMqttMessageReceived;  
OperateResult connect = mqttClient.ConnectServer();
if (!connect.IsSuccess)
{
    lognet.WriteInfo("Connect failed: " + connect.Message);
    Console.ReadLine();
    return;
}

mqttEntity.AlbertEdgeInfo.ForEach(x =>
{
    lognet.WriteInfo("订阅主题: " + x.EdgeTopic);
    mqttClient.SubscribeMessage(x.EdgeTopic);
});



Console.ReadLine();
mqttClient.ConnectClose();

void MqttClient_OnMqttMessageReceived(MqttClient client, string topic, byte[] payload)
{
    try
    {
        lognet.WriteInfo($"监测到变更-{topic}-{Encoding.UTF8.GetString(payload)}");

        var albertEdgeInfo = mqttEntity.AlbertEdgeInfo.FirstOrDefault(x => x.EdgeTopic == topic);

        if (albertEdgeInfo != null && Encoding.UTF8.GetString(payload) == albertEdgeInfo.EdgeTopicValue)
        {
            Task.Run(() =>
            {
                lock (_locker)
                {
                    string lastStation = "";
                    string lastResult = "";

                    albertEdgeInfo?.EdgeTopicProcess.OrderBy(x => x.Order).ToList().ForEach(x =>
                    {
                        lognet.WriteInfo($"{x.Description} 开始执行");

                        // 不启用该流程
                        if (x.IsUse == "0")
                        {
                            lognet.WriteInfo($"{x.Description} 未启用该流程");
                            return;
                        }

                        if (x.EdgeType == "WebApi")
                        {
                            if (x.EdgeMethod.Contains("Post"))
                            {
                                // 带上 NotResult,则无需判断上一站结果
                                if (!x.EdgeMethod.Contains("NotResult") && lastResult != "OK")
                                {
                                    lognet.WriteError($"上一站结果不为OK，不执行");
                                    return;
                                }

                                x.EdgeSubList?.ForEach(edgeSub =>
                                {
                                    // 不启用该流程
                                    if (edgeSub.SubIsUse == "0")
                                    {
                                        lognet.WriteInfo($"{edgeSub.SubDescription} 未启用该流程");
                                        return;
                                    }

                                    if (edgeSub?.SubEdgeType == "WebApi")
                                    {
                                        if (edgeSub?.SubMethod == "Get")
                                        {
                                            lognet.WriteInfo($"{edgeSub.SubDescription} 开始");
                                            var result = webApi.Get(edgeSub.SubUrl);

                                            if (result.IsSuccess && (!string.IsNullOrEmpty(result.Content)))
                                            {
                                                var resultStr = DesrializeFromResult(edgeSub.SubDateType, edgeSub.SubDateTypeLength, result.Content);

                                                if (string.IsNullOrEmpty(resultStr))
                                                {
                                                    lognet.WriteInfo($"{edgeSub.SubDescription} 失败,值为空 {result.Content}");
                                                }
                                                else
                                                {
                                                    x.EdgeBody = x.EdgeBody.Replace($"@value{edgeSub.SubOrder}", resultStr);
                                                    lognet.WriteInfo($"{edgeSub.SubDescription} 成功,{x.EdgeBody}");
                                                }
                                            }
                                            else
                                            {
                                                lognet.WriteError($"{x.Description} 失败，信息为{result.Message}");
                                            }
                                        }

                                        if (edgeSub?.SubMethod == "Post[NotResult]")
                                        {

                                        }
                                    }

                                    if (edgeSub?.SubEdgeType == "SqlSugar")
                                    {

                                    }
                                });

                                // 执行外层的 Post 请求
                                var result = webApi.Post(x.EdgeUrl, x.EdgeBody);

                                if (!result.IsSuccess)
                                {
                                    lognet.WriteError($"{x.Description} 失败，信息为{result.Message}");
                                }
                                else
                                {
                                    lognet.WriteInfo($"{x.Description} 成功，信息为{x.EdgeBody}");
                                }
                            }

                            if (x.EdgeMethod == "Get")
                            {

                            }
                        }

                        if (x.EdgeType == "SqlSugar")
                        {
                            if (x.EdgeMethod == "SELECT")
                            {
                                x.EdgeSubList.ForEach(edgeSub =>
                                {
                                    // 不启用该流程
                                    if (edgeSub.SubIsUse == "0")
                                    {
                                        lognet.WriteInfo($"{edgeSub.SubDescription} 未启用该流程");
                                        return;
                                    }

                                    if (edgeSub?.SubEdgeType == "WebApi")
                                    {
                                        if (edgeSub?.SubMethod == "Get")
                                        {
                                            lognet.WriteInfo($"{edgeSub.SubDescription} 开始");
                                            var result = webApi.Get(edgeSub.SubUrl);

                                            if (result.IsSuccess && (!string.IsNullOrEmpty(result.Content)))
                                            {
                                                var resultStr = DesrializeFromResult(edgeSub.SubDateType, edgeSub.SubDateTypeLength, result.Content);

                                                if (string.IsNullOrEmpty(resultStr))
                                                {
                                                    lognet.WriteInfo($"{x.Description} 失败,值为空 {result.Content}");
                                                }
                                                else
                                                {
                                                    x.EdgeBody = x.EdgeBody.Replace($"@value{edgeSub.SubOrder}", resultStr);
                                                    lognet.WriteInfo($"{x.Description} 成功,{x.EdgeBody}");
                                                }
                                            }
                                            else
                                            {
                                                lognet.WriteError($"{x.Description} 失败，信息为{result.Message}");
                                            }
                                        }
                                    }

                                    if (edgeSub?.SubEdgeType == "SqlSugar")
                                    {

                                    }
                                });

                                var resultTable = db.Ado.GetDataTable(x.EdgeBody);

                                if (resultTable != null && resultTable.Rows.Count > 0)
                                {
                                    lastStation = resultTable.Rows[0]["LastStation"].ToString().Trim();
                                    lastResult = resultTable.Rows[0]["LastResult"].ToString().Trim();
                                    lognet.WriteInfo($"{lastStation} {lastResult}");
                                }
                                else
                                {
                                    lognet.WriteError($"未查询到上一站情况");
                                }
                            }
                        }
                    });
                } 
            });
        }
    }
    catch (Exception ex)
    {
        lognet.WriteError($"An error occurred while processing the MQTT message{ex.Message}");
    }
    
}

string? DesrializeFromResult(string edgeSubDateType,string edgeSubDateTypeLength,string resultContent)
{
    try
    {
        if (edgeSubDateType == "string")
        {
            var resultStr = JsonSerializer.Deserialize<OperateResult<string>>(resultContent)?.Content
            .ToString().Replace("?", "").Replace("？", "").Trim();
            // 带字符串长度，未自适应，如果自适应则需要在边缘网关设置字符串长度为 0.
            //resultStr = Regex.Replace(resultStr, @"^\?(?:\\n)?[\x01-\x08\x0E-\x1F]*(.*)", "$1").Replace("?", "").Trim();
            return resultStr;
        }

        if (edgeSubDateType == "double")
        {
            return JsonSerializer.Deserialize<OperateResult<double>>(resultContent)?.Content.ToString().Trim();
        }

        if (edgeSubDateType == "float")
        {
            return JsonSerializer.Deserialize<OperateResult<double>>(resultContent)?.Content.ToString().Trim();
        }

        if (edgeSubDateType == "int")
        {
            return JsonSerializer.Deserialize<OperateResult<int>>(resultContent)?.Content.ToString().Trim();
        }

        if (edgeSubDateType == "short")
        {
            return JsonSerializer.Deserialize<OperateResult<short>>(resultContent)?.Content.ToString().Trim();
        }

        if (edgeSubDateType == "ulong")
        {
            return JsonSerializer.Deserialize<OperateResult<ulong>>(resultContent)?.Content.ToString().Trim();
        }

        if (edgeSubDateType == "long")
        {
            return JsonSerializer.Deserialize<OperateResult<long>>(resultContent)?.Content.ToString().Trim();
        }

        if (edgeSubDateType == "bool")
        {
            return JsonSerializer.Deserialize<OperateResult<bool>>(resultContent)?.Content.ToString().Trim();
        }

        return null;
    }
    catch (Exception ex)
    {

        lognet.WriteError($"转换失败，出现异常{ex.Message}");
        return null;
    }
    
}