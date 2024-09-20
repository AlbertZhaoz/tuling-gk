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
    [Entity(TableCnName = "设备数据类型",TableName = "Albert_DeviceDataType")]
    public partial class Albert_DeviceDataType:BaseEntity
    {
        /// <summary>
       ///设备数据类型主键
       /// </summary>
       [Key]
       [Display(Name ="设备数据类型主键")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int DeviceDataTypePkInt { get; set; }

       /// <summary>
       ///设备数据类型名字
       /// </summary>
       [Display(Name ="设备数据类型名字")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string DeviceDataTypeName { get; set; }

       /// <summary>
       ///设备数据类型启用(Y/N)
       /// </summary>
       [Display(Name ="设备数据类型启用(Y/N)")]
       [MaxLength(1)]
       [Column(TypeName="nvarchar(1)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string DeviceDataTypeIsUse { get; set; }

       /// <summary>
       ///设备数据类型备注
       /// </summary>
       [Display(Name ="设备数据类型备注")]
       [MaxLength(900)]
       [Column(TypeName="nvarchar(900)")]
       [Editable(true)]
       public string DeviceDataTypeRemark { get; set; }

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