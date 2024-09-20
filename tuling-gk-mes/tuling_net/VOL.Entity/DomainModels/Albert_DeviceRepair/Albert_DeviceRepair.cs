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
    [Entity(TableCnName = "设备维修",TableName = "Albert_DeviceRepair")]
    public partial class Albert_DeviceRepair:BaseEntity
    {
        /// <summary>
       ///维修主键
       /// </summary>
       [Key]
       [Display(Name ="维修主键")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int RepairPkInt { get; set; }

       /// <summary>
       ///维修编码
       /// </summary>
       [Display(Name ="维修编码")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string RepairCode { get; set; }

       /// <summary>
       ///维修名称
       /// </summary>
       [Display(Name ="维修名称")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string RepairName { get; set; }

       /// <summary>
       ///维修开始时间
       /// </summary>
       [Display(Name ="维修开始时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? RepairStartDate { get; set; }

       /// <summary>
       ///维修结束时间
       /// </summary>
       [Display(Name ="维修结束时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? RepairEndDate { get; set; }

       /// <summary>
       ///维修人员
       /// </summary>
       [Display(Name ="维修人员")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string RepairCycleType { get; set; }

       /// <summary>
       ///维修状态
       /// </summary>
       [Display(Name ="维修状态")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string RepairStatus { get; set; }

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