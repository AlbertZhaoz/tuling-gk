using System.Text.Json.Serialization;

namespace WpfTulingGkMes.Models;

public class UserModel
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string UUID { get; set; }
    [JsonIgnore]
    public string Token { get; set; }
}