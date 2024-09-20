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
    [Entity(TableCnName = "设备工站",TableName = "Albert_DeviceStationConfigure")]
    public partial class Albert_DeviceStationConfigure:BaseEntity
    {
        /// <summary>
       ///工站主键
       /// </summary>
       [Key]
       [Display(Name ="工站主键")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int DeviceDBPkInt { get; set; }

       /// <summary>
       ///设备主键
       /// </summary>
       [Display(Name ="设备主键")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int DevicePkInt { get; set; }

       /// <summary>
       ///工站排序
       /// </summary>
       [Display(Name ="工站排序")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int DeviceDBSort { get; set; }

       /// <summary>
       ///工站名称
       /// </summary>
       [Display(Name ="工站名称")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string DeviceDBName { get; set; }

       /// <summary>
       ///工站别名
       /// </summary>
       [Display(Name ="工站别名")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string DeviceDBSubname { get; set; }

       /// <summary>
       ///工站启用(Y/N)
       /// </summary>
       [Display(Name ="工站启用(Y/N)")]
       [MaxLength(1)]
       [Column(TypeName="nvarchar(1)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string DeviceDBIsUse { get; set; }

       /// <summary>
       ///工站状态
       /// </summary>
       [Display(Name ="工站状态")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string DeviceDBStatus { get; set; }

       /// <summary>
       ///工站备注
       /// </summary>
       [Display(Name ="工站备注")]
       [MaxLength(255)]
       [Column(TypeName="nvarchar(255)")]
       [Editable(true)]
       public string DeviceDBRemark { get; set; }

       /// <summary>
       ///工站开始运行时间
       /// </summary>
       [Display(Name ="工站开始运行时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? DeviceDBStartTime { get; set; }

       /// <summary>
       ///工站结束运行时间
       /// </summary>
       [Display(Name ="工站结束运行时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? DeviceDBEndTime { get; set; }

       /// <summary>
       ///创建ID
       /// </summary>
       [Display(Name ="创建ID")]
       [Column(TypeName="int")]
       public int? CreateID { get; set; }

       /// <summary>
       ///创建人
       /// </summary>
       [Display(Name ="创建人")]
       [MaxLength(30)]
       [Column(TypeName="nvarchar(30)")]
       public string Creator { get; set; }

       /// <summary>
       ///创建时间
       /// </summary>
       [Display(Name ="创建时间")]
       [Column(TypeName="datetime")]
       [Required(AllowEmptyStrings=false)]
       public DateTime CreateDate { get; set; }

       /// <summary>
       ///修改ID
       /// </summary>
       [Display(Name ="修改ID")]
       [Column(TypeName="int")]
       public int? ModifyID { get; set; }

       /// <summary>
       ///修改人
       /// </summary>
       [Display(Name ="修改人")]
       [MaxLength(30)]
       [Column(TypeName="nvarchar(30)")]
       public string Modifier { get; set; }

       /// <summary>
       ///修改时间
       /// </summary>
       [Display(Name ="修改时间")]
       [Column(TypeName="datetime")]
       [Required(AllowEmptyStrings=false)]
       public DateTime ModifyDate { get; set; }

       
    }
}