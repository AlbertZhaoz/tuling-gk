<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/dataquery/albert_datafirstreworkview/Albert_DataFirstReworkView.js此处编写
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
    import extend from "@/extension/dataquery/albert_datafirstreworkview/Albert_DataFirstReworkView.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'DataFirstReworkPkInt',
                footer: "Foots",
                cnName: '环形1线返工配置',
                name: 'albert_datafirstreworkview/Albert_DataFirstReworkView',
                url: "/Albert_DataFirstReworkView/",
                sortName: "ModifyDate"
            });
            const editFormFields = ref({});
            const editFormOptions = ref([]);
            const searchFormFields = ref({});
            const searchFormOptions = ref([]);
            const columns = ref([{field:'DataFirstReworkPkInt',title:'环形1线返工主键',type:'int',width:110,hidden:true,require:true,align:'left'},
                       {field:'ProductCode',title:'产品码',type:'string',width:110,require:true,align:'left',sort:true},
                       {field:'OpFinalResult',title:'最终结果',type:'string',width:110,align:'left'},
                       {field:'OpFinalStation',title:'最终站',type:'string',width:110,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',sort:true,width:150,require:true,align:'left',sort:true}]);
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
