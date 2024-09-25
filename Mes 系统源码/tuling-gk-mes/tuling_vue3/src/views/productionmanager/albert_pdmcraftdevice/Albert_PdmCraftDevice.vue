<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/productionmanager/albert_pdmcraftdevice/Albert_PdmCraftDevice.js此处编写
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
    import extend from "@/extension/productionmanager/albert_pdmcraftdevice/Albert_PdmCraftDevice.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'PdmCraftDevicePkInt',
                footer: "Foots",
                cnName: '工艺设备',
                name: 'albert_pdmcraftdevice/Albert_PdmCraftDevice',
                url: "/Albert_PdmCraftDevice/",
                sortName: "CraftSort"
            });
            const editFormFields = ref({"CraftPkInt":"","CraftSort":"","DeviceDBName":"","DeviceDBSubname":""});
            const editFormOptions = ref([[{"title":"工艺主键","required":true,"field":"CraftPkInt","disabled":true,"type":"number"},
                               {"title":"工艺排序","required":true,"field":"CraftSort","disabled":true,"type":"text"},
                               {"title":"工站名称","required":true,"field":"DeviceDBName","disabled":true,"type":"text"},
                               {"title":"工站别名","required":true,"field":"DeviceDBSubname","disabled":true,"type":"text"}]]);
            const searchFormFields = ref({});
            const searchFormOptions = ref([]);
            const columns = ref([{field:'PdmCraftDevicePkInt',title:'工艺设备主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'CraftPkInt',title:'工艺主键',type:'int',width:120,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'CraftSort',title:'工艺排序',type:'int',width:110,readonly:true,require:true,align:'left',sort:true},
                       {field:'DevicePkInt',title:'设备主键',type:'int',width:110,hidden:true,readonly:true,align:'left'},
                       {field:'DeviceDBPkInt',title:'工站主键',type:'int',width:120,hidden:true,readonly:true,align:'left'},
                       {field:'DeviceDBName',title:'工站名称',type:'string',width:120,readonly:true,require:true,align:'left'},
                       {field:'DeviceDBSubname',title:'工站别名',type:'string',width:120,readonly:true,require:true,align:'left'},
                       {field:'DeviceDBIsUse',title:'工站启用(Y/N)',type:'string',width:120,readonly:true,align:'left'},
                       {field:'DeviceDBStatus',title:'工站状态',type:'string',width:120,hidden:true,readonly:true,align:'left'},
                       {field:'DeviceDBStartTime',title:'工站开始时间',type:'datetime',width:120,hidden:true,readonly:true,align:'left',sort:true},
                       {field:'DeviceDBEndTime',title:'工站结束时间',type:'datetime',width:120,hidden:true,readonly:true,align:'left',sort:true},
                       {field:'DeviceDBRemark',title:'工站备注',type:'string',width:120,hidden:true,readonly:true,align:'left'},
                       {field:'ProductBeat',title:'产线节拍',type:'decimal',width:120,hidden:true,align:'left'},
                       {field:'ProductQuantity',title:'产线产量',type:'int',width:120,hidden:true,align:'left'},
                       {field:'IsRepairStatus',title:'维修状态',type:'string',bind:{ key:'维修状态',data:[]},width:120,hidden:true,align:'left'},
                       {field:'IsRepairStartTime',title:'维修开始时间',type:'datetime',width:120,hidden:true,align:'left',sort:true},
                       {field:'IsRepairEndTime',title:'维修结束时间',type:'datetime',width:120,hidden:true,align:'left',sort:true},
                       {field:'IsRepairPerson',title:'维修人员',type:'string',width:120,hidden:true,align:'left'},
                       {field:'IsMaintainanceStatus',title:'保养状态',type:'string',bind:{ key:'保养状态',data:[]},width:120,hidden:true,align:'left'},
                       {field:'IsMaintainanceStartTime',title:'保养开始时间',type:'datetime',width:120,hidden:true,align:'left',sort:true},
                       {field:'IsMaintainanceEndTime',title:'保养结束时间',type:'datetime',width:120,hidden:true,align:'left',sort:true},
                       {field:'IsMaintainancePerson',title:'保养人员',type:'string',width:120,hidden:true,align:'left'},
                       {field:'CreateID',title:'创建ID',type:'int',width:100,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:100,hidden:true,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:150,hidden:true,require:true,align:'left',sort:true},
                       {field:'ModifyID',title:'修改ID',type:'int',width:100,hidden:true,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:100,hidden:true,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:150,hidden:true,require:true,align:'left',sort:true}]);
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
