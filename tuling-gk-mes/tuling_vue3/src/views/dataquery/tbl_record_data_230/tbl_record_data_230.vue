<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/dataquery/tbl_record_data_230/tbl_record_data_230.js此处编写
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
    import extend from "@/extension/dataquery/tbl_record_data_230/tbl_record_data_230.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: '自增主键',
                footer: "Foots",
                cnName: 'Op230氦检数据',
                name: 'tbl_record_data_230/tbl_record_data_230',
                url: "/tbl_record_data_230/",
                sortName: "记录时间"
            });
            const editFormFields = ref({});
            const editFormOptions = ref([]);
            const searchFormFields = ref({});
            const searchFormOptions = ref([]);
            const columns = ref([{field:'自增主键',title:'主键',type:'int',width:120,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'记录时间',title:'记录时间',type:'datetime',width:180,align:'left',sort:true},
                       {field:'检测标志',title:'检测标志',type:'string',width:110,align:'left'},
                       {field:'工件型号',title:'工件型号',type:'string',width:110,align:'left'},
                       {field:'条码',title:'条码',type:'string',width:160,align:'left'},
                       {field:'结果',title:'结果',type:'string',width:110,align:'left'},
                       {field:'箱号',title:'箱号',type:'string',width:110,align:'left'},
                       {field:'箱体抽空',title:'箱体抽空',type:'string',width:110,align:'left'},
                       {field:'充氮',title:'充氮',type:'string',width:110,align:'left'},
                       {field:'充氮检测时间',title:'充氮时间',type:'string',width:110,align:'left'},
                       {field:'压降',title:'压降',type:'string',width:110,align:'left'},
                       {field:'充氦',title:'充氦',type:'string',width:110,align:'left'},
                       {field:'充氦检测时间',title:'充氦时间',type:'string',width:110,align:'left'},
                       {field:'漏率',title:'漏率',type:'string',width:110,align:'left'},
                       {field:'报警点',title:'报警点',type:'string',width:110,align:'left'},
                       {field:'节拍',title:'节拍',type:'string',width:110,align:'left'},
                       {field:'氦气浓度',title:'氦气浓度',type:'string',width:110,align:'left'},
                       {field:'BG',title:'BG',type:'string',width:110,align:'left'},
                       {field:'SG',title:'SG',type:'string',width:110,align:'left'},
                       {field:'SN',title:'SN',type:'string',width:110,align:'left'},
                       {field:'flag',title:'flag',type:'string',width:110,align:'left'}]);
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
