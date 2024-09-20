using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using NET_FiveMinutes_008_UseIdentity;
using NET_FiveMinutes_008_UseIdentity.Common;
using NET_FiveMinutes_008_UseIdentity.HostedServices;
using NET_FiveMinutes_008_UseIdentity.Models;

{
    // �γ̴�٣�
    // 1.Identity��ʶ��ܽ��� AddIdentityCore
    // 2.�йܷ���IHostService  BackgroudService����
    // 3.OData���� Microsoft.AspNetCore.OData
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
    //����ֱ�Ӹ�ֵ����ʽ������
    string connStr = "Server = .; Database = albert_fiveminutes; Trusted_Connection = True;MultipleActiveResultSets=true";
    opt.UseSqlServer(connStr);
    //����Zack.EFCore.Batch.MSSQL Package.֧����������SQL Server���ݿ�
    opt.UseBatchEF_MSSQL();
});

// ���ñ�ʶ��ܵ��û�����
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

    // ����������������������ʱ��
    // Ĭ��Ϊ5���ӣ���¼ʧ��5��������
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    opt.Lockout.MaxFailedAccessAttempts = 10;
});

// �йܷ���
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
