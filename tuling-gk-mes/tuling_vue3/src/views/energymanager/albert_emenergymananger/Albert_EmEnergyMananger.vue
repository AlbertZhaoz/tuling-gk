<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/energymanager/albert_emenergymananger/Albert_EmEnergyMananger.js此处编写
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
    import extend from "@/extension/energymanager/albert_emenergymananger/Albert_EmEnergyMananger.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'EmEnergyManangerPkInt',
                footer: "Foots",
                cnName: '能耗管控',
                name: 'albert_emenergymananger/Albert_EmEnergyMananger',
                url: "/Albert_EmEnergyMananger/",
                sortName: "EmEnergyManangerPkInt"
            });
            const editFormFields = ref({"Name":"","ElectricOrGas":""});
            const editFormOptions = ref([[{"title":"能控名称","field":"Name","type":"text"},
                               {"dataKey":"电表/气表","data":[],"title":"电表/气表","field":"ElectricOrGas","type":"select"}]]);
            const searchFormFields = ref({});
            const searchFormOptions = ref([]);
            const columns = ref([{field:'EmEnergyManangerPkInt',title:'能耗管理主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'Name',title:'能控名称',type:'string',width:120,align:'left',sort:true},
                       {field:'ElectricOrGas',title:'电表/气表',type:'string',bind:{ key:'电表/气表',data:[]},width:120,align:'left'},
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
