<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/dataquery/albert_dataerror/albert_dataerror.js此处编写
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
    import extend from "@/extension/dataquery/albert_dataerror/albert_dataerror.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'DataPkInt',
                footer: "Foots",
                cnName: '防错件查询',
                name: 'albert_dataerror/albert_dataerror',
                url: "/albert_dataerror/",
                sortName: "DataPkInt"
            });
            const editFormFields = ref({});
            const editFormOptions = ref([]);
            const searchFormFields = ref({});
            const searchFormOptions = ref([]);
            const columns = ref([{field:'ErrorCode',title:'防错码',type:'string',width:120,require:true,align:'left',sort:true},
                       {field:'DataPkInt',title:'自增ID',type:'int',width:120,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'ProductFunction',title:'工作类型（0正常件、1防错件、2返工件)',type:'string',width:120,align:'left'},
                       {field:'ProductContent',title:'工作内容',type:'string',width:120,align:'left'},
                       {field:'Op60EPOk',title:'Op60OK',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op60EPHigh',title:'Op60垫片偏高',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op60EPLow',title:'Op60垫片偏低',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op60EPDeformation',title:'Op60垫片变形',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op90EPOk',title:'Op90OK',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op90EPMiss',title:'Op90卡簧漏装',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op90EPDouble',title:'Op90卡簧装两个',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op90EPDpMiss',title:'Op90垫片漏装',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op90EPDpDouble',title:'Op90垫片装两个',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op90EPBD',title:'Op90标定件',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op110EPOk',title:'Op110OK',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op110EPSRMiss',title:'Op110小O-Ring漏装',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op110EPBRMiss',title:'Op110大O-Ring漏装',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op110EPSRDouble',title:'Op110小O-Ring装两个',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op110EPBRDouble',title:'Op110大O-Ring装两个',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op120EPOK',title:'Op120OK',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op120EPNBig',title:'Op120扭矩偏大',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op120EPNSmall',title:'Op120扭矩偏小',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op170EPOK',title:'Op170OK',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op170EPOffMark',title:'Op170装偏',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op170EPMiss',title:'Op170漏装',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op200_1EPOK',title:'Op200_1OK',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op200_1EPMiss',title:'Op200_1漏装',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op200_1EPDouble',title:'Op200_1多装',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op220EPOK',title:'Op220OK',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op220EPNG',title:'Op220NG',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op230EPResult',title:'Op230结果',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op230EPType',title:'Op230类型',type:'string',width:120,align:'left'},
                       {field:'Op230EPBack',title:'Op230备用',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op240EPResult',title:'Op240结果',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op240EPType',title:'Op240类型',type:'string',width:120,align:'left'},
                       {field:'Op240EPBack',title:'Op240备用',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op250EPResult',title:'Op250结果',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op250EPType',title:'Op250类型',type:'string',width:120,align:'left'},
                       {field:'Op250EPBack',title:'Op250备用',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op290EPResult',title:'Op290结果',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op290EPType',title:'Op290类型',type:'string',width:120,align:'left'},
                       {field:'Op290EPBack',title:'Op290备用',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op300EPResult',title:'Op300结果',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'},
                       {field:'Op300EPType',title:'Op300类型',type:'string',width:120,align:'left'},
                       {field:'Op300EPBack',title:'Op300备用',type:'string',bind:{ key:'数据结果',data:[]},width:120,align:'left'}]);
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
