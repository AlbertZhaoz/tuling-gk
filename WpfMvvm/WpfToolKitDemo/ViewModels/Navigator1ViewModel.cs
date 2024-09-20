using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WpfToolKitDemo.Services;

namespace WpfToolKitDemo.ViewModels;

public partial class Navigator1ViewModel:ViewModelBase
{
    private readonly NavigationTulingService _navigationTulingService;
    private readonly UserService userService;

    [ObservableProperty]
    string? userName;

    public Navigator1ViewModel(NavigationTulingService navigationTulingService, UserService userService)
    {
        this._navigationTulingService = navigationTulingService;
        this.userService = userService;
        UserName = userService.UserName;
    }

    [RelayCommand]
    void Logout()
    {
        // navigate back to login page
        userService.UserName = null;
        _navigationTulingService.NavigateTo<Navigator2ViewModel>();
    }
}

public partial class Navigator2ViewModel:ViewModelBase
{
    private readonly NavigationTulingService _navigationTulingService;
    private readonly UserService userService;

    [ObservableProperty]
    string? userName = "Sean";

    public Navigator2ViewModel(NavigationTulingService navigationTulingService, UserService userService)
    {
        this._navigationTulingService = navigationTulingService;
        this.userService = userService;
    }

    [RelayCommand]
    void Login()
    {
        // navigate to home page
        userService.UserName = UserName;
        _navigationTulingService.NavigateTo<Navigator1ViewModel>();
    }
}