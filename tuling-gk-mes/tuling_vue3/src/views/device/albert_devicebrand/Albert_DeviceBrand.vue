<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/device/albert_devicebrand/Albert_DeviceBrand.js此处编写
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
    import extend from "@/extension/device/albert_devicebrand/Albert_DeviceBrand.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'DeviceBrandPkInt',
                footer: "Foots",
                cnName: '设备品牌',
                name: 'albert_devicebrand/Albert_DeviceBrand',
                url: "/Albert_DeviceBrand/",
                sortName: "DeviceBrandPkInt"
            });
            const editFormFields = ref({"DeviceBrandName":"","DeviceBrandIsUse":"","DeviceBrandRemark":""});
            const editFormOptions = ref([[{"title":"设备品牌名字","required":true,"field":"DeviceBrandName","type":"text"},
                               {"dataKey":"DeviceIsUse","data":[],"title":"设备品牌启用(Y/N)","required":true,"field":"DeviceBrandIsUse","type":"select"},
                               {"title":"设备品牌备注","field":"DeviceBrandRemark","type":"text"}]]);
            const searchFormFields = ref({"DeviceBrandName":"","DeviceBrandIsUse":"","DeviceBrandRemark":""});
            const searchFormOptions = ref([[{"title":"设备品牌名字","field":"DeviceBrandName","type":"text"},{"dataKey":"DeviceIsUse","data":[],"title":"设备品牌启用(Y/N)","field":"DeviceBrandIsUse","type":"select"},{"title":"设备品牌备注","field":"DeviceBrandRemark","type":"like"}]]);
            const columns = ref([{field:'DeviceBrandPkInt',title:'设备品牌主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'DeviceBrandName',title:'设备品牌名字',type:'string',sort:true,width:120,require:true,align:'left',sort:true},
                       {field:'DeviceBrandIsUse',title:'设备品牌启用(Y/N)',type:'string',bind:{ key:'DeviceIsUse',data:[]},width:110,require:true,align:'left'},
                       {field:'DeviceBrandRemark',title:'设备品牌备注',type:'string',width:220,align:'left'},
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
