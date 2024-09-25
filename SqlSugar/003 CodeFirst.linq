<Query Kind="Program">
  <NuGetReference>SqlSugarCore</NuGetReference>
  <Namespace>SqlSugar</Namespace>
</Query>

void Main()
{
	try
	{
		SqlSugarClient Db = new SqlSugarClient(new ConnectionConfig()
		{
			ConnectionString = "server=localhost;Database=mes;Uid=root;Pwd=root123",
			DbType = SqlSugar.DbType.MySql,
			IsAutoCloseConnection = true
		},
		db =>
			{
				db.Aop.OnLogExecuting = (sql, pars) =>
				{
					//获取原生SQL推荐 5.1.4.63  性能OK
					//Console.WriteLine(UtilMethods.GetNativeSql(sql, pars));

					//获取无参数化SQL 对性能有影响，特别大的SQL参数多的，调试使用
					//Console.WriteLine(UtilMethods.GetSqlString(SqlSugar.DbType.MySql, sql, pars));
				};
		});

		// 具体的代码
		//建表
		Db.CodeFirst.SetStringDefaultLength(200).InitTables(typeof(Student));

		//例1 获取所有表
//		var tables = Db.DbMaintenance.GetTableInfoList(false);//true 走缓存 false不走缓存
//		foreach (var table in tables)
//		{
//			Console.WriteLine($"{table.Name}--{table.Description}");//输出表信息
//
//			//获取列信息
//			//var columns=db.DbMaintenance.GetColumnInfosByTableName("表名",false);
//		}
	}
	catch (Exception ex)
	{
		ex.Message.Dump();
	}
}

//唯一索引 (true表示唯一索引 或者叫 唯一约束)
[SugarIndex("unique_codetable1_StudentName", nameof(Student.Name), OrderByType.Desc, true)]
[SugarTable("dbstudent")]//当和数据库名称不一样可以设置表别名 指定表明
public class Student
{
	[SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//数据库是自增才配自增 
	public int Id { get; set; }
	public int? SchoolId { get; set; }
	[SugarColumn(ColumnName = "StudentName")]//数据库与实体不一样设置列名 
	public string Name { get; set; }
}

