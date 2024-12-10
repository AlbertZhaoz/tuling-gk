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

		// 具体的代码


		// 返回影响行数
		//db.Insertable(stu).ExecuteCommand().Dump();
		// 返回自增列
		//db.Insertable(stu).ExecuteReturnIdentity().Dump();

		//SnowFlakeSingle.Instance.NextId().Dump();

		var stuList = new List<Student>();
		
		for (int i = 0; i < 1000; i++)
		{
			var stu = new Student();
			stu.SchoolId = i;
			stu.Name = $"zhangsan{i}";
			stu.Age = 18+i;
			stu.isdeleted = false;
			stuList.Add(stu);
		}
		 //万金油写法，批量插入
		var sw = new Stopwatch();
		sw.Start();
		db.Insertable(stuList).ExecuteCommand();
		sw.Stop();
		sw.ElapsedMilliseconds.Dump();

		// 大批量数据插入
		//var sw = new Stopwatch();
		//sw.Start();
		//db.Fastest<Student>().PageSize(10000).BulkCopy(stuList);
		//sw.Stop();
		//sw.ElapsedMilliseconds.Dump();

		// 根据字典插入
		//var dc = new Dictionary<string, object>();
		//dc.Add("StudentName", "lisi");
		//dc.Add("SchoolId", 1);
		//dc.Add("Age", 18);
		//db.Insertable(dc).AS("dbstudent").ExecuteCommand();

		// 匿名对象插入
		//db.InsertableByDynamic(new { StudentName = "lisi2", SchoolId = 1 ,Age=20})
		//		.AS("dbstudent")
		//		.ExecuteCommand();

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
	public int Age {get;set;}
	public bool isdeleted { get; set; }
}

