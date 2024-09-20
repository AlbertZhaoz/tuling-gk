using Microsoft.Extensions.Configuration;
using WpfTulingGkMes.Models;

namespace WpfTulingGkMes.Helpers;

public class ConfigHelper
{
    private static readonly Lazy<ConfigHelper> lazy =
        new Lazy<ConfigHelper>(()=> new ConfigHelper());

    public static ConfigHelper Instance { get { return lazy.Value; } }

    private ConfigHelper() { }

    public WebUri? WebUriProp { get; set; } = new WebUri();

    public UserModel CurrentUser { get; set; }
}