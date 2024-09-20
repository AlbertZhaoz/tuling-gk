using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using WpfPrismExtension.ViewModels;
using WpfPrismExtension.Views;

namespace WpfPrismExtension
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //2. 注册导航
            containerRegistry.RegisterForNavigation<ViewA>("PageA");
            containerRegistry.RegisterForNavigation<ViewB>();

            // 注册弹窗
            containerRegistry.RegisterDialog<DialogTuling,DialogTulingViewModel>();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog(){ModulePath=@".\Modules"};
        }
    }
}
