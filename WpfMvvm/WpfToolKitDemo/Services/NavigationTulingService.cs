
using Microsoft.Extensions.DependencyInjection;
using WpfToolKitDemo.ViewModels;

namespace WpfToolKitDemo.Services
{
    public class NavigationTulingService
    {

        private ViewModelBase? currentViewModel;

        public ViewModelBase? CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;

                CurrentViewModelChanged?.Invoke();
            }
        }

        public event Action? CurrentViewModelChanged;

        public void NavigateTo<T>() where T : ViewModelBase
            => CurrentViewModel = App.Current.Services.GetRequiredService<T>();
    }
}
