using LiveCharts;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTulingMesBoard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Func<ChartPoint, string> PointLabel { get; set; }

        ObservableCollection<ProductInfo> ProductInfos { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            InitLiveChart2();
            this.DataContext = this;
            InitBinding();
        }

        private void InitBinding()
        {
            ProductInfos = new ObservableCollection<ProductInfo>()
            {
                new ProductInfo(){ProductCode="420102316207500",FinalResult="NG"},
                new ProductInfo(){ProductCode="420102316207501",FinalResult="OK"},  
                new ProductInfo(){ProductCode="420102316207502",FinalResult="NG"},
                new ProductInfo(){ProductCode="420102316207503",FinalResult="OK"},  
                new ProductInfo(){ProductCode="420102316207504",FinalResult="OK"},  
                new ProductInfo(){ProductCode="420102316207505",FinalResult="OK"},  
                new ProductInfo(){ProductCode="420102316207506",FinalResult="OK"},  
                new ProductInfo(){ProductCode="420102316207507",FinalResult="OK"},  
                new ProductInfo(){ProductCode="420102316207508",FinalResult="OK"},  
                new ProductInfo(){ProductCode="420102316207509",FinalResult="OK"},  
                new ProductInfo(){ProductCode="420102316207510",FinalResult="OK"},  
                new ProductInfo(){ProductCode="420102316207511",FinalResult="NG"},  
                new ProductInfo(){ProductCode="420102316207512",FinalResult="NG"},  
                new ProductInfo(){ProductCode="420102316207513",FinalResult="OK"},  
                new ProductInfo(){ProductCode="420102316207514",FinalResult="OK"},  
                new ProductInfo(){ProductCode="420102316207515",FinalResult="OK"},  
                new ProductInfo(){ProductCode="420102316207516",FinalResult="OK"},  
                new ProductInfo(){ProductCode="420102316207517",FinalResult="OK"},  
            };

            this.dataGridProductInfos.ItemsSource = ProductInfos;

            // Load images
            for (int i = 1; i <= 7; i++)
            {
                this.CoverFlowMain.Add("pack://application:,,,/Resources/Images/" + i + ".jpg");
            }
           
        }

        private void InitLiveChart2()
        {
            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})",
                chartPoint.Y, chartPoint.Participation);
        }
    }

    public class ProductInfo : INotifyPropertyChanged
    {
        private string productCode;

        public string ProductCode
        {
            get { return productCode; }
            set
            {
                productCode = value;

                if (this.PropertyChanged != null)
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("ProductCode"));

            }
        }

        private string finalResult;

        public string FinalResult
        {
            get { return finalResult; }
            set
            {
                finalResult = value;

                if (this.PropertyChanged != null)
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("FinalResult"));

            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}