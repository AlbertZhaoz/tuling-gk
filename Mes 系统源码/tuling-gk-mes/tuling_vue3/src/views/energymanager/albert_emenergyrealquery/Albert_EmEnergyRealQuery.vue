<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/energymanager/albert_emenergyrealquery/Albert_EmEnergyRealQuery.js此处编写
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
    import extend from "@/extension/energymanager/albert_emenergyrealquery/Albert_EmEnergyRealQuery.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'EmEnergyRealQueryPkInt',
                footer: "Foots",
                cnName: '能耗实时采集',
                name: 'albert_emenergyrealquery/Albert_EmEnergyRealQuery',
                url: "/Albert_EmEnergyRealQuery/",
                sortName: "EmEnergyRealQueryPkInt"
            });
            const editFormFields = ref({});
            const editFormOptions = ref([]);
            const searchFormFields = ref({});
            const searchFormOptions = ref([[{"dataKey":"电表/气表","data":[],"title":"电表/气表","field":"ElectricOrGas","type":"select"}]]);
            const columns = ref([{field:'EmEnergyRealQueryPkInt',title:'能耗实时采集主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'EmEnergyManangerPkInt',title:'能耗管理主键',type:'int',width:120,hidden:true,align:'left'},
                       {field:'Name',title:'能控名称',type:'string',width:120,align:'left',sort:true},
                       {field:'ElectricOrGas',title:'电表/气表',type:'string',bind:{ key:'电表/气表',data:[]},width:120,align:'left'},
                       {field:'ActualValue',title:'实际消耗值',type:'decimal',width:110,align:'left'},
                       {field:'ActualTime',title:'实际采集时间',type:'datetime',width:150,align:'left',sort:true}]);
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
