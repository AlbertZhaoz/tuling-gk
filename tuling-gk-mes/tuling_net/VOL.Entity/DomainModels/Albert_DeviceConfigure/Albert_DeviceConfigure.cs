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
    [Entity(TableCnName = "设备台账",TableName = "Albert_DeviceConfigure")]
    public partial class Albert_DeviceConfigure:BaseEntity
    {
        /// <summary>
       ///设备主键
       /// </summary>
       [Key]
       [Display(Name ="设备主键")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int DevicePkInt { get; set; }

       /// <summary>
       ///设备排序
       /// </summary>
       [Display(Name ="设备排序")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int DeviceSort { get; set; }

       /// <summary>
       ///设备编码
       /// </summary>
       [Display(Name ="设备编码")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string DeviceCode { get; set; }

       /// <summary>
       ///设备名称
       /// </summary>
       [Display(Name ="设备名称")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string DeviceName { get; set; }

       /// <summary>
       ///设备别名
       /// </summary>
       [Display(Name ="设备别名")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string DeivceSubname { get; set; }

       /// <summary>
       ///设备启用(Y/N)
       /// </summary>
       [Display(Name ="设备启用(Y/N)")]
       [MaxLength(1)]
       [Column(TypeName="nvarchar(1)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string DeviceIsUse { get; set; }

       /// <summary>
       ///通讯地址
       /// </summary>
       [Display(Name ="通讯地址")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string CommunicationAddress { get; set; }

       /// <summary>
       ///通讯端口
       /// </summary>
       [Display(Name ="通讯端口")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? CommunicationPort { get; set; }

       /// <summary>
       ///通讯超时时间
       /// </summary>
       [Display(Name ="通讯超时时间")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? CommunicationOvertime { get; set; }

       /// <summary>
       ///设备类型
       /// </summary>
       [Display(Name ="设备类型")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string DeviceType { get; set; }

       /// <summary>
       ///设备状态
       /// </summary>
       [Display(Name ="设备状态")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       public string DeviceStatus { get; set; }

       /// <summary>
       ///设备心跳
       /// </summary>
       [Display(Name ="设备心跳")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string DeviceHeartBeat { get; set; }

       /// <summary>
       ///设备备注
       /// </summary>
       [Display(Name ="设备备注")]
       [MaxLength(255)]
       [Column(TypeName="nvarchar(255)")]
       [Editable(true)]
       public string DeivceRemark { get; set; }

       /// <summary>
       ///所属车间
       /// </summary>
       [Display(Name ="所属车间")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string Workshop { get; set; }

       /// <summary>
       ///品牌
       /// </summary>
       [Display(Name ="品牌")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string Brand { get; set; }

       /// <summary>
       ///设备开始运行时间
       /// </summary>
       [Display(Name ="设备开始运行时间")]
       [Column(TypeName="datetime")]
       public DateTime? DeviceStartTime { get; set; }

       /// <summary>
       ///设备结束运行时间
       /// </summary>
       [Display(Name ="设备结束运行时间")]
       [Column(TypeName="datetime")]
       public DateTime? DeviceEndTime { get; set; }

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