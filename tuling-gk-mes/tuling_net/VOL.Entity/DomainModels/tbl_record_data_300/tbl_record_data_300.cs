/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果数据库字段发生变化，请在代码生器重新生成此Model
 */
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SqlSugar;
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels
{
    [Entity(TableCnName = "Op300高品数据",TableName = "tbl_record_data")]
    public partial class tbl_record_data_300:BaseEntity
    {
        /// <summary>
       ///序号
       /// </summary>
       [Key]
       [Display(Name ="序号")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int ID { get; set; }

       /// <summary>
       ///GUID
       /// </summary>
       [Display(Name ="GUID")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string GUID { get; set; }

       /// <summary>
       ///开始时间
       /// </summary>
       [Display(Name ="开始时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? StartTime { get; set; }

       /// <summary>
       ///工站
       /// </summary>
       [Display(Name ="工站")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string Station { get; set; }

       /// <summary>
       ///操作员
       /// </summary>
       [Display(Name ="操作员")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string Operator { get; set; }

       /// <summary>
       ///批次号
       /// </summary>
       [Display(Name ="批次号")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string BatchNO { get; set; }

       /// <summary>
       ///产品条码
       /// </summary>
       [Display(Name ="产品条码")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string Barcode { get; set; }

       /// <summary>
       ///产品型号
       /// </summary>
       [Display(Name = "产品型号")]
       [MaxLength(50)]
       [Column(TypeName = "nvarchar(50)")]
       [Editable(true)]
       [SugarColumn(ColumnName = "Product Model")]
       public string ProductModel { get; set; }

       /// <summary>
       ///生产类型（正常件，master等）
       /// </summary>
       [Display(Name = "生产类型（正常件，master等）")]
       [MaxLength(50)]
       [Column(TypeName = "nvarchar(50)")]
       [Editable(true)]
       [SugarColumn(ColumnName = "Product Type")]
       public string ProductType { get; set; }

       /// <summary>
       ///NG原因
       /// </summary>
       [Display(Name = "NG原因")]
       [MaxLength(255)]
       [Column(TypeName = "nvarchar(255)")]
       [Editable(true)]
       [SugarColumn(ColumnName = "NG Classification")]
       public string NGClassification { get; set; }

        /// <summary>
        ///是否返工
        /// </summary>
        [Display(Name ="是否返工")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       [Editable(true)]
       public string IsRework { get; set; }

       /// <summary>
       ///是否重新测试
       /// </summary>
       [Display(Name ="是否重新测试")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       [Editable(true)]
       public string IsRetest { get; set; }

       /// <summary>
       ///内漏_小球1口进气压力
       /// </summary>
       [Display(Name ="内漏_小球1口进气压力")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       [Editable(true)]
       public string 内漏_小球1口进气压力 { get; set; }

       /// <summary>
       ///内漏_小球1口泄露值
       /// </summary>
       [Display(Name ="内漏_小球1口泄露值")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       [Editable(true)]
       public string 内漏_小球1口泄露值 { get; set; }

       /// <summary>
       ///内漏_小球5口进气压力
       /// </summary>
       [Display(Name ="内漏_小球5口进气压力")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       [Editable(true)]
       public string 内漏_小球5口进气压力 { get; set; }

       /// <summary>
       ///内漏_小球5口泄露值
       /// </summary>
       [Display(Name ="内漏_小球5口泄露值")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       [Editable(true)]
       public string 内漏_小球5口泄露值 { get; set; }

       /// <summary>
       ///开启_小球1口进气压力
       /// </summary>
       [Display(Name ="开启_小球1口进气压力")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       [Editable(true)]
       public string 开启_小球1口进气压力 { get; set; }

       /// <summary>
       ///开启_小球开启步数1
       /// </summary>
       [Display(Name ="开启_小球开启步数1")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       [Editable(true)]
       public string 开启_小球开启步数1 { get; set; }

       /// <summary>
       ///开启_小球开启电流1
       /// </summary>
       [Display(Name ="开启_小球开启电流1")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       [Editable(true)]
       public string 开启_小球开启电流1 { get; set; }

       /// <summary>
       ///开启_小球关闭步数1
       /// </summary>
       [Display(Name ="开启_小球关闭步数1")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       [Editable(true)]
       public string 开启_小球关闭步数1 { get; set; }

       /// <summary>
       ///开启_小球5口进气压力
       /// </summary>
       [Display(Name ="开启_小球5口进气压力")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       [Editable(true)]
       public string 开启_小球5口进气压力 { get; set; }

       /// <summary>
       ///开启_小球开启步数2
       /// </summary>
       [Display(Name ="开启_小球开启步数2")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       [Editable(true)]
       public string 开启_小球开启步数2 { get; set; }

       /// <summary>
       ///开启_小球开启电流2
       /// </summary>
       [Display(Name ="开启_小球开启电流2")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       [Editable(true)]
       public string 开启_小球开启电流2 { get; set; }

       /// <summary>
       ///开启_小球关闭步数2
       /// </summary>
       [Display(Name ="开启_小球关闭步数2")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       [Editable(true)]
       public string 开启_小球关闭步数2 { get; set; }

       /// <summary>
       ///流量_小球offset
       /// </summary>
       [Display(Name ="流量_小球offset")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       [Editable(true)]
       public string 流量_小球offset { get; set; }

       /// <summary>
       ///流量_小球进气压力
       /// </summary>
       [Display(Name ="流量_小球进气压力")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       [Editable(true)]
       public string 流量_小球进气压力 { get; set; }

       /// <summary>
       ///流量_小球流量值
       /// </summary>
       [Display(Name ="流量_小球流量值")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       [Editable(true)]
       public string 流量_小球流量值 { get; set; }

       /// <summary>
       ///总结果
       /// </summary>
       [Display(Name ="总结果")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       [Editable(true)]
       public string TotalResult { get; set; }

       
    }
}