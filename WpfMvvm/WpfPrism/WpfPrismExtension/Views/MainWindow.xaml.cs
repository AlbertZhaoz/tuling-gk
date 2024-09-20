using System.Windows;
using Prism.Regions;

namespace WpfPrismExtension.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IRegionManager _regionManger;

        public MainWindow(IRegionManager regionManger)
        {
            InitializeComponent();

            //RegionManager.SetRegionName(xx,"ContentRegion");
            _regionManger = regionManger;
            // 指定界面区域为哪一个用户控件
            _regionManger.RegisterViewWithRegion("ContentRegion",typeof(ViewA));
        }
    }
}
