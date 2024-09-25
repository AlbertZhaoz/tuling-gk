<Query Kind="Program">
  <NuGetReference>SqlSugarCore</NuGetReference>
  <Namespace>SqlSugar</Namespace>
</Query>

void Main()
{
	SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
	{
		ConnectionString = "datasource=demo.db",
		DbType = SqlSugar.DbType.MySql,
		IsAutoCloseConnection = true
	},
	db =>
	{
		db.Aop.OnLogExecuting = (sql, pars) =>
		{
			//获取原生SQL推荐 5.1.4.63  性能OK
			Console.WriteLine(UtilMethods.GetNativeSql(sql, pars));
			//获取无参数化SQL 对性能有影响，特别大的SQL参数多的，调试使用
			//Console.WriteLine(UtilMethods.GetSqlString(DbType.SqlServer,sql,pars));
	};
	//注意多租户 有几个设置几个
	//db.GetConnection(i).Aop
	});
	
	
}

