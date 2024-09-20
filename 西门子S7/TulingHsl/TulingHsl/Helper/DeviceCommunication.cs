using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using HslCommunication.LogNet;
using Newtonsoft.Json;
using TulingHsl.Models;

namespace TulingHsl.Helper
{
    public class DeviceCommunication
    {
        /// <summary>
        /// 单例设计模式
        /// </summary>
        private static Lazy<DeviceCommunication> _instance = new Lazy<DeviceCommunication>((Func<DeviceCommunication>)(() => new DeviceCommunication()));
        public static DeviceCommunication Instance => DeviceCommunication._instance.Value;

        /// <summary>
        /// 日志
        /// </summary>
        public ILogNet TulingLog = new LogNetDateTime( System.IO.Path.Combine( AppDomain.CurrentDomain.BaseDirectory, "Logs" ), GenerateMode.ByEveryDay );

        /// <summary>
        /// S7 设备集合
        /// </summary>
        public List<S7Device> S7Devices { get; set; }= new List<S7Device>();

        private DeviceCommunication()
        {
            GetAllS7Device();
        }

        /// <summary>
        /// 获取所有S7设备
        /// </summary>
        public void GetAllS7Device()
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + DeviceConst.CONFIG + DeviceConst.S7_CONFIG;

                if (File.Exists(path))
                {
                    S7Devices = JsonConvert.DeserializeObject<List<S7Device>>(File.ReadAllText(path));

                    if(S7Devices == null)
                    {
                        S7Devices = new List<S7Device>();
                    }
                }
            }
            catch (Exception e)
            {
                TulingLog.WriteError(e.Message);
            }
        }

        /// <summary>
        /// 保存所有S7设备
        /// </summary>
        public void SaveAllS7Device()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + DeviceConst.CONFIG + DeviceConst.S7_CONFIG;
            File.WriteAllText(path, JsonConvert.SerializeObject(S7Devices));
        }

        /// <summary>
        /// 测试ping
        /// </summary>
        /// <param name="strHost"></param>
        /// <param name="strErr"></param>
        /// <returns></returns>
        public bool CmdPing(string strHost, out string strErr)
        {
            try
            {
                lock (strHost)
                {
                    if (strHost == "." || strHost == "localhost") strHost = "127.0.0.1";
                    if (!IPAddress.TryParse(strHost, out var ip))
                    {
                        strErr = "连接失败";
                        return false;
                    }

                    // Windows L2TP VPN和非Windows VPN使用ping VPN服务端的方式获取是否可以连通     
                    var pingSender = new Ping();
                    var options = new PingOptions();

                    // Use the default Ttl value which is 128,     
                    // but change the fragmentation behavior.     
                    options.DontFragment = true;

                    // Create a buffer of 32 bytes of data to be transmitted.     
                    var data = "test";
                    var buffer = Encoding.ASCII.GetBytes(data);
                    var timeout = 50;
                    var reply = pingSender.Send(strHost, timeout, buffer, options);
                    strErr = "";
                    return reply?.Status == IPStatus.Success;
                }
            }
            catch (Exception ex)
            {
                strErr = ex.Message;
                return false;
            }
        }
    }
}