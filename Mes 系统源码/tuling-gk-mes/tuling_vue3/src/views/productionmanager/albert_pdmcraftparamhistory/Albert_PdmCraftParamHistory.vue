<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/productionmanager/albert_pdmcraftparamhistory/Albert_PdmCraftParamHistory.js此处编写
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
    import extend from "@/extension/productionmanager/albert_pdmcraftparamhistory/Albert_PdmCraftParamHistory.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'PdmCraftParamHistoryPkInt',
                footer: "Foots",
                cnName: '工艺参数下发历史',
                name: 'albert_pdmcraftparamhistory/Albert_PdmCraftParamHistory',
                url: "/Albert_PdmCraftParamHistory/",
                sortName: "PdmCraftParamHistoryPkInt"
            });
            const editFormFields = ref({});
            const editFormOptions = ref([]);
            const searchFormFields = ref({"CraftPkInt":"","ParamName":""});
            const searchFormOptions = ref([[{"dataKey":"工艺名称","data":[],"title":"工艺编码","field":"CraftPkInt","type":"select"},{"title":"参数名","field":"ParamName","type":"like"}]]);
            const columns = ref([{field:'PdmCraftParamHistoryPkInt',title:'工艺参数下发历史主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'CraftParamPkInt',title:'上下限参数主键',type:'int',width:110,hidden:true,align:'left'},
                       {field:'CraftPkInt',title:'工艺编码',type:'int',bind:{ key:'工艺名称',data:[]},width:110,hidden:true,align:'left'},
                       {field:'ParamName',title:'参数名',type:'string',width:120,align:'left',sort:true},
                       {field:'ParamValue',title:'参数值',type:'string',width:120,align:'left'},
                       {field:'IsEnable',title:'是否启用',type:'string',width:110,align:'left'},
                       {field:'Status',title:'下发状态',type:'string',width:110,align:'left'},
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
