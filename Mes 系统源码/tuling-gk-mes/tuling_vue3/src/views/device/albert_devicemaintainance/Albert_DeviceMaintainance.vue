<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/device/albert_devicemaintainance/Albert_DeviceMaintainance.js此处编写
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
    import extend from "@/extension/device/albert_devicemaintainance/Albert_DeviceMaintainance.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'MaintainancePkInt',
                footer: "Foots",
                cnName: '设备保养',
                name: 'albert_devicemaintainance/Albert_DeviceMaintainance',
                url: "/Albert_DeviceMaintainance/",
                sortName: "MaintainancePkInt"
            });
            const editFormFields = ref({"MaintainanceCode":"","MaintainanceName":"","MaintainanceStartDate":"","MaintainanceEndDate":"","MaintainanceCycleType":"","MaintainanceCycleCount":"","MaintainanceStatus":""});
            const editFormOptions = ref([[{"title":"保养编码","field":"MaintainanceCode","type":"text"},
                               {"title":"保养名称","required":true,"field":"MaintainanceName","type":"text"},
                               {"title":"保养开始时间","field":"MaintainanceStartDate","type":"datetime"},
                               {"title":"保养结束时间","field":"MaintainanceEndDate","type":"datetime"}],
                              [{"dataKey":"MaintainanceCycleType","data":[],"title":"保养周期类型","field":"MaintainanceCycleType","type":"select"},
                               {"title":"保养周期时间","field":"MaintainanceCycleCount","type":"decimal"},
                               {"title":"保养状态","field":"MaintainanceStatus","type":"text"}]]);
            const searchFormFields = ref({"MaintainanceCode":"","MaintainanceName":"","MaintainanceStartDate":"","MaintainanceEndDate":"","MaintainanceCycleType":"","MaintainanceCycleCount":"","MaintainanceStatus":""});
            const searchFormOptions = ref([[{"title":"保养编码","field":"MaintainanceCode","type":"like"},{"title":"保养名称","field":"MaintainanceName","type":"like"},{"title":"保养开始时间","field":"MaintainanceStartDate","type":"date"},{"title":"保养结束时间","field":"MaintainanceEndDate","type":"date"}],[{"dataKey":"MaintainanceCycleType","data":[],"title":"保养周期类型","field":"MaintainanceCycleType","type":"select"},{"title":"保养周期时间","field":"MaintainanceCycleCount","type":"decimal"},{"title":"保养状态","field":"MaintainanceStatus","type":"text"}]]);
            const columns = ref([{field:'MaintainancePkInt',title:'保养主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'MaintainanceCode',title:'保养编码',type:'string',sort:true,width:120,align:'left',sort:true},
                       {field:'MaintainanceName',title:'保养名称',type:'string',sort:true,width:120,require:true,align:'left'},
                       {field:'MaintainanceStartDate',title:'保养开始时间',type:'datetime',sort:true,width:130,align:'left',sort:true},
                       {field:'MaintainanceEndDate',title:'保养结束时间',type:'datetime',sort:true,width:130,align:'left',sort:true},
                       {field:'MaintainanceCycleType',title:'保养周期类型',type:'string',bind:{ key:'MaintainanceCycleType',data:[]},width:120,align:'left'},
                       {field:'MaintainanceCycleCount',title:'保养周期时间',type:'int',width:110,align:'left'},
                       {field:'MaintainanceStatus',title:'保养状态',type:'string',width:120,align:'left'},
                       {field:'CreateID',title:'创建ID',type:'int',width:100,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:100,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:130,require:true,align:'left',sort:true},
                       {field:'ModifyID',title:'修改ID',type:'int',width:100,hidden:true,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:100,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:130,require:true,align:'left',sort:true}]);
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
