<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/productionmanager/albert_craftparam/Albert_CraftParam.js此处编写
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
    import extend from "@/extension/productionmanager/albert_craftparam/Albert_CraftParam.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'CraftParamPkInt',
                footer: "Foots",
                cnName: '上下限设置',
                name: 'albert_craftparam/Albert_CraftParam',
                url: "/Albert_CraftParam/",
                sortName: "CraftParamPkInt"
            });
            const editFormFields = ref({"ParamName":"","ParamValue":"","IsEnable":""});
            const editFormOptions = ref([[{"title":"参数名","field":"ParamName","type":"text"},
                               {"title":"参数值","field":"ParamValue","type":"text"},
                               {"dataKey":"DeviceIsUse","data":[],"title":"是否启用","field":"IsEnable","type":"select"}]]);
            const searchFormFields = ref({});
            const searchFormOptions = ref([]);
            const columns = ref([{field:'CraftParamPkInt',title:'上下限参数主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'CraftPkInt',title:'工艺编码',type:'int',width:110,hidden:true,align:'left'},
                       {field:'ParamName',title:'参数名',type:'string',width:120,align:'left',sort:true},
                       {field:'ParamValue',title:'参数值',type:'string',width:120,align:'left'},
                       {field:'IsEnable',title:'是否启用',type:'string',bind:{ key:'DeviceIsUse',data:[]},width:110,align:'left'},
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
