using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using DIע��.Filter;
using DotNetʵս.AutofacCommon;
using DotNetʵս.Services;

var builder = WebApplication.CreateBuilder(args);
// Get ContainerBuilder

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region ���̻�д��
//�滻���õ� ServiceProviderFactory
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containBuilder =>
{
    containBuilder.RegisterModule<AutofacModule>();
});
#endregion

#region ����ע��
// �滻���õ� ServiceProviderFactory

// �滻���õ� ServcieProviderFacotry Ϊ AutofacServiceProviderFactory
// builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
// builder.Host.ConfigureContainer<ContainerBuilder>(containBuilder =>
// {
//     // ˲̬ע��
//     containBuilder.RegisterType<MyService>().As<IMyService>().InstancePerDependency();
//     // ���������� ��������ע��
//     containBuilder.RegisterType<UserService>().As<IUserService>().InstancePerDependency().EnableInterfaceInterceptors().PropertiesAutowired();
//     // Q:���ͬʱʹ��
// });
#endregion

#region Autofac AOP ������
// builder.Host.ConfigureContainer<ContainerBuilder>(containBuilder =>
// {
//     // ע��ӿ�������
//     containBuilder.RegisterType<MyInterceptor>();
//     // ���ýӿ�����������ȻҲ�����ڽӿ��ϱ�ע���� [Intercept(typeof(MyInterceptor))]
//     containBuilder.RegisterType<MyService>().As<IMyService>().EnableInterfaceInterceptors().InterceptedBy(typeof(MyInterceptor));
//     var myService = containBuilder.Build().Resolve<MyService>();
//     myService.ShowCode();
// });
#endregion

#region ������ע��
// builder.Host.ConfigureContainer<ContainerBuilder>(containBuilder =>
// {
//     containBuilder.RegisterType<MyNameService>().InstancePerMatchingLifetimeScope("MyScope");
// });
#endregion

#region ����ע��
// builder.Host.ConfigureContainer<ContainerBuilder>(containBuilder =>
// {
//     containBuilder.RegisterType<MyServiceV2>().Named<IMyService>("V2");
//     containBuilder.RegisterType<MyServiceV2>().Named<IMyService>("V3");
// });

#endregion

#region ����ע��
// builder.Host.ConfigureContainer<ContainerBuilder>(containBuilder =>
// {
//     containBuilder.RegisterType<MyNameService>().AsSelf();
//     containBuilder.RegisterType<MyNameService>();
//     containBuilder.RegisterType<MyServiceV2>().Named<IMyService>("V2").PropertiesAutowired();
// });

#endregion

#region ������ȫ��ע��
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

#region ������ʹ��

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
