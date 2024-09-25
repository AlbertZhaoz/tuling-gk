<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/device/albert_devicerepair/Albert_DeviceRepair.js此处编写
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
    import extend from "@/extension/device/albert_devicerepair/Albert_DeviceRepair.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'RepairPkInt',
                footer: "Foots",
                cnName: '设备维修',
                name: 'albert_devicerepair/Albert_DeviceRepair',
                url: "/Albert_DeviceRepair/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"RepairCode":"","RepairName":"","RepairStartDate":"","RepairEndDate":"","RepairCycleType":"","RepairStatus":""});
            const editFormOptions = ref([[{"title":"维修编码","field":"RepairCode","disabled":true},
                               {"title":"维修名称","required":true,"field":"RepairName","type":"text"},
                               {"title":"维修开始时间","field":"RepairStartDate","type":"datetime"},
                               {"title":"维修结束时间","field":"RepairEndDate","type":"datetime"}],
                              [{"title":"维修人员","field":"RepairCycleType","type":"text"},
                               {"title":"维修状态","field":"RepairStatus","type":"text"}]]);
            const searchFormFields = ref({"RepairCode":"","RepairName":"","RepairStartDate":"","RepairEndDate":"","RepairCycleType":"","RepairStatus":""});
            const searchFormOptions = ref([[{"title":"维修编码","field":"RepairCode","type":"like"},{"title":"维修名称","field":"RepairName","type":"like"},{"title":"维修开始时间","field":"RepairStartDate","type":"date"},{"title":"维修结束时间","field":"RepairEndDate","type":"date"}],[{"title":"维修人员","field":"RepairCycleType","type":"text"},{"title":"维修状态","field":"RepairStatus","type":"text"}]]);
            const columns = ref([{field:'RepairPkInt',title:'维修主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'RepairCode',title:'维修编码',type:'string',sort:true,width:120,readonly:true,align:'left',sort:true},
                       {field:'RepairName',title:'维修名称',type:'string',width:120,require:true,align:'left'},
                       {field:'RepairStartDate',title:'维修开始时间',type:'datetime',sort:true,width:130,align:'left',sort:true},
                       {field:'RepairEndDate',title:'维修结束时间',type:'datetime',width:130,align:'left',sort:true},
                       {field:'RepairCycleType',title:'维修人员',type:'string',width:120,align:'left'},
                       {field:'RepairStatus',title:'维修状态',type:'string',width:120,align:'left'},
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
