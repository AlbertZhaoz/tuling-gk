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
    [Entity(TableCnName = "Op230氦检数据",TableName = "tbl_record_data_230")]
    public partial class tbl_record_data_230:BaseEntity
    {
        /// <summary>
       ///记录时间
       /// </summary>
       [Key]
       [Display(Name ="记录时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public DateTime 记录时间 { get; set; }

       /// <summary>
       ///检测标志
       /// </summary>
       [Display(Name ="检测标志")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string 检测标志 { get; set; }

       /// <summary>
       ///工件型号
       /// </summary>
       [Display(Name ="工件型号")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string 工件型号 { get; set; }

       /// <summary>
       ///条码
       /// </summary>
       [Display(Name ="条码")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       public string 条码 { get; set; }

       /// <summary>
       ///结果
       /// </summary>
       [Display(Name ="结果")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string 结果 { get; set; }

       /// <summary>
       ///箱号
       /// </summary>
       [Display(Name ="箱号")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string 箱号 { get; set; }

       /// <summary>
       ///箱体抽空
       /// </summary>
       [Display(Name ="箱体抽空")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string 箱体抽空 { get; set; }

       /// <summary>
       ///充氮
       /// </summary>
       [Display(Name ="充氮")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string 充氮 { get; set; }

       /// <summary>
       ///充氮时间
       /// </summary>
       [Display(Name ="充氮时间")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string 充氮检测时间 { get; set; }

       /// <summary>
       ///压降
       /// </summary>
       [Display(Name ="压降")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string 压降 { get; set; }

       /// <summary>
       ///充氦
       /// </summary>
       [Display(Name ="充氦")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string 充氦 { get; set; }

       /// <summary>
       ///充氦时间
       /// </summary>
       [Display(Name ="充氦时间")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string 充氦检测时间 { get; set; }

       /// <summary>
       ///漏率
       /// </summary>
       [Display(Name ="漏率")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string 漏率 { get; set; }

       /// <summary>
       ///报警点
       /// </summary>
       [Display(Name ="报警点")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string 报警点 { get; set; }

       /// <summary>
       ///节拍
       /// </summary>
       [Display(Name ="节拍")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string 节拍 { get; set; }

       /// <summary>
       ///氦气浓度
       /// </summary>
       [Display(Name ="氦气浓度")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string 氦气浓度 { get; set; }

       /// <summary>
       ///BG
       /// </summary>
       [Display(Name ="BG")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string BG { get; set; }

       /// <summary>
       ///SG
       /// </summary>
       [Display(Name ="SG")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string SG { get; set; }

       /// <summary>
       ///SN
       /// </summary>
       [Display(Name ="SN")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string SN { get; set; }

       /// <summary>
       ///flag
       /// </summary>
       [Display(Name ="flag")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       [Editable(true)]
       public string flag { get; set; }

       
    }
}