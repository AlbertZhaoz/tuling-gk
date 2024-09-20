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
    [Entity(TableCnName = "环形1线",TableName = "Albert_DataFirst")]
    public partial class Albert_DataFirst:BaseEntity
    {
        /// <summary>
       ///数据主键
       /// </summary>
       [Key]
       [Display(Name ="数据主键")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int DataPkInt { get; set; }

       /// <summary>
       ///工单号
       /// </summary>
       [Display(Name ="工单号")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string WorkorderCode { get; set; }

       /// <summary>
       ///产品码(轴承)
       /// </summary>
       [Display(Name ="产品码(轴承)")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string ProductCode { get; set; }

       /// <summary>
       ///RFID
       /// </summary>
       [Display(Name ="RFID")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       [Editable(true)]
       public string RFID { get; set; }

       /// <summary>
       ///工作类型
       /// </summary>
       [Display(Name ="工作类型")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string ProductFunction { get; set; }

       /// <summary>
       ///工作内容
       /// </summary>
       [Display(Name ="工作内容")]
       [MaxLength(1000)]
       [Column(TypeName="nvarchar(1000)")]
       public string ProductContent { get; set; }

       /// <summary>
       ///预留
       /// </summary>
       [Display(Name ="预留")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string Op10WorkType { get; set; }

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
       ///最终时间
       /// </summary>
       [Display(Name ="最终时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? OpFinalDate { get; set; }

       /// <summary>
       ///Op10加工结果
       /// </summary>
       [Display(Name ="Op10加工结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       [Editable(true)]
       public string Op10Result { get; set; }

       /// <summary>
       ///Op10加工时间
       /// </summary>
       [Display(Name ="Op10加工时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? Op10Time { get; set; }

       /// <summary>
       ///Op10节拍
       /// </summary>
       [Display(Name ="Op10节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op10Beat { get; set; }

       /// <summary>
       ///Op20加工结果
       /// </summary>
       [Display(Name ="Op20加工结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       [Editable(true)]
       public string Op20Result { get; set; }

       /// <summary>
       ///Op20加工时间
       /// </summary>
       [Display(Name ="Op20加工时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? Op20Time { get; set; }

       /// <summary>
       ///Op20节拍
       /// </summary>
       [Display(Name ="Op20节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op20Beat { get; set; }

       /// <summary>
       ///Op30加工结果
       /// </summary>
       [Display(Name ="Op30加工结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       [Editable(true)]
       public string Op30Result { get; set; }

       /// <summary>
       ///Op30加工时间
       /// </summary>
       [Display(Name ="Op30加工时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? Op30Time { get; set; }

       /// <summary>
       ///Op30节拍
       /// </summary>
       [Display(Name ="Op30节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op30Beat { get; set; }

       /// <summary>
       ///Op40加工结果
       /// </summary>
       [Display(Name ="Op40加工结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       [Editable(true)]
       public string Op40Result { get; set; }

       /// <summary>
       ///Op40加工时间
       /// </summary>
       [Display(Name ="Op40加工时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? Op40Time { get; set; }

       /// <summary>
       ///Op40节拍
       /// </summary>
       [Display(Name ="Op40节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op40Beat { get; set; }

       /// <summary>
       ///Op50加工结果
       /// </summary>
       [Display(Name ="Op50加工结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       [Editable(true)]
       public string Op50Result { get; set; }

       /// <summary>
       ///Op50加工时间
       /// </summary>
       [Display(Name ="Op50加工时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? Op50Time { get; set; }

       /// <summary>
       ///Op50节拍
       /// </summary>
       [Display(Name ="Op50节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op50Beat { get; set; }

       /// <summary>
       ///Op60加工结果
       /// </summary>
       [Display(Name ="Op60加工结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       [Editable(true)]
       public string Op60Result { get; set; }

       /// <summary>
       ///Op60加工时间
       /// </summary>
       [Display(Name ="Op60加工时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? Op60Time { get; set; }

       /// <summary>
       ///Op60节拍
       /// </summary>
       [Display(Name ="Op60节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op60Beat { get; set; }

       /// <summary>
       ///Op60压力数据
       /// </summary>
       [Display(Name ="Op60压力数据")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       [Editable(true)]
       public string Op60Pressure { get; set; }

       /// <summary>
       ///Op60压力文件
       /// </summary>
       [Display(Name ="Op60压力文件")]
       [MaxLength(255)]
       [Column(TypeName="nvarchar(255)")]
       [Editable(true)]
       public string Op60PressureFile { get; set; }

       /// <summary>
       ///Op60IX结果
       /// </summary>
       [Display(Name ="Op60IX结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op60IXResult { get; set; }

       /// <summary>
       ///Op60IX照片
       /// </summary>
       [Display(Name ="Op60IX照片")]
       [MaxLength(400)]
       [Column(TypeName="nvarchar(400)")]
       public string Op60IXFile { get; set; }

       /// <summary>
       ///Op60IX5_1
       /// </summary>
       [Display(Name ="Op60IX5_1")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op60IX5_1 { get; set; }

       /// <summary>
       ///Op60IX5_2
       /// </summary>
       [Display(Name ="Op60IX5_2")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op60IX5_2 { get; set; }

       /// <summary>
       ///Op60IX5_3
       /// </summary>
       [Display(Name ="Op60IX5_3")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op60IX5_3 { get; set; }

       /// <summary>
       ///Op60IX5_4
       /// </summary>
       [Display(Name ="Op60IX5_4")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op60IX5_4 { get; set; }

       /// <summary>
       ///Op70加工结果
       /// </summary>
       [Display(Name ="Op70加工结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       [Editable(true)]
       public string Op70Result { get; set; }

       /// <summary>
       ///Op70加工时间
       /// </summary>
       [Display(Name ="Op70加工时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? Op70Time { get; set; }

       /// <summary>
       ///Op70节拍
       /// </summary>
       [Display(Name ="Op70节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op70Beat { get; set; }

       /// <summary>
       ///Op80加工结果
       /// </summary>
       [Display(Name ="Op80加工结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       [Editable(true)]
       public string Op80Result { get; set; }

       /// <summary>
       ///Op80加工时间
       /// </summary>
       [Display(Name ="Op80加工时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? Op80Time { get; set; }

       /// <summary>
       ///Op80节拍
       /// </summary>
       [Display(Name ="Op80节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op80Beat { get; set; }

       /// <summary>
       ///Op90加工结果
       /// </summary>
       [Display(Name ="Op90加工结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       [Editable(true)]
       public string Op90Result { get; set; }

       /// <summary>
       ///Op90加工时间
       /// </summary>
       [Display(Name ="Op90加工时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? Op90Time { get; set; }

       /// <summary>
       ///Op90位移结果
       /// </summary>
       [Display(Name ="Op90位移结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op90DisplaceResult { get; set; }

       /// <summary>
       ///Op90位移值
       /// </summary>
       [Display(Name ="Op90位移值")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op90DisplaceValue { get; set; }

       /// <summary>
       ///Op90IV3结果
       /// </summary>
       [Display(Name ="Op90IV3结果")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string Op90IV3Result { get; set; }

       /// <summary>
       ///Op90相机图片文件
       /// </summary>
       [Display(Name ="Op90相机图片文件")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string Op90IV3File { get; set; }

       /// <summary>
       ///Op90节拍
       /// </summary>
       [Display(Name ="Op90节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op90Beat { get; set; }

       /// <summary>
       ///Op100加工结果
       /// </summary>
       [Display(Name ="Op100加工结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       [Editable(true)]
       public string Op100Result { get; set; }

       /// <summary>
       ///Op100加工时间
       /// </summary>
       [Display(Name ="Op100加工时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? Op100Time { get; set; }

       /// <summary>
       ///Op100节拍
       /// </summary>
       [Display(Name ="Op100节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op100Beat { get; set; }

       /// <summary>
       ///Op110加工结果
       /// </summary>
       [Display(Name ="Op110加工结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       [Editable(true)]
       public string Op110Result { get; set; }

       /// <summary>
       ///Op110加工时间
       /// </summary>
       [Display(Name ="Op110加工时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? Op110Time { get; set; }

       /// <summary>
       ///Op110相机图片文件
       /// </summary>
       [Display(Name ="Op110相机图片文件")]
       [MaxLength(90)]
       [Column(TypeName="nvarchar(90)")]
       [Editable(true)]
       public string Op110IV3File { get; set; }

       /// <summary>
       ///Op110节拍
       /// </summary>
       [Display(Name ="Op110节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op110Beat { get; set; }

       /// <summary>
       ///Op110相机结果
       /// </summary>
       [Display(Name ="Op110相机结果")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string Op110IV3Result { get; set; }

       /// <summary>
       ///Op120加工结果
       /// </summary>
       [Display(Name ="Op120加工结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       [Editable(true)]
       public string Op120Result { get; set; }

       /// <summary>
       ///Op120加工时间
       /// </summary>
       [Display(Name ="Op120加工时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? Op120Time { get; set; }

       /// <summary>
       ///Op120扭矩结果
       /// </summary>
       [Display(Name ="Op120扭矩结果")]
       [MaxLength(2000)]
       [Column(TypeName="nvarchar(2000)")]
       public string Op120TorqueResult { get; set; }

       /// <summary>
       ///Op120扭矩曲线数据
       /// </summary>
       [Display(Name ="Op120扭矩曲线数据")]
       [MaxLength(2000)]
       [Column(TypeName="nvarchar(2000)")]
       public string Op120TorqueList { get; set; }

       /// <summary>
       ///Op120前半程最大值
       /// </summary>
       [Display(Name ="Op120前半程最大值")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       public string Op120MaxFirstHalf { get; set; }

       /// <summary>
       ///Op120前半程最小值
       /// </summary>
       [Display(Name ="Op120前半程最小值")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       public string Op120MinFirstHalf { get; set; }

       /// <summary>
       ///Op120前半程平均值
       /// </summary>
       [Display(Name ="Op120前半程平均值")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       public string Op120AverageFirstHalf { get; set; }

       /// <summary>
       ///Op120后半程最大值
       /// </summary>
       [Display(Name ="Op120后半程最大值")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       public string Op120MaxSecondHalf { get; set; }

       /// <summary>
       ///Op120后半程最小值
       /// </summary>
       [Display(Name ="Op120后半程最小值")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       public string Op120MinSecondHalf { get; set; }

       /// <summary>
       ///Op120后半程平均值
       /// </summary>
       [Display(Name ="Op120后半程平均值")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       public string Op120AverageSecondHalf { get; set; }

       /// <summary>
       ///Op120相机照片
       /// </summary>
       [Display(Name ="Op120相机照片")]
       [MaxLength(255)]
       [Column(TypeName="nvarchar(255)")]
       public string Op120IV3File { get; set; }

       /// <summary>
       ///Op120节拍
       /// </summary>
       [Display(Name ="Op120节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op120Beat { get; set; }

       /// <summary>
       ///Op130加工结果
       /// </summary>
       [Display(Name ="Op130加工结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       [Editable(true)]
       public string Op130Result { get; set; }

       /// <summary>
       ///Op130加工时间
       /// </summary>
       [Display(Name ="Op130加工时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? Op130Time { get; set; }

       /// <summary>
       ///Op130节拍
       /// </summary>
       [Display(Name ="Op130节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op130Beat { get; set; }

       /// <summary>
       ///Op140加工结果
       /// </summary>
       [Display(Name ="Op140加工结果")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string Op140Result { get; set; }

       /// <summary>
       ///Op140加工时间
       /// </summary>
       [Display(Name ="Op140加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op140Time { get; set; }

       /// <summary>
       ///Op140节拍
       /// </summary>
       [Display(Name ="Op140节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op140Beat { get; set; }

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
       public DateTime? ModifyDate { get; set; }

       
    }
}