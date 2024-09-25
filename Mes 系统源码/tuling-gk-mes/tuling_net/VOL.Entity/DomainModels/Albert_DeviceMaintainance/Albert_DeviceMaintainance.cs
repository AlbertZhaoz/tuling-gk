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
    [Entity(TableCnName = "设备保养",TableName = "Albert_DeviceMaintainance")]
    public partial class Albert_DeviceMaintainance:BaseEntity
    {
        /// <summary>
       ///保养主键
       /// </summary>
       [Key]
       [Display(Name ="保养主键")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int MaintainancePkInt { get; set; }

       /// <summary>
       ///保养编码
       /// </summary>
       [Display(Name ="保养编码")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string MaintainanceCode { get; set; }

       /// <summary>
       ///保养名称
       /// </summary>
       [Display(Name ="保养名称")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string MaintainanceName { get; set; }

       /// <summary>
       ///保养开始时间
       /// </summary>
       [Display(Name ="保养开始时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? MaintainanceStartDate { get; set; }

       /// <summary>
       ///保养结束时间
       /// </summary>
       [Display(Name ="保养结束时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? MaintainanceEndDate { get; set; }

       /// <summary>
       ///保养周期类型
       /// </summary>
       [Display(Name ="保养周期类型")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string MaintainanceCycleType { get; set; }

       /// <summary>
       ///保养周期时间
       /// </summary>
       [Display(Name ="保养周期时间")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? MaintainanceCycleCount { get; set; }

       /// <summary>
       ///保养状态
       /// </summary>
       [Display(Name ="保养状态")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string MaintainanceStatus { get; set; }

       /// <summary>
       ///创建ID
       /// </summary>
       [Display(Name ="创建ID")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? CreateID { get; set; }

       /// <summary>
       ///创建人
       /// </summary>
       [Display(Name ="创建人")]
       [MaxLength(30)]
       [Column(TypeName="nvarchar(30)")]
       [Editable(true)]
       public string Creator { get; set; }

       /// <summary>
       ///创建时间
       /// </summary>
       [Display(Name ="创建时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public DateTime CreateDate { get; set; }

       /// <summary>
       ///修改ID
       /// </summary>
       [Display(Name ="修改ID")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? ModifyID { get; set; }

       /// <summary>
       ///修改人
       /// </summary>
       [Display(Name ="修改人")]
       [MaxLength(30)]
       [Column(TypeName="nvarchar(30)")]
       [Editable(true)]
       public string Modifier { get; set; }

       /// <summary>
       ///修改时间
       /// </summary>
       [Display(Name ="修改时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public DateTime ModifyDate { get; set; }

       
    }
}