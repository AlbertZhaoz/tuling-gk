using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using WpfPrismModule.Views;

namespace WpfPrismModule
{
    public class WpfPrismModuleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<RegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegionModule",typeof(ViewTuling));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}