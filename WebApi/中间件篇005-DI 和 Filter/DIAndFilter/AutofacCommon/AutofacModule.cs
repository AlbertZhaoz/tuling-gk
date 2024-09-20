using Autofac;
using Autofac.Extras.DynamicProxy;
using DotNet实战.Services;

namespace DotNet实战.AutofacCommon;

public class AutofacModule:Autofac.Module
{
    protected override void Load(ContainerBuilder containBuilder)
    {
        containBuilder.RegisterType<MyInterceptor>();

        // 在这边注册
        containBuilder.RegisterType<UserService>().As<IUserService>().EnableInterfaceInterceptors();

        containBuilder.RegisterType<MyService>().As<IMyService>().SingleInstance().EnableInterfaceInterceptors();
    }
}