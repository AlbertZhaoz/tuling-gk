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
	    var stu = new Student();
		stu.Id = 1;
		stu.SchoolId = 1;
		stu.Name = "lisi5";
		stu.Age = 22;
		//db.Updateable(stu).ExecuteCommand().Dump();
		//db.Tracking(stu);//创建跟踪
		//stu.Name = "lisi5";//只改修改了name那么只会更新name
		//db.Updateable(stu).ExecuteCommand().Dump();//因为每条记录的列数不一样，批量数据多性能差，不建议用
		
		db.Updateable(stu).WhereColumns(it=>new { it.Name}).ExecuteCommand().Dump();
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
}

// 两个对象差异比较
//void Main()
//{
//	var originStu = new Student
//	{
//		Id = 1,
//		Name = "lisi2",
//		Age = 18,
//		SchoolId = 1
//	};
//
//	var modifiedStu = new Student
//	{
//		Id = 1,
//		Name = "lisi4",
//		Age = 22,
//		SchoolId = 1
//	};
//
//	var changedProperties = GetChangedProperties(originStu, modifiedStu);
//
//	foreach (var element in changedProperties)
//	{
//		element.Dump();
//	}
//}
//
//static List<string> GetChangedProperties<T>(T originObject, T modifiedObject)
//{
//	var type = typeof(T);
//	var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
//
//	var changedProperties = new List<string>();
//
//	foreach (var property in properties)
//	{
//		var originalValue = property.GetValue(originObject);
//		var modifiedValue = property.GetValue(modifiedObject);
//
//		if (!Equals(originalValue, modifiedValue))
//		{
//			changedProperties.Add("prperty:" + property.Name + "--value:" + modifiedValue.ToString());
//		}
//	}
//
//	return changedProperties;
//}
