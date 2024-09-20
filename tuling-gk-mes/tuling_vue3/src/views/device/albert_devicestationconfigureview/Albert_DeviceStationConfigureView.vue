<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/device/albert_devicestationconfigureview/Albert_DeviceStationConfigureView.js此处编写
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
    import extend from "@/extension/device/albert_devicestationconfigureview/Albert_DeviceStationConfigureView.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'DeviceDBPkInt',
                footer: "Foots",
                cnName: '设备工站查询',
                name: 'albert_devicestationconfigureview/Albert_DeviceStationConfigureView',
                url: "/Albert_DeviceStationConfigureView/",
                sortName: "DeviceDBPkInt"
            });
            const editFormFields = ref({});
            const editFormOptions = ref([]);
            const searchFormFields = ref({});
            const searchFormOptions = ref([]);
            const columns = ref([{field:'DeviceDBPkInt',title:'工站主键',type:'int',width:110,require:true,align:'left',sort:true},
                       {field:'DevicePkInt',title:'设备主键',type:'int',width:110,require:true,align:'left'},
                       {field:'DeviceDBSort',title:'工站排序',type:'int',width:110,require:true,align:'left'},
                       {field:'DeviceDBName',title:'工站名称',type:'string',width:120,require:true,align:'left'},
                       {field:'DeviceDBSubname',title:'工站别名',type:'string',width:120,align:'left'},
                       {field:'DeviceDBIsUse',title:'工站启用(Y/N)',type:'string',width:110,require:true,align:'left'},
                       {field:'DeviceDBStatus',title:'工站状态',type:'string',width:120,align:'left'},
                       {field:'DeviceDBRemark',title:'工站备注',type:'string',width:220,align:'left'},
                       {field:'DeviceDBStartTime',title:'工站开始运行时间',type:'datetime',width:150,align:'left',sort:true},
                       {field:'DeviceDBEndTime',title:'工站结束运行时间',type:'datetime',width:150,align:'left',sort:true},
                       {field:'CreateID',title:'创建ID',type:'int',width:100,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:100,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:150,require:true,align:'left',sort:true},
                       {field:'ModifyID',title:'修改ID',type:'int',width:100,hidden:true,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:100,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:150,require:true,align:'left',sort:true}]);
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
