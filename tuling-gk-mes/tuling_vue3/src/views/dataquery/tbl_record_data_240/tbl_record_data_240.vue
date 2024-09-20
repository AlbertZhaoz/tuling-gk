<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/dataquery/tbl_record_data_240/tbl_record_data_240.js此处编写
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
    import extend from "@/extension/dataquery/tbl_record_data_240/tbl_record_data_240.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'ID',
                footer: "Foots",
                cnName: 'Op240高品数据',
                name: 'tbl_record_data_240/tbl_record_data_240',
                url: "/tbl_record_data_240/",
                sortName: "StartTime"
            });
            const editFormFields = ref({});
            const editFormOptions = ref([]);
            const searchFormFields = ref({"Barcode":""});
            const searchFormOptions = ref([[{"title":"产品条码","field":"Barcode","type":"text"}]]);
            const columns = ref([{field:'ID',title:'序号',type:'int',width:120,require:true,align:'left',sort:true},
                       {field:'GUID',title:'GUID',type:'string',width:120,align:'left'},
                       {field:'StartTime',title:'开始时间',type:'datetime',width:180,align:'left',sort:true},
                       {field:'Station',title:'工站',type:'string',width:120,align:'left'},
                       {field:'Operator',title:'操作员',type:'string',width:120,align:'left'},
                       {field:'BatchNO',title:'批次号',type:'string',width:120,align:'left'},
                       {field:'Barcode',title:'产品条码',type:'string',width:180,align:'left'},
                       {field:'ProductModel',title:'产品型号',type:'string',width:120,align:'left'},
                       {field:'ProductType',title:'生产类型（正常件，master等）',type:'string',width:120,align:'left'},
                       {field:'NGClassification',title:'NG原因',type:'string',width:120,align:'left'},
                       {field:'IsRework',title:'是否返工',type:'string',width:120,align:'left'},
                       {field:'IsRetest',title:'是否重测试',type:'string',width:120,align:'left'},
                       {field:'小球进口压力均值1',title:'小球进口压力均值1',type:'string',width:120,align:'left'},
                       {field:'小球开启扭矩峰值1',title:'小球开启扭矩峰值1',type:'string',width:120,align:'left'},
                       {field:'小球进口压力均值2',title:'小球进口压力均值2',type:'string',width:120,align:'left'},
                       {field:'小球开启扭矩峰值2',title:'小球开启扭矩峰值2',type:'string',width:120,align:'left'},
                       {field:'TotalResult',title:'总结果',type:'string',width:120,align:'left'}]);
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
