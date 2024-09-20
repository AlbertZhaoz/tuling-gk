<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/inbound/albert_inboundorderouter/Albert_InboundOrderOuter.js此处编写
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
    import extend from "@/extension/inbound/albert_inboundorderouter/Albert_InboundOrderOuter.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'InboundOrderOuterPkInt',
                footer: "Foots",
                cnName: '出库单',
                name: 'albert_inboundorderouter/Albert_InboundOrderOuter',
                url: "/Albert_InboundOrderOuter/",
                sortName: "InboundOrderOuterPkInt"
            });
            const editFormFields = ref({"InboundOrderOuterCode":"","InboundOuterName":"","InboundOuterType":"","InboundOrderOuterDate":"","InboundOrderOuterRemark":""});
            const editFormOptions = ref([[{"title":"出库单单号","required":true,"field":"InboundOrderOuterCode","type":"text"},
                               {"title":"出库单名称","required":true,"field":"InboundOuterName","type":"text"},
                               {"title":"出库单类型","field":"InboundOuterType","type":"text"},
                               {"title":"出库单日期","field":"InboundOrderOuterDate","type":"date"}],
                              [{"title":"出库备注","field":"InboundOrderOuterRemark","type":"text"}]]);
            const searchFormFields = ref({"InboundOrderOuterCode":"","InboundOuterName":"","InboundOuterType":"","InboundOrderOuterDate":""});
            const searchFormOptions = ref([[{"title":"出库单单号","field":"InboundOrderOuterCode","type":"like"},{"title":"出库单名称","field":"InboundOuterName","type":"like"},{"title":"出库单类型","field":"InboundOuterType","type":"like"},{"title":"出库单日期","field":"InboundOrderOuterDate","type":"date"}]]);
            const columns = ref([{field:'InboundOrderOuterPkInt',title:'出库单主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'InboundOrderOuterCode',title:'出库单单号',type:'string',sort:true,width:120,require:true,align:'left',sort:true},
                       {field:'InboundOuterName',title:'出库单名称',type:'string',sort:true,width:120,require:true,align:'left'},
                       {field:'InboundOuterType',title:'出库单类型',type:'string',sort:true,width:120,align:'left'},
                       {field:'InboundOrderOuterDate',title:'出库单日期',type:'datetime',width:150,align:'left',sort:true},
                       {field:'InboundOrderOuterRemark',title:'出库备注',type:'string',width:220,align:'left'},
                       {field:'CreateID',title:'创建ID',type:'int',width:100,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:100,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:150,require:true,align:'left',sort:true},
                       {field:'ModifyID',title:'修改ID',type:'int',width:100,hidden:true,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:100,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:150,require:true,align:'left',sort:true}]);
            const detail = ref({
                cnName: "出库单列表",
                table: "Albert_InboundOrderOuterList",
                columns: [{field:'InboundOrderOuterListPkInt',title:'出库单列表主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'InboundOrderOuterPkInt',title:'出库单主键',type:'int',sort:true,width:110,edit:{type:''},require:true,align:'left',sort:true},
                       {field:'InboundOrderOuterProduceCode',title:'产品编码',type:'string',sort:true,width:120,edit:{type:''},align:'left'},
                       {field:'InboundOrderOuterProduceName',title:'产品名称',type:'string',width:120,edit:{type:''},align:'left'},
                       {field:'InboundOrderOuterProduceStandard',title:'产品规格',type:'string',width:120,edit:{type:''},align:'left'},
                       {field:'InboundOrderOuterUnitId',title:'库存单位',type:'string',width:120,edit:{type:''},align:'left'},
                       {field:'InboundOrderOuterMaxStock',title:'最大库存',type:'int',width:110,edit:{type:''},align:'left'},
                       {field:'InboundOrderOuterMinStock',title:'最小库存',type:'int',width:110,edit:{type:''},align:'left'},
                       {field:'InboundOrderOuterSafeStock',title:'安全库存',type:'int',width:110,edit:{type:''},align:'left'},
                       {field:'InboundOrderOuterCurrentStock',title:'当前库存',type:'int',width:110,edit:{type:''},align:'left'},
                       {field:'InboundOrderOuterCurrentQty',title:'当前入库数量',type:'int',width:110,edit:{type:''},align:'left'},
                       {field:'InboundOrderOuterTotalQty',title:'总入库数量',type:'int',width:110,edit:{type:''},align:'left'},
                       {field:'CreateID',title:'创建ID',type:'int',width:100,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:100,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:150,require:true,align:'left',sort:true},
                       {field:'ModifyID',title:'修改ID',type:'int',width:100,hidden:true,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:100,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:150,require:true,align:'left',sort:true}],
                sortName: "InboundOrderOuterListPkInt",
                key: "InboundOrderOuterListPkInt"
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
