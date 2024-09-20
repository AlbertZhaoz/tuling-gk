<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/device/albert_devicedatatype/Albert_DeviceDataType.js此处编写
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
    import extend from "@/extension/device/albert_devicedatatype/Albert_DeviceDataType.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'DeviceDataTypePkInt',
                footer: "Foots",
                cnName: '设备数据类型',
                name: 'albert_devicedatatype/Albert_DeviceDataType',
                url: "/Albert_DeviceDataType/",
                sortName: "DeviceDataTypePkInt"
            });
            const editFormFields = ref({"DeviceDataTypeName":"","DeviceDataTypeIsUse":"","DeviceDataTypeRemark":""});
            const editFormOptions = ref([[{"title":"设备数据类型名字","field":"DeviceDataTypeName","type":"text"},
                               {"dataKey":"DeviceIsUse","data":[],"title":"设备数据类型启用(Y/N)","required":true,"field":"DeviceDataTypeIsUse","type":"select"},
                               {"title":"设备数据类型备注","field":"DeviceDataTypeRemark","type":"text"}]]);
            const searchFormFields = ref({"DeviceDataTypeName":"","DeviceDataTypeIsUse":"","DeviceDataTypeRemark":""});
            const searchFormOptions = ref([[{"title":"设备数据类型名字","field":"DeviceDataTypeName","type":"like"},{"dataKey":"DeviceIsUse","data":[],"title":"设备数据类型启用(Y/N)","field":"DeviceDataTypeIsUse","type":"select"},{"title":"设备数据类型备注","field":"DeviceDataTypeRemark","type":"like"}]]);
            const columns = ref([{field:'DeviceDataTypePkInt',title:'设备数据类型主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'DeviceDataTypeName',title:'设备数据类型名字',type:'string',width:160,align:'left',sort:true},
                       {field:'DeviceDataTypeIsUse',title:'设备数据类型启用(Y/N)',type:'string',bind:{ key:'DeviceIsUse',data:[]},width:160,require:true,align:'left'},
                       {field:'DeviceDataTypeRemark',title:'设备数据类型备注',type:'string',width:220,align:'left'},
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
