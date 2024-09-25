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
    [Entity(TableCnName = "报警记录查询",TableName = "Albert_Alarm")]
    public partial class Albert_Alarm:BaseEntity
    {
        /// <summary>
       ///报警主键
       /// </summary>
       [Key]
       [Display(Name ="报警主键")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int AlarmPkInt { get; set; }

       /// <summary>
       ///设备主键
       /// </summary>
       [Display(Name ="设备主键")]
       [Column(TypeName="int")]
       public int? DevicePkInt { get; set; }

       /// <summary>
       ///设备编码
       /// </summary>
       [Display(Name ="设备编码")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       public string DeviceCode { get; set; }

       /// <summary>
       ///设备名称
       /// </summary>
       [Display(Name ="设备名称")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       public string DeviceName { get; set; }

       /// <summary>
       ///报警类型
       /// </summary>
       [Display(Name ="报警类型")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       public string AlarmType { get; set; }

       /// <summary>
       ///报警开始时间
       /// </summary>
       [Display(Name ="报警开始时间")]
       [Column(TypeName="datetime")]
       public DateTime? AlarmStartTime { get; set; }

       /// <summary>
       ///报警结束时间
       /// </summary>
       [Display(Name ="报警结束时间")]
       [Column(TypeName="datetime")]
       public DateTime? AlarmEndTime { get; set; }

       /// <summary>
       ///报警备注
       /// </summary>
       [Display(Name ="报警备注")]
       [MaxLength(255)]
       [Column(TypeName="nvarchar(255)")]
       public string AlarmNote { get; set; }

       /// <summary>
       ///报警消除
       /// </summary>
       [Display(Name ="报警消除")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       [Editable(true)]
       public string AlarmStatus { get; set; }

       
    }
}