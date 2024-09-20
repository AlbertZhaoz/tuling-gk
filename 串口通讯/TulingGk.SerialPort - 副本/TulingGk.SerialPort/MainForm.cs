using DevExpress.ClipboardSource.SpreadsheetML;
using Masuit.Tools;
using System;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TouchSocket.Core;
using TouchSocket.Sockets;
using TulingGk.SerialPort.Helper;
using TulingGk.SerialPort.Models;
using StringExtension = TulingGk.SerialPort.Helper.StringExtension;

namespace TulingGk.SerialPort
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        private string _selectPortName;
        private bool _isOpen = false;
        private string logFilePath = "";
        private Thread CycleThread;
        private bool _isCycle = false;

        private TcpClient tcpClient = new TcpClient();
        private TcpService tcpServer = new TcpService();
        private UdpSession updSession = new UdpSession();

        public MainForm()
        {
            InitializeComponent();
            InitData();
            InitThread();
        }

        private void InitThread()
        {
            var saveLogThread = new Thread(() =>
            {
                while (true)
                {
                    if (checkEditRec2File.Checked && !string.IsNullOrEmpty(logFilePath))
                    {
                        File.WriteAllText(logFilePath, memoEditLog.Text);
                    }

                    Thread.Sleep(10000);
                }
            });

            saveLogThread.Start();
        }

        private void InitData()
        {
            comboBoxEditType.Properties.Items.AddRange(Faker.GetTypes());
            comboBoxEditIp.Properties.Items.AddRange(Faker.GetIps());
            comboBoxEditType.SelectedIndex = 0;
            comboBoxEditIp.SelectedIndex = 0;

            memoEditLog.AppendText(Environment.NewLine);
            memoEditSend.AppendText(Environment.NewLine);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if(comboBoxEditType.Text == "TCP Server")
                {
                    StartTcpServer();
                }
                else if(comboBoxEditType.Text == "TCP Client")
                {
                    StartTcpClient();
                }
                else
                {
                    StartUdp();
                }
            }
            catch (Exception exception)
            {
                btnOpen.Text = "打开";
                memoEditLog.AppendText(exception.Message.FormatStringLog());
            }
        }

        private void StartUdp()
        {
           
        }

        private void StartTcpServer()
        {
           if (_isOpen)
            {
                tcpServer.Stop();
                btnOpen.Text = "打开";
                ChangeComboxEnable(true);
                memoEditLog.AppendText("连接关闭".FormatStringLog());
            }
            else
            {
                tcpServer.Connecting = (client, args) =>
                {
                    Invoke(new Action(() =>
                    {
                        memoEditLog.AppendText($"正在连接{client.IP}:{client.Port} 客户端".FormatStringLog());
                    }));
                    return EasyTask.CompletedTask;
                };
                tcpServer.Connected = (client, args) =>
                {
                    Invoke(new Action(() =>
                    {
                        memoEditLog.AppendText($"{client.IP}:{client.Port} 客户端连接成功".FormatStringLog());
                    }));
                    return EasyTask.CompletedTask;
                };
                tcpServer.Disconnecting = (client, args) =>
                {
                    // 只有当主动断开时才有效
                    Invoke(new Action(() =>
                    {
                        memoEditLog.AppendText($"{client.IP}:{client.Port} 客户端正在断开连接".FormatStringLog());
                    }));
                    return EasyTask.CompletedTask;
                };
                tcpServer.Disconnected = (client, args) =>
                {
                    Invoke(new Action(() =>
                    {
                        memoEditLog.AppendText($"{client.IP}:{client.Port} 客户端断开连接".FormatStringLog());
                    }));
                    return EasyTask.CompletedTask;
                };
                tcpServer.Received = (client, args) =>
                {
                    // 从客户端收到信息:注意：数据长度是byteBlock.Len
                    var mes = Encoding.UTF8.GetString(args.ByteBlock.Buffer, 0, args.ByteBlock.Len);
                    client.Logger.Info($"已从{client.IP}:{client.Port} 接收到信息：{mes}");

                    if (checkEditRecAscii.Checked)
                    {
                        Invoke(new Action(() =>
                        {
                            memoEditLog.AppendText($"已从{client.IP}:{client.Port}接收到信息：{mes}".FormatStringLog());
                        }));
                    }
                    else
                    {
                        Invoke(new Action(() =>
                        {
                            memoEditLog.AppendText($@"已从{client.IP}:{client.Port}接收到信息：{string.Join(" ", args.ByteBlock.Buffer.Take(args.ByteBlock.Len).Select(b => b.ToString("X2")).ToArray())}"
                                .FormatStringLog());
                        }));
                    }

                    // 将收到的信息直接返回给发送方
                    client.Send($"已收到信息：{mes}");

                    return EasyTask.CompletedTask;
                };

                var ip = comboBoxEditIp.Text;
                var port = textEditPort.Text.ToInt32();

                tcpServer.Setup(new TouchSocketConfig()//载入配置
                    .SetListenIPHosts($"tcp://{ip}:{port}")//同时监听两个地址
                    .ConfigureContainer(a =>//容器的配置顺序应该在最前面
                    {
                        a.AddConsoleLogger();//添加一个控制台日志注入（注意：在maui中控制台日志不可用）
                    })
                    .ConfigurePlugins(a =>
                    {
                        // 开启断线重连
                        // 如需永远尝试连接，tryCount 设置为 -1 即可。
                        a.UseReconnection(5, true, 1000);
                    }));

                tcpServer.Start();//启动

                ChangeComboxEnable(false);
                btnOpen.Text = "关闭";
                memoEditLog.AppendText("连接打开".FormatStringLog());
            }

            _isOpen = !_isOpen;
            ChangeMemoEditLastend();
        }

        private void StartTcpClient()
        {
             if (_isOpen)
            {
                tcpClient?.Close();
                btnOpen.Text = "打开";
                ChangeComboxEnable(true);
                memoEditLog.AppendText("连接关闭".FormatStringLog());
            }
            else
            {
                tcpClient.Connecting += (client, args) =>
                {
                    Invoke(new Action(()=>{ 
                        memoEditLog.AppendText($"{client.IP}:{client.Port} 正在连接服务器".FormatStringLog());
                    }));

                    return EasyTask.CompletedTask;
                };

                tcpClient.Connected += (client, args) =>
                {
                    Invoke(new Action(()=>{ 
                        memoEditLog.AppendText($"{client.IP}:{client.Port} 连接服务器成功".FormatStringLog());
                    }));

                    return EasyTask.CompletedTask;
                };

                tcpClient.Disconnecting += (client, args) =>
                {
                    Invoke(new Action(()=>{ 
                        memoEditLog.AppendText($"{client.IP}:{client.Port} 连接正在断开".FormatStringLog());
                    }));

                    return EasyTask.CompletedTask;
                };
                tcpClient.Disconnecting += (client, args) =>
                {
                    Invoke(new Action(()=>{ 
                        memoEditLog.AppendText($"{client.IP}:{client.Port} 连接已经断开".FormatStringLog());
                    }));

                    return EasyTask.CompletedTask;
                };

                tcpClient.Received = (client, args) =>
                {
                    //从服务器收到信息。但是一般byteBlock和requestInfo会根据适配器呈现不同的值。
                    var msg = Encoding.UTF8.GetString(args.ByteBlock.Buffer, 0, args.ByteBlock.Len);

                    client.Logger.Info($"已经从 {client.IP}:{client.Port} 接收到消息了{msg}");

                    if (checkEditRecAscii.Checked)
                    {
                        Invoke(new Action(()=>{ 
                            memoEditLog.AppendText($"已经从 {client.IP}:{client.Port} 接收到消息了{msg}".FormatStringLog());
                        }));
                    }
                    else
                    {
                        
                        Invoke(new Action(()=>{ 
                            memoEditLog.AppendText($"已经从 {client.IP}:{client.Port} 接收到消息了{string.Join(" ",args.ByteBlock.Buffer.Take(args.ByteBlock.Len).Select(b=>b.ToString("X2").ToArray()))}".FormatStringLog());
                        }));
                    }

                    client.Send($"已经收到消息了:{msg}");

                    return EasyTask.CompletedTask;
                };

                var ip = comboBoxEditIp.Text;
                var port = textEditPort.Text.ToInt32();

                tcpClient.Setup(new TouchSocketConfig()
                    .SetRemoteIPHost($"{ip}:{port}")
                    .ConfigureContainer(a=>a.AddConsoleLogger())
                    .ConfigurePlugins(a=>
                    {
                        a.UseReconnection(5,true,1000);
                    }));

                tcpClient.Connect();
                tcpClient.Send("已经连接上了");

                ChangeComboxEnable(false);
                btnOpen.Text = "关闭";
                memoEditLog.AppendText("连接打开".FormatStringLog());
            }

            _isOpen = !_isOpen;
        }

        private void ChangeMemoEditLastend()
        {
            if (checkEditAuto.Checked)
            {
                memoEditLog.SelectionStart = memoEditLog.Text.Length;
                memoEditLog.ScrollToCaret();
            }
        }


        private void ChangeComboxEnable(bool enbale)
        {
            comboBoxEditType.Enabled = enbale;
            comboBoxEditIp.Enabled = enbale;
        }

        private void checkEditRecLog_CheckedChanged(object sender, EventArgs e)
        {
            StringExtension.checkEditRecLog = checkEditRecLog.Checked;
        }

        private void checkEditRec2File_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEditRec2File.Checked)
            {
                // 弹出保存文件对话框
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    logFilePath = saveFileDialog.FileName;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            memoEditLog.Text = "";
        }


        private void DisableControls(bool enable)
        {
            checkEditSendAscii.Enabled = enable;
            checkEditSendHex.Enabled = enable;
            checkEditCycle.Enabled = enable;
            textEditCycle.Enabled = enable;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                var result = memoEditSend.Text;

                if(result.Length > 0)
                {
                    // 结果追加生成随机数
                    if (checkEditRandom.Checked)
                    {
                        result+=new Random().Next(1,999).ToString();
                    }

                    // true 表明已经处于循环发送状态，false 表明已经处于单次发送状态
                    if (_isCycle)
                    {
                        CycleThread?.Abort();

                        // 将发送选项设置为 disbale
                        btnSend.Text = "发送";
                        _isCycle = false;
                        DisableControls(true);
                    }
                    else
                    {
                        if (checkEditCycle.Checked)
                        {
                            CycleThread = new Thread(()=>{
                                while (_isCycle)
                                {
                                    SendMessageFromService(result);
                                    Thread.Sleep(textEditCycle.Text.ToString().ToInt32());
                                }
                            });
                            CycleThread?.Start();
                            _isCycle = true;
                            DisableControls(false);
                            // 将发送选项设置为 disbale
                            btnSend.Text = "停止发送";
                        }
                        else
                        {
                            SendMessageFromService(result);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                memoEditLog.AppendText(exception.Message.FormatStringLog());
            }
        }

        private void SendMessageFromService(string result)
        {
           Invoke(new Action(()=>{

               if (checkEditSendAscii.Checked)
               {
                   memoEditLog.AppendText(result.FormatStringLog());

                   if(comboBoxEditType.Text == "TCP Server")
                   {
                       tcpServer.GetClients().ToList().ForEach(client=>{ 
                           client.Send(result);
                           });
                   }
                   else
                   {
                       tcpClient.Send(result);
                   }
               }            
               }));
        }

        /// <字符串转16进制格式,不够自动前面补零>
        /// 
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        private byte[] TranStrToToHexByte(string hexString)
        {
            int i;
            hexString = hexString.Replace(" ", "");//清除空格
            if ((hexString.Length % 2) != 0)//奇数个
            {
                byte[] returnBytes = new byte[(hexString.Length + 1) / 2];

                try
                {
                    for (i = 0; i < (hexString.Length - 1) / 2; i++)
                    {
                        returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
                    }
                    returnBytes[returnBytes.Length - 1] = Convert.ToByte(hexString.Substring(hexString.Length - 1, 1).PadLeft(2, '0'), 16);
                }
                catch
                {
                    memoEditLog.AppendText("含有非16进制字符".FormatStringLog());
                    return null;
                }

                return returnBytes;
            }
            else
            {
                byte[] returnBytes = new byte[(hexString.Length) / 2];
                try
                {
                    for (i = 0; i < returnBytes.Length; i++)
                    {
                        returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
                    }
                }
                catch
                {
                    memoEditLog.AppendText("含有非16进制字符".FormatStringLog());
                    return null;
                }
                return returnBytes;
            }
        }
    }
}