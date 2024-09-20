<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/dataquery/tbl_record_data_300/tbl_record_data_300.js此处编写
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
    import extend from "@/extension/dataquery/tbl_record_data_300/tbl_record_data_300.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'ID',
                footer: "Foots",
                cnName: 'Op300高品数据',
                name: 'tbl_record_data_300/tbl_record_data_300',
                url: "/tbl_record_data_300/",
                sortName: "StartTime"
            });
            const editFormFields = ref({});
            const editFormOptions = ref([]);
            const searchFormFields = ref({"Barcode":""});
            const searchFormOptions = ref([[{"title":"产品条码","field":"Barcode","type":"text"}]]);
            const columns = ref([{field:'ID',title:'序号',type:'int',width:110,require:true,align:'left',sort:true},
                       {field:'GUID',title:'GUID',type:'string',width:110,align:'left'},
                       {field:'StartTime',title:'开始时间',type:'datetime',width:150,align:'left',sort:true},
                       {field:'ProductModel',title:'产品型号',type:'string',width:120,align:'left'},
                       {field:'ProductType',title:'生产类型（正常件，master等）',type:'string',width:120,align:'left'},
                       {field:'NGClassification',title:'NG原因',type:'string',width:120,align:'left'},
                       {field:'Station',title:'工站',type:'string',width:110,align:'left'},
                       {field:'Operator',title:'操作员',type:'string',width:110,align:'left'},
                       {field:'BatchNO',title:'批次号',type:'string',width:110,align:'left'},
                       {field:'Barcode',title:'产品条码',type:'string',width:110,align:'left'},
                       {field:'IsRework',title:'是否返工',type:'string',width:110,align:'left'},
                       {field:'IsRetest',title:'是否重新测试',type:'string',width:110,align:'left'},
                       {field:'内漏_小球1口进气压力',title:'内漏_小球1口进气压力',type:'string',width:110,align:'left'},
                       {field:'内漏_小球1口泄露值',title:'内漏_小球1口泄露值',type:'string',width:110,align:'left'},
                       {field:'内漏_小球5口进气压力',title:'内漏_小球5口进气压力',type:'string',width:110,align:'left'},
                       {field:'内漏_小球5口泄露值',title:'内漏_小球5口泄露值',type:'string',width:110,align:'left'},
                       {field:'开启_小球1口进气压力',title:'开启_小球1口进气压力',type:'string',width:110,align:'left'},
                       {field:'开启_小球开启步数1',title:'开启_小球开启步数1',type:'string',width:110,align:'left'},
                       {field:'开启_小球开启电流1',title:'开启_小球开启电流1',type:'string',width:110,align:'left'},
                       {field:'开启_小球关闭步数1',title:'开启_小球关闭步数1',type:'string',width:110,align:'left'},
                       {field:'开启_小球5口进气压力',title:'开启_小球5口进气压力',type:'string',width:110,align:'left'},
                       {field:'开启_小球开启步数2',title:'开启_小球开启步数2',type:'string',width:110,align:'left'},
                       {field:'开启_小球开启电流2',title:'开启_小球开启电流2',type:'string',width:110,align:'left'},
                       {field:'开启_小球关闭步数2',title:'开启_小球关闭步数2',type:'string',width:110,align:'left'},
                       {field:'流量_小球offset',title:'流量_小球offset',type:'string',width:110,align:'left'},
                       {field:'流量_小球进气压力',title:'流量_小球进气压力',type:'string',width:110,align:'left'},
                       {field:'流量_小球流量值',title:'流量_小球流量值',type:'string',width:110,align:'left'},
                       {field:'TotalResult',title:'总结果',type:'string',width:110,align:'left'}]);
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
