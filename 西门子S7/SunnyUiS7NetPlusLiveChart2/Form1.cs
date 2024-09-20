using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication.LogNet;
using HslCommunication.Profinet.Siemens;
using LiveCharts;
using LiveCharts.Wpf;
using MiniExcelLibs;
using ScottPlot;
using ScottPlot.Plottable;
using Sunny.UI;
using SunnyScopplotS7netplus.Models;

namespace SunnyScopplotS7netplus
{
    public partial class Form1 : UIForm
    {
        private DataGetModel _selectedGetModel;
        private List<DataGetModel> dataGetModels;

        private SiemensS7Net _s7Net;
        private ILogNet logNet7 = new LogNetDateTime(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs"), GenerateMode.ByEveryDay);

        double[] liveData = new double[400];
        DataGen.Electrocardiogram ecg = new DataGen.Electrocardiogram();
        Stopwatch sw = Stopwatch.StartNew();
        VLine vline;

        private CancellationTokenSource _ctsWrite = new CancellationTokenSource();
        private CancellationTokenSource _ctsDataCopy = new CancellationTokenSource();
        private CancellationTokenSource _ctsPlotRefresh = new CancellationTokenSource();

        private Task _taskWrite;
        private Task _taskDataCopy;
        private Task _taskPlotRefresh;

        private bool _acqEnable = false;

        public Form1()
        {
            InitializeComponent();
            InitData();
            InitDataCycleThread();
            // https://scottplot.net/faq/live-data/
            InitPlots();
            InitPlotDataThread();
            InitHeartThread();
        }

        private void InitPlotDataThread()
        {
            _taskDataCopy = Task.Run(() => UpdateDataTask(_ctsDataCopy.Token), _ctsDataCopy.Token);
            _taskPlotRefresh = Task.Run(() => PlotRefreshTask(_ctsPlotRefresh.Token), _ctsPlotRefresh.Token);
        }

        private async Task PlotRefreshTask(CancellationToken ct)
        {
            while (!_ctsPlotRefresh.IsCancellationRequested)
            {
                if (liveData?.Length > 0)
                {
                    Invoke(new Action(() =>
                    {
                        formsPlot1.Refresh();
                    }));
                }

                await Task.Delay(100, ct);
            }
        }

        private async Task MockDataTask(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                var nextValue = (float)ecg.GetVoltage(sw.Elapsed.TotalSeconds);


                if (_s7Net != null && s7Status.State == UILightState.On)
                {
                    if (_selectedGetModel != null)
                    {
                        await _s7Net.WriteAsync($"DB1.DBD{_selectedGetModel.Address}", nextValue);
                    }
                }

                await Task.Delay(100, ct);
            }
        }

        private async Task UpdateDataTask(CancellationToken ct)
        {
            while (_acqEnable && !_ctsDataCopy.IsCancellationRequested)
            {
                try
                {

                    // 从 plc 里面读取
                    double nextValue = 0;

                    if (_s7Net != null && s7Status.State == UILightState.On)
                    {
                        if (_selectedGetModel != null)
                        {
                            var operateResult = await _s7Net.ReadFloatAsync($"DB1.DBD{_selectedGetModel.Address}");

                            if (operateResult.IsSuccess)
                            {
                                nextValue = operateResult.Content;
                            }
                        }
                    }

                    if (uiCheckBoxRoll.Checked)
                    {
                        // "roll" new values over old values like a traditional ECG machine
                        nextValueIndex = (nextValueIndex < liveData.Length - 1) ? nextValueIndex + 1 : 0;
                        liveData[nextValueIndex] = nextValue;
                        vline.IsVisible = true;
                        vline.X = nextValueIndex;
                    }
                    else
                    {
                        // "scroll" the whole chart to the left
                        Array.Copy(liveData, 1, liveData, 0, liveData.Length - 1);
                        liveData[liveData.Length - 1] = nextValue;
                        vline.IsVisible = false;
                    }


                    Invoke(new Action(() =>
                    {
                        // 更新 LiveChart2 控件曲线值
                        var series = (LineSeries)cartesianChart1.Series.First();
                        series.Values.Add(nextValue);

                        if (series.Values.Count > 500)
                        {
                            series.Values.RemoveAt(0);
                        }

                        cartesianChart1.Update();
                    }));

                    await Task.Delay(100, ct);
                }
                catch (Exception ex)
                {
                    logNet7.WriteError(ex.Message);
                }
            }
        }

        private void InitPlots()
        {
            // plot the data array only once and we can updates its values later
            formsPlot1.Plot.AddSignal(liveData);
            formsPlot1.Plot.AxisAutoX(margin: 0);
            formsPlot1.Plot.SetAxisLimits(yMin: -1, yMax: 2.5);

            // plot a red vertical line and save it so we can move it later
            vline = formsPlot1.Plot.AddVerticalLine(0, Color.Red, 2);

            // customize styling
            formsPlot1.Plot.Title("Electrocardiogram Strip Chart");
            formsPlot1.Plot.YLabel("Potential (mV)");
            formsPlot1.Plot.XLabel("Time (seconds)");
            formsPlot1.Plot.Grid(false);

            // LiveChart2 实现实时曲线
            cartesianChart1.Series = new LiveCharts.SeriesCollection
            {
                new LineSeries{
                    Title = "实时压力数据",
                    Values = new ChartValues<double>(),
                    PointGeometry = null // 不需要显示每一个点的标记
                }
            };

            cartesianChart1.AxisX.Add(new Axis
            {
                // x轴显示样式
                LabelFormatter = value => DateTime.Now.ToString("hh:mm:ss"),
                Separator = new Separator { Step = 1 }
            });
            cartesianChart1.AxisY.Add(new Axis { Title = "压力值" });
        }

