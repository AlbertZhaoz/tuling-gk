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
using VOL.Entity.SystemModels;

namespace VOL.Entity.DomainModels
{
    [Entity(TableCnName = "能耗小时记录",TableName = "Albert_EmEnergyQuery")]
    public partial class Albert_EmEnergyQuery:BaseEntity
    {
        /// <summary>
       ///能耗小时记录主键
       /// </summary>
       [Key]
       [Display(Name ="能耗小时记录主键")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int EmEnergyQueryPkInt { get; set; }

       /// <summary>
       ///能耗管理主键
       /// </summary>
       [Display(Name ="能耗管理主键")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? EmEnergyManangerPkInt { get; set; }

       /// <summary>
       ///时间段
       /// </summary>
       [Display(Name ="时间段")]
       [MaxLength(99)]
       [Column(TypeName="nvarchar(99)")]
       [Editable(true)]
       public string TimePeriod { get; set; }

       /// <summary>
       ///小时最大值
       /// </summary>
       [Display(Name ="小时最大值")]
       [DisplayFormat(DataFormatString="24,6")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? MaxValue { get; set; }

       /// <summary>
       ///小时最小值
       /// </summary>
       [Display(Name ="小时最小值")]
       [DisplayFormat(DataFormatString="24,6")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? MinValue { get; set; }

       /// <summary>
       ///小时平均值
       /// </summary>
       [Display(Name ="小时平均值")]
       [DisplayFormat(DataFormatString="24,6")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? AverageValue { get; set; }

       
    }
}