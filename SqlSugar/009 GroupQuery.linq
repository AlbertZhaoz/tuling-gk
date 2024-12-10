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
			ConnectionString = "server=localhost;Database=mes;Uid=root;Pwd=root123;AllowLoadLocalInfile=true",
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

		// 按照年月日进行分组
		//db.Queryable<Student>().GroupBy(s => s.UpdateTime.Date)
		//.Select(g => new {
		//	Date = g.UpdateTime.Date,
		//	AgeAvg = SqlFunc.AggregateAvg(g.Age),
		//	IdTotalCount = SqlFunc.AggregateCount(g.Id)
		//}).ToList().Dump();
		
		//db.Queryable<Student>()
		//.Select(it=>SqlFunc.AggregateDistinctCount(it.SchoolId)).ToList().Dump();
		
		db.Queryable<Student>().Take(10).OrderBy(st=>SqlFunc.GetRandom()).ToList().Dump(); 
	}
	catch (Exception ex)
	{
		ex.Message.Dump();
	}
}


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