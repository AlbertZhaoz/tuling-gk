using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        private S7Helper s7Helper;

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
                Invoke(new Action(() =>
                {
                    formsPlot1.Refresh();
                }));

                await Task.Delay(100, ct);
            }
        }

        private async Task MockDataTask(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                var nextValue = (float)ecg.GetVoltage(sw.Elapsed.TotalSeconds);


                if (s7Helper != null && s7Helper.Connected)
                {
                    if (_selectedGetModel != null)
                    {
                        s7Helper.WriteSingleData_Float(1,
                            _selectedGetModel.Address.ToInt(),
                            nextValue,
                            4
                            , PlcDataType.Float);
                    }
                }

                await Task.Delay(100, ct);
            }
        }

        private async Task UpdateDataTask(CancellationToken ct)
        {
            while (_acqEnable && !_ctsDataCopy.IsCancellationRequested)
            {
                // 从 plc 里面读取
                double nextValue = 0;

                if(s7Helper != null&& s7Helper.Connected)
                {
                    nextValue = s7Helper.ReadSingleData_Float(1, 4, 4, PlcDataType.Float);
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

                await Task.Delay(100, ct);
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

            Closed += (sender, args) =>
            {
                // timerUpdateData?.Stop();
                // timerRender?.Stop();
            };
        }

        int nextValueIndex = -1;

        private void InitDataCycleThread()
        {
            var thread = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        if (s7Helper != null && s7Helper.Connected)
                        {
                            var temputre = s7Helper.ReadSingleData_Float(1, 4, 4, PlcDataType.Float);

                            Invoke(new Action(() =>
                            {
                                uiTempture.Value = temputre;
                            }));
                        }

                        Thread.Sleep(500);
                    }
                    catch (Exception ex)
                    {
                        HLog.Error("读取温度失败", ex);
                    }
                }
            });

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

        private void uiTurnSwitch1_ValueChanged(object sender, bool value)
        {
            if (uiTurnSwitch1.Active)
            {
                try
                {
                    s7Helper = new S7Helper("S71200", s7Ip.Text);

                    var status = s7Helper.ConnectPLC(s7Port.Value,
                        (short)s7Rack.Value,
                        (short)s7Slot.Value);

                    s7Status.State = status ? UILightState.On : UILightState.Off;

                    var temputre = s7Helper.ReadSingleData_Float(1, 4, 4, PlcDataType.Float);
                    uiTempture.Value = temputre;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            else
            {
                s7Status.State = UILightState.Off;

                if (s7Helper != null)
                {
                    s7Helper.DisconnectPLC();
                }
            }
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
            _taskWrite = Task.Run(()=>MockDataTask(_ctsWrite.Token), _ctsWrite.Token);
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
