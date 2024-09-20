<!--
*Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/inbound/albert_inboundorder/Albert_InboundOrder.js此处编写
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
    import extend from "@/extension/inbound/albert_inboundorder/Albert_InboundOrder.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'InboundOrderPkInt',
                footer: "Foots",
                cnName: '入库单',
                name: 'albert_inboundorder/Albert_InboundOrder',
                url: "/Albert_InboundOrder/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"InboundOrderCode":"","InboundName":"","InboundType":"","InboundOrderDate":""});
            const editFormOptions = ref([[{"title":"入库单单号","required":true,"field":"InboundOrderCode","type":"text"},
                               {"title":"入库单名称","required":true,"field":"InboundName","type":"text"}],
                              [{"title":"入库单类型","field":"InboundType","type":"text"},
                               {"title":"入库单日期","field":"InboundOrderDate","type":"text"}]]);
            const searchFormFields = ref({});
            const searchFormOptions = ref([]);
            const columns = ref([{field:'InboundOrderPkInt',title:'入库单主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'InboundOrderCode',title:'入库单单号',type:'string',sort:true,width:120,require:true,align:'left',sort:true},
                       {field:'InboundName',title:'入库单名称',type:'string',sort:true,width:120,require:true,align:'left'},
                       {field:'InboundType',title:'入库单类型',type:'string',sort:true,width:120,align:'left'},
                       {field:'InboundOrderDate',title:'入库单日期',type:'datetime',width:150,align:'left',sort:true},
                       {field:'InboundOrderRemark',title:'备注',type:'string',width:220,align:'left'},
                       {field:'CreateID',title:'创建ID',type:'int',width:100,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:100,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:150,require:true,align:'left',sort:true},
                       {field:'ModifyID',title:'修改ID',type:'int',width:100,hidden:true,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:100,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:150,require:true,align:'left',sort:true}]);
            const detail = ref({
                cnName: "入库单列表",
                table: "Albert_InboundOrderList",
                columns: [{field:'InboundOrderListPkInt',title:'入库单列表主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'InboundOrderPkInt',title:'入库单主键',type:'int',width:110,require:true,align:'left',sort:true},
                       {field:'InboundOrderProduceCode',title:'产品编码',type:'string',sort:true,width:120,edit:{type:'text'},align:'left'},
                       {field:'InboundOrderProduceName',title:'产品名称',type:'string',sort:true,width:120,edit:{type:'text'},align:'left'},
                       {field:'InboundOrderProduceStandard',title:'产品规格',type:'string',width:120,edit:{type:'text'},align:'left'},
                       {field:'InboundOrderUnitId',title:'库存单位',type:'string',width:120,edit:{type:'text'},align:'left'},
                       {field:'InboundOrderMaxStock',title:'最大库存',type:'int',sort:true,width:110,edit:{type:'number'},align:'left'},
                       {field:'InboundOrderMinStock',title:'最小库存',type:'int',sort:true,width:110,edit:{type:'number'},align:'left'},
                       {field:'InboundOrderSafeStock',title:'安全库存',type:'int',sort:true,width:110,edit:{type:'number'},align:'left'},
                       {field:'InboundOrderCurrentStock',title:'当前库存',type:'int',width:110,edit:{type:'number'},align:'left'},
                       {field:'InboundOrderCurrentQty',title:'当前入库数量',type:'int',width:110,edit:{type:'number'},align:'left'},
                       {field:'InboundOrderTotalQty',title:'总入库数量',type:'int',width:110,edit:{type:''},align:'left'},
                       {field:'CreateID',title:'创建ID',type:'int',width:100,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:100,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:150,require:true,align:'left',sort:true},
                       {field:'ModifyID',title:'修改ID',type:'int',width:100,hidden:true,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:100,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:150,require:true,align:'left',sort:true}],
                sortName: "InboundOrderListPkInt",
                key: "InboundOrderListPkInt"
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
