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
                    // ע���������ͨ�� Guid �� ʱ������ɵ�Ψһ ID,�´ξͿ���ֱ��ͨ����������λ������ı���
                    SerialNumber = Guid.NewGuid().ToString()+ ";"+ dtActual.ToFileTimeUtc().ToString(),
                    PayMoney = i * (new Random().Next(1, 100)),
                    BillsInfo = $"���������Ϣ--{i}",
                    BillComment = $"������㱸ע--{i}",
                    MachineSerialNo = Guid.NewGuid().ToString(),
                    CreateTime = dtActual,
                };

                bilisMonthList.Add(bill);
            }

            // ����Ҫ�� SplitTable������ѩ�� ID ���Զ���ֵ ID
            var snowFlake =  DbScoped.SugarScope.Insertable(bilisMonthList).SplitTable().ExecuteReturnSnowflakeIdList();

            return Ok(snowFlake);
        }

        /// <summary>
        /// ���� SN ��ѯ����
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
        /// ����ʱ���������
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        [HttpGet(Name = "QueryByTime")]
        public ActionResult QueryByTime(DateTime startTime,DateTime endTime)
        {
            ////���Where
            // var list = db.Queryable<OrderSpliteTest>().Where(it => it.Id > 0).SplitTable(beginDate, endDate).ToPageList(1, 2);
            // ����������д�� SplitTable ǰ�棬��Ϊ�������ȹ����ںϲ�
            var bill = DbScoped.SugarScope.Queryable<BillsMonth>().SplitTable(startTime, endTime).OrderBy(x=>x.CreateTime).ToList();
            return Ok(bill);
        }

        /// <summary>
        /// ������ˮ�Ż�ȡʱ���
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <returns></returns>

        private string GetTableBySN(string serialNumber)
        {
            var splitArr = serialNumber.Split(';');
            if(splitArr.Length > 1) {
                var dtSpan = long.Parse(splitArr[1]);
                var dtActual = DateTime.FromFileTimeUtc(dtSpan);
                // �·����ַ�ʽ������
                var dtTableName = DbScoped.SugarScope.SplitHelper<BillsMonth>().GetTableName(dtActual);
                //var dtTableName = typeof(BillsMonth).Name + "_" + dtActual.Date.AddDays(1 - dtActual.Day).ToString("yyyyMMdd");
                return dtTableName;
            }

            return "";
        }
    }
}