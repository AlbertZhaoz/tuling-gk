<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/basicdata/albert_basicnumberrule/Albert_BasicNumberRule.js此处编写
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
    import extend from "@/extension/basicdata/albert_basicnumberrule/Albert_BasicNumberRule.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'BasicNumberRulePkInt',
                footer: "Foots",
                cnName: '编号规则',
                name: 'albert_basicnumberrule/Albert_BasicNumberRule',
                url: "/Albert_BasicNumberRule/",
                sortName: "BasicNumberRulePkInt"
            });
            const editFormFields = ref({"FormCode":"","Prefix":"","SubmitTime":"","SerialNumber":"","GenerativeRule":""});
            const editFormOptions = ref([[{"dataKey":"NumberRuleForm","data":[],"title":"目标表单","field":"FormCode","type":"select"}],
                              [{"title":"编号前缀","field":"Prefix","type":"text"}],
                              [{"dataKey":"SubmitTime","data":[],"title":"提交时间规则","field":"SubmitTime","type":"radio"}],
                              [{"title":"流水号位","field":"SerialNumber","type":"text"}],
                              [{"title":"编号生成规则","required":true,"field":"GenerativeRule","type":"text"}]]);
            const searchFormFields = ref({"GenerativeRule":"","FormCode":"","Prefix":"","SubmitTime":"","SerialNumber":""});
            const searchFormOptions = ref([[{"dataKey":"NumberRuleForm","data":[],"title":"目标表单","field":"FormCode","type":"select"}],[{"title":"编号前缀","field":"Prefix","type":"text"}],[{"dataKey":"SubmitTime","data":[],"title":"提交时间规则","field":"SubmitTime","type":"radio"}],[{"title":"流水号位","field":"SerialNumber","type":"text"}],[{"title":"编号生成规则","field":"GenerativeRule","type":"text"}]]);
            const columns = ref([{field:'BasicNumberRulePkInt',title:'编号规则主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'Prefix',title:'编号前缀',type:'string',width:120,align:'left',sort:true},
                       {field:'SubmitTime',title:'提交时间规则',type:'string',bind:{ key:'SubmitTime',data:[]},width:120,align:'left'},
                       {field:'SerialNumber',title:'流水号位',type:'int',width:120,align:'left'},
                       {field:'GenerativeRule',title:'编号生成规则',type:'string',width:160,require:true,align:'left'},
                       {field:'FormCode',title:'目标表单',type:'string',bind:{ key:'NumberRuleForm',data:[]},sort:true,width:120,align:'left'},
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
