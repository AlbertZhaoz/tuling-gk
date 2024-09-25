<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/device/albert_devicerepairlist/Albert_DeviceRepairList.js此处编写
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
    import extend from "@/extension/device/albert_devicerepairlist/Albert_DeviceRepairList.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'RepairListPkInt',
                footer: "Foots",
                cnName: '设备维修列表',
                name: 'albert_devicerepairlist/Albert_DeviceRepairList',
                url: "/Albert_DeviceRepairList/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"DevicePkInt":"","DeviceCode":"","DeviceName":"","DeivceSubname":"","DeviceType":"","DeivceRemark":"","Workshop":"","Brand":""});
            const editFormOptions = ref([[{"title":"设备编码","field":"DeviceCode","disabled":true,"type":"text"},
                               {"title":"设备主键","required":true,"field":"DevicePkInt","disabled":true,"type":"number"},
                               {"title":"设备名称","required":true,"field":"DeviceName","disabled":true,"type":"text"},
                               {"title":"设备别名","field":"DeivceSubname","disabled":true,"type":"text"}],
                              [{"dataKey":"DeviceType","data":[],"title":"设备类型","field":"DeviceType","disabled":true,"type":"select"},
                               {"title":"设备备注","field":"DeivceRemark","disabled":true,"type":"text"},
                               {"dataKey":"BasicWorkshop","data":[],"title":"所属车间","field":"Workshop","disabled":true,"type":"select"},
                               {"dataKey":"Brand","data":[],"title":"品牌","field":"Brand","disabled":true,"type":"select"}]]);
            const searchFormFields = ref({"DeviceCode":"","DeviceName":""});
            const searchFormOptions = ref([[{"title":"设备编码","field":"DeviceCode","type":"like"},{"title":"设备名称","field":"DeviceName","type":"like"}]]);
            const columns = ref([{field:'RepairListPkInt',title:'维修列表主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'RepairPkInt',title:'维修主键',type:'int',width:110,readonly:true,require:true,align:'left',sort:true},
                       {field:'DevicePkInt',title:'设备主键',type:'int',width:110,readonly:true,require:true,align:'left'},
                       {field:'DeviceCode',title:'设备编码',type:'string',sort:true,width:120,readonly:true,align:'left'},
                       {field:'DeviceName',title:'设备名称',type:'string',sort:true,width:120,readonly:true,require:true,align:'left'},
                       {field:'DeivceSubname',title:'设备别名',type:'string',width:120,readonly:true,align:'left'},
                       {field:'DeviceType',title:'设备类型',type:'string',bind:{ key:'DeviceType',data:[]},width:120,readonly:true,align:'left'},
                       {field:'DeivceRemark',title:'设备备注',type:'string',width:220,readonly:true,align:'left'},
                       {field:'Workshop',title:'所属车间',type:'string',bind:{ key:'BasicWorkshop',data:[]},width:120,readonly:true,align:'left'},
                       {field:'Brand',title:'品牌',type:'string',bind:{ key:'Brand',data:[]},width:120,readonly:true,align:'left'},
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
