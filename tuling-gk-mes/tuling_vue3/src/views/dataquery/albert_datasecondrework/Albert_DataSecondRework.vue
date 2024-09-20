<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/dataquery/albert_datasecondrework/Albert_DataSecondRework.js此处编写
 -->
<template>
    <view-grid ref="grid"
               :columns="columns"
               :detail="detail"
               :editFormFields="editFormFields"
               :editFormOptions="editFormOptions"
               :searchFormFields="searchFormFields"
               :searchFormOptions="searchFormOptions"
               :table="table"
               :extend="extend">
    </view-grid>
</template>
<script>
    import extend from "@/extension/dataquery/albert_datasecondrework/Albert_DataSecondRework.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'DataPkInt',
                footer: "Foots",
                cnName: '环形2线返工查询',
                name: 'albert_datasecondrework/Albert_DataSecondRework',
                url: "/Albert_DataSecondRework/",
                sortName: "DataPkInt"
            });
            const editFormFields = ref({});
            const editFormOptions = ref([]);
            const searchFormFields = ref({});
            const searchFormOptions = ref([]);
            const columns = ref([{field:'DataPkInt',title:'数据主键',type:'int',width:120,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'WorkorderCode',title:'工单号',type:'string',width:120,align:'left',sort:true},
                       {field:'ShellCode',title:'壳体码',type:'string',width:120,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'ProductCode',title:'轴承码(1线）',type:'string',width:120,hidden:true,readonly:true,align:'left'},
                       {field:'RunCode',title:'执行器码(270)',type:'string',width:120,align:'left'},
                       {field:'RFID',title:'RFID',type:'string',width:120,align:'left'},
                       {field:'ProductFunction',title:'工作类型（0正常件、1防错件、2返工件)',type:'string',width:120,align:'left'},
                       {field:'ProductContent',title:'工作内容',type:'string',width:120,align:'left'},
                       {field:'OpFinalResult',title:'最终结果',type:'string',width:120,align:'left'},
                       {field:'OpFinalStation',title:'最终站',type:'string',width:120,align:'left'},
                       {field:'OpFinalDate',title:'最终时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op150Result',title:'Op150加工结果',type:'string',width:120,align:'left'},
                       {field:'Op150Time',title:'Op150加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op150Beat',title:'Op150节拍',type:'string',width:120,align:'left'},
                       {field:'Op160Result',title:'Op160加工结果',type:'string',width:120,align:'left'},
                       {field:'Op160Time',title:'Op160加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op160Beat',title:'Op160节拍',type:'string',width:120,align:'left'},
                       {field:'Op170Result',title:'Op170加工结果',type:'string',width:120,align:'left'},
                       {field:'Op170Time',title:'Op170加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op170Beat',title:'Op170节拍',type:'string',width:120,align:'left'},
                       {field:'Op170IV3Result',title:'Op170照片结果',type:'string',width:120,align:'left'},
                       {field:'Op170IV3File',title:'Op170照片',type:'string',width:120,align:'left'},
                       {field:'Op180_1Result',title:'Op180_1加工结果',type:'string',width:120,align:'left'},
                       {field:'Op180_1Time',title:'Op180_1加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op180_1Beat',title:'Op180_1节拍',type:'string',width:120,align:'left'},
                       {field:'Op180_2Result',title:'Op180_2加工结果',type:'string',width:120,align:'left'},
                       {field:'Op180_2Time',title:'Op180_2加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op180_2Beat',title:'Op180_2节拍',type:'string',width:120,align:'left'},
                       {field:'Op180_3Result',title:'Op180_3加工结果',type:'string',width:120,align:'left'},
                       {field:'Op180_3Time',title:'Op180_3加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op180_3Beat',title:'Op180_3节拍',type:'string',width:120,align:'left'},
                       {field:'Op180_3Torque',title:'Op180_3扭矩数据',type:'string',width:120,align:'left'},
                       {field:'Op180_3Angle',title:'Op180_3角度数据',type:'string',width:120,align:'left'},
                       {field:'Op180_3TorqueResult',title:'Op180_3扭矩结果',type:'string',width:120,align:'left'},
                       {field:'Op180_3Torque2',title:'Op180_3扭矩数据2',type:'string',width:120,align:'left'},
                       {field:'Op180_3Angle2',title:'Op180_3角度数据2',type:'string',width:120,align:'left'},
                       {field:'Op180_3TorqueResult2',title:'Op180_3扭矩结果2',type:'string',width:120,align:'left'},
                       {field:'Op190Result',title:'Op190加工结果',type:'string',width:120,align:'left'},
                       {field:'Op190Time',title:'Op190加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op190Beat',title:'Op190节拍',type:'string',width:120,align:'left'},
                       {field:'Op190Signal',title:'Op190信号',type:'string',width:120,align:'left'},
                       {field:'Op200_1Result',title:'Op200_1加工结果',type:'string',width:120,align:'left'},
                       {field:'Op200_1Time',title:'Op200_1加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op200_1Beat',title:'Op200_1节拍',type:'string',width:120,align:'left'},
                       {field:'Op200_2Result',title:'Op200_2加工结果',type:'string',width:120,align:'left'},
                       {field:'Op200_2Time',title:'Op200_2加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op200_2Beat',title:'Op200_2节拍',type:'string',width:120,align:'left'},
                       {field:'Op200_2IV3Result',title:'Op200_2IV3结果',type:'string',width:120,align:'left'},
                       {field:'Op210Result',title:'Op210加工结果',type:'string',width:120,align:'left'},
                       {field:'Op210Time',title:'Op210加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op210Beat',title:'Op210节拍',type:'string',width:120,align:'left'},
                       {field:'Op210Torque',title:'Op210扭矩数据',type:'string',width:120,align:'left'},
                       {field:'Op210Angle',title:'Op210角度数据',type:'string',width:120,align:'left'},
                       {field:'Op210TorqueResult',title:'Op210扭矩结果',type:'string',width:120,align:'left'},
                       {field:'Op220Result',title:'Op220加工结果',type:'string',width:120,align:'left'},
                       {field:'Op220Time',title:'Op220加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op220Beat',title:'Op220节拍',type:'string',width:120,align:'left'},
                       {field:'Op220DisplaceResult',title:'Op220位移结果',type:'string',width:120,align:'left'},
                       {field:'Op220Displace',title:'Op220位移值',type:'string',width:120,align:'left'},
                       {field:'Op240_1Result',title:'Op240_1加工结果',type:'string',width:120,align:'left'},
                       {field:'Op240_1Time',title:'Op240_1加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op240_1Beat',title:'Op240_1节拍',type:'string',width:120,align:'left'},
                       {field:'Op240_2Result',title:'Op240_2加工结果',type:'string',width:120,align:'left'},
                       {field:'Op240_2Time',title:'Op240_2加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op240_2Beat',title:'Op240_2节拍',type:'string',width:120,align:'left'},
                       {field:'Op240_2Signal',title:'Op240_2结果信号',type:'string',width:120,align:'left'},
                       {field:'Op250_1Result',title:'Op250_1加工结果',type:'string',width:120,align:'left'},
                       {field:'Op250_1Time',title:'Op250_1加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op250_1Beat',title:'Op250_1节拍',type:'string',width:120,align:'left'},
                       {field:'Op250_2Result',title:'Op250_2加工结果',type:'string',width:120,align:'left'},
                       {field:'Op250_2Time',title:'Op250_2加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op250_2Beat',title:'Op250_2节拍',type:'string',width:120,align:'left'},
                       {field:'Op250_2Signal',title:'Op250_2信号结果',type:'string',width:120,align:'left'},
                       {field:'Op260Result',title:'Op260加工结果',type:'string',width:120,align:'left'},
                       {field:'Op260Time',title:'Op260加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op260Beat',title:'Op260节拍',type:'string',width:120,align:'left'},
                       {field:'Op270Result',title:'Op270加工结果',type:'string',width:120,align:'left'},
                       {field:'Op270Time',title:'Op270加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op270Beat',title:'Op270节拍',type:'string',width:120,align:'left'},
                       {field:'Op280Result',title:'Op280加工结果',type:'string',width:120,align:'left'},
                       {field:'Op280Time',title:'Op280加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op280Beat',title:'Op280节拍',type:'string',width:120,align:'left'},
                       {field:'Op280Torque',title:'Op280扭矩数据',type:'string',width:120,align:'left'},
                       {field:'Op280Angle',title:'Op280角度数据',type:'string',width:120,align:'left'},
                       {field:'Op280TorqueResult',title:'Op280扭矩结果',type:'string',width:120,align:'left'},
                       {field:'Op280Torque2',title:'Op280扭矩数据2',type:'string',width:120,align:'left'},
                       {field:'Op280Angle2',title:'Op280角度数据2',type:'string',width:120,align:'left'},
                       {field:'Op280TorqueResult2',title:'Op280扭矩结果2',type:'string',width:120,align:'left'},
                       {field:'Op280Torque3',title:'Op280扭矩数据3',type:'string',width:120,align:'left'},
                       {field:'Op280Angle3',title:'Op280角度数据3',type:'string',width:120,align:'left'},
                       {field:'Op280TorqueResult3',title:'Op280扭矩结果3',type:'string',width:120,align:'left'},
                       {field:'Op290_1Result',title:'Op290_1加工结果',type:'string',width:120,align:'left'},
                       {field:'Op290_1Time',title:'Op290_1加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op290_1Beat',title:'Op290_1节拍',type:'string',width:120,align:'left'},
                       {field:'Op290_2Result',title:'Op290_2加工结果',type:'string',width:120,align:'left'},
                       {field:'Op290_2Time',title:'Op290_2加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op290_2Beat',title:'Op290_2节拍',type:'string',width:120,align:'left'},
                       {field:'Op290_2Signal',title:'Op290_2信号结果',type:'string',width:120,align:'left'},
                       {field:'Op300_1Result',title:'Op300_1加工结果',type:'string',width:120,align:'left'},
                       {field:'Op300_1Time',title:'Op300_1加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op300_1Beat',title:'Op300_1节拍',type:'string',width:120,align:'left'},
                       {field:'Op300_2Result',title:'Op300_2加工结果',type:'string',width:120,align:'left'},
                       {field:'Op300_2Time',title:'Op300_2加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op300_2Beat',title:'Op300_2节拍',type:'string',width:120,align:'left'},
                       {field:'Op300_2Signal',title:'Op300_2信号结果',type:'string',width:120,align:'left'},
                       {field:'Op310_1Result',title:'Op310_1加工结果',type:'string',width:120,align:'left'},
                       {field:'Op310_1Time',title:'Op310_1加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op310_1Beat',title:'Op310_1节拍',type:'string',width:120,align:'left'},
                       {field:'Op310_2Result',title:'Op310_2加工结果',type:'string',width:120,align:'left'},
                       {field:'Op310_2Time',title:'Op310_2加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op310_2Beat',title:'Op310_2节拍',type:'string',width:120,align:'left'},
                       {field:'Op320Result',title:'Op320加工结果',type:'string',width:120,align:'left'},
                       {field:'Op320Time',title:'Op320加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op320Beat',title:'Op320节拍',type:'string',width:120,align:'left'},
                       {field:'Op320Torque',title:'Op320扭矩数据',type:'string',width:120,align:'left'},
                       {field:'Op320Angle',title:'Op320角度数据',type:'string',width:120,align:'left'},
                       {field:'Op320TorqueResult',title:'Op320扭矩结果',type:'string',width:120,align:'left'},
                       {field:'Op330Result',title:'Op330加工结果',type:'string',width:120,align:'left'},
                       {field:'Op330Time',title:'Op330加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op330Beat',title:'Op330节拍',type:'string',width:120,align:'left'},
                       {field:'Op340Result',title:'Op340加工结果',type:'string',width:120,align:'left'},
                       {field:'Op340Time',title:'Op340加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op340Beat',title:'Op340节拍',type:'string',width:120,align:'left'},
                       {field:'Op350Result',title:'Op350加工结果',type:'string',width:120,align:'left'},
                       {field:'Op350Time',title:'Op350加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op350Beat',title:'Op350节拍',type:'string',width:120,align:'left'},
                       {field:'Op360Result',title:'Op360加工结果',type:'string',width:120,align:'left'},
                       {field:'Op360Time',title:'Op360加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op360Beat',title:'Op360节拍',type:'string',width:120,align:'left'},
                       {field:'ModifyID',title:'修改ID',type:'int',width:120,hidden:true,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:120,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op200_2IV3File',title:'Op200_2IV3相机照片',type:'string',width:120,align:'left'},
                       {field:'Op230Result',title:'Op230_1加工结果',type:'string',width:120,align:'left'},
                       {field:'Op230Time',title:'Op230_1加工时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'Op230Beat',title:'Op230_1节拍',type:'string',width:120,align:'left'},
                       {field:'Op230Signal',title:'Op230_3信号结果',type:'string',width:120,align:'left'}]);
            const detail = ref({
                cnName: "#detailCnName",
                table: "#detailTable",
                columns: [],
                sortName: "",
                key: ""
            });
            return {
                table,
                extend,
                editFormFields,
                editFormOptions,
                searchFormFields,
                searchFormOptions,
                columns,
                detail,
            };
        },
    });
</script>
