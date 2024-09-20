using DevExpress.ClipboardSource.SpreadsheetML;
using Masuit.Tools;
using System;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TulingGk.SerialPort.Helper;
using TulingGk.SerialPort.Models;

namespace TulingGk.SerialPort
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        private string _selectPortName;
        private bool _isOpen = false;
        private string logFilePath = "";
        private Thread CycleThread;
        private bool _isCycle = false;

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
            comboBoxEditPort.Properties.Items.AddRange(Faker.GetPorts());
            comboBoxEditBaudRate.Properties.Items.AddRange(Faker.GetBounds());
            comboBoxEditParity.Properties.Items.AddRange(Enum.GetValues(typeof(Parity)));
            comboBoxEditDataBits.Properties.Items.AddRange(Faker.GetDataBits());
            comboBoxEditStopBits.Properties.Items.AddRange(Enum.GetValues(typeof(StopBits)));

            comboBoxEditPort.SelectedIndex = 0;
            comboBoxEditBaudRate.SelectedIndex = 6;
            comboBoxEditParity.SelectedIndex = 0;
            comboBoxEditDataBits.SelectedIndex = 0;
            comboBoxEditStopBits.SelectedIndex = 1;

            memoEditLog.AppendText(Environment.NewLine);
            memoEditSend.AppendText(Environment.NewLine);
        }

        protected override void WndProc(ref Message m)
        {
            string[] ports = new string[] { };

            //1.设备改变
            if (m.Msg == 0x0219)
            {
                //2.设备已拔出
                if (m.WParam.ToInt32() == 0x8004)
                {

                    //2.1 消息提醒
                    memoEditLog.AppendText("设备已拔出!".FormatStringLog());

                    //2.2 重新获取串口
                    ports = System.IO.Ports.SerialPort.GetPortNames();
                    comboBoxEditPort.Properties.Items.Clear();
                    comboBoxEditPort.Properties.Items.AddRange(ports);
                }
                // 3. 设备已连接
                else if (m.WParam.ToInt32() == 0x8000)
                {
                    memoEditLog.AppendText("设备已连接!".FormatStringLog());
                    ports = System.IO.Ports.SerialPort.GetPortNames();
                    comboBoxEditPort.Properties.Items.Clear();
                    comboBoxEditPort.Properties.Items.AddRange(ports);
                }

                //2 处理用户串口
                if (_isOpen)
                {
                    if (!ports.Contains(_selectPortName))
                    {
                        //2.3.1 释放掉原先的串口资源
                        serialPort?.Close();
                        serialPort?.Dispose();
                        //2.3.2 断开连接，改变按钮文字
                        btnOpen.Text = "打开";
                        ChangeComboxEnable(true);
                        comboBoxEditPort.SelectedIndex = comboBoxEditPort.Properties.Items.Count > 0 ? 0 : -1;
                    }
                    else
                    {
                        comboBoxEditPort.SelectedIndex = comboBoxEditPort.Properties.Items.IndexOf(_selectPortName);
                    }
                }

                ChangeMemoEditLastend();
            }
            base.WndProc(ref m);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (_isOpen)
                {
                    serialPort?.Close();
                    btnOpen.Text = "打开";
                    ChangeComboxEnable(true);
                    memoEditLog.AppendText("连接关闭".FormatStringLog());
                }
                else
                {
                    serialPort.PortName = comboBoxEditPort.Text;
                    serialPort.BaudRate = comboBoxEditBaudRate.Text.ToInt32();
                    serialPort.DataBits = comboBoxEditDataBits.Text.ToInt32();

                    if (Enum.TryParse(comboBoxEditStopBits.Text, out StopBits stopBit))
                    {

                        if (stopBit != StopBits.None)
                        {
                            serialPort.StopBits = stopBit;
                        }
                    }

                    if (Enum.TryParse(comboBoxEditParity.Text, out Parity parity))
                    {
                        serialPort.Parity = parity;
                    }

                    serialPort?.Open();
                    ChangeComboxEnable(false);
                    btnOpen.Text = "关闭";
                    memoEditLog.AppendText("连接打开".FormatStringLog());
                }

                _isOpen = !_isOpen;
                ChangeMemoEditLastend();
            }
            catch (Exception exception)
            {
                btnOpen.Text = "打开";
                memoEditLog.AppendText(exception.Message.FormatStringLog());
            }
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
            comboBoxEditPort.Enabled = enbale;
            comboBoxEditBaudRate.Enabled = enbale;
            comboBoxEditParity.Enabled = enbale;
            comboBoxEditDataBits.Enabled = enbale;
            comboBoxEditStopBits.Enabled = enbale;
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

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int len = serialPort.BytesToRead;
            byte[] buffers = new byte[len];
            serialPort.Read(buffers, 0, len);
            string data = System.Text.Encoding.UTF8.GetString(buffers);
            Invoke(new Action(() =>
            {

                if (checkEditRecAscii.Checked)
                {
                    memoEditLog.AppendText(data.FormatStringLog());                 
                }
                else
                {
                    memoEditLog.AppendText(string.Join(" ",buffers.Select(b => b.ToString("X2")).ToArray()).FormatStringLog());
                }
            }));
        }

        private void SendMessage2Port(string result)
        {
            Invoke(new Action(()=>{ 
                if (checkEditSendAscii.Checked)
                {
                    memoEditLog.AppendText(result.FormatStringLog());  
                    serialPort.Write(result);
                }
                else
                {
                    byte[] sendBytes = TranStrToToHexByte(result);

                    if (sendBytes != null)
                    {
                        memoEditLog.AppendText(string.Join(" ",sendBytes.Select(b => b.ToString("X2")).ToArray()).FormatStringLog());
                        serialPort.Write(sendBytes, 0, sendBytes.Length);
                    }
                } 
            }));
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

                if(result.Length > 0&&result!="\r\n")
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
                                    SendMessage2Port(result);

                                    Thread.Sleep(textEditCycle.EditValue.ToString().ToInt32());
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
                            SendMessage2Port(result);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                memoEditLog.AppendText(exception.Message.FormatStringLog());
            }
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