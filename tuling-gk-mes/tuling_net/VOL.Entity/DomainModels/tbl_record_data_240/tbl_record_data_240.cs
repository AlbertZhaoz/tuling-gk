/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果数据库字段发生变化，请在代码生器重新生成此Model
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels
{
    [Entity(TableCnName = "Op240高品数据",TableName = "tbl_record_data")]
    [Table("tbl_record_data")]
    public partial class tbl_record_data_240:BaseEntity
    {
        /// <summary>
       ///序号
       /// </summary>
       [Key]
       [Display(Name ="序号")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int ID { get; set; }

       /// <summary>
       ///GUID
       /// </summary>
       [Display(Name ="GUID")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string GUID { get; set; }

       /// <summary>
       ///开始时间
       /// </summary>
       [Display(Name ="开始时间")]
       [Column(TypeName="datetime")]
       public DateTime? StartTime { get; set; }

       /// <summary>
       ///工站
       /// </summary>
       [Display(Name ="工站")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string Station { get; set; }

       /// <summary>
       ///操作员
       /// </summary>
       [Display(Name ="操作员")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string Operator { get; set; }

       /// <summary>
       ///批次号
       /// </summary>
       [Display(Name ="批次号")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string BatchNO { get; set; }

       /// <summary>
       ///产品条码
       /// </summary>
       [Display(Name ="产品条码")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string Barcode { get; set; }

       /// <summary>
       ///产品型号
       /// </summary>
       [Display(Name ="产品型号")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [SugarColumn(ColumnName = "Product Model")]
       public string ProductModel { get; set; }

       /// <summary>
       ///生产类型（正常件，master等）
       /// </summary>
       [Display(Name ="生产类型（正常件，master等）")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [SugarColumn(ColumnName = "Product Type")]
        public string ProductType { get; set; }

       /// <summary>
       ///NG原因
       /// </summary>
       [Display(Name ="NG原因")]
       [MaxLength(255)]
       [Column(TypeName="nvarchar(255)")]
       [SugarColumn(ColumnName = "NG Classification")]
        public string NGClassification { get; set; }

       /// <summary>
       ///是否返工
       /// </summary>
       [Display(Name ="是否返工")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       public string IsRework { get; set; }

       /// <summary>
       ///是否重测试
       /// </summary>
       [Display(Name ="是否重测试")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       public string IsRetest { get; set; }

       /// <summary>
       ///小球进口压力均值1
       /// </summary>
       [Display(Name ="小球进口压力均值1")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       public string 小球进口压力均值1 { get; set; }

       /// <summary>
       ///小球开启扭矩峰值1
       /// </summary>
       [Display(Name ="小球开启扭矩峰值1")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       public string 小球开启扭矩峰值1 { get; set; }

       /// <summary>
       ///小球进口压力均值2
       /// </summary>
       [Display(Name ="小球进口压力均值2")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       public string 小球进口压力均值2 { get; set; }

       /// <summary>
       ///小球开启扭矩峰值2
       /// </summary>
       [Display(Name ="小球开启扭矩峰值2")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       public string 小球开启扭矩峰值2 { get; set; }

       /// <summary>
       ///总结果
       /// </summary>
       [Display(Name ="总结果")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       public string TotalResult { get; set; }

       
    }
}