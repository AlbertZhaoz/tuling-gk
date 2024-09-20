using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfToolKitDemo.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    int _age = 18;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FullName))]
    string _firstName="Albert";

    [ObservableProperty]
    string _lastName="Zhao";

    public string FullName => $"{FirstName}-{LastName}";

    [ObservableProperty]
    string _title = "工控一期";

    private TaskNotifier? changeTitleRequset;

    public Task? ChangeTitleRequest
    {
        get { return changeTitleRequset; }
        set => SetPropertyAndNotifyOnCompletion(ref changeTitleRequset,value);
    }

    [RelayCommand]
    void ChangeTitle()
    {
        ChangeTitleRequest = Task.Delay(2000).ContinueWith(_=>Title="工控一期课程更新了");
    }


    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ChangeAgeCommand))]
    bool _isActive =false;

    [RelayCommand(CanExecute =nameof(IsActive))]
    void ChangeAge()
    {
        Age = 22;
    }

    // bool ChangeAgeCan()
    // {
    //     return IsActive;
    // }

    [RelayCommand]
    void ChangeFirstName()
    {
        FirstName = "AlbertPlus";
    }
}