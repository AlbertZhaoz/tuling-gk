using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VOL.Core.HttpClientCache
{
    public class HttpClientCacheHandler:DelegatingHandler
    {
        private readonly IMemoryCache _memoryCache;

        public HttpClientCacheHandler(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        /* 使用的时候需要在 Startup.cs 中注册
        services.AddTransient<CacheHttpClientMessageHanlder>();
        services.AddHttpClient("CacheClient").
                AddHttpMessageHandler<CacheHttpClientMessageHanlder>();

        调用直接使用 HttpClient 即可
        HttpClient httpClient = _httpClientFactory.CreateClient("CacheClient");
        // 1、相当于直接查询(第三方服务)
        var result = httpClient.GetAsync("http://localhost:5000/Seckills").Result;
        // 2、数据库
        return result.Content.ReadAsStringAsync().Result;

        */
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // 本地缓存
            if (_memoryCache.TryGetValue(request.RequestUri.AbsoluteUri, out HttpResponseMessage cachedResponse))
            {
                CacheControlHeaderValue cacheControl = cachedResponse.Headers.CacheControl;
                if (!cacheControl.NoCache && !cacheControl.NoStore)
                {
                    return cachedResponse;
                }
            }

            // 从远程查找
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            // 需要配合浏览器缓存中间件一起使用，服务端要加特性以此添加浏览器请求头标识
            // [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60, NoStore =false)]
            // [HttpCacheValidation(MustRevalidate = true)]
            var cacheControlResponse = response.Headers.CacheControl;
            var noCache = cacheControlResponse.NoCache;
            var noStore = cacheControlResponse.NoStore;
            var maxAge = cacheControlResponse.MaxAge;

            if (!noCache && !noStore)
            {
                // 设置缓存过期时间
                MemoryCacheEntryOptions memoryCacheEntryOptions = new MemoryCacheEntryOptions();
                memoryCacheEntryOptions.AbsoluteExpirationRelativeToNow = maxAge;

                // 存储到本地缓存中
                _memoryCache.Set(request.RequestUri.AbsoluteUri, response, memoryCacheEntryOptions);
            }

            return response;
        }
    }
}
