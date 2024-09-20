<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/inbound/albert_inboundorderlist/Albert_InboundOrderList.js此处编写
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
    import extend from "@/extension/inbound/albert_inboundorderlist/Albert_InboundOrderList.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'InboundOrderListPkInt',
                footer: "Foots",
                cnName: '入库单列表',
                name: 'albert_inboundorderlist/Albert_InboundOrderList',
                url: "/Albert_InboundOrderList/",
                sortName: "InboundOrderListPkInt"
            });
            const editFormFields = ref({"InboundOrderProduceCode":"","InboundOrderProduceName":"","InboundOrderProduceStandard":"","InboundOrderUnitId":"","InboundOrderMaxStock":"","InboundOrderMinStock":"","InboundOrderSafeStock":"","InboundOrderCurrentStock":"","InboundOrderCurrentQty":"","InboundOrderTotalQty":""});
            const editFormOptions = ref([[{"title":"产品编码","field":"InboundOrderProduceCode","type":"text"},
                               {"title":"产品名称","field":"InboundOrderProduceName","type":"text"},
                               {"title":"产品规格","field":"InboundOrderProduceStandard","type":"text"},
                               {"title":"库存单位","field":"InboundOrderUnitId","type":"text"}],
                              [{"title":"最大库存","field":"InboundOrderMaxStock","type":"number"},
                               {"title":"最小库存","field":"InboundOrderMinStock","type":"number"},
                               {"title":"安全库存","field":"InboundOrderSafeStock","type":"number"},
                               {"title":"当前库存","field":"InboundOrderCurrentStock","type":"number"}],
                              [{"title":"当前入库数量","field":"InboundOrderCurrentQty","type":"number"},
                               {"title":"总入库数量","field":"InboundOrderTotalQty","type":"number"}]]);
            const searchFormFields = ref({});
            const searchFormOptions = ref([]);
            const columns = ref([{field:'InboundOrderListPkInt',title:'入库单列表主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'InboundOrderPkInt',title:'入库单主键',type:'int',width:110,require:true,align:'left',sort:true},
                       {field:'InboundOrderProduceCode',title:'产品编码',type:'string',sort:true,width:120,align:'left'},
                       {field:'InboundOrderProduceName',title:'产品名称',type:'string',sort:true,width:120,align:'left'},
                       {field:'InboundOrderProduceStandard',title:'产品规格',type:'string',width:120,align:'left'},
                       {field:'InboundOrderUnitId',title:'库存单位',type:'string',width:120,align:'left'},
                       {field:'InboundOrderMaxStock',title:'最大库存',type:'int',sort:true,width:110,align:'left'},
                       {field:'InboundOrderMinStock',title:'最小库存',type:'int',sort:true,width:110,align:'left'},
                       {field:'InboundOrderSafeStock',title:'安全库存',type:'int',sort:true,width:110,align:'left'},
                       {field:'InboundOrderCurrentStock',title:'当前库存',type:'int',width:110,align:'left'},
                       {field:'InboundOrderCurrentQty',title:'当前入库数量',type:'int',width:110,align:'left'},
                       {field:'InboundOrderTotalQty',title:'总入库数量',type:'int',width:110,align:'left'},
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
