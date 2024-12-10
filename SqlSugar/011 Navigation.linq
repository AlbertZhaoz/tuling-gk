<Query Kind="Program">
  <NuGetReference>Mapster</NuGetReference>
  <NuGetReference>SqlSugarCore</NuGetReference>
  <Namespace>SqlSugar</Namespace>
  <Namespace>Mapster</Namespace>
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


		//var list = db.Queryable<Student>()
		// .Includes(x => x.SchoolA) //填充子对象 （不填充可以不写）
		// .Where(x => x.SchoolA.SchoolName == "北京大学")
		// .ToList().Dump();

		// 性能优化使用，查询条数达到上千条可以使用底层分页
		//var listNew = new List<Student>();
		//db.Queryable<Student>()
		//	.Includes(it => it.SchoolA)
		//	.ForEach(it => listNew.Add(it), 300); //每次查询300条


		//var list = db.Queryable<Student>()
		//		   .Includes(x => x.SchoolA).ToList();
		//var dtoList = list.Adapt<List<StudentDto>>();
		//dtoList.Dump();

		db.Queryable<Student>()
				   .Includes(x => x.SchoolA)
				   .Select(x => new StudentDto {
				   	Name2 = x.Name,
					SchoolA = x.SchoolA
				   },true).ToList().Dump();
	}
	catch (Exception ex)
	{
		ex.Message.Dump();
	}
}


public class StudentDto
{
	public int Id { get; set; }
	public int? SchoolId { get; set; }
	public string Name2 { get; set; }
	public int Age { get; set; }
	public DateTime UpdateTime { get; set; }
	public School SchoolA { get; set; }
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
	
	[Navigate(NavigateType.OneToOne,nameof(SchoolId),nameof(SchoolA.SchoolId))]
	public School SchoolA { get; set; }
}

[SugarTable("dbschool")]//当和数据库名称不一样可以设置表别名 指定表明
public class School
{
	[SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//数据库是自增才配自增 
	public int Id { get; set; }
	public int? SchoolId { get; set; }
	public string SchoolName { get; set; }
}
