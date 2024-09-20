using System;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace WpfPrismExtension.ViewModels;

public class DialogTulingViewModel:BindableBase,IDialogAware
{
    public bool CanCloseDialog()
    {
        return true;
    }

    public void OnDialogClosed()
    {
        
    }

    public void OnDialogOpened(IDialogParameters parameters)
    {
        
    }

    public string Title { get; } = "TulingDialog";
    public event Action<IDialogResult> RequestClose;
}