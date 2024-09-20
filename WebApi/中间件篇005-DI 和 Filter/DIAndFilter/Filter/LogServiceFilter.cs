using Microsoft.AspNetCore.Mvc.Filters;

namespace DotNet实战.Filter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class LogServiceFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("执行前...");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("执行后...");
        }
    }
}
