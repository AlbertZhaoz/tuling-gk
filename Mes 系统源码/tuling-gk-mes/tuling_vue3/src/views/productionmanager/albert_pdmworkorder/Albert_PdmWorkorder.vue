<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/productionmanager/albert_pdmworkorder/Albert_PdmWorkorder.js此处编写
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
    import extend from "@/extension/productionmanager/albert_pdmworkorder/Albert_PdmWorkorder.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'WorkorderPkInt',
                footer: "Foots",
                cnName: '工单管理',
                name: 'albert_pdmworkorder/Albert_PdmWorkorder',
                url: "/Albert_PdmWorkorder/",
                sortName: "WorkorderPkInt"
            });
            const editFormFields = ref({"WorkorderCode":"","ProductPkInt":"","ProductCode":"","ProductName":"","ProductCurStock":"","WorkorderStatus":"","WorkorderPrinciple":"","WorkorderPlan":"","WorkorderPlanStartDate":"","WorkorderPlanEndDate":"","WorkorderActual":""});
            const editFormOptions = ref([[{"title":"工单编码","required":true,"field":"WorkorderCode","disabled":true,"type":"text"},
                               {"title":"产品主键","required":true,"field":"ProductPkInt","disabled":true,"type":"text"},
                               {"title":"产品编码","required":true,"field":"ProductCode","disabled":true,"type":"text"},
                               {"title":"产品名称","required":true,"field":"ProductName","disabled":true,"type":"text"}],
                              [{"title":"产品当前库存","field":"ProductCurStock","disabled":true,"type":"number"},
                               {"dataKey":"工单状态","data":[],"title":"工单状态","field":"WorkorderStatus","type":"select"},
                               {"title":"工单负责人","field":"WorkorderPrinciple","type":"text"},
                               {"title":"工单计划产量","field":"WorkorderPlan","type":"number"}],
                              [{"title":"工单计划开始时间","field":"WorkorderPlanStartDate","type":"datetime"},
                               {"title":"工单计划结束时间","field":"WorkorderPlanEndDate","type":"datetime"},
                               {"title":"工单实际产量","field":"WorkorderActual","type":"number"}]]);
            const searchFormFields = ref({"WorkorderCode":"","ProductCode":"","ProductName":"","ProductCurStock":"","WorkorderStatus":"","WorkorderPrinciple":"","WorkorderPlan":"","WorkorderPlanStartDate":""});
            const searchFormOptions = ref([[{"title":"工单编码","field":"WorkorderCode","type":"like"},{"title":"产品编码","field":"ProductCode","type":"like"},{"title":"产品名称","field":"ProductName","type":"like"},{"title":"产品当前库存","field":"ProductCurStock","type":"text"}],[{"dataKey":"工单状态","data":[],"title":"工单状态","field":"WorkorderStatus","type":"select"},{"title":"工单负责人","field":"WorkorderPrinciple","type":"text"},{"title":"工单计划产量","field":"WorkorderPlan","type":"number"},{"title":"工单计划开始时间","field":"WorkorderPlanStartDate","type":"datetime"}]]);
            const columns = ref([{field:'WorkorderCode',title:'工单编码',type:'string',width:160,readonly:true,require:true,align:'left',sort:true},
                       {field:'WorkorderPkInt',title:'工单主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'ProductPkInt',title:'产品主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'ProductCode',title:'产品编码',type:'string',width:160,readonly:true,require:true,align:'left'},
                       {field:'ProductName',title:'产品名称',type:'string',sort:true,width:120,readonly:true,require:true,align:'left'},
                       {field:'ProductCurStock',title:'产品当前库存',type:'int',width:110,readonly:true,align:'left'},
                       {field:'WorkorderStatus',title:'工单状态',type:'string',bind:{ key:'工单状态',data:[]},width:110,align:'left'},
                       {field:'WorkorderPrinciple',title:'工单负责人',type:'string',width:110,align:'left'},
                       {field:'WorkorderSchedule',title:'工单进度(%)',type:'int',width:110,align:'left'},
                       {field:'WorkorderOK',title:'工单良品',type:'int',width:110,readonly:true,align:'left'},
                       {field:'WorkorderNG',title:'工单不良品',type:'int',width:110,readonly:true,align:'left'},
                       {field:'WorkorderPassRate',title:'工单合格率(%)',type:'int',width:110,align:'left'},
                       {field:'WorkorderPlan',title:'工单计划产量',type:'int',width:110,align:'left'},
                       {field:'WorkorderPlanStartDate',title:'工单计划开始时间',type:'datetime',width:150,align:'left',sort:true},
                       {field:'WorkorderPlanEndDate',title:'工单计划结束时间',type:'datetime',width:150,align:'left',sort:true},
                       {field:'WorkorderActual',title:'工单实际产量',type:'int',width:110,align:'left'},
                       {field:'WorkorderActualStartDate',title:'工单实际开始时间',type:'datetime',width:110,align:'left',sort:true},
                       {field:'WorkorderActualEndDate',title:'工单实际结束时间',type:'datetime',width:110,align:'left',sort:true},
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
