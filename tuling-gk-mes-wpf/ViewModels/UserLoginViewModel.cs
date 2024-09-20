using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using WpfTulingGkMes.Helpers;
using WpfTulingGkMes.Models;

namespace WpfTulingGkMes.ViewModels;

public partial class UserLoginViewModel : ObservableValidator
{
    [ObservableProperty]
    [Required]
    string _userName = "test";

    [ObservableProperty]
    [Required]
    string _password = "test123";

    [ObservableProperty]
    string _uUID = Guid.NewGuid().ToString();

    [ObservableProperty]
    string _errorMessage="";

    [ObservableProperty]
    bool _isLoginOk = false;

    [RelayCommand]
    async Task Submit(object? obj)
    {
        ValidateAllProperties();

        if (HasErrors)
        {
            ErrorMessage = string.Join(Environment.NewLine,GetErrors());
        }
        else
        {
            var currentUser = new UserModel();
            currentUser.UserName = UserName;
            currentUser.Password = Password;
            currentUser.UUID = UUID;

            // 提交到后端服务器
            var webResponseContent = await RestClientHelper.Instance
                .GetUser(ConfigHelper.Instance.WebUriProp.BaseUri+ConfigHelper.Instance.WebUriProp.LoginUri, currentUser);
            try
            {
                if (webResponseContent.Status = true)
                {
                    if((object?)webResponseContent?.Data == null)
                    {
                        ErrorMessage = webResponseContent.Message;

                        return;
                    }

                    if(webResponseContent.Data.TryGetProperty("token",out JsonElement tokenElement))
                    {
                        string token = tokenElement.GetString();
                        currentUser.Token = token;
                        ConfigHelper.Instance.CurrentUser = currentUser;

                        // 关闭登录窗口，并且 DialogResult 返回 True；
                        (obj as Window).DialogResult = true;

                        ErrorMessage = string.Empty;
                    }
                }
                else
                {
                    ErrorMessage = "接口请求失败";
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        } 
    }
}