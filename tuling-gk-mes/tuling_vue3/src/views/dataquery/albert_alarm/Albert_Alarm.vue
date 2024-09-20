<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/dataquery/albert_alarm/Albert_Alarm.js此处编写
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
    import extend from "@/extension/dataquery/albert_alarm/Albert_Alarm.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'AlarmPkInt',
                footer: "Foots",
                cnName: '报警记录查询',
                name: 'albert_alarm/Albert_Alarm',
                url: "/Albert_Alarm/",
                sortName: "AlarmPkInt"
            });
            const editFormFields = ref({"AlarmStatus":""});
            const editFormOptions = ref([[{"dataKey":"消警状态","data":[],"title":"报警消除","field":"AlarmStatus","type":"select"}]]);
            const searchFormFields = ref({"DeviceCode":"","AlarmType":"","AlarmStartTime":"","AlarmEndTime":""});
            const searchFormOptions = ref([[{"title":"设备编码","field":"DeviceCode","type":"text"},{"title":"报警类型","field":"AlarmType","type":"text"},{"title":"报警开始时间","field":"AlarmStartTime","type":"datetime"},{"title":"报警结束时间","field":"AlarmEndTime","type":"datetime"}]]);
            const columns = ref([{field:'AlarmPkInt',title:'报警主键',type:'int',width:120,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'DevicePkInt',title:'设备主键',type:'int',width:120,align:'left',sort:true},
                       {field:'DeviceCode',title:'设备编码',type:'string',width:120,align:'left'},
                       {field:'DeviceName',title:'设备名称',type:'string',width:120,align:'left'},
                       {field:'AlarmType',title:'报警类型',type:'string',sort:true,width:120,align:'left'},
                       {field:'AlarmStartTime',title:'报警开始时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'AlarmEndTime',title:'报警结束时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'AlarmNote',title:'报警备注',type:'string',width:120,align:'left'},
                       {field:'AlarmStatus',title:'报警消除',type:'string',bind:{ key:'消警状态',data:[]},width:120,align:'left'}]);
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
