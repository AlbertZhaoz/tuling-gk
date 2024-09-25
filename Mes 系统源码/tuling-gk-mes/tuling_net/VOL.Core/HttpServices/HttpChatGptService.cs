using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using VOL.Core.Services;

namespace VOL.Core.HttpService
{
    public class HttpChatGptService
    {
        private RestClient _restClient;
        private string _chatGptToken;

        public HttpChatGptService(string chatGptUrl,string chatGptToken)
        {
            try
            {
                _restClient = new RestClient(chatGptUrl);
                _restClient.Timeout = -1;
                _restClient.UserAgent = "Apifox/1.0.0 (https://www.apifox.cn)";
                _chatGptToken = chatGptToken;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        private void AddHeader(RestRequest request)
        {
            // 设置HTTP头
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {_chatGptToken}");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Host", "api.openai.com");
            request.AddHeader("Connection", "keep-alive");
        }

        /// <summary>
        /// POST
        /// </summary>
        /// <param name="resource">resource</param>
        /// <param name="obj">body参数</param>
        /// <returns>HttpStatusCode</returns>
        public IRestResponse Post(string body)
        {
            try
            {
                var request = new RestRequest(Method.POST);
                AddHeader(request);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = _restClient.Execute(request);
                return response;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }

        public T Post<T>(string body) where T : new()
        {
            try
            {

                var request = new RestRequest(Method.POST);
                AddHeader(request);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = _restClient.Execute(request);
                return JsonConvert.DeserializeObject<T>(response.Content);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return default;
            }
        }
    }
}
