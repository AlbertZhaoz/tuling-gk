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
    [Entity(TableCnName = "出库单列表",TableName = "Albert_InboundOrderOuterList")]
    public partial class Albert_InboundOrderOuterList:BaseEntity
    {
        /// <summary>
       ///出库单列表主键
       /// </summary>
       [Key]
       [Display(Name ="出库单列表主键")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int InboundOrderOuterListPkInt { get; set; }

       /// <summary>
       ///出库单主键
       /// </summary>
       [Display(Name ="出库单主键")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int InboundOrderOuterPkInt { get; set; }

       /// <summary>
       ///产品编码
       /// </summary>
       [Display(Name ="产品编码")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string InboundOrderOuterProduceCode { get; set; }

       /// <summary>
       ///产品名称
       /// </summary>
       [Display(Name ="产品名称")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string InboundOrderOuterProduceName { get; set; }

       /// <summary>
       ///产品规格
       /// </summary>
       [Display(Name ="产品规格")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string InboundOrderOuterProduceStandard { get; set; }

       /// <summary>
       ///库存单位
       /// </summary>
       [Display(Name ="库存单位")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string InboundOrderOuterUnitId { get; set; }

       /// <summary>
       ///最大库存
       /// </summary>
       [Display(Name ="最大库存")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? InboundOrderOuterMaxStock { get; set; }

       /// <summary>
       ///最小库存
       /// </summary>
       [Display(Name ="最小库存")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? InboundOrderOuterMinStock { get; set; }

       /// <summary>
       ///安全库存
       /// </summary>
       [Display(Name ="安全库存")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? InboundOrderOuterSafeStock { get; set; }

       /// <summary>
       ///当前库存
       /// </summary>
       [Display(Name ="当前库存")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? InboundOrderOuterCurrentStock { get; set; }

       /// <summary>
       ///当前入库数量
       /// </summary>
       [Display(Name ="当前入库数量")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? InboundOrderOuterCurrentQty { get; set; }

       /// <summary>
       ///总入库数量
       /// </summary>
       [Display(Name ="总入库数量")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? InboundOrderOuterTotalQty { get; set; }

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