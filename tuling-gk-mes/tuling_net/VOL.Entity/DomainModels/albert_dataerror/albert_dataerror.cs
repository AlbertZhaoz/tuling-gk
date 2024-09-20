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
    [Entity(TableCnName = "防错件查询",TableName = "albert_dataerror")]
    public partial class albert_dataerror:BaseEntity
    {
        /// <summary>
       ///防错码
       /// </summary>
       [Display(Name ="防错码")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Required(AllowEmptyStrings=false)]
       public string ErrorCode { get; set; }

       /// <summary>
       ///自增ID
       /// </summary>
       [Key]
       [Display(Name ="自增ID")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int DataPkInt { get; set; }

       /// <summary>
       ///工作类型（0正常件、1防错件、2返工件)
       /// </summary>
       [Display(Name ="工作类型（0正常件、1防错件、2返工件)")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string ProductFunction { get; set; }

       /// <summary>
       ///工作内容
       /// </summary>
       [Display(Name ="工作内容")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string ProductContent { get; set; }

       /// <summary>
       ///Op60OK
       /// </summary>
       [Display(Name ="Op60OK")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op60EPOk { get; set; }

       /// <summary>
       ///Op60垫片偏高
       /// </summary>
       [Display(Name ="Op60垫片偏高")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op60EPHigh { get; set; }

       /// <summary>
       ///Op60垫片偏低
       /// </summary>
       [Display(Name ="Op60垫片偏低")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op60EPLow { get; set; }

       /// <summary>
       ///Op60垫片变形
       /// </summary>
       [Display(Name ="Op60垫片变形")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op60EPDeformation { get; set; }

       /// <summary>
       ///Op90OK
       /// </summary>
       [Display(Name ="Op90OK")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op90EPOk { get; set; }

       /// <summary>
       ///Op90卡簧漏装
       /// </summary>
       [Display(Name ="Op90卡簧漏装")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op90EPMiss { get; set; }

       /// <summary>
       ///Op90卡簧装两个
       /// </summary>
       [Display(Name ="Op90卡簧装两个")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op90EPDouble { get; set; }

       /// <summary>
       ///Op90垫片漏装
       /// </summary>
       [Display(Name ="Op90垫片漏装")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op90EPDpMiss { get; set; }

       /// <summary>
       ///Op90垫片装两个
       /// </summary>
       [Display(Name ="Op90垫片装两个")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op90EPDpDouble { get; set; }

       /// <summary>
       ///Op90标定件
       /// </summary>
       [Display(Name ="Op90标定件")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op90EPBD { get; set; }

       /// <summary>
       ///Op110OK
       /// </summary>
       [Display(Name ="Op110OK")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op110EPOk { get; set; }

       /// <summary>
       ///Op110小O-Ring漏装
       /// </summary>
       [Display(Name ="Op110小O-Ring漏装")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op110EPSRMiss { get; set; }

       /// <summary>
       ///Op110大O-Ring漏装
       /// </summary>
       [Display(Name ="Op110大O-Ring漏装")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op110EPBRMiss { get; set; }

       /// <summary>
       ///Op110小O-Ring装两个
       /// </summary>
       [Display(Name ="Op110小O-Ring装两个")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op110EPSRDouble { get; set; }

       /// <summary>
       ///Op110大O-Ring装两个
       /// </summary>
       [Display(Name ="Op110大O-Ring装两个")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op110EPBRDouble { get; set; }

       /// <summary>
       ///Op120OK
       /// </summary>
       [Display(Name ="Op120OK")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op120EPOK { get; set; }

       /// <summary>
       ///Op120扭矩偏大
       /// </summary>
       [Display(Name ="Op120扭矩偏大")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op120EPNBig { get; set; }

       /// <summary>
       ///Op120扭矩偏小
       /// </summary>
       [Display(Name ="Op120扭矩偏小")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op120EPNSmall { get; set; }

       /// <summary>
       ///Op170OK
       /// </summary>
       [Display(Name ="Op170OK")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op170EPOK { get; set; }

       /// <summary>
       ///Op170装偏
       /// </summary>
       [Display(Name ="Op170装偏")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op170EPOffMark { get; set; }

       /// <summary>
       ///Op170漏装
       /// </summary>
       [Display(Name ="Op170漏装")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op170EPMiss { get; set; }

       /// <summary>
       ///Op200_1OK
       /// </summary>
       [Display(Name ="Op200_1OK")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op200_1EPOK { get; set; }

       /// <summary>
       ///Op200_1漏装
       /// </summary>
       [Display(Name ="Op200_1漏装")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op200_1EPMiss { get; set; }

       /// <summary>
       ///Op200_1多装
       /// </summary>
       [Display(Name ="Op200_1多装")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op200_1EPDouble { get; set; }

       /// <summary>
       ///Op220OK
       /// </summary>
       [Display(Name ="Op220OK")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op220EPOK { get; set; }

       /// <summary>
       ///Op220NG
       /// </summary>
       [Display(Name ="Op220NG")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op220EPNG { get; set; }

       /// <summary>
       ///Op230结果
       /// </summary>
       [Display(Name ="Op230结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op230EPResult { get; set; }

       /// <summary>
       ///Op230类型
       /// </summary>
       [Display(Name ="Op230类型")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op230EPType { get; set; }

       /// <summary>
       ///Op230备用
       /// </summary>
       [Display(Name ="Op230备用")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op230EPBack { get; set; }

       /// <summary>
       ///Op240结果
       /// </summary>
       [Display(Name ="Op240结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op240EPResult { get; set; }

       /// <summary>
       ///Op240类型
       /// </summary>
       [Display(Name ="Op240类型")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op240EPType { get; set; }

       /// <summary>
       ///Op240备用
       /// </summary>
       [Display(Name ="Op240备用")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op240EPBack { get; set; }

       /// <summary>
       ///Op250结果
       /// </summary>
       [Display(Name ="Op250结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op250EPResult { get; set; }

       /// <summary>
       ///Op250类型
       /// </summary>
       [Display(Name ="Op250类型")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op250EPType { get; set; }

       /// <summary>
       ///Op250备用
       /// </summary>
       [Display(Name ="Op250备用")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op250EPBack { get; set; }

       /// <summary>
       ///Op290结果
       /// </summary>
       [Display(Name ="Op290结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op290EPResult { get; set; }

       /// <summary>
       ///Op290类型
       /// </summary>
       [Display(Name ="Op290类型")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op290EPType { get; set; }

       /// <summary>
       ///Op290备用
       /// </summary>
       [Display(Name ="Op290备用")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op290EPBack { get; set; }

       /// <summary>
       ///Op300结果
       /// </summary>
       [Display(Name ="Op300结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op300EPResult { get; set; }

       /// <summary>
       ///Op300类型
       /// </summary>
       [Display(Name ="Op300类型")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op300EPType { get; set; }

       /// <summary>
       ///Op300备用
       /// </summary>
       [Display(Name ="Op300备用")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op300EPBack { get; set; }

       
    }
}