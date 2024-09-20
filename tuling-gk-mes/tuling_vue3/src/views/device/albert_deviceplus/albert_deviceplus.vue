<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/device/albert_deviceplus/albert_deviceplus.js此处编写
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
    import extend from "@/extension/device/albert_deviceplus/albert_deviceplus.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'Id',
                footer: "Foots",
                cnName: '设备增强表',
                name: 'albert_deviceplus/albert_deviceplus',
                url: "/albert_deviceplus/",
                sortName: "Id"
            });
            const editFormFields = ref({"DeviceName":"","DeviceIp":""});
            const editFormOptions = ref([[{"title":"设备名称","required":true,"field":"DeviceName","type":"text"},
                               {"title":"设备IP","field":"DeviceIp","type":"text"}]]);
            const searchFormFields = ref({"DeviceName":"","DeviceIp":""});
            const searchFormOptions = ref([[{"title":"设备名称","field":"DeviceName","type":"like"},{"title":"设备IP","field":"DeviceIp","type":"like"}]]);
            const columns = ref([{field:'Id',title:'主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'DeviceName',title:'设备名称',type:'string',width:110,require:true,align:'left',sort:true},
                       {field:'DeviceIp',title:'设备IP',type:'string',width:110,align:'left'}]);
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
