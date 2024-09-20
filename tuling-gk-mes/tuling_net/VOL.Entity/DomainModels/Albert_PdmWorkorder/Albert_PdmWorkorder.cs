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
    [Entity(TableCnName = "工单管理",TableName = "Albert_PdmWorkorder")]
    public partial class Albert_PdmWorkorder:BaseEntity
    {
        /// <summary>
       ///工单编码
       /// </summary>
       [Display(Name ="工单编码")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string WorkorderCode { get; set; }

       /// <summary>
       ///工单主键
       /// </summary>
       [Key]
       [Display(Name ="工单主键")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int WorkorderPkInt { get; set; }

       /// <summary>
       ///产品主键
       /// </summary>
       [Display(Name ="产品主键")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int ProductPkInt { get; set; }

       /// <summary>
       ///产品编码
       /// </summary>
       [Display(Name ="产品编码")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string ProductCode { get; set; }

       /// <summary>
       ///产品名称
       /// </summary>
       [Display(Name ="产品名称")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string ProductName { get; set; }

       /// <summary>
       ///产品当前库存
       /// </summary>
       [Display(Name ="产品当前库存")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? ProductCurStock { get; set; }

       /// <summary>
       ///工单状态
       /// </summary>
       [Display(Name ="工单状态")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string WorkorderStatus { get; set; }

       /// <summary>
       ///工单负责人
       /// </summary>
       [Display(Name ="工单负责人")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string WorkorderPrinciple { get; set; }

       /// <summary>
       ///工单进度(%)
       /// </summary>
       [Display(Name ="工单进度(%)")]
       [Column(TypeName="int")]
       public int? WorkorderSchedule { get; set; }

       /// <summary>
       ///工单良品
       /// </summary>
       [Display(Name ="工单良品")]
       [Column(TypeName="int")]
       public int? WorkorderOK { get; set; }

       /// <summary>
       ///工单不良品
       /// </summary>
       [Display(Name ="工单不良品")]
       [Column(TypeName="int")]
       public int? WorkorderNG { get; set; }

       /// <summary>
       ///工单合格率(%)
       /// </summary>
       [Display(Name ="工单合格率(%)")]
       [Column(TypeName="int")]
       public int? WorkorderPassRate { get; set; }

       /// <summary>
       ///工单计划产量
       /// </summary>
       [Display(Name ="工单计划产量")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? WorkorderPlan { get; set; }

       /// <summary>
       ///工单计划开始时间
       /// </summary>
       [Display(Name ="工单计划开始时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? WorkorderPlanStartDate { get; set; }

       /// <summary>
       ///工单计划结束时间
       /// </summary>
       [Display(Name ="工单计划结束时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? WorkorderPlanEndDate { get; set; }

       /// <summary>
       ///工单实际产量
       /// </summary>
       [Display(Name ="工单实际产量")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? WorkorderActual { get; set; }

       /// <summary>
       ///工单实际开始时间
       /// </summary>
       [Display(Name ="工单实际开始时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? WorkorderActualStartDate { get; set; }

       /// <summary>
       ///工单实际结束时间
       /// </summary>
       [Display(Name ="工单实际结束时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? WorkorderActualEndDate { get; set; }

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