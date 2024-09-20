<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/dataquery/albert_access/Albert_Access.js此处编写
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
    import extend from "@/extension/dataquery/albert_access/Albert_Access.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'AccessPkInt',
                footer: "Foots",
                cnName: '门禁记录查询',
                name: 'albert_access/Albert_Access',
                url: "/Albert_Access/",
                sortName: "AccessPkInt"
            });
            const editFormFields = ref({});
            const editFormOptions = ref([]);
            const searchFormFields = ref({"PersonCard":"","PersonDepartment":"","PersonName":"","AccessTime":"","AccessStatus":"","AccessMachineNumber":""});
            const searchFormOptions = ref([[{"title":"人员卡号","field":"PersonCard","type":"like"},{"title":"人员部门","field":"PersonDepartment","type":"like"},{"title":"人员姓名","field":"PersonName","type":"like"},{"title":"刷卡时间","field":"AccessTime","type":"datetime"}],[{"title":"刷卡状态","field":"AccessStatus","type":"text"},{"title":"刷卡机器编号","field":"AccessMachineNumber","type":"text"}]]);
            const columns = ref([{field:'AccessPkInt',title:'门禁主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'PersonCard',title:'人员卡号',type:'string',sort:true,width:120,align:'left',sort:true},
                       {field:'PersonDepartment',title:'人员部门',type:'string',width:120,align:'left'},
                       {field:'PersonName',title:'人员姓名',type:'string',width:110,align:'left'},
                       {field:'AccessTime',title:'刷卡时间',type:'datetime',width:150,align:'left',sort:true},
                       {field:'AccessStatus',title:'刷卡状态',type:'string',width:120,align:'left'},
                       {field:'AccessMachineNumber',title:'刷卡机器编号',type:'string',width:120,align:'left'}]);
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
