using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using DI注入.Filter;
using DotNet实战.AutofacCommon;
using DotNet实战.Services;

var builder = WebApplication.CreateBuilder(args);
// Get ContainerBuilder

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region 工程化写法
//替换内置的 ServiceProviderFactory
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containBuilder =>
{
    containBuilder.RegisterModule<AutofacModule>();
});
#endregion

#region 类型注入
// 替换内置的 ServiceProviderFactory

// 替换内置的 ServcieProviderFacotry 为 AutofacServiceProviderFactory
// builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
// builder.Host.ConfigureContainer<ContainerBuilder>(containBuilder =>
// {
//     // 瞬态注入
//     containBuilder.RegisterType<MyService>().As<IMyService>().InstancePerDependency();
//     // 允许拦截器 允许属性注入
//     containBuilder.RegisterType<UserService>().As<IUserService>().InstancePerDependency().EnableInterfaceInterceptors().PropertiesAutowired();
//     // Q:如果同时使用
// });
#endregion

#region Autofac AOP 拦截器
// builder.Host.ConfigureContainer<ContainerBuilder>(containBuilder =>
// {
//     // 注入接口拦截器
//     containBuilder.RegisterType<MyInterceptor>();
//     // 启用接口拦截器，当然也可以在接口上标注特性 [Intercept(typeof(MyInterceptor))]
//     containBuilder.RegisterType<MyService>().As<IMyService>().EnableInterfaceInterceptors().InterceptedBy(typeof(MyInterceptor));
//     var myService = containBuilder.Build().Resolve<MyService>();
//     myService.ShowCode();
// });
#endregion

#region 子容器注册
// builder.Host.ConfigureContainer<ContainerBuilder>(containBuilder =>
// {
//     containBuilder.RegisterType<MyNameService>().InstancePerMatchingLifetimeScope("MyScope");
// });
#endregion

#region 命名注入
// builder.Host.ConfigureContainer<ContainerBuilder>(containBuilder =>
// {
//     containBuilder.RegisterType<MyServiceV2>().Named<IMyService>("V2");
//     containBuilder.RegisterType<MyServiceV2>().Named<IMyService>("V3");
// });

#endregion

#region 属性注入
// builder.Host.ConfigureContainer<ContainerBuilder>(containBuilder =>
// {
//     containBuilder.RegisterType<MyNameService>().AsSelf();
//     containBuilder.RegisterType<MyNameService>();
//     containBuilder.RegisterType<MyServiceV2>().Named<IMyService>("V2").PropertiesAutowired();
// });

#endregion

#region 过滤器全局注册
// builder.Services.AddMvc(opt =>
// {
//     opt.Filters.Add<AuthorizationFilterAttribute>();
//     opt.Filters.Add<ResourceFilterAttribute>();
//     opt.Filters.Add<SelfActionFilterAttribute>();
//     opt.Filters.Add<ExceptionFilterAttribute>();
//     opt.Filters.Add<ResultFilterAttribute>();
//     opt.Filters.Add<AlwaysRunResultFilterAttribute>();
// });
#endregion

var app = builder.Build();

#region 子容器使用

// .NET6 GetAutofacRoot
// var autofacRootScope = app.Services.GetRequiredService<ILifetimeScope>();
//
// using (var myscope = autofacRootScope.BeginLifetimeScope("MyScope"))
// {
//     var serviceRoot = myscope.Resolve<MyNameService>();
//     using (var scope = myscope.BeginLifetimeScope())
//     {
//         var service1 = scope.Resolve<MyNameService>();
//         var service2 = scope.Resolve<MyNameService>();
//         Console.WriteLine(service1 == service2);
//         Console.WriteLine(service1 == serviceRoot);
//     }
// }
#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
