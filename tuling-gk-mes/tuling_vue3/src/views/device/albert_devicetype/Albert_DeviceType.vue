<!--
*Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/device/albert_devicetype/Albert_DeviceType.js此处编写
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
    import extend from "@/extension/device/albert_devicetype/Albert_DeviceType.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'DeviceTypePkInt',
                footer: "Foots",
                cnName: '设备类型',
                name: 'albert_devicetype/Albert_DeviceType',
                url: "/Albert_DeviceType/",
                sortName: "DeviceTypePkInt"
            });
            const editFormFields = ref({"DeviceType":""});
            const editFormOptions = ref([[{"title":"设备类型","required":true,"field":"DeviceType","type":"text"}]]);
            const searchFormFields = ref({"DeviceType":""});
            const searchFormOptions = ref([[{"title":"设备类型","field":"DeviceType","type":"like"}]]);
            const columns = ref([{field:'DeviceTypePkInt',title:'设备类型主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'DeviceType',title:'设备类型',type:'string',width:120,require:true,align:'left',sort:true},
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
