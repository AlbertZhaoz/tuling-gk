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
					Console.WriteLine(UtilMethods.GetSqlString(SqlSugar.DbType.MySql, sql, pars));
				};
			});

		// 具体的代码
		//db.Queryable<Student>().ToList().Dump();
		//db.Queryable<Student>().Count().Dump();
		//db.Queryable<Student>().Where(it => it.Name == "Tuling996").ToList().Dump();
		//db.Queryable<Student>().Where(it=>it.ModifierName !=null).ToList().Dump();
		//db.Queryable<Student>().Where(it =>it.Name.Contains("tuling1")).ToList().Dump();
		//db.Queryable<Student>().Where(it => it.Id > 10 && it.Name == "tuling996").ToList().Dump();
		//db.Queryable<Student>().InSingle(999).Dump();
		//db.Queryable<Student>().Where(it=>it.Id>1100).Any().Dump();

		//List<Student> list = new List<Student>();
		//list.Add(new Student(){
		//	Id = 999,
		//	Name = "Tuling996"
		//});
		//
		//
		//db.Queryable<Student>().Where(it => list.Any(s => s.Id == it.Id && s.Name == it.Name)).ToList().Dump();

		//db.Queryable<Student>().OrderBy(s => s.Id, OrderByType.Desc).ToList().Dump();

		//db.Queryable<Student>().Select(it => new {it.Name,it.SchoolId}).ToList().Dump();

		//db.Queryable<Student>()
		//.IgnoreColumns(it =>it.SchoolId)
		//.Where(it => it.Name == "Tuling996")
		//.ToList().Dump();

		//db.Queryable<Student>()
		//.IgnoreColumns(it => new {it.SchoolId,it.Name})
		//.Where(it => it.Name == "Tuling996")
		//.ToList().Dump();


		int pagenumber = 1; // pagenumber是从1开始的不是从零开始的
		int pageSize = 10;
		int totalCount = 0;
		
		for (int i = 1; i < 100; i++)
		{
			//单表分页
			pagenumber = i;
			var page = db.Queryable<Student>().ToPageList(pagenumber, pageSize, ref totalCount);
			totalCount.Dump();
			page.Dump();	
		}

		
		
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