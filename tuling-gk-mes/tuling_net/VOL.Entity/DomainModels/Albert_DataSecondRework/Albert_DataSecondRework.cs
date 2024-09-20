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
    [Entity(TableCnName = "环形2线返工查询",TableName = "Albert_DataSecondRework")]
    public partial class Albert_DataSecondRework:BaseEntity
    {
        /// <summary>
       ///数据主键
       /// </summary>
       [Key]
       [Display(Name ="数据主键")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int DataPkInt { get; set; }

       /// <summary>
       ///工单号
       /// </summary>
       [Display(Name ="工单号")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string WorkorderCode { get; set; }

       /// <summary>
       ///壳体码
       /// </summary>
       [Display(Name ="壳体码")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       [Required(AllowEmptyStrings=false)]
       public string ShellCode { get; set; }

       /// <summary>
       ///轴承码(1线）
       /// </summary>
       [Display(Name ="轴承码(1线）")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       public string ProductCode { get; set; }

       /// <summary>
       ///执行器码(270)
       /// </summary>
       [Display(Name ="执行器码(270)")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string RunCode { get; set; }

       /// <summary>
       ///RFID
       /// </summary>
       [Display(Name ="RFID")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string RFID { get; set; }

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
       [MaxLength(1000)]
       [Column(TypeName="nvarchar(1000)")]
       public string ProductContent { get; set; }

       /// <summary>
       ///最终结果
       /// </summary>
       [Display(Name ="最终结果")]
       [MaxLength(5)]
       [Column(TypeName="nvarchar(5)")]
       public string OpFinalResult { get; set; }

       /// <summary>
       ///最终站
       /// </summary>
       [Display(Name ="最终站")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string OpFinalStation { get; set; }

       /// <summary>
       ///最终时间
       /// </summary>
       [Display(Name ="最终时间")]
       [Column(TypeName="datetime")]
       public DateTime? OpFinalDate { get; set; }

       /// <summary>
       ///Op150加工结果
       /// </summary>
       [Display(Name ="Op150加工结果")]
       [MaxLength(5)]
       [Column(TypeName="nvarchar(5)")]
       public string Op150Result { get; set; }

       /// <summary>
       ///Op150加工时间
       /// </summary>
       [Display(Name ="Op150加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op150Time { get; set; }

       /// <summary>
       ///Op150节拍
       /// </summary>
       [Display(Name ="Op150节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op150Beat { get; set; }

       /// <summary>
       ///Op160加工结果
       /// </summary>
       [Display(Name ="Op160加工结果")]
       [MaxLength(5)]
       [Column(TypeName="nvarchar(5)")]
       public string Op160Result { get; set; }

       /// <summary>
       ///Op160加工时间
       /// </summary>
       [Display(Name ="Op160加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op160Time { get; set; }

       /// <summary>
       ///Op160节拍
       /// </summary>
       [Display(Name ="Op160节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op160Beat { get; set; }

       /// <summary>
       ///Op170加工结果
       /// </summary>
       [Display(Name ="Op170加工结果")]
       [MaxLength(5)]
       [Column(TypeName="nvarchar(5)")]
       public string Op170Result { get; set; }

       /// <summary>
       ///Op170加工时间
       /// </summary>
       [Display(Name ="Op170加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op170Time { get; set; }

       /// <summary>
       ///Op170节拍
       /// </summary>
       [Display(Name ="Op170节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op170Beat { get; set; }

       /// <summary>
       ///Op170照片结果
       /// </summary>
       [Display(Name ="Op170照片结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op170IV3Result { get; set; }

       /// <summary>
       ///Op170照片
       /// </summary>
       [Display(Name ="Op170照片")]
       [MaxLength(350)]
       [Column(TypeName="nvarchar(350)")]
       public string Op170IV3File { get; set; }

       /// <summary>
       ///Op180_1加工结果
       /// </summary>
       [Display(Name ="Op180_1加工结果")]
       [MaxLength(5)]
       [Column(TypeName="nvarchar(5)")]
       public string Op180_1Result { get; set; }

       /// <summary>
       ///Op180_1加工时间
       /// </summary>
       [Display(Name ="Op180_1加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op180_1Time { get; set; }

       /// <summary>
       ///Op180_1节拍
       /// </summary>
       [Display(Name ="Op180_1节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op180_1Beat { get; set; }

       /// <summary>
       ///Op180_2加工结果
       /// </summary>
       [Display(Name ="Op180_2加工结果")]
       [MaxLength(5)]
       [Column(TypeName="nvarchar(5)")]
       public string Op180_2Result { get; set; }

       /// <summary>
       ///Op180_2加工时间
       /// </summary>
       [Display(Name ="Op180_2加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op180_2Time { get; set; }

       /// <summary>
       ///Op180_2节拍
       /// </summary>
       [Display(Name ="Op180_2节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op180_2Beat { get; set; }

       /// <summary>
       ///Op180_3加工结果
       /// </summary>
       [Display(Name ="Op180_3加工结果")]
       [MaxLength(5)]
       [Column(TypeName="nvarchar(5)")]
       public string Op180_3Result { get; set; }

       /// <summary>
       ///Op180_3加工时间
       /// </summary>
       [Display(Name ="Op180_3加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op180_3Time { get; set; }

       /// <summary>
       ///Op180_3节拍
       /// </summary>
       [Display(Name ="Op180_3节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op180_3Beat { get; set; }

       /// <summary>
       ///Op180_3扭矩数据
       /// </summary>
       [Display(Name ="Op180_3扭矩数据")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op180_3Torque { get; set; }

       /// <summary>
       ///Op180_3角度数据
       /// </summary>
       [Display(Name ="Op180_3角度数据")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op180_3Angle { get; set; }

       /// <summary>
       ///Op180_3扭矩结果
       /// </summary>
       [Display(Name ="Op180_3扭矩结果")]
       [MaxLength(2)]
       [Column(TypeName="nvarchar(2)")]
       public string Op180_3TorqueResult { get; set; }

       /// <summary>
       ///Op180_3扭矩数据2
       /// </summary>
       [Display(Name ="Op180_3扭矩数据2")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op180_3Torque2 { get; set; }

       /// <summary>
       ///Op180_3角度数据2
       /// </summary>
       [Display(Name ="Op180_3角度数据2")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op180_3Angle2 { get; set; }

       /// <summary>
       ///Op180_3扭矩结果2
       /// </summary>
       [Display(Name ="Op180_3扭矩结果2")]
       [MaxLength(2)]
       [Column(TypeName="nvarchar(2)")]
       public string Op180_3TorqueResult2 { get; set; }

       /// <summary>
       ///Op190加工结果
       /// </summary>
       [Display(Name ="Op190加工结果")]
       [MaxLength(5)]
       [Column(TypeName="nvarchar(5)")]
       public string Op190Result { get; set; }

       /// <summary>
       ///Op190加工时间
       /// </summary>
       [Display(Name ="Op190加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op190Time { get; set; }

       /// <summary>
       ///Op190节拍
       /// </summary>
       [Display(Name ="Op190节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op190Beat { get; set; }

       /// <summary>
       ///Op190信号
       /// </summary>
       [Display(Name ="Op190信号")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op190Signal { get; set; }

       /// <summary>
       ///Op200_1加工结果
       /// </summary>
       [Display(Name ="Op200_1加工结果")]
       [MaxLength(5)]
       [Column(TypeName="nvarchar(5)")]
       public string Op200_1Result { get; set; }

       /// <summary>
       ///Op200_1加工时间
       /// </summary>
       [Display(Name ="Op200_1加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op200_1Time { get; set; }

       /// <summary>
       ///Op200_1节拍
       /// </summary>
       [Display(Name ="Op200_1节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op200_1Beat { get; set; }

       /// <summary>
       ///Op200_2加工结果
       /// </summary>
       [Display(Name ="Op200_2加工结果")]
       [MaxLength(5)]
       [Column(TypeName="nvarchar(5)")]
       public string Op200_2Result { get; set; }

       /// <summary>
       ///Op200_2加工时间
       /// </summary>
       [Display(Name ="Op200_2加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op200_2Time { get; set; }

       /// <summary>
       ///Op200_2节拍
       /// </summary>
       [Display(Name ="Op200_2节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op200_2Beat { get; set; }

       /// <summary>
       ///Op200_2IV3结果
       /// </summary>
       [Display(Name ="Op200_2IV3结果")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string Op200_2IV3Result { get; set; }

       /// <summary>
       ///Op200_2IV3相机照片
       /// </summary>
       [Display(Name ="Op200_2IV3相机照片")]
       [MaxLength(350)]
       [Column(TypeName="nvarchar(350)")]
       public string Op200_2IV3File { get; set; }

       /// <summary>
       ///Op210加工结果
       /// </summary>
       [Display(Name ="Op210加工结果")]
       [MaxLength(5)]
       [Column(TypeName="nvarchar(5)")]
       public string Op210Result { get; set; }

       /// <summary>
       ///Op210加工时间
       /// </summary>
       [Display(Name ="Op210加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op210Time { get; set; }

       /// <summary>
       ///Op210节拍
       /// </summary>
       [Display(Name ="Op210节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op210Beat { get; set; }

       /// <summary>
       ///Op210扭矩数据
       /// </summary>
       [Display(Name ="Op210扭矩数据")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op210Torque { get; set; }

       /// <summary>
       ///Op210角度数据
       /// </summary>
       [Display(Name ="Op210角度数据")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op210Angle { get; set; }

       /// <summary>
       ///Op210扭矩结果
       /// </summary>
       [Display(Name ="Op210扭矩结果")]
       [MaxLength(2)]
       [Column(TypeName="nvarchar(2)")]
       public string Op210TorqueResult { get; set; }

       /// <summary>
       ///Op220加工结果
       /// </summary>
       [Display(Name ="Op220加工结果")]
       [MaxLength(5)]
       [Column(TypeName="nvarchar(5)")]
       public string Op220Result { get; set; }

       /// <summary>
       ///Op220加工时间
       /// </summary>
       [Display(Name ="Op220加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op220Time { get; set; }

       /// <summary>
       ///Op220节拍
       /// </summary>
       [Display(Name ="Op220节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op220Beat { get; set; }

       /// <summary>
       ///Op220位移结果
       /// </summary>
       [Display(Name ="Op220位移结果")]
       [MaxLength(2)]
       [Column(TypeName="nvarchar(2)")]
       public string Op220DisplaceResult { get; set; }

       /// <summary>
       ///Op220位移值
       /// </summary>
       [Display(Name ="Op220位移值")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op220Displace { get; set; }

       /// <summary>
       ///Op230加工结果
       /// </summary>
       [Display(Name ="Op230加工结果")]
       [MaxLength(5)]
       [Column(TypeName="nvarchar(5)")]
       public string Op230Result { get; set; }

       /// <summary>
       ///Op230加工时间
       /// </summary>
       [Display(Name ="Op230加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op230Time { get; set; }

       /// <summary>
       ///Op230节拍
       /// </summary>
       [Display(Name ="Op230节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op230Beat { get; set; }

       /// <summary>
       ///Op230信号结果
       /// </summary>
       [Display(Name ="Op230信号结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op230Signal { get; set; }

       /// <summary>
       ///Op240加工结果
       /// </summary>
       [Display(Name ="Op240加工结果")]
       [MaxLength(5)]
       [Column(TypeName="nvarchar(5)")]
       public string Op240Result { get; set; }

       /// <summary>
       ///Op240加工时间
       /// </summary>
       [Display(Name ="Op240加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op240Time { get; set; }

       /// <summary>
       ///Op240节拍
       /// </summary>
       [Display(Name ="Op240节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op240Beat { get; set; }

       /// <summary>
       ///Op240结果信号
       /// </summary>
       [Display(Name ="Op240结果信号")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op240Signal { get; set; }

       /// <summary>
       ///Op250加工结果
       /// </summary>
       [Display(Name ="Op250加工结果")]
       [MaxLength(5)]
       [Column(TypeName="nvarchar(5)")]
       public string Op250Result { get; set; }

       /// <summary>
       ///Op250加工时间
       /// </summary>
       [Display(Name ="Op250加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op250Time { get; set; }

       /// <summary>
       ///Op250节拍
       /// </summary>
       [Display(Name ="Op250节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op250Beat { get; set; }

       /// <summary>
       ///Op250信号结果
       /// </summary>
       [Display(Name ="Op250信号结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op250Signal { get; set; }

       /// <summary>
       ///Op260加工结果
       /// </summary>
       [Display(Name ="Op260加工结果")]
       [MaxLength(5)]
       [Column(TypeName="nvarchar(5)")]
       public string Op260Result { get; set; }

       /// <summary>
       ///Op260加工时间
       /// </summary>
       [Display(Name ="Op260加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op260Time { get; set; }

       /// <summary>
       ///Op260节拍
       /// </summary>
       [Display(Name ="Op260节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op260Beat { get; set; }

       /// <summary>
       ///Op270加工结果
       /// </summary>
       [Display(Name ="Op270加工结果")]
       [MaxLength(5)]
       [Column(TypeName="nvarchar(5)")]
       public string Op270Result { get; set; }

       /// <summary>
       ///Op270加工时间
       /// </summary>
       [Display(Name ="Op270加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op270Time { get; set; }

       /// <summary>
       ///Op270节拍
       /// </summary>
       [Display(Name ="Op270节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op270Beat { get; set; }

       /// <summary>
       ///Op280加工结果
       /// </summary>
       [Display(Name ="Op280加工结果")]
       [MaxLength(5)]
       [Column(TypeName="nvarchar(5)")]
       public string Op280Result { get; set; }

       /// <summary>
       ///Op280加工时间
       /// </summary>
       [Display(Name ="Op280加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op280Time { get; set; }

       /// <summary>
       ///Op280节拍
       /// </summary>
       [Display(Name ="Op280节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op280Beat { get; set; }

       /// <summary>
       ///Op280扭矩数据
       /// </summary>
       [Display(Name ="Op280扭矩数据")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string Op280Torque { get; set; }

       /// <summary>
       ///Op280角度数据
       /// </summary>
       [Display(Name ="Op280角度数据")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op280Angle { get; set; }

       /// <summary>
       ///Op280扭矩结果
       /// </summary>
       [Display(Name ="Op280扭矩结果")]
       [MaxLength(5)]
       [Column(TypeName="nvarchar(5)")]
       public string Op280TorqueResult { get; set; }

       /// <summary>
       ///Op280扭矩数据2
       /// </summary>
       [Display(Name ="Op280扭矩数据2")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string Op280Torque2 { get; set; }

       /// <summary>
       ///Op280角度数据2
       /// </summary>
       [Display(Name ="Op280角度数据2")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op280Angle2 { get; set; }

       /// <summary>
       ///Op280扭矩结果2
       /// </summary>
       [Display(Name ="Op280扭矩结果2")]
       [MaxLength(5)]
       [Column(TypeName="nvarchar(5)")]
       public string Op280TorqueResult2 { get; set; }

       /// <summary>
       ///Op280扭矩数据3
       /// </summary>
       [Display(Name ="Op280扭矩数据3")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string Op280Torque3 { get; set; }

       /// <summary>
       ///Op280角度数据3
       /// </summary>
       [Display(Name ="Op280角度数据3")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op280Angle3 { get; set; }

       /// <summary>
       ///Op280扭矩结果3
       /// </summary>
       [Display(Name ="Op280扭矩结果3")]
       [MaxLength(5)]
       [Column(TypeName="nvarchar(5)")]
       public string Op280TorqueResult3 { get; set; }

       /// <summary>
       ///Op290加工结果
       /// </summary>
       [Display(Name ="Op290加工结果")]
       [MaxLength(5)]
       [Column(TypeName="nvarchar(5)")]
       public string Op290Result { get; set; }

       /// <summary>
       ///Op290加工时间
       /// </summary>
       [Display(Name ="Op290加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op290Time { get; set; }

       /// <summary>
       ///Op290节拍
       /// </summary>
       [Display(Name ="Op290节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op290Beat { get; set; }

       /// <summary>
       ///Op290信号结果
       /// </summary>
       [Display(Name ="Op290信号结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op290Signal { get; set; }

       /// <summary>
       ///Op300加工结果
       /// </summary>
       [Display(Name ="Op300加工结果")]
       [MaxLength(5)]
       [Column(TypeName="nvarchar(5)")]
       public string Op300Result { get; set; }

       /// <summary>
       ///Op300加工时间
       /// </summary>
       [Display(Name ="Op300加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op300Time { get; set; }

       /// <summary>
       ///Op300节拍
       /// </summary>
       [Display(Name ="Op300节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op300Beat { get; set; }

       /// <summary>
       ///Op300信号结果
       /// </summary>
       [Display(Name ="Op300信号结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op300Signal { get; set; }

       /// <summary>
       ///Op310加工结果
       /// </summary>
       [Display(Name ="Op310加工结果")]
       [MaxLength(5)]
       [Column(TypeName="nvarchar(5)")]
       public string Op310Result { get; set; }

       /// <summary>
       ///Op310加工时间
       /// </summary>
       [Display(Name ="Op310加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op310Time { get; set; }

       /// <summary>
       ///Op310节拍
       /// </summary>
       [Display(Name ="Op310节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op310Beat { get; set; }

       /// <summary>
       ///Op320加工结果
       /// </summary>
       [Display(Name ="Op320加工结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op320Result { get; set; }

       /// <summary>
       ///Op320加工时间
       /// </summary>
       [Display(Name ="Op320加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op320Time { get; set; }

       /// <summary>
       ///Op320节拍
       /// </summary>
       [Display(Name ="Op320节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op320Beat { get; set; }

       /// <summary>
       ///Op320扭矩数据
       /// </summary>
       [Display(Name ="Op320扭矩数据")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string Op320Torque { get; set; }

       /// <summary>
       ///Op320角度数据
       /// </summary>
       [Display(Name ="Op320角度数据")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op320Angle { get; set; }

       /// <summary>
       ///Op320扭矩结果
       /// </summary>
       [Display(Name ="Op320扭矩结果")]
       [MaxLength(5)]
       [Column(TypeName="nvarchar(5)")]
       public string Op320TorqueResult { get; set; }

       /// <summary>
       ///Op330加工结果
       /// </summary>
       [Display(Name ="Op330加工结果")]
       [MaxLength(5)]
       [Column(TypeName="nvarchar(5)")]
       public string Op330Result { get; set; }

       /// <summary>
       ///Op330加工时间
       /// </summary>
       [Display(Name ="Op330加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op330Time { get; set; }

       /// <summary>
       ///Op330节拍
       /// </summary>
       [Display(Name ="Op330节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op330Beat { get; set; }

       /// <summary>
       ///Op340加工结果
       /// </summary>
       [Display(Name ="Op340加工结果")]
       [MaxLength(5)]
       [Column(TypeName="nvarchar(5)")]
       public string Op340Result { get; set; }

       /// <summary>
       ///Op340加工时间
       /// </summary>
       [Display(Name ="Op340加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op340Time { get; set; }

       /// <summary>
       ///Op340节拍
       /// </summary>
       [Display(Name ="Op340节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op340Beat { get; set; }

       /// <summary>
       ///Op350加工结果
       /// </summary>
       [Display(Name ="Op350加工结果")]
       [MaxLength(5)]
       [Column(TypeName="nvarchar(5)")]
       public string Op350Result { get; set; }

       /// <summary>
       ///Op350加工时间
       /// </summary>
       [Display(Name ="Op350加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op350Time { get; set; }

       /// <summary>
       ///Op350节拍
       /// </summary>
       [Display(Name ="Op350节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op350Beat { get; set; }

       /// <summary>
       ///Op360加工结果
       /// </summary>
       [Display(Name ="Op360加工结果")]
       [MaxLength(5)]
       [Column(TypeName="nvarchar(5)")]
       public string Op360Result { get; set; }

       /// <summary>
       ///Op360加工时间
       /// </summary>
       [Display(Name ="Op360加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op360Time { get; set; }

       /// <summary>
       ///Op360节拍
       /// </summary>
       [Display(Name ="Op360节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op360Beat { get; set; }

       /// <summary>
       ///修改ID
       /// </summary>
       [Display(Name ="修改ID")]
       [Column(TypeName="int")]
       public int? ModifyID { get; set; }

       /// <summary>
       ///修改人
       /// </summary>
       [Display(Name ="修改人")]
       [MaxLength(30)]
       [Column(TypeName="nvarchar(30)")]
       public string Modifier { get; set; }

       /// <summary>
       ///修改时间
       /// </summary>
       [Display(Name ="修改时间")]
       [Column(TypeName="datetime")]
       public DateTime? ModifyDate { get; set; }

       
    }
}