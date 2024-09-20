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
    [Entity(TableCnName = "产品管理",TableName = "Albert_PdmProduct")]
    public partial class Albert_PdmProduct:BaseEntity
    {
        /// <summary>
       ///产品主键
       /// </summary>
       [Key]
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
       ///产品规格
       /// </summary>
       [Display(Name ="产品规格")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string ProductStandard { get; set; }

       /// <summary>
       ///库存单位
       /// </summary>
       [Display(Name ="库存单位")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string ProductUnitId { get; set; }

       /// <summary>
       ///产品最大库存
       /// </summary>
       [Display(Name ="产品最大库存")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? ProductMaxStock { get; set; }

       /// <summary>
       ///产品最小库存
       /// </summary>
       [Display(Name ="产品最小库存")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? ProductMinStock { get; set; }

       /// <summary>
       ///产品安全库存
       /// </summary>
       [Display(Name ="产品安全库存")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? ProductSafeStock { get; set; }

       /// <summary>
       ///产品当前库存
       /// </summary>
       [Display(Name ="产品当前库存")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? ProductCurStock { get; set; }

       /// <summary>
       ///工艺主键
       /// </summary>
       [Display(Name ="工艺主键")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int CraftPkInt { get; set; }

       /// <summary>
       ///工艺编码
       /// </summary>
       [Display(Name ="工艺编码")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string CraftCode { get; set; }

       /// <summary>
       ///工艺路线
       /// </summary>
       [Display(Name ="工艺路线")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string CraftName { get; set; }

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