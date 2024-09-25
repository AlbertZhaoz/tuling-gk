using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LiveCharts;
using LiveCharts.Wpf;
using MiniExcelLibs;
using WpfTulingGkMes.Models;
using MessageBox = System.Windows.MessageBox;

namespace WpfTulingGkMes.ViewModels;

public partial class DeviceCollectionViewModel : ObservableObject
{
    [ObservableProperty] SeriesCollection _lineSeriesCollection = new SeriesCollection();

    [ObservableProperty] List<DataGetModel> _dataList = new List<DataGetModel>();
    
    [ObservableProperty] bool _isChecked = false;

    public DeviceCollectionViewModel()
    {
        GetDataList();
        GetSeriesCollection();
        StartRealTimeUpdate();  // 启动实时更新
    }

    [RelayCommand]
    void GetDataList()
    {
        try
        {
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "DataGet.xlsx";

            if (!File.Exists(filePath))
            {
                return;
            }

            using (var stream = File.OpenRead(filePath))
            {
                DataList = stream.Query<DataGetModel>().ToList();
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }

    [RelayCommand]
    void GetSeriesCollection()
    {
        //初始化数据
        List<string> titles = new List<string> { "一层", "二层", "三层" };

        List<List<int>> values = new List<List<int>>
        {
            new List<int> { 20, 10, 50, 10, 50, 10, 50, 10, 50, 10, 50, 10 }, //, 50 , 10,  10, 50,10, 50
            new List<int> { 20, 10, 50, 10, 50, 10, 50, 10, 50, 10, 50, 10 }, //, 50 , 10,  10, 50,10, 50
            new List<int> { 10, 50, 30, 50, 30, 50, 30, 50, 30, 50, 30, 50 } //, 30 , 30 , 50, 30 , 10, 50
        };
        List<string> _dates = new List<string>();
        for (int i = 0; i < titles.Count; i++)
        {
            var fill = new SolidColorBrush();
            fill.Opacity = 1;
            LineSeries lineseries = new LineSeries();
            lineseries.DataLabels = true;
            lineseries.Title = titles[i];
            lineseries.Foreground = fill;
            lineseries.Fill = fill;
            lineseries.Values = new ChartValues<int>(values[i]);

            LineSeriesCollection.Add(lineseries);
        }
    }
    
    private DispatcherTimer _timer;
    private Random _random = new Random();
    private void StartRealTimeUpdate()
    {
        _timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1)  // 每1秒更新一次数据
        };
        _timer.Tick += UpdateChartData;
        _timer.Start();
    }

    private void UpdateChartData(object sender, EventArgs e)
    {
        if(IsChecked)
        {
            foreach (var series in LineSeriesCollection)
            {
                if (series is LineSeries lineSeries)
                {
                    var values = lineSeries.Values as ChartValues<int>;
                    values.RemoveAt(0);  // 删除最早的数据点
                    
                    // 这边可以从实际 plc 中读取（plc 做成单例模式)
                    values.Add(_random.Next(0, 100));  // 添加随机模拟数据
                }
            }
        }
    }
}