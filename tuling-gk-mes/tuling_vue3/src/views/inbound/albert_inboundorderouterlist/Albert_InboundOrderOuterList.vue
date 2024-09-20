<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/inbound/albert_inboundorderouterlist/Albert_InboundOrderOuterList.js此处编写
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
    import extend from "@/extension/inbound/albert_inboundorderouterlist/Albert_InboundOrderOuterList.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'InboundOrderOuterListPkInt',
                footer: "Foots",
                cnName: '出库单列表',
                name: 'albert_inboundorderouterlist/Albert_InboundOrderOuterList',
                url: "/Albert_InboundOrderOuterList/",
                sortName: "InboundOrderOuterListPkInt"
            });
            const editFormFields = ref({"InboundOrderOuterProduceCode":"","InboundOrderOuterProduceName":"","InboundOrderOuterProduceStandard":"","InboundOrderOuterUnitId":"","InboundOrderOuterMaxStock":"","InboundOrderOuterMinStock":"","InboundOrderOuterSafeStock":"","InboundOrderOuterCurrentStock":"","InboundOrderOuterCurrentQty":"","InboundOrderOuterTotalQty":""});
            const editFormOptions = ref([[{"title":"产品编码","field":"InboundOrderOuterProduceCode"},
                               {"title":"产品名称","field":"InboundOrderOuterProduceName"},
                               {"title":"产品规格","field":"InboundOrderOuterProduceStandard"},
                               {"title":"库存单位","field":"InboundOrderOuterUnitId"}],
                              [{"title":"最大库存","field":"InboundOrderOuterMaxStock","type":"number"},
                               {"title":"最小库存","field":"InboundOrderOuterMinStock","type":"number"},
                               {"title":"安全库存","field":"InboundOrderOuterSafeStock","type":"number"},
                               {"title":"当前库存","field":"InboundOrderOuterCurrentStock","type":"number"}],
                              [{"title":"当前入库数量","field":"InboundOrderOuterCurrentQty","type":"number"},
                               {"title":"总入库数量","field":"InboundOrderOuterTotalQty","type":"number"}]]);
            const searchFormFields = ref({});
            const searchFormOptions = ref([]);
            const columns = ref([{field:'InboundOrderOuterListPkInt',title:'出库单列表主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'InboundOrderOuterPkInt',title:'出库单主键',type:'int',sort:true,width:110,require:true,align:'left',sort:true},
                       {field:'InboundOrderOuterProduceCode',title:'产品编码',type:'string',sort:true,width:120,align:'left'},
                       {field:'InboundOrderOuterProduceName',title:'产品名称',type:'string',width:120,align:'left'},
                       {field:'InboundOrderOuterProduceStandard',title:'产品规格',type:'string',width:120,align:'left'},
                       {field:'InboundOrderOuterUnitId',title:'库存单位',type:'string',width:120,align:'left'},
                       {field:'InboundOrderOuterMaxStock',title:'最大库存',type:'int',width:110,align:'left'},
                       {field:'InboundOrderOuterMinStock',title:'最小库存',type:'int',width:110,align:'left'},
                       {field:'InboundOrderOuterSafeStock',title:'安全库存',type:'int',width:110,align:'left'},
                       {field:'InboundOrderOuterCurrentStock',title:'当前库存',type:'int',width:110,align:'left'},
                       {field:'InboundOrderOuterCurrentQty',title:'当前入库数量',type:'int',width:110,align:'left'},
                       {field:'InboundOrderOuterTotalQty',title:'总入库数量',type:'int',width:110,align:'left'},
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
