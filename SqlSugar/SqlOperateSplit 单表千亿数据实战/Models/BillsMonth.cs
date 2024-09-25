using SqlSugar;

namespace Albert.SqlOperateSplitDemo.Models
{

    [SplitTable(SplitType.Month)]//按年分表 （自带分表支持 年、季、月、周、日）
    [SugarTable("BillsMonth_{year}{month}{day}")]//3个变量必须要有，这么设计为了兼容开始按年，后面改成按月、按日
    // 创建唯一索引--SerialNumber
    [SugarIndex("unique_BillsMonth_SerialNumber", nameof(BillsMonth.SerialNumber), OrderByType.Desc, true)]
    [SugarIndex("index_BillsMonth_CreateTime", nameof(BillsMonth.CreateTime), OrderByType.Asc)]
    public class BillsMonth
    {
        // 内部自带雪花 ID 实现
        [SugarColumn(IsPrimaryKey = true)]
        public long Id { get; set; }
        public string SerialNumber { get; set; }
        public decimal PayMoney { get; set; }
        public string BillsInfo { get; set; }
        public DateTime BillDate { get; set; }
        [SugarColumn(IsNullable = true)]//设置为可空字段
        public string BillComment { get; set; }
        public string MachineSerialNo { get; set; }
        [SplitField] //分表字段 在插入的时候会根据这个字段插入哪个表，在更新删除的时候用这个字段找出相关表
        // 需要创建普通索引，用于范围查询

        public DateTime CreateTime { get; set; }
    }
}
