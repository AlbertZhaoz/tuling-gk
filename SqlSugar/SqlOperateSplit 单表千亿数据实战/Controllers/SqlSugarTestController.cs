using Albert.SqlOperateSplitDemo.Models;
using Microsoft.AspNetCore.Mvc;
using SqlSugar.IOC;

namespace Albert.SqlOperateSplitDemo.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SqlSugarTestController : ControllerBase
    {
        private readonly ILogger<SqlSugarTestController> _logger;

        public SqlSugarTestController(ILogger<SqlSugarTestController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "InsertData")]
        public ActionResult InsertData()
        {
            var bilisMonthList = new List<BillsMonth>();

           

            for (int i = 0; i < 365; i++)
            {
                var dtActual = DateTime.Now.AddDays(new Random().Next(1, 365));

                var bill = new BillsMonth()
                {
                    // 注意这边我是通过 Guid 和 时间戳生成的唯一 ID,下次就可以直接通过反解析定位到具体的表了
                    SerialNumber = Guid.NewGuid().ToString()+ ";"+ dtActual.ToFileTimeUtc().ToString(),
                    PayMoney = i * (new Random().Next(1, 100)),
                    BillsInfo = $"随便来点信息--{i}",
                    BillComment = $"随便来点备注--{i}",
                    MachineSerialNo = Guid.NewGuid().ToString(),
                    CreateTime = dtActual,
                };

                bilisMonthList.Add(bill);
            }

            // 必须要加 SplitTable，返回雪花 ID 并自动赋值 ID
            var snowFlake =  DbScoped.SugarScope.Insertable(bilisMonthList).SplitTable().ExecuteReturnSnowflakeIdList();

            return Ok(snowFlake);
        }

        /// <summary>
        /// 根据 SN 查询数据
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        [HttpGet(Name = "QueryBySN")]
        public ActionResult QueryBySN(string serialNumber)
        {
            var tableName = GetTableBySN(serialNumber);
            var bill = DbScoped.SugarScope.Queryable<BillsMonth>().AS(tableName).Where(x=>x.SerialNumber== serialNumber).ToList();
            return Ok(bill);
        }

        /// <summary>
        /// 根据时间过滤数据
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        [HttpGet(Name = "QueryByTime")]
        public ActionResult QueryByTime(DateTime startTime,DateTime endTime)
        {
            ////结合Where
            // var list = db.Queryable<OrderSpliteTest>().Where(it => it.Id > 0).SplitTable(beginDate, endDate).ToPageList(1, 2);
            // 条件尽可能写在 SplitTable 前面，因为这样会先过滤在合并
            var bill = DbScoped.SugarScope.Queryable<BillsMonth>().SplitTable(startTime, endTime).OrderBy(x=>x.CreateTime).ToList();
            return Ok(bill);
        }

        /// <summary>
        /// 根据流水号获取时间戳
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <returns></returns>

        private string GetTableBySN(string serialNumber)
        {
            var splitArr = serialNumber.Split(';');
            if(splitArr.Length > 1) {
                var dtSpan = long.Parse(splitArr[1]);
                var dtActual = DateTime.FromFileTimeUtc(dtSpan);
                // 下方两种方式都可以
                var dtTableName = DbScoped.SugarScope.SplitHelper<BillsMonth>().GetTableName(dtActual);
                //var dtTableName = typeof(BillsMonth).Name + "_" + dtActual.Date.AddDays(1 - dtActual.Day).ToString("yyyyMMdd");
                return dtTableName;
            }

            return "";
        }
    }
}