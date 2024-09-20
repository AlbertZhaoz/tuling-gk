<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/dataquery/albert_datafirst/Albert_DataFirst.js此处编写
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
    import extend from "@/extension/dataquery/albert_datafirst/Albert_DataFirst.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'DataPkInt',
                footer: "Foots",
                cnName: '环形1线',
                name: 'albert_datafirst/Albert_DataFirst',
                url: "/Albert_DataFirst/",
                sortName: "OpFinalDate"
            });
            const editFormFields = ref({});
            const editFormOptions = ref([]);
            const searchFormFields = ref({"ProductCode":"","ProductFunction":"","OpFinalResult":"","OpFinalStation":"","OpFinalDate":""});
            const searchFormOptions = ref([[{"title":"产品码(轴承)","field":"ProductCode","type":"like"},{"dataKey":"工作类型","data":[],"title":"工作类型","field":"ProductFunction","type":"select"},{"dataKey":"OKNG","data":[],"title":"最终结果","field":"OpFinalResult","type":"select"}],[{"title":"最终站","field":"OpFinalStation","type":"text"},{"title":"最终时间","field":"OpFinalDate","type":"datetime"}]]);
            const columns = ref([{field:'DataPkInt',title:'数据主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'WorkorderCode',title:'工单号',type:'string',width:150,hidden:true,align:'left'},
                       {field:'ProductCode',title:'产品码(轴承)',type:'string',width:150,require:true,align:'left',sort:true},
                       {field:'RFID',title:'RFID',type:'string',width:60,hidden:true,align:'left'},
                       {field:'ProductFunction',title:'工作类型',type:'string',bind:{ key:'工作类型',data:[]},width:120,align:'left'},
                       {field:'ProductContent',title:'工作内容',type:'string',width:120,hidden:true,align:'left'},
                       {field:'Op10WorkType',title:'预留',type:'string',width:120,hidden:true,align:'left'},
                       {field:'OpFinalResult',title:'最终结果',type:'string',bind:{ key:'OKNG',data:[]},width:80,align:'left'},
                       {field:'OpFinalStation',title:'最终站',type:'string',width:110,align:'left'},
                       {field:'OpFinalDate',title:'最终时间',type:'datetime',width:180,align:'left',sort:true},
                       {field:'Op10Result',title:'Op10加工结果',type:'string',width:110,align:'left'},
                       {field:'Op10Time',title:'Op10加工时间',type:'datetime',width:180,align:'left',sort:true},
                       {field:'Op10Beat',title:'Op10节拍',type:'string',width:120,align:'left'},
                       {field:'Op20Result',title:'Op20加工结果',type:'string',width:110,align:'left'},
                       {field:'Op20Time',title:'Op20加工时间',type:'datetime',width:180,align:'left',sort:true},
                       {field:'Op20Beat',title:'Op20节拍',type:'string',width:120,align:'left'},
                       {field:'Op30Result',title:'Op30加工结果',type:'string',width:110,align:'left'},
                       {field:'Op30Time',title:'Op30加工时间',type:'datetime',width:180,align:'left',sort:true},
                       {field:'Op30Beat',title:'Op30节拍',type:'string',width:120,align:'left'},
                       {field:'Op40Result',title:'Op40加工结果',type:'string',width:110,align:'left'},
                       {field:'Op40Time',title:'Op40加工时间',type:'datetime',width:180,align:'left',sort:true},
                       {field:'Op40Beat',title:'Op40节拍',type:'string',width:120,align:'left'},
                       {field:'Op50Result',title:'Op50加工结果',type:'string',width:110,align:'left'},
                       {field:'Op50Time',title:'Op50加工时间',type:'datetime',width:180,align:'left',sort:true},
                       {field:'Op50Beat',title:'Op50节拍',type:'string',width:120,align:'left'},
                       {field:'Op60Result',title:'Op60加工结果',type:'string',width:110,align:'left'},
                       {field:'Op60Time',title:'Op60加工时间',type:'datetime',width:180,align:'left',sort:true},
                       {field:'Op60Beat',title:'Op60节拍',type:'string',width:120,align:'left'},
                       {field:'Op60Pressure',title:'Op60压力数据',type:'string',width:110,align:'left'},
                       {field:'Op60PressureFile',title:'Op60压力文件',type:'string',width:120,align:'left'},
                       {field:'Op60IXResult',title:'Op60IX结果',type:'string',width:120,align:'left'},
                       {field:'Op60IXFile',title:'Op60IX照片',type:'string',width:120,align:'left'},
                       {field:'Op60IX5_1',title:'Op60IX5_1',type:'string',width:120,align:'left'},
                       {field:'Op60IX5_2',title:'Op60IX5_2',type:'string',width:120,align:'left'},
                       {field:'Op60IX5_3',title:'Op60IX5_3',type:'string',width:120,align:'left'},
                       {field:'Op60IX5_4',title:'Op60IX5_4',type:'string',width:120,align:'left'},
                       {field:'Op70Result',title:'Op70加工结果',type:'string',width:110,align:'left'},
                       {field:'Op70Time',title:'Op70加工时间',type:'datetime',width:180,align:'left',sort:true},
                       {field:'Op70Beat',title:'Op70节拍',type:'string',width:120,align:'left'},
                       {field:'Op80Result',title:'Op80加工结果',type:'string',width:110,align:'left'},
                       {field:'Op80Time',title:'Op80加工时间',type:'datetime',width:180,align:'left',sort:true},
                       {field:'Op80Beat',title:'Op80节拍',type:'string',width:120,align:'left'},
                       {field:'Op90Result',title:'Op90加工结果',type:'string',width:110,align:'left'},
                       {field:'Op90Time',title:'Op90加工时间',type:'datetime',width:180,align:'left',sort:true},
                       {field:'Op90DisplaceResult',title:'Op90位移结果',type:'string',width:120,align:'left'},
                       {field:'Op90DisplaceValue',title:'Op90位移值',type:'string',width:120,align:'left'},
                       {field:'Op90IV3Result',title:'Op90IV3结果',type:'string',width:120,align:'left'},
                       {field:'Op90IV3File',title:'Op90相机图片文件',type:'string',width:120,hidden:true,align:'left'},
                       {field:'Op90Beat',title:'Op90节拍',type:'string',width:120,align:'left'},
                       {field:'Op100Result',title:'Op100加工结果',type:'string',width:110,align:'left'},
                       {field:'Op100Time',title:'Op100加工时间',type:'datetime',width:180,align:'left',sort:true},
                       {field:'Op100Beat',title:'Op100节拍',type:'string',width:120,align:'left'},
                       {field:'Op110Result',title:'Op110加工结果',type:'string',width:110,align:'left'},
                       {field:'Op110Time',title:'Op110加工时间',type:'datetime',width:180,align:'left',sort:true},
                       {field:'Op110IV3File',title:'Op110相机图片文件',type:'string',width:120,hidden:true,align:'left'},
                       {field:'Op110Beat',title:'Op110节拍',type:'string',width:120,align:'left'},
                       {field:'Op110IV3Result',title:'Op110相机结果',type:'string',width:120,align:'left'},
                       {field:'Op120Result',title:'Op120加工结果',type:'string',width:110,align:'left'},
                       {field:'Op120Time',title:'Op120加工时间',type:'datetime',width:180,align:'left',sort:true},
                       {field:'Op120TorqueResult',title:'Op120扭矩结果',type:'string',width:120,align:'left'},
                       {field:'Op120TorqueList',title:'Op120扭矩曲线数据',type:'string',width:120,align:'left'},
                       {field:'Op120MaxFirstHalf',title:'Op120前半程最大值',type:'string',width:120,align:'left'},
                       {field:'Op120MinFirstHalf',title:'Op120前半程最小值',type:'string',width:120,align:'left'},
                       {field:'Op120AverageFirstHalf',title:'Op120前半程平均值',type:'string',width:120,align:'left'},
                       {field:'Op120MaxSecondHalf',title:'Op120后半程最大值',type:'string',width:120,align:'left'},
                       {field:'Op120MinSecondHalf',title:'Op120后半程最小值',type:'string',width:120,align:'left'},
                       {field:'Op120AverageSecondHalf',title:'Op120后半程平均值',type:'string',width:120,align:'left'},
                       {field:'Op120IV3File',title:'Op120相机照片',type:'string',width:120,align:'left'},
                       {field:'Op120Beat',title:'Op120节拍',type:'string',width:120,align:'left'},
                       {field:'Op130Result',title:'Op130加工结果',type:'string',width:110,align:'left'},
                       {field:'Op130Time',title:'Op130加工时间',type:'datetime',width:180,align:'left',sort:true},
                       {field:'Op130Beat',title:'Op130节拍',type:'string',width:120,align:'left'},
                       {field:'Op140Result',title:'Op140加工结果',type:'string',width:120,hidden:true,align:'left'},
                       {field:'Op140Time',title:'Op140加工时间',type:'datetime',width:180,hidden:true,align:'left',sort:true},
                       {field:'Op140Beat',title:'Op140节拍',type:'string',width:120,hidden:true,align:'left'},
                       {field:'ModifyID',title:'修改ID',type:'int',width:100,hidden:true,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:100,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:180,align:'left',sort:true}]);
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
