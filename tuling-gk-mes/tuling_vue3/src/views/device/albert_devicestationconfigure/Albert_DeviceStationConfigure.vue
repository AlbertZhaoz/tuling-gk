<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/device/albert_devicestationconfigure/Albert_DeviceStationConfigure.js此处编写
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
    import extend from "@/extension/device/albert_devicestationconfigure/Albert_DeviceStationConfigure.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'DeviceDBPkInt',
                footer: "Foots",
                cnName: '设备工站',
                name: 'albert_devicestationconfigure/Albert_DeviceStationConfigure',
                url: "/Albert_DeviceStationConfigure/",
                sortName: "DeviceDBSort"
            });
            const editFormFields = ref({"DeviceDBSort":"","DeviceDBName":"","DeviceDBSubname":"","DeviceDBIsUse":"","DeviceDBStatus":"","DeviceDBRemark":"","DeviceDBStartTime":"","DeviceDBEndTime":""});
            const editFormOptions = ref([[{"title":"工站排序","required":true,"field":"DeviceDBSort","type":"number"},
                               {"title":"工站名称","required":true,"field":"DeviceDBName","type":"text"},
                               {"title":"工站别名","field":"DeviceDBSubname","type":"text"},
                               {"dataKey":"DeviceIsUse","data":[],"title":"工站启用(Y/N)","required":true,"field":"DeviceDBIsUse","type":"select"}],
                              [{"dataKey":"DeviceStatus","data":[],"title":"工站状态","field":"DeviceDBStatus","type":"select"},
                               {"title":"工站备注","field":"DeviceDBRemark","type":"text"},
                               {"title":"工站开始运行时间","field":"DeviceDBStartTime","type":"datetime"},
                               {"title":"工站结束运行时间","field":"DeviceDBEndTime","type":"datetime"}]]);
            const searchFormFields = ref({"DeviceDBSort":"","DeviceDBName":""});
            const searchFormOptions = ref([[{"title":"工站排序","field":"DeviceDBSort","type":"number"},{"title":"工站名称","field":"DeviceDBName","type":"text"}]]);
            const columns = ref([{field:'DeviceDBPkInt',title:'工站主键',type:'int',width:120,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'DevicePkInt',title:'设备主键',type:'int',width:120,hidden:true,require:true,align:'left'},
                       {field:'DeviceDBSort',title:'工站排序',type:'int',width:120,require:true,align:'left',sort:true},
                       {field:'DeviceDBName',title:'工站名称',type:'string',width:120,require:true,align:'left'},
                       {field:'DeviceDBSubname',title:'工站别名',type:'string',width:120,align:'left'},
                       {field:'DeviceDBIsUse',title:'工站启用(Y/N)',type:'string',bind:{ key:'DeviceIsUse',data:[]},width:120,require:true,align:'left'},
                       {field:'DeviceDBStatus',title:'工站状态',type:'string',bind:{ key:'DeviceStatus',data:[]},width:120,align:'left'},
                       {field:'DeviceDBRemark',title:'工站备注',type:'string',width:120,align:'left'},
                       {field:'DeviceDBStartTime',title:'工站开始运行时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'DeviceDBEndTime',title:'工站结束运行时间',type:'datetime',width:120,align:'left',sort:true},
                       {field:'CreateID',title:'创建ID',type:'int',width:120,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:120,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:120,require:true,align:'left',sort:true},
                       {field:'ModifyID',title:'修改ID',type:'int',width:120,hidden:true,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:120,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:120,require:true,align:'left',sort:true}]);
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
