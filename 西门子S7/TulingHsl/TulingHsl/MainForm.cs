using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Charts.Native;
using DevExpress.Utils.Extensions;
using DevExpress.XtraCharts;
using HslCommunication.Profinet.LSIS;
using HslCommunication.Profinet.Siemens;
using Masuit.Tools;
using MiniExcelLibs;
using Sunny.UI;
using TulingHsl.Forms;
using TulingHsl.Helper;
using TulingHsl.Models;
using TulingHsl.UserControls;

namespace TulingHsl
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        private S7DeviceUc _selecteds7DeviceUc;
        private S7Device _selectedS7Device;
        private ConcurrentDictionary<string, Series> LineDataDic = new ConcurrentDictionary<string, Series>();
        private int lineIndex = 0;

        public MainForm()
        {
            InitializeComponent();
            InitData();
            InitChart();
        }

        private void InitChart()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(100);

                    if (_selectedS7Device != null && _selectedS7Device.IsConnected)
                    {
                        Random random = new Random();
                        await _selectedS7Device.SiemensS7NetHandle.WriteAsync("DB1.DBD4", (float)random.NextDouble() * 1);
                        await _selectedS7Device.SiemensS7NetHandle.WriteAsync("DB1.DBD8", (float)random.NextDouble() * 2);
                        await _selectedS7Device.SiemensS7NetHandle.WriteAsync("DB1.DBD12", (float)random.NextDouble() * 3);
                    }
                }
            });
        }

        private void InitData()
        {
            DeviceCommunication.Instance.GetAllS7Device();
            AddDevice2Panel();
        }

        private void btnAddDevice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var addForm = new AddDeviceForm();
            addForm.StartPosition = FormStartPosition.CenterParent;

            // 将添加的西门子设备添加到列表中
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                AddDevice2Panel();
            }
        }

        private void AddDevice2Panel()
        {
            stackPanelDevice.Controls.Clear();

            var s7UcList = DeviceCommunication.Instance.S7Devices
                .Select(x =>
                {
                    var s7DeviceUc = new S7DeviceUc(x);
                    s7DeviceUc.RefreshChooseS7DeviceAction += RefreshChooseS7Device;
                    return s7DeviceUc;
                })
                .ToArray();

            stackPanelDevice.Controls.AddRange(s7UcList);
        }

        /// <summary>
        /// 刷新选中的西门子设备
        /// </summary>
        public void RefreshChooseS7Device(S7DeviceUc selecteds7DeviceUc)
        {
            DeviceCommunication.Instance.S7Devices.ForEach(x => x.IsSelected = false);
            _selecteds7DeviceUc = selecteds7DeviceUc;
            _selectedS7Device = selecteds7DeviceUc._s7Device;

            if (_selectedS7Device != null)
            {
                _selectedS7Device.IsSelected = true;

                if (File.Exists(_selectedS7Device.GetExcelPath))
                {
                    using (var stream = File.OpenRead(_selectedS7Device.GetExcelPath))
                    {
                        // 显示西门子设备读地址表
                        gridControlExcel.DataSource = stream.Query<DataModel>().ToList();
                    }
                }

                if (File.Exists(_selectedS7Device.SetExcelPath))
                {
                    using (var stream = File.OpenRead(_selectedS7Device.SetExcelPath))
                    {
                        // 显示西门子设备写地址表
                        gridControlSetExcel.DataSource = stream.Query<DataModel>().ToList();
                    }
                }

                foreach (S7DeviceUc s7DeviceUc in stackPanelDevice.Controls)
                {
                    s7DeviceUc.RefreshCheckBox();
                }
            }
        }

        private void btnSingleCollection_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (_selectedS7Device == null)
                {
                    MessageBox.Show("请先选择西门子设备");
                    return;
                }

                _selectedS7Device.HeartCts.Cancel();
                _selectedS7Device.SiemensS7NetHandle = new SiemensS7Net(_selectedS7Device.Type,
                _selectedS7Device.Ip);
                _selectedS7Device.SiemensS7NetHandle.Port = _selectedS7Device.Port;

                DeviceCommunication.Instance.TulingLog.WriteInfo("PLC 连接成功");

                _selectedS7Device.HeartCts = new CancellationTokenSource();
                _selectedS7Device.HeartTask = Task.Run(async () =>
                {
                    while (true)
                    {
                        await Task.Delay(200);

                        try
                        {
                            _selectedS7Device.IsConnected = false;

                            if (_selectedS7Device != null && _selectedS7Device.SiemensS7NetHandle != null
                            &&!_selectedS7Device.HeartCts.IsCancellationRequested)
                            {
                                var operateResult = await _selectedS7Device.SiemensS7NetHandle.ReadBoolAsync(
                                    _selectedS7Device.HeartAddress);

                                if (operateResult.IsSuccess)
                                {
                                    _selectedS7Device.IsConnected = true;  
                                } 
                            }

                            _selecteds7DeviceUc.RefreshStatus();
                        }
                        catch (Exception ex)
                        {
                            DeviceCommunication.Instance.TulingLog.WriteError(ex.Message);
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                DeviceCommunication.Instance.TulingLog.WriteError(ex.Message);
            }

        }

        private async void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var selectedRows = gridView1.GetSelectedRows()
                .Select(rowHandle => gridView1.GetRow(rowHandle) as DataModel)
                .Where(selectedRow => selectedRow != null)
                .ToList();

            // 启动新的采集任务
            foreach (var selectedRow in selectedRows)
            {
                if (!LineDataDic.ContainsKey(selectedRow.Address))
                {
                    var series = new Series(selectedRow.Address, ViewType.Line);
                    series.ArgumentScaleType = ScaleType.Numerical;
                    ((LineSeriesView)series.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                    ((LineSeriesView)series.View).LineMarkerOptions.Size = 20;
                    ((LineSeriesView)series.View).LineMarkerOptions.Kind = MarkerKind.Cross;
                    ((LineSeriesView)series.View).LineStyle.DashStyle = DashStyle.Dash;
                    chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
                    chartControl1.Series.Add(series);
                    LineDataDic.TryAdd(selectedRow.Address, series);
                }

                await StartCollectionTaskAsync(selectedRow);
            }

            // 取消未选中的采集任务
            var addressesToCancel = _selectedS7Device.GetDataTaskDic.Keys
                .Except(selectedRows.Select(row => row.Address))
                .ToList();

            foreach (var cancelAddress in addressesToCancel)
            {
                if (LineDataDic.ContainsKey(cancelAddress))
                {
                    chartControl1.Series.RemoveWhere(x => x.Name == cancelAddress);
                    LineDataDic.RemoveWhere(x => x.Key == cancelAddress);
                }

                if (_selectedS7Device.GetDataTaskDic.TryRemove(cancelAddress, out var cts))
                {
                    cts.Cancel();
                }
            }
        }

        private async Task StartCollectionTaskAsync(DataModel selectedRow)
        {
            if (_selectedS7Device == null)
            {
                return;
            }

            if (_selectedS7Device.GetDataTaskDic.ContainsKey(selectedRow.Address))
            {
                DeviceCommunication.Instance.TulingLog.WriteInfo($"Task for address {selectedRow.Address} is already running.");
                return;
            }

            var cts = new CancellationTokenSource();
            if (_selectedS7Device.GetDataTaskDic.TryAdd(selectedRow.Address, cts))
            {
                try
                {
                    await Task.Run(() => CollectDataAsync(selectedRow, cts.Token), cts.Token);
                }
                catch (OperationCanceledException)
                {
                    DeviceCommunication.Instance.TulingLog.WriteInfo($"Task for address {selectedRow.Address} was cancelled.");
                }
                finally
                {
                    _selectedS7Device.GetDataTaskDic.TryRemove(selectedRow.Address, out _);
                }
            }
        }

        private async Task CollectDataAsync(DataModel selectedRow, CancellationToken token)
        {
            // 实现你的采集逻辑，例如从设备读取数据
            while (!token.IsCancellationRequested)
            {
                // 模拟一个等待时间
                await Task.Delay(200, token);

                Interlocked.Increment(ref lineIndex);

                if (_selectedS7Device != null && _selectedS7Device.IsConnected)
                {

                    var operateResult = await _selectedS7Device.SiemensS7NetHandle.ReadFloatAsync(
                        DeviceConst.GET_ADDRESS + selectedRow.Address);

                    if (operateResult.IsSuccess)
                    {
                        DeviceCommunication.Instance.TulingLog.WriteInfo($"Collected data for " +
                                                                         $"{DeviceConst.GET_ADDRESS + selectedRow.Address}: {operateResult.Content}");

                        if (LineDataDic.TryGetValue(selectedRow.Address, out var series))
                        {
                            Invoke(new Action(() =>
                            {
                                series.Points.Add(new SeriesPoint(lineIndex, operateResult.Content));
                                // 移除旧的数据点以保持图表的流畅性
                                if (series.Points.Count > 100)
                                {
                                    series.Points.RemoveAt(0);
                                }
                                // 更新图表
                                chartControl1.Refresh();
                            }));


                        }
                    }
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (var cts in _selectedS7Device?.GetDataTaskDic?.Values)
            {
                cts.Cancel();
            }

            base.OnFormClosed(e);
        }

        private async void btnDisconnect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_selectedS7Device != null && _selectedS7Device.SiemensS7NetHandle != null)
            {
                _selectedS7Device.HeartCts.Cancel();

                foreach (var cts in _selectedS7Device?.GetDataTaskDic?.Values)
                {
                    cts.Cancel();
                }

                await _selectedS7Device.SiemensS7NetHandle.ConnectCloseAsync();

                _selectedS7Device.IsConnected = false;
                _selecteds7DeviceUc?.RefreshStatus();
            }
        }

        /// <summary>
        /// 小伙伴自己来完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelDevice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
