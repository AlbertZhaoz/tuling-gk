<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/productionmanager/albert_craft/Albert_Craft.js此处编写
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
    import extend from "@/extension/productionmanager/albert_craft/Albert_Craft.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'CraftPkInt',
                footer: "Foots",
                cnName: '工艺管理',
                name: 'albert_craft/Albert_Craft',
                url: "/Albert_Craft/",
                sortName: "CraftCode"
            });
            const editFormFields = ref({"CraftCode":"","CraftName":"","CraftIsUse":"","CraftRemark":""});
            const editFormOptions = ref([[{"title":"工艺编码","required":true,"field":"CraftCode","disabled":true,"type":"text"},
                               {"title":"工艺名称","required":true,"field":"CraftName","type":"text"},
                               {"dataKey":"DeviceIsUse","data":[],"title":"工艺启用(Y/N)","required":true,"field":"CraftIsUse","type":"select"},
                               {"title":"工艺备注","field":"CraftRemark","type":"text"}]]);
            const searchFormFields = ref({"CraftCode":"","CraftName":"","CraftIsUse":"","CraftRemark":""});
            const searchFormOptions = ref([[{"title":"工艺编码","field":"CraftCode","type":"text"},{"title":"工艺名称","field":"CraftName","type":"text"},{"dataKey":"DeviceIsUse","data":[],"title":"工艺启用(Y/N)","field":"CraftIsUse","type":"select"},{"title":"工艺备注","field":"CraftRemark","type":"text"}]]);
            const columns = ref([{field:'CraftPkInt',title:'工艺主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'CraftCode',title:'工艺编码',type:'string',width:120,readonly:true,require:true,align:'left',sort:true},
                       {field:'CraftName',title:'工艺名称',type:'string',width:120,require:true,align:'left'},
                       {field:'CraftIsUse',title:'工艺启用(Y/N)',type:'string',bind:{ key:'DeviceIsUse',data:[]},width:50,require:true,align:'left'},
                       {field:'CraftRemark',title:'工艺备注',type:'string',width:50,align:'left'},
                       {field:'CreateID',title:'创建ID',type:'int',width:100,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:100,hidden:true,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:150,hidden:true,require:true,align:'left',sort:true},
                       {field:'ModifyID',title:'修改ID',type:'int',width:100,hidden:true,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:100,hidden:true,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:150,hidden:true,require:true,align:'left',sort:true}]);
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
