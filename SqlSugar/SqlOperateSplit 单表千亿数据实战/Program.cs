using Albert.SqlOperateSplitDemo.Models;
using SqlSugar.IOC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region SqlSugarCore 相关
builder.Services.AddSqlSugar(new SqlSugar.IOC.IocConfig()
{
    ConnectionString = "Data Source=139.196.89.233;Database=MySqlDemo;AllowLoadLocalInfile=true;User ID=root;Password=eason12138;allowPublicKeyRetrieval=true;pooling=true;CharSet=utf8;port=3306;sslmode=none;",
    DbType = IocDbType.MySql,
    IsAutoCloseConnection = true
});

// 设置参数
builder.Services.ConfigurationSugar(db =>
{
    // 设置 AOP,打印 Sql
    db.Aop.OnLogExecuting = (sql, p) =>
    {
        Console.WriteLine(sql);
    };
    //设置更多连接参数
    //db.CurrentConnectionConfig.XXXX=XXXX
    //db.CurrentConnectionConfig.MoreSettings=new ConnMoreSettings(){}
    //二级缓存设置
    //db.CurrentConnectionConfig.ConfigureExternalServices = new ConfigureExternalServices()
    //{
    // DataInfoCacheService = myCache //配置我们创建的缓存类
    //}
    //读写分离设置
    //laveConnectionConfigs = new List<SlaveConnectionConfig>(){...}

    /*多租户注意*/
    //单库是db.CurrentConnectionConfig 
    //多租户需要db.GetConnection(configId).CurrentConnectionConfig 
});
// 初始化先创建表
// DbScoped.SugarScope.CodeFirst.InitTables(typeof(BillsMonth));
#endregion

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
