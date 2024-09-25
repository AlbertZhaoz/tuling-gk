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
			Console.WriteLine(UtilMethods.GetSqlString(SqlSugar.DbType.MySql,sql,pars));


		};

		//注意多租户 有几个设置几个
		//db.GetConnection(i).Aop

	});

		//.net6以上 string加?
		//Db.DbFirst.Where(it => it.ToLower().StartsWith("albert_datafirst"))
		//.CreateClassFile(@"C:\Users\AlbertZhao\Desktop\Models", "Models");

		//
				//Db.Queryable<albert_datafirst>().Where(it => it.DataPkInt == 1)
				//.ToList()
				//.Dump();

		Db.Queryable<albert_datafirst>()
		.Where(it => it.ProductCode == "4201042316117759")
		.ToList()
		.Dump();
	}
	catch (Exception ex)
	{
		
		ex.Message.Dump();
	}
	
}


	///<summary>
	///环形1线追溯查询
	///</summary>
	public partial class albert_datafirst
	{
		public albert_datafirst()
		{


		}
		/// <summary>
		/// Desc:数据主键
		/// Default:
		/// Nullable:False
		/// </summary>           
		public int DataPkInt { get; set; }

		/// <summary>
		/// Desc:工单号
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string WorkorderCode { get; set; }

		/// <summary>
		/// Desc:产品码(轴承）
		/// Default:
		/// Nullable:False
		/// </summary>           
		public string ProductCode { get; set; }

		/// <summary>
		/// Desc:RFID
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string RFID { get; set; }

		/// <summary>
		/// Desc:工作类型（0正常件、1防错件、2返工件)
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string ProductFunction { get; set; }

		/// <summary>
		/// Desc:工作内容
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string ProductContent { get; set; }

		/// <summary>
		/// Desc:最终结果
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string OpFinalResult { get; set; }

		/// <summary>
		/// Desc:最终站
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string OpFinalStation { get; set; }

		/// <summary>
		/// Desc:最终时间
		/// Default:
		/// Nullable:True
		/// </summary>           
		public DateTime? OpFinalDate { get; set; }

		/// <summary>
		/// Desc:预留
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op10WorkType { get; set; }

		/// <summary>
		/// Desc:Op10加工结果
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op10Result { get; set; }

		/// <summary>
		/// Desc:Op10加工时间
		/// Default:
		/// Nullable:True
		/// </summary>           
		public DateTime? Op10Time { get; set; }

		/// <summary>
		/// Desc:Op10节拍
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op10Beat { get; set; }

		/// <summary>
		/// Desc:Op20加工结果
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op20Result { get; set; }

		/// <summary>
		/// Desc:Op20加工时间
		/// Default:
		/// Nullable:True
		/// </summary>           
		public DateTime? Op20Time { get; set; }

		/// <summary>
		/// Desc:Op20节拍
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op20Beat { get; set; }

		/// <summary>
		/// Desc:Op30加工结果
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op30Result { get; set; }

		/// <summary>
		/// Desc:Op30加工时间
		/// Default:
		/// Nullable:True
		/// </summary>           
		public DateTime? Op30Time { get; set; }

		/// <summary>
		/// Desc:Op30节拍
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op30Beat { get; set; }

		/// <summary>
		/// Desc:Op40加工结果
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op40Result { get; set; }

		/// <summary>
		/// Desc:Op40加工时间
		/// Default:
		/// Nullable:True
		/// </summary>           
		public DateTime? Op40Time { get; set; }

		/// <summary>
		/// Desc:Op40节拍
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op40Beat { get; set; }

		/// <summary>
		/// Desc:Op50加工结果
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op50Result { get; set; }

		/// <summary>
		/// Desc:Op50加工时间
		/// Default:
		/// Nullable:True
		/// </summary>           
		public DateTime? Op50Time { get; set; }

		/// <summary>
		/// Desc:Op50节拍
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op50Beat { get; set; }

		/// <summary>
		/// Desc:Op60加工结果
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op60Result { get; set; }

		/// <summary>
		/// Desc:Op60加工时间
		/// Default:
		/// Nullable:True
		/// </summary>           
		public DateTime? Op60Time { get; set; }

		/// <summary>
		/// Desc:Op60节拍
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op60Beat { get; set; }

		/// <summary>
		/// Desc:Op60压力数据
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op60Pressure { get; set; }

		/// <summary>
		/// Desc:Op60压力文件
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op60PressureFile { get; set; }

		/// <summary>
		/// Desc:Op60IX结果
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op60IXResult { get; set; }

		/// <summary>
		/// Desc:Op60IX照片
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op60IXFile { get; set; }

		/// <summary>
		/// Desc:Op60IX5_1
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op60IX5_1 { get; set; }

		/// <summary>
		/// Desc:Op60IX5_2
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op60IX5_2 { get; set; }

		/// <summary>
		/// Desc:Op60IX5_3
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op60IX5_3 { get; set; }

		/// <summary>
		/// Desc:Op60IX5_4
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op60IX5_4 { get; set; }

		/// <summary>
		/// Desc:Op70加工结果
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op70Result { get; set; }

		/// <summary>
		/// Desc:Op70加工时间
		/// Default:
		/// Nullable:True
		/// </summary>           
		public DateTime? Op70Time { get; set; }

		/// <summary>
		/// Desc:Op70节拍
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op70Beat { get; set; }

		/// <summary>
		/// Desc:Op80加工结果
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op80Result { get; set; }

		/// <summary>
		/// Desc:Op80加工时间
		/// Default:
		/// Nullable:True
		/// </summary>           
		public DateTime? Op80Time { get; set; }

		/// <summary>
		/// Desc:Op80节拍
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op80Beat { get; set; }

		/// <summary>
		/// Desc:Op90加工结果
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op90Result { get; set; }

		/// <summary>
		/// Desc:Op90位移结果
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op90DisplaceResult { get; set; }

		/// <summary>
		/// Desc:Op90位移值
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op90DisplaceValue { get; set; }

		/// <summary>
		/// Desc:Op90加工时间
		/// Default:
		/// Nullable:True
		/// </summary>           
		public DateTime? Op90Time { get; set; }

		/// <summary>
		/// Desc:Op90IV3结果
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op90IV3Result { get; set; }

		/// <summary>
		/// Desc:Op90相机图片文件
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op90IV3File { get; set; }

		/// <summary>
		/// Desc:Op90Beat
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op90Beat { get; set; }

		/// <summary>
		/// Desc:Op100加工结果
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op100Result { get; set; }

		/// <summary>
		/// Desc:Op100加工时间
		/// Default:
		/// Nullable:True
		/// </summary>           
		public DateTime? Op100Time { get; set; }

		/// <summary>
		/// Desc:Op100节拍
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op100Beat { get; set; }

		/// <summary>
		/// Desc:Op110加工结果
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op110Result { get; set; }

		/// <summary>
		/// Desc:Op110加工时间
		/// Default:
		/// Nullable:True
		/// </summary>           
		public DateTime? Op110Time { get; set; }

		/// <summary>
		/// Desc:Op110相机结果
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op110IV3Result { get; set; }

		/// <summary>
		/// Desc:Op110相机图片文件
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op110IV3File { get; set; }

		/// <summary>
		/// Desc:Op110节拍
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op110Beat { get; set; }

		/// <summary>
		/// Desc:Op120加工结果
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op120Result { get; set; }

		/// <summary>
		/// Desc:Op120加工时间
		/// Default:
		/// Nullable:True
		/// </summary>           
		public DateTime? Op120Time { get; set; }

		/// <summary>
		/// Desc:Op120扭矩结果
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op120TorqueResult { get; set; }

		/// <summary>
		/// Desc:Op120扭矩曲线数据
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op120TorqueList { get; set; }

		/// <summary>
		/// Desc:Op120前半程最大值
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op120MaxFirstHalf { get; set; }

		/// <summary>
		/// Desc:Op120前半程最小值
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op120MinFirstHalf { get; set; }

		/// <summary>
		/// Desc:Op120前半程平均值
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op120AverageFirstHalf { get; set; }

		/// <summary>
		/// Desc:Op120后半程最大值
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op120MaxSecondHalf { get; set; }

		/// <summary>
		/// Desc:Op120后半程最小值
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op120MinSecondHalf { get; set; }

		/// <summary>
		/// Desc:Op120后半程平均值
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op120AverageSecondHalf { get; set; }

		/// <summary>
		/// Desc:Op120相机照片
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op120IV3File { get; set; }

		/// <summary>
		/// Desc:Op120节拍
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op120Beat { get; set; }

		/// <summary>
		/// Desc:Op130加工结果
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op130Result { get; set; }

		/// <summary>
		/// Desc:Op130加工时间
		/// Default:
		/// Nullable:True
		/// </summary>           
		public DateTime? Op130Time { get; set; }

		/// <summary>
		/// Desc:Op130节拍
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op130Beat { get; set; }

		/// <summary>
		/// Desc:Op140加工结果
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op140Result { get; set; }

		/// <summary>
		/// Desc:Op140加工时间
		/// Default:
		/// Nullable:True
		/// </summary>           
		public DateTime? Op140Time { get; set; }

		/// <summary>
		/// Desc:Op140节拍
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Op140Beat { get; set; }

		/// <summary>
		/// Desc:修改ID
		/// Default:
		/// Nullable:True
		/// </summary>           
		public int? ModifyID { get; set; }

		/// <summary>
		/// Desc:修改人
		/// Default:
		/// Nullable:True
		/// </summary>           
		public string Modifier { get; set; }

		/// <summary>
		/// Desc:修改时间
		/// Default:
		/// Nullable:True
		/// </summary>           
		public DateTime? ModifyDate { get; set; }

	}


