using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using NET_FiveMinutes_008_UseIdentity;
using NET_FiveMinutes_008_UseIdentity.Common;
using NET_FiveMinutes_008_UseIdentity.HostedServices;
using NET_FiveMinutes_008_UseIdentity.Models;

{
    // 课程大纲：
    // 1.Identity标识框架讲解 AddIdentityCore
    // 2.托管服务IHostService  BackgroudService讲解
    // 3.OData讲解 Microsoft.AspNetCore.OData
}


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add OData
builder.Services.AddControllers().AddOData(opt=>
{
    opt.Select().Filter().OrderBy().Count().Expand().SetMaxTop(100);
    opt.AddRouteComponents("odata", ODataAlbertModelBuilder.GetEdmModel());
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AlbertDbContext>(opt=>
{
    //先用直接赋值的形式来测试
    string connStr = "Server = .; Database = albert_fiveminutes; Trusted_Connection = True;MultipleActiveResultSets=true";
    opt.UseSqlServer(connStr);
    //引用Zack.EFCore.Batch.MSSQL Package.支持批量操作SQL Server数据库
    opt.UseBatchEF_MSSQL();
});

// 配置标识框架的用户配置
builder.Services.AddDataProtection();
builder.Services.AddIdentityCore<User>(opt=>
{
    opt.Password.RequireDigit = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequiredLength = 6;
    opt.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
    opt.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;

    // 增加锁定次数，增加锁定时间
    // 默认为5分钟，登录失败5次则锁定
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    opt.Lockout.MaxFailedAccessAttempts = 10;
});

// 托管服务
builder.Services.AddHostedService<ExplortStatisticBgService>();

var idBuilder = new IdentityBuilder(typeof(User),typeof(Role),builder.Services);
idBuilder.AddEntityFrameworkStores<AlbertDbContext>()
    .AddDefaultTokenProviders()
    .AddRoleManager<RoleManager<Role>>()
    .AddUserManager<UserManager<User>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
