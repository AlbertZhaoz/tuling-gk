using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using WpfToolKitDemo.Services;

namespace WpfToolKitDemo.ViewModels;

public partial class NavigatorRootViewModel:ViewModelBase
{
    private readonly NavigationTulingService navigator;

    [ObservableProperty]
    private ViewModelBase? currentViewModel;

    public NavigatorRootViewModel()
    {
        navigator = App.Current.Services.GetRequiredService<NavigationTulingService>();

        navigator.CurrentViewModelChanged += () =>
        {
            CurrentViewModel = navigator.CurrentViewModel;
        };

        // navigate to login page at first
        navigator.NavigateTo<Navigator1ViewModel>();
    }
}

public class ViewModelBase : ObservableObject
{

}