using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfPrismExtension.ViewModels
{
    // INavigationAware
    public class ViewAViewModel:IConfirmNavigationRequest
    {
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        // 导航进来
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var test = navigationContext.Parameters.GetValue<string>("Tuling");
            MessageBox.Show(test);   
        }

        // 导航从 A 视图离开时候
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
           
        }

        // 导航前询问能否导航
        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            var result = false;

            if (MessageBox.Show("能够导航到视图B？", "请客观慎重一些", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                result = true;
            }

            continuationCallback(result);
        }
    }
}
