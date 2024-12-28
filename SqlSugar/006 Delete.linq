<Query Kind="Program">
  <NuGetReference>SqlSugarCore</NuGetReference>
  <Namespace>SqlSugar</Namespace>
</Query>

void Main()
{
	try
	{
		SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
		{
			ConnectionString = "server=localhost;Database=sqlsugar;Uid=root;Pwd=root123;AllowLoadLocalInfile=true",
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
		//db.Deleteable<Student>(new Student() { Id = 1 }).ExecuteCommand().Dump();
		//db.Deleteable<Student>().In(2).ExecuteCommand().Dump();
		db.CodeFirst.InitTables(typeof(Student));
		//db.Deleteable<Student>().In(3).IsLogic().ExecuteCommand().Dump();

		db.Deleteable<Student>()
   .In(3)
   .IsLogic()
   .ExecuteCommand("isdeleted", true, "UpdateTime", "ModifierName", "88").Dump();
	}
	catch (Exception ex)
	{
		ex.Message.Dump();
	}
}

//唯一索引 (true表示唯一索引 或者叫 唯一约束)
[SugarTable("dbstudent")]//当和数据库名称不一样可以设置表别名 指定表明
public class Student
{
	[SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//数据库是自增才配自增 
	public int Id { get; set; }
	public int? SchoolId { get; set; }
	[SugarColumn(ColumnName = "StudentName")]//数据库与实体不一样设置列名 
	public string Name { get; set; }
	public int Age { get; set; }
	public bool isdeleted { get; set; }
	[SugarColumn(IsNullable = true)]
	public DateTime UpdateTime { get; set; }
	[SugarColumn(IsNullable = true)]
	public string ModifierName { get; set; }
}