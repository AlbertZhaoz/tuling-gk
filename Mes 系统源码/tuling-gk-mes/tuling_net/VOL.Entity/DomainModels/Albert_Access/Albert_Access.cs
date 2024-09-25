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
    [Entity(TableCnName = "门禁记录查询",TableName = "Albert_Access")]
    public partial class Albert_Access:BaseEntity
    {
        /// <summary>
       ///门禁主键
       /// </summary>
       [Key]
       [Display(Name ="门禁主键")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int AccessPkInt { get; set; }

       /// <summary>
       ///人员卡号
       /// </summary>
       [Display(Name ="人员卡号")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string PersonCard { get; set; }

       /// <summary>
       ///人员部门
       /// </summary>
       [Display(Name ="人员部门")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string PersonDepartment { get; set; }

       /// <summary>
       ///人员姓名
       /// </summary>
       [Display(Name ="人员姓名")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       [Editable(true)]
       public string PersonName { get; set; }

       /// <summary>
       ///刷卡时间
       /// </summary>
       [Display(Name ="刷卡时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? AccessTime { get; set; }

       /// <summary>
       ///刷卡状态
       /// </summary>
       [Display(Name ="刷卡状态")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string AccessStatus { get; set; }

       /// <summary>
       ///刷卡机器编号
       /// </summary>
       [Display(Name ="刷卡机器编号")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string AccessMachineNumber { get; set; }

       
    }
}