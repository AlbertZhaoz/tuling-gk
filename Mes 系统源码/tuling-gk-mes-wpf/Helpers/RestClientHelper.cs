using RestSharp;
using System.Net;
using System.Text.Json;
using WpfTulingGkMes.Models;
using WpfTulingGkMes.ViewModels;

namespace WpfTulingGkMes.Helpers;

public class RestClientHelper
{
    private static readonly Lazy<RestClientHelper> lazy =
        new Lazy<RestClientHelper>(()=> new RestClientHelper());

    public static RestClientHelper Instance { get { return lazy.Value; } }

    private RestClientHelper() { }

    public async Task<WebResponseContent?>  GetUser(string rootUri,UserModel userLogin)
    {
        var client = new RestClient(rootUri);
        var request = new RestRequest();
        request.AddHeader("Content-Type", "application/json");
        request.AddHeader("Accept", "*/*");
        request.AddHeader("Host", "139.196.89.233:10000");
        request.AddHeader("Connection", "keep-alive");
        request.AddParameter("application/json", JsonSerializer.Serialize(userLogin),  ParameterType.RequestBody);
        var response = await client.PostAsync<WebResponseContent>(request); 

        return response;
    }
}