        int nextValueIndex = -1;

        private void InitDataCycleThread()
        {
            var thread = new Thread(async () =>
            {
                while (true)
                {
                    try
                    {
                        if (_s7Net != null && s7Status.State == UILightState.On)
                        {
                            var operateResult = await _s7Net.ReadFloatAsync($"DB1.DBD4");

                            if (operateResult.IsSuccess)
                            {
                                Invoke(new Action(() =>
                                {
                                    uiTempture.Value = operateResult.Content;
                                    logNet7.WriteError($"读取温度数据成功{operateResult.Content}");
                                }));
                            }
                        }

                        Thread.Sleep(500);
                    }
                    catch (Exception ex)
                    {
                        logNet7.WriteError("读取温度数据失败", ex.Message);
                    }
                }
            });

            thread.IsBackground = true;
            thread.Start();
        }
        private void InitData()
        {
            try
            {
                var iniFilePath = AppDomain.CurrentDomain.BaseDirectory + "config.ini";
                IniFile ini = new IniFile(iniFilePath);
                string dataGetPath = ini.ReadString("Setup",
                    "DataGetPath",
                    "DataGet.xlsx");
                string dataSetPath = ini.ReadString("Setup",
                    "DataSetPath",
                    "DataGet.xlsx");

                using (var stream = File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + dataGetPath))
                {
                    dataGetModels = stream.Query<DataGetModel>().ToList();

                    gridPlc.DataSource = dataGetModels;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private async void uiTurnSwitch1_ValueChanged(object sender, bool value)
        {
            if (uiTurnSwitch1.Active)
            {
                try
                {
                    _s7Net = new SiemensS7Net(SiemensPLCS.S1200, s7Ip.Text);
                    _s7Net.Slot = (byte)s7Slot.Value;
                    _s7Net.Rack = (byte)s7Rack.Value;

                    logNet7.WriteInfo("PLC 连接成功");

                    var operateResult = await _s7Net.ReadFloatAsync("DB1.DBD4");

                    if (operateResult.IsSuccess)
                    {
                        uiTempture.Value = operateResult.Content;
                    }
                }
                catch (Exception e)
                {
                    logNet7.WriteError(e.Message);
                }
            }
            else
            {
                s7Status.State = UILightState.Off;

                if (_s7Net != null)
                {
                    await _s7Net.ConnectCloseAsync();
                }
            }
        }

        /// <summary>
        /// 心跳用于判断 PLC 通讯是否正常
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void InitHeartThread()
        {
            var thread = new Thread(async () =>
            {
                while (true)
                {

                    await Task.Delay(1000);

                    if (_s7Net != null)
                    {
                        var readResult = await _s7Net.ReadBoolAsync("M100");

                        s7Status.State = readResult.IsSuccess ? UILightState.On : UILightState.Off;
                    }
                    else
                    {
                        s7Status.State = UILightState.Off;
                    }

                }
            });

            thread.IsBackground = true;
            thread.Start();
        }

        private void uiCheckBoxRoll_CheckedChanged(object sender, EventArgs e)
        {
            // clear old data values
            for (int i = 0; i < liveData.Length; i++)
                liveData[i] = 0;
        }

        private void uiButtonAcq_Click(object sender, EventArgs e)
        {
            if (_acqEnable)
            {
                sw.Stop();
                _acqEnable = false;
                _ctsDataCopy?.Cancel();
                _ctsPlotRefresh?.Cancel();
            }
            else
            {
                sw.Start();
                _acqEnable = true;
                _ctsDataCopy = new CancellationTokenSource();
                _ctsPlotRefresh = new CancellationTokenSource();

                _taskDataCopy = Task.Run(() => UpdateDataTask(_ctsDataCopy.Token), _ctsDataCopy.Token);
                _taskPlotRefresh = Task.Run(() => PlotRefreshTask(_ctsPlotRefresh.Token), _ctsPlotRefresh.Token);
            }
        }

        private async void uiButtonMock_Click(object sender, EventArgs e)
        {
            _ctsWrite?.Cancel();
            _ctsWrite = new CancellationTokenSource();
            _taskWrite = Task.Run(() => MockDataTask(_ctsWrite.Token), _ctsWrite.Token);
        }

        private void gridPlc_SelectIndexChange(object sender, int index)
        {
            if (gridPlc.SelectedRows.Count > 0)
            {
                _selectedGetModel = gridPlc.SelectedRows[0].DataBoundItem as DataGetModel;

                if (_selectedGetModel == null)
                {
                    MessageBox.Show("转换失败");
                }
            }
        }
    }
}
