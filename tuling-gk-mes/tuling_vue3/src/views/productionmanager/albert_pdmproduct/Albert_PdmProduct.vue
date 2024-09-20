<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/productionmanager/albert_pdmproduct/Albert_PdmProduct.js此处编写
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
    import extend from "@/extension/productionmanager/albert_pdmproduct/Albert_PdmProduct.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'ProductPkInt',
                footer: "Foots",
                cnName: '产品管理',
                name: 'albert_pdmproduct/Albert_PdmProduct',
                url: "/Albert_PdmProduct/",
                sortName: "ProductPkInt"
            });
            const editFormFields = ref({"ProductCode":"","ProductName":"","ProductStandard":"","ProductUnitId":"","ProductMaxStock":"","ProductMinStock":"","ProductSafeStock":"","ProductCurStock":"","CraftPkInt":"","CraftCode":"","CraftName":""});
            const editFormOptions = ref([[{"title":"产品编码","required":true,"field":"ProductCode","disabled":true,"type":"text"},
                               {"title":"产品名称","required":true,"field":"ProductName","type":"text"},
                               {"title":"产品规格","field":"ProductStandard","type":"text"},
                               {"title":"库存单位","field":"ProductUnitId","type":"text"}],
                              [{"title":"产品最大库存","field":"ProductMaxStock","type":"number"},
                               {"title":"产品最小库存","field":"ProductMinStock","type":"number"},
                               {"title":"产品安全库存","field":"ProductSafeStock","type":"number"},
                               {"title":"产品当前库存","field":"ProductCurStock","type":"number"}],
                              [{"title":"工艺主键","required":true,"field":"CraftPkInt","disabled":true,"type":"text"},
                               {"title":"工艺编码","required":true,"field":"CraftCode","disabled":true,"type":"text"},
                               {"title":"工艺路线","required":true,"field":"CraftName","disabled":true,"type":"text"}]]);
            const searchFormFields = ref({"ProductCode":"","ProductName":"","ProductStandard":""});
            const searchFormOptions = ref([[{"title":"产品编码","field":"ProductCode","type":"like"},{"title":"产品名称","field":"ProductName"},{"title":"产品规格","field":"ProductStandard"}]]);
            const columns = ref([{field:'ProductPkInt',title:'产品主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'ProductCode',title:'产品编码',type:'string',sort:true,width:140,readonly:true,require:true,align:'left',sort:true},
                       {field:'ProductName',title:'产品名称',type:'string',sort:true,width:120,require:true,align:'left'},
                       {field:'ProductStandard',title:'产品规格',type:'string',width:120,align:'left'},
                       {field:'ProductUnitId',title:'库存单位',type:'string',width:120,align:'left'},
                       {field:'ProductMaxStock',title:'产品最大库存',type:'int',width:140,align:'left'},
                       {field:'ProductMinStock',title:'产品最小库存',type:'int',width:140,align:'left'},
                       {field:'ProductSafeStock',title:'产品安全库存',type:'int',width:140,align:'left'},
                       {field:'ProductCurStock',title:'产品当前库存',type:'int',width:140,align:'left'},
                       {field:'CraftPkInt',title:'工艺主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'CraftCode',title:'工艺编码',type:'string',width:120,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'CraftName',title:'工艺路线',type:'string',width:120,readonly:true,require:true,align:'left'},
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
