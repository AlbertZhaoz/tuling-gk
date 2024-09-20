using Castle.DynamicProxy;

namespace DotNet实战.AutofacCommon;

public class MyInterceptor : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        // 判断接口方法是否需要忽略拦截
        if (invocation.Method.IsDefined(typeof(IgnoreInterceptAttribute), true))
        {
            invocation.Proceed();
            return;
        }

        Console.WriteLine($"Intercept before,Method:{invocation.Method.Name}");
        invocation.Proceed();
        Console.WriteLine($"Intercept after,Method:{invocation.Method.Name}");
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class IgnoreInterceptAttribute : Attribute
    {
    }
}