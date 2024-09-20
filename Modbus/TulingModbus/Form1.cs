using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication.ModBus;
using HZH_Controls.Controls;
using Sunny.UI;
using ArrowDirection = HZH_Controls.Controls.ArrowDirection;
using ConfigHelper = TulingModbus.Helper.ConfigHelper;

namespace TulingModbus
{
    public partial class Form1 : UIForm
    {
        private ModbusRtu _modbusRtu;
        private CancellationTokenSource _ctsCollect = new CancellationTokenSource();
        private bool _isCollect = false;
        private BlockingCollection<short[]> _collection = new BlockingCollection<short[]>(500);

        public Form1()
        {
            InitializeComponent();
            InitConfig();
            InitModbus();
            InitUiRefresh();
        }

        private void InitUiRefresh()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    _collection.TryTake(out var data);

                    if(data != null)
                    {
                        // 做一系列数据更新到界面上的处理
                        Invoke(new Action(() =>
                        {
                            if(data.Length >8){ 
                                ucMeter1.Value = data[0];
                                ucMeter2.Value = data[1];
                                ucThermometer2.Value = data[3];
                                // 刷新界面上的缺料方向
                                ucArrowLoss.Direction = data[7]==0? ArrowDirection.Left:ArrowDirection.Right;
                                // 刷新界面温度计
                                ucThermometer1.Value = data[8];
                            }
                       
                        }));
                    }

                    await Task.Delay(10);
                }
            });
        }

        private void InitConfig()
        {
            ConfigHelper.Current.Load();
        }

        private void InitModbus()
        {
            _modbusRtu = new ModbusRtu();

            _modbusRtu.SerialPortInni(sp =>
            {
                sp.PortName = ConfigHelper.Current.PortName;
                sp.BaudRate = ConfigHelper.Current.BaudRate;
                sp.DataBits = ConfigHelper.Current.DataBits;
                sp.Parity = ConfigHelper.Current.Parity;
                sp.StopBits = ConfigHelper.Current.StopBits;
                sp.RtsEnable = ConfigHelper.Current.RtsEnable;
            });

            _modbusRtu.ReceiveTimeOut = ConfigHelper.Current.ReceiveTimeOut;
            _modbusRtu.AddressStartWithZero = ConfigHelper.Current.AddressStartWithZero;
            _modbusRtu.DataFormat = ConfigHelper.Current.DataFormat;
            _modbusRtu.Station = ConfigHelper.Current.Station;
            _modbusRtu.Crc16CheckEnable = ConfigHelper.Current.Crc16CheckEnable;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                var result = _modbusRtu.Open();

                if (result.IsSuccess)
                {
                    MessageBox.Show("称重设备 PSD900 连接成功");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCollect_Click(object sender, EventArgs e)
        {
            if (_modbusRtu == null)
            {
                btnCollect.BackColor = System.Drawing.Color.Green;
                MessageBox.Show("请先连接称重设备");
                return;
            }

            if (_isCollect)
            {
                btnCollect.Text = "开始采集";
                btnCollect.BackColor = System.Drawing.Color.Green;
                _ctsCollect?.Cancel();
            }
            else
            {
                btnCollect.Text = "停止采集";
                btnCollect.BackColor = System.Drawing.Color.Red;

                _ctsCollect = new CancellationTokenSource();
                Task.Run(async () =>
                {
                    while (!_ctsCollect.Token.IsCancellationRequested)
                    {
                        try
                        {
                            var result = await _modbusRtu.ReadInt16Async("1", 9);

                            if (result.IsSuccess)
                            {
                                if (!_collection.TryAdd(result.Content))
                                {
                                    // 数据满了
                                    _collection.TryTake(out var data);
                                }
                            }

                            await Task.Delay(100);
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception);
                        }
                    }

                }, _ctsCollect.Token);
            }

            _isCollect = !_isCollect;
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (_modbusRtu == null)
            {
                btnCollect.BackColor = System.Drawing.Color.Green;
                MessageBox.Show("请先连接称重设备");
                return;
            }

            _ctsCollect = new CancellationTokenSource();
            Task.Run(async () =>
            {
                while (!_ctsCollect.Token.IsCancellationRequested)
                {
                    try
                    {
                        var random = new Random();
                        var coefficient =  (short)random.Next(1,50);
                        var loss =  (short)random.Next(-1,2);
                        var percent =  (short)random.Next(1,45);

                        short[] data = new short[9]
                        { 
                            (short)(coefficient),
                            (short)(coefficient+2),
                            (short)(coefficient+2),
                            (short)(percent+2),
                            (short)(percent*2),
                            (short)(coefficient+2),
                            (short)(coefficient+2),
                            (short)(loss),
                            (short)(percent),
                        };

                        var result = await _modbusRtu.WriteAsync("1",data);

                        
                        await Task.Delay(100);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                    }
                }

            }, _ctsCollect.Token);
        }
    }
}
