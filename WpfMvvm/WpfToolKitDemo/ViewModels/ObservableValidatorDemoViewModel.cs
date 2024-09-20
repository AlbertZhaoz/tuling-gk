using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations;
using WpfToolKitDemo.Properties;

namespace WpfToolKitDemo.ViewModels;

public partial class ObservableValidatorDemoViewModel:ObservableValidator
{
    [ObservableProperty]
    [Range(0,200)]
    [Required]
    int _age;

    // partial void OnAgeChanged(int value)
    // {
    //     ValidateProperty(value,nameof(Age));
    // }

    [ObservableProperty]
    [Required]
    [EmailAddress(ErrorMessageResourceName ="EmailError",ErrorMessageResourceType =typeof(Lang))]
    // [RegularExpression("ddd")]
    string _email;

    [ObservableProperty]
    string _errMessages;

    [RelayCommand]
    void Submit()
    {
        // 校验全部规则
        ValidateAllProperties();

        if (HasErrors)
        {
            ErrMessages = string.Join(Environment.NewLine,GetErrors().Select(e => e.ErrorMessage));
        }
        else
        {
            ErrMessages="";
        }       
    }
}

public class GreaterThanAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        return base.IsValid(value);
    }
}