using Albert.SqlOperateSplitDemo.Models;
using SqlSugar.IOC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region SqlSugarCore ���
builder.Services.AddSqlSugar(new SqlSugar.IOC.IocConfig()
{
    ConnectionString = "Data Source=139.196.89.233;Database=MySqlDemo;AllowLoadLocalInfile=true;User ID=root;Password=eason12138;allowPublicKeyRetrieval=true;pooling=true;CharSet=utf8;port=3306;sslmode=none;",
    DbType = IocDbType.MySql,
    IsAutoCloseConnection = true
});

// ���ò���
builder.Services.ConfigurationSugar(db =>
{
    // ���� AOP,��ӡ Sql
    db.Aop.OnLogExecuting = (sql, p) =>
    {
        Console.WriteLine(sql);
    };
    //���ø������Ӳ���
    //db.CurrentConnectionConfig.XXXX=XXXX
    //db.CurrentConnectionConfig.MoreSettings=new ConnMoreSettings(){}
    //������������
    //db.CurrentConnectionConfig.ConfigureExternalServices = new ConfigureExternalServices()
    //{
    // DataInfoCacheService = myCache //�������Ǵ����Ļ�����
    //}
    //��д��������
    //laveConnectionConfigs = new List<SlaveConnectionConfig>(){...}

    /*���⻧ע��*/
    //������db.CurrentConnectionConfig 
    //���⻧��Ҫdb.GetConnection(configId).CurrentConnectionConfig 
});
// ��ʼ���ȴ�����
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
