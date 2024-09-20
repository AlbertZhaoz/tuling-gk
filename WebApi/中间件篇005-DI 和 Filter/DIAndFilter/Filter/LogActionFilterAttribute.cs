using Microsoft.AspNetCore.Mvc.Filters;

namespace DotNet实战.Filter
{
    public class LogActionFilterAttribute : ActionFilterAttribute
    {
        private readonly ILogger<LogActionFilterAttribute> _logger;
        public LogActionFilterAttribute(ILogger<LogActionFilterAttribute> logger)
        {
            _logger = logger;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("执行前...");
            _logger.LogInformation("日志打印：执行前");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("执行后...");
            _logger.LogInformation("日志打印：执行后");
        }
    }
}
