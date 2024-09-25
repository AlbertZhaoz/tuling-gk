<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/basicdata/albert_basicworkshop/Albert_BasicWorkshop.js此处编写
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
    import extend from "@/extension/basicdata/albert_basicworkshop/Albert_BasicWorkshop.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'BasicWorkshopPkInt',
                footer: "Foots",
                cnName: '车间管理',
                name: 'albert_basicworkshop/Albert_BasicWorkshop',
                url: "/Albert_BasicWorkshop/",
                sortName: "BasicWorkshopPkInt"
            });
            const editFormFields = ref({"BasicWorkshopName":"","BasicWorkshopPrincipal":"","BasicWorkshopIsUse":"","BasicWorkshopArea":"","BasicWorkshopRemark":""});
            const editFormOptions = ref([[{"title":"车间名称","required":true,"field":"BasicWorkshopName","type":"text"},
                               {"title":"车间负责人","field":"BasicWorkshopPrincipal","type":"text"},
                               {"dataKey":"DeviceIsUse","data":[],"title":"车间是否启用","required":true,"field":"BasicWorkshopIsUse","type":"select"},
                               {"title":"车间面积(m2)","field":"BasicWorkshopArea","type":"decimal"}],
                              [{"title":"车间备注","field":"BasicWorkshopRemark","type":"text"}]]);
            const searchFormFields = ref({"BasicWorkshopCode":"","BasicWorkshopName":"","BasicWorkshopPrincipal":"","BasicWorkshopIsUse":""});
            const searchFormOptions = ref([[{"title":"车间编码","field":"BasicWorkshopCode","type":"like"},{"title":"车间名称","field":"BasicWorkshopName","type":"like"},{"title":"车间负责人","field":"BasicWorkshopPrincipal","type":"like"},{"dataKey":"DeviceIsUse","data":[],"title":"车间是否启用","field":"BasicWorkshopIsUse","type":"select"}]]);
            const columns = ref([{field:'BasicWorkshopPkInt',title:'车间主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'BasicWorkshopCode',title:'车间编码',type:'string',width:150,align:'left',sort:true},
                       {field:'BasicWorkshopName',title:'车间名称',type:'string',width:120,require:true,align:'left'},
                       {field:'PersonManagerPkInt',title:'人员管理主键',type:'int',width:110,align:'left'},
                       {field:'BasicWorkshopPrincipal',title:'车间负责人',type:'string',width:120,align:'left'},
                       {field:'BasicWorkshopIsUse',title:'车间是否启用',type:'string',bind:{ key:'DeviceIsUse',data:[]},width:110,require:true,align:'left'},
                       {field:'BasicWorkshopArea',title:'车间面积(m2)',type:'int',width:110,align:'left'},
                       {field:'BasicWorkshopRemark',title:'车间备注',type:'string',width:220,align:'left'},
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
