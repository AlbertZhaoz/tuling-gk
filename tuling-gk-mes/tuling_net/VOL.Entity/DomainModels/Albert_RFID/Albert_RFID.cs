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
    [Entity(TableCnName = "RFID查询",TableName = "Albert_RFID")]
    public partial class Albert_RFID:BaseEntity
    {
        /// <summary>
       ///RFID主键
       /// </summary>
       [Key]
       [Display(Name ="RFID主键")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int RFIDPkInt { get; set; }

       /// <summary>
       ///RFID编号
       /// </summary>
       [Display(Name ="RFID编号")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string RFID { get; set; }

       /// <summary>
       ///RFID被占用
       /// </summary>
       [Display(Name ="RFID被占用")]
       [Column(TypeName="int")]
       public int? RFIDIsUse { get; set; }

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
       ///产品码(轴承码）
       /// </summary>
       [Display(Name ="产品码(轴承码）")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string ProductCode { get; set; }

       /// <summary>
       ///壳体码
       /// </summary>
       [Display(Name ="壳体码")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string ShellCode { get; set; }

       /// <summary>
       ///执行器码
       /// </summary>
       [Display(Name ="执行器码")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string RunCode { get; set; }

       /// <summary>
       ///防错码
       /// </summary>
       [Display(Name ="防错码")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string ErrorCode { get; set; }

       /// <summary>
       ///最终结果
       /// </summary>
       [Display(Name ="最终结果")]
       [MaxLength(50)]
       [Column(TypeName="nvarchar(50)")]
       public string OpFinalResult { get; set; }

       /// <summary>
       ///Op10节拍
       /// </summary>
       [Display(Name ="Op10节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op10Beat { get; set; }

       /// <summary>
       ///Op10结果
       /// </summary>
       [Display(Name ="Op10结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op10Result { get; set; }

       /// <summary>
       ///Op10加工时间
       /// </summary>
       [Display(Name ="Op10加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op10Time { get; set; }

       /// <summary>
       ///钢球在位(Y/N)
       /// </summary>
       [Display(Name ="钢球在位(Y/N)")]
       [MaxLength(1)]
       [Column(TypeName="nvarchar(1)")]
       public string SteelBall { get; set; }

       /// <summary>
       ///堵帽在位(Y/N)
       /// </summary>
       [Display(Name ="堵帽在位(Y/N)")]
       [MaxLength(1)]
       [Column(TypeName="nvarchar(1)")]
       public string PlugCap { get; set; }

       /// <summary>
       ///螺帽在位(Y/N)
       /// </summary>
       [Display(Name ="螺帽在位(Y/N)")]
       [MaxLength(1)]
       [Column(TypeName="nvarchar(1)")]
       public string Nut { get; set; }

       /// <summary>
       ///弹簧在位(Y/N)
       /// </summary>
       [Display(Name ="弹簧在位(Y/N)")]
       [MaxLength(1)]
       [Column(TypeName="nvarchar(1)")]
       public string Spring { get; set; }

       /// <summary>
       ///轴承在位(Y/N)
       /// </summary>
       [Display(Name ="轴承在位(Y/N)")]
       [MaxLength(1)]
       [Column(TypeName="nvarchar(1)")]
       public string Bearing { get; set; }

       /// <summary>
       ///壳体在位(Y/N)
       /// </summary>
       [Display(Name ="壳体在位(Y/N)")]
       [MaxLength(1)]
       [Column(TypeName="nvarchar(1)")]
       public string Case { get; set; }

       /// <summary>
       ///Op150节拍
       /// </summary>
       [Display(Name ="Op150节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op150Beat { get; set; }

       /// <summary>
       ///Op150结果
       /// </summary>
       [Display(Name ="Op150结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op150Result { get; set; }

       /// <summary>
       ///Op150加工时间
       /// </summary>
       [Display(Name ="Op150加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op150Time { get; set; }

       /// <summary>
       ///Op160节拍
       /// </summary>
       [Display(Name ="Op160节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op160Beat { get; set; }

       /// <summary>
       ///Op160结果
       /// </summary>
       [Display(Name ="Op160结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op160Result { get; set; }

       /// <summary>
       ///Op160加工时间
       /// </summary>
       [Display(Name ="Op160加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op160Time { get; set; }

       /// <summary>
       ///Op170节拍
       /// </summary>
       [Display(Name ="Op170节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op170Beat { get; set; }

       /// <summary>
       ///Op170结果
       /// </summary>
       [Display(Name ="Op170结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op170Result { get; set; }

       /// <summary>
       ///Op170加工时间
       /// </summary>
       [Display(Name ="Op170加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op170Time { get; set; }

       /// <summary>
       ///Op170IV3结果
       /// </summary>
       [Display(Name ="Op170IV3结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op170IV3Result { get; set; }

       /// <summary>
       ///Op170IV3照片
       /// </summary>
       [Display(Name ="Op170IV3照片")]
       [MaxLength(350)]
       [Column(TypeName="nvarchar(350)")]
       public string Op170IV3File { get; set; }

       /// <summary>
       ///Op180_1节拍
       /// </summary>
       [Display(Name ="Op180_1节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op180_1Beat { get; set; }

       /// <summary>
       ///Op180_1结果
       /// </summary>
       [Display(Name ="Op180_1结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op180_1Result { get; set; }

       /// <summary>
       ///Op180_1加工时间
       /// </summary>
       [Display(Name ="Op180_1加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op180_1Time { get; set; }

       /// <summary>
       ///Op180_2节拍
       /// </summary>
       [Display(Name ="Op180_2节拍")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op180_2Beat { get; set; }

       /// <summary>
       ///Op180_2结果
       /// </summary>
       [Display(Name ="Op180_2结果")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op180_2Result { get; set; }

       /// <summary>
       ///Op180_2加工时间
       /// </summary>
       [Display(Name ="Op180_2加工时间")]
       [Column(TypeName="datetime")]
       public DateTime? Op180_2Time { get; set; }

       /// <summary>
       ///预留
       /// </summary>
       [Display(Name ="预留")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op10WorkType { get; set; }

       /// <summary>
       ///最后执行站
       /// </summary>
       [Display(Name ="最后执行站")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string OpFinalStation { get; set; }

       /// <summary>
       ///OP10读取的Function
       /// </summary>
       [Display(Name ="OP10读取的Function")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op10R_Get_Function { get; set; }

       /// <summary>
       ///OP10读取的Content
       /// </summary>
       [Display(Name ="OP10读取的Content")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op10R_Get_Content { get; set; }

       /// <summary>
       ///OP10发送的读取信号
       /// </summary>
       [Display(Name ="OP10发送的读取信号")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op10R_Send_Read { get; set; }

       /// <summary>
       ///OP20读取的RFID
       /// </summary>
       [Display(Name ="OP20读取的RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op20R_Get_RFID { get; set; }

       /// <summary>
       ///OP20读取的轴承码
       /// </summary>
       [Display(Name ="OP20读取的轴承码")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op20R_Get_ProductCode { get; set; }

       /// <summary>
       ///OP20发送的读取信号
       /// </summary>
       [Display(Name ="OP20发送的读取信号")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op20R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op30R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op30R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op30R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op30R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op40R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op40R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op40R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op40R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op50R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op50R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op50R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op50R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op60R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op60R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op60R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op60R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op70R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op70R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op70R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op70R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op80R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op80R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op80R_Get_ProductCode")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op80R_Get_ProductCode { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op80R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op80R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op90R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op90R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op90R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op90R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op100R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op100R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op100R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op100R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op110R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op110R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op110R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op110R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op120R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op120R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op120R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op120R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op130R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op130R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op130R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op130R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op135R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op135R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op135R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op135R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op140R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op140R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op140R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op140R_Send_Read { get; set; }

       /// <summary>
       ///OP10读取的RFID
       /// </summary>
       [Display(Name ="OP10读取的RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op10R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op150R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op150R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op150R_Get_Function")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op150R_Get_Function { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op150R_Get_Content")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op150R_Get_Content { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op150R_Get_ProductCode")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op150R_Get_ProductCode { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op150R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op150R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op160R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op160R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op160R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op160R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op170R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op170R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op170R_Get_ProductCode")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op170R_Get_ProductCode { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op170R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op170R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op180_1R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op180_1R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op180_1R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op180_1R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op180_2R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op180_2R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op180_2R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op180_2R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op180_3R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op180_3R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op180_3R_Get_ProductCode")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op180_3R_Get_ProductCode { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op180_3R_Get_ShellCode")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op180_3R_Get_ShellCode { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op180_3R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op180_3R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op190R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op190R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op190R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op190R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op200_1R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op200_1R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op200_1R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op200_1R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op200_2R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op200_2R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op200_2R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op200_2R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op210R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op210R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op210R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op210R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op220R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op220R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op220R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op220R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op230_1R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op230_1R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op230_1R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op230_1R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op230_2R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op230_2R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op230_2R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op230_2R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op230_3R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op230_3R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op230_3R_Get_ProductCode")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op230_3R_Get_ProductCode { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op230_3R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op230_3R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op230_4R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op230_4R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op230_4R_Get_ProductCode")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op230_4R_Get_ProductCode { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op230_4R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op230_4R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op240_1R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op240_1R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op240_1R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op240_1R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op240_2R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op240_2R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op240_2R_Get_ProductCode")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op240_2R_Get_ProductCode { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op240_2R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op240_2R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op250_1R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op250_1R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op250_1R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op250_1R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op250_2R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op250_2R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op250_2R_Get_ProductCode")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op250_2R_Get_ProductCode { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op250_2R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op250_2R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op260R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op260R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op260R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op260R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op270R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op270R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op270R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op270R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op280R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op280R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op280R_Get_ProductCode")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op280R_Get_ProductCode { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op280R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op280R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op290_1R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op290_1R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op290_1R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op290_1R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op290_2R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op290_2R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op290_2R_Get_ProductCode")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op290_2R_Get_ProductCode { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op290_2R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op290_2R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op300_1R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op300_1R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op300_1R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op300_1R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op300_2R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op300_2R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op300_2R_Get_ProductCode")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op300_2R_Get_ProductCode { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op300_2R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op300_2R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op310_1R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op310_1R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op310_1R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op310_1R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op310_2R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op310_2R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op310_2R_Get_ProductCode")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op310_2R_Get_ProductCode { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op310_2R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op310_2R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op320R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op320R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op320R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op320R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op330R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op330R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op330R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op330R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op340R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op340R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op340R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op340R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op350R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op350R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op350R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op350R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op360R_Get_RFID")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op360R_Get_RFID { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op360R_Send_Read")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op360R_Send_Read { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="Op320R_Get_ProductCode")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Op320R_Get_ProductCode { get; set; }

       
    }
}