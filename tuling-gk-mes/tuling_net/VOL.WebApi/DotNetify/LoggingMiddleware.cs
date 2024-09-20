using Castle.Core.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace VOL.WebApi.DotNetify
{
    /// <summary>
    /// 实现每次接口调用的拦截请求
    /// </summary>
    public class LoggingMiddleware : IMiddleware
    {
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(ILogger<LoggingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next(context);
            _logger.LogInformation($"请求类型：{context.Request.Method}--请求方法名：{context.Request.Path}--请求状态：{context.Response.StatusCode}");
        }
    }
}
