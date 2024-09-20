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
    [Entity(TableCnName = "车间管理",TableName = "Albert_BasicWorkshop")]
    public partial class Albert_BasicWorkshop:BaseEntity
    {
        /// <summary>
       ///车间主键
       /// </summary>
       [Key]
       [Display(Name ="车间主键")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int BasicWorkshopPkInt { get; set; }

       /// <summary>
       ///车间编码
       /// </summary>
       [Display(Name ="车间编码")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string BasicWorkshopCode { get; set; }

       /// <summary>
       ///车间名称
       /// </summary>
       [Display(Name ="车间名称")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string BasicWorkshopName { get; set; }

       /// <summary>
       ///人员管理主键
       /// </summary>
       [Display(Name ="人员管理主键")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? PersonManagerPkInt { get; set; }

       /// <summary>
       ///车间负责人
       /// </summary>
       [Display(Name ="车间负责人")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string BasicWorkshopPrincipal { get; set; }

       /// <summary>
       ///车间是否启用
       /// </summary>
       [Display(Name ="车间是否启用")]
       [MaxLength(1)]
       [Column(TypeName="nvarchar(1)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string BasicWorkshopIsUse { get; set; }

       /// <summary>
       ///车间面积(m2)
       /// </summary>
       [Display(Name ="车间面积(m2)")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? BasicWorkshopArea { get; set; }

       /// <summary>
       ///车间备注
       /// </summary>
       [Display(Name ="车间备注")]
       [MaxLength(900)]
       [Column(TypeName="nvarchar(900)")]
       [Editable(true)]
       public string BasicWorkshopRemark { get; set; }

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