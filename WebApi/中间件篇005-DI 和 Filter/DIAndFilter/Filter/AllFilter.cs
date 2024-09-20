using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DI注入.Filter
{
    public class AuthorizationFilterAttribute : Attribute,IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // 获取 context.HttpContext 信息来进行鉴权拦截
            // 如果不包含 admin 直接中断请求
            if (!context.HttpContext.Request.QueryString.Value.Contains("admin"))
            {
                Console.WriteLine("AuthFilter 里面包含了 admin");
                context.Result = new JsonResult(new
                {
                    Code = 401,
                    Info = "只有 Admin 才有请求权限"
                });
            }
            Console.WriteLine("AuthFilter 执行鉴权");
        }
    }

    public class ResourceFilterAttribute : Attribute, IResourceFilter,IAsyncResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("ResourceFilter 执行资源前");
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine("ResourceFilter 执行资源后");
        }

        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            Console.WriteLine("ResourceFilter 执行资源前");
            await next();
            Console.WriteLine("ResourceFilter 执行资源后");
        }
    }

    public class ExceptionFilterAttribute:Attribute,IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Console.WriteLine("ExceptionFilter 异常过滤器");
        }
    }

    public class SelfActionFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // 判断接口是否忽略了过滤器 有则返回特定信息
            if (context.ActionDescriptor.EndpointMetadata.Any(x => x.GetType() == typeof(IgnoreActionFilterAttribute)))
            {
                context.Result = new JsonResult(new
                {
                    Code = 401,
                    Info = "接口忽略了过滤器"
                });
            }
            Console.WriteLine("ActionFilter 执行Action前");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("ActionFilter 执行Action后");
        }
    }

    public class LogTestActionFilterAttribute : Attribute, IActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = 0;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("LogTest 执行Action前");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("LogTest 执行Action后");
        }
    }

    public class TimeActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Time 执行Action前");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Time 执行Action后");
        }
    }

    public class IgnoreActionFilterAttribute : Attribute
    {

    }

    public class ResultFilterAttribute : Attribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine("ResultFilter 执行结果前");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("ResultFilter执行结果后");
        }
    }

    public class AlwaysRunResultFilterAttribute : Attribute, IAlwaysRunResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine("AlwaysRunResultFilter 执行结果前");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("AlwaysRunResultFilter 执行结果后");
        }
    }
}
