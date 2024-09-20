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
    [Entity(TableCnName = "能耗实时采集",TableName = "Albert_EmEnergyRealQuery")]
    public partial class Albert_EmEnergyRealQuery:BaseEntity
    {
        /// <summary>
       ///能耗实时采集主键
       /// </summary>
       [Key]
       [Display(Name ="能耗实时采集主键")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int EmEnergyRealQueryPkInt { get; set; }

       /// <summary>
       ///能耗管理主键
       /// </summary>
       [Display(Name ="能耗管理主键")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? EmEnergyManangerPkInt { get; set; }

       /// <summary>
       ///能控名称
       /// </summary>
       [Display(Name ="能控名称")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string Name { get; set; }

       /// <summary>
       ///电表/气表
       /// </summary>
       [Display(Name ="电表/气表")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string ElectricOrGas { get; set; }

       /// <summary>
       ///实际消耗值
       /// </summary>
       [Display(Name ="实际消耗值")]
       [DisplayFormat(DataFormatString="24,6")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? ActualValue { get; set; }

       /// <summary>
       ///实际采集时间
       /// </summary>
       [Display(Name ="实际采集时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? ActualTime { get; set; }

       
    }
}