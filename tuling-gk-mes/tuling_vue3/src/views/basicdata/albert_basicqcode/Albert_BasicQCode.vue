<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/basicdata/albert_basicqcode/Albert_BasicQCode.js此处编写
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
    import extend from "@/extension/basicdata/albert_basicqcode/Albert_BasicQCode.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'BasicQCodePkInt',
                footer: "Foots",
                cnName: '赋码管理',
                name: 'albert_basicqcode/Albert_BasicQCode',
                url: "/Albert_BasicQCode/",
                sortName: "BasicQCodePkInt"
            });
            const editFormFields = ref({"BasicQCodeName":"","BasicQCodeContent":"","BasicQCodeIsUse":"","BasicQCodeImage":""});
            const editFormOptions = ref([[{"title":"条码名称","field":"BasicQCodeName","type":"text"},
                               {"title":"条码代码内容","field":"BasicQCodeContent","type":"text"},
                               {"dataKey":"DeviceIsUse","data":[],"title":"条码是否使用","field":"BasicQCodeIsUse","type":"select"},
                               {"title":"条码呈现","field":"BasicQCodeImage","type":"text"}]]);
            const searchFormFields = ref({"BasicQCodeName":""});
            const searchFormOptions = ref([[{"title":"条码名称","field":"BasicQCodeName","type":"like"}]]);
            const columns = ref([{field:'BasicQCodePkInt',title:'赋码主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'BasicQCodeName',title:'条码名称',type:'string',width:120,align:'left',sort:true},
                       {field:'BasicQCodeContent',title:'条码代码内容',type:'string',width:220,align:'left'},
                       {field:'BasicQCodeIsUse',title:'条码是否使用',type:'string',bind:{ key:'DeviceIsUse',data:[]},width:110,align:'left'},
                       {field:'BasicQCodeImage',title:'条码呈现',type:'string',width:220,align:'left'},
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
