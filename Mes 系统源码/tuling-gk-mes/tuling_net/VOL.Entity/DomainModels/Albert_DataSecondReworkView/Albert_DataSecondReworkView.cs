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
    [Entity(TableCnName = "环形2线返工配置",TableName = "Albert_DataSecondReworkView")]
    public partial class Albert_DataSecondReworkView:BaseEntity
    {
        /// <summary>
       ///环形2线返工主键
       /// </summary>
       [Key]
       [Display(Name ="环形2线返工主键")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int DataSecondReworkPkInt { get; set; }

       /// <summary>
       ///下线标签码
       /// </summary>
       [Display(Name ="下线标签码")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string ProductCode { get; set; }

       /// <summary>
       ///最终结果
       /// </summary>
       [Display(Name ="最终结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       [Editable(true)]
       public string OpFinalResult { get; set; }

       /// <summary>
       ///最终站
       /// </summary>
       [Display(Name ="最终站")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       [Editable(true)]
       public string OpFinalStation { get; set; }

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