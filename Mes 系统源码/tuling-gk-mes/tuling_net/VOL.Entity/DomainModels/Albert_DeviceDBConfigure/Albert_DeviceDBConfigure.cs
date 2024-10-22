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
    [Entity(TableCnName = "设备地址块",TableName = "Albert_DeviceDBConfigure")]
    public partial class Albert_DeviceDBConfigure:BaseEntity
    {
        /// <summary>
       ///地址块主键
       /// </summary>
       [Key]
       [Display(Name ="地址块主键")]
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
       ///地址块排序
       /// </summary>
       [Display(Name ="地址块排序")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int DeviceDBSort { get; set; }

       /// <summary>
       ///地址块名称
       /// </summary>
       [Display(Name ="地址块名称")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string DeviceDBName { get; set; }

       /// <summary>
       ///地址块别名
       /// </summary>
       [Display(Name ="地址块别名")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string DeviceDBSubname { get; set; }

       /// <summary>
       ///地址块启用(Y/N)
       /// </summary>
       [Display(Name ="地址块启用(Y/N)")]
       [MaxLength(1)]
       [Column(TypeName="nvarchar(1)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string DeviceDBIsUse { get; set; }

       /// <summary>
       ///地址块状态
       /// </summary>
       [Display(Name ="地址块状态")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string DeviceDBStatus { get; set; }

       /// <summary>
       ///地址块备注
       /// </summary>
       [Display(Name ="地址块备注")]
       [MaxLength(255)]
       [Column(TypeName="nvarchar(255)")]
       public string DeviceDBRemark { get; set; }

       /// <summary>
       ///地址块请求类型
       /// </summary>
       [Display(Name ="地址块请求类型")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string DeviceDBRequestType { get; set; }

       /// <summary>
       ///地址块请求间隔
       /// </summary>
       [Display(Name ="地址块请求间隔")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? DeviceDBRequestTime { get; set; }

       /// <summary>
       ///读数据地址
       /// </summary>
       [Display(Name ="读数据地址")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string DeviceDBReadAddress { get; set; }

       /// <summary>
       ///读数据类型
       /// </summary>
       [Display(Name ="读数据类型")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string DeviceDBReadType { get; set; }

       /// <summary>
       ///读数据长度
       /// </summary>
       [Display(Name ="读数据长度")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? DeviceDBReadLength { get; set; }

       /// <summary>
       ///读数据规则
       /// </summary>
       [Display(Name ="读数据规则")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string DeviceDBReadExtra { get; set; }

       /// <summary>
       ///读数据结果
       /// </summary>
       [Display(Name ="读数据结果")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string DeviceDBReadResult { get; set; }

       /// <summary>
       ///数据库启用(Y/N)
       /// </summary>
       [Display(Name ="数据库启用(Y/N)")]
       [MaxLength(1)]
       [Column(TypeName="nvarchar(1)")]
       [Editable(true)]
       public string DeviceDBSaveToDb { get; set; }

       /// <summary>
       ///数据库连接字符串
       /// </summary>
       [Display(Name ="数据库连接字符串")]
       [MaxLength(255)]
       [Column(TypeName="nvarchar(255)")]
       [Editable(true)]
       public string DeviceDBDbConnect { get; set; }

       /// <summary>
       ///数据库执行语句
       /// </summary>
       [Display(Name ="数据库执行语句")]
       [MaxLength(900)]
       [Column(TypeName="nvarchar(900)")]
       [Editable(true)]
       public string DeviceDBDbSql { get; set; }

       /// <summary>
       ///响应启用(Y/N)
       /// </summary>
       [Display(Name ="响应启用(Y/N)")]
       [MaxLength(1)]
       [Column(TypeName="nvarchar(1)")]
       [Editable(true)]
       public string DeviceDBIsResponse { get; set; }

       /// <summary>
       ///写数据地址
       /// </summary>
       [Display(Name ="写数据地址")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string DeviceDBWriteAddress { get; set; }

       /// <summary>
       ///写数据类型
       /// </summary>
       [Display(Name ="写数据类型")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string DeviceDBWriteType { get; set; }

       /// <summary>
       ///写数据长度
       /// </summary>
       [Display(Name ="写数据长度")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? DeviceDBWriteLength { get; set; }

       /// <summary>
       ///写数据规则
       /// </summary>
       [Display(Name ="写数据规则")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string DeviceDBWriteExtra { get; set; }

       /// <summary>
       ///写数据结果
       /// </summary>
       [Display(Name ="写数据结果")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string DeviceDBWriteResult { get; set; }

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

       /// <summary>
       ///地址块开始运行时间
       /// </summary>
       [Display(Name ="地址块开始运行时间")]
       [Column(TypeName="datetime")]
       public DateTime? DeviceDBStartTime { get; set; }

       /// <summary>
       ///地址块结束运行时间
       /// </summary>
       [Display(Name ="地址块结束运行时间")]
       [Column(TypeName="datetime")]
       public DateTime? DeviceDBEndTime { get; set; }

       
    }
}