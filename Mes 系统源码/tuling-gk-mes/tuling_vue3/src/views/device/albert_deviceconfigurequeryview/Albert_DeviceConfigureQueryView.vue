<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/device/albert_deviceconfigurequeryview/Albert_DeviceConfigureQueryView.js此处编写
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
    import extend from "@/extension/device/albert_deviceconfigurequeryview/Albert_DeviceConfigureQueryView.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'DevicePkInt',
                footer: "Foots",
                cnName: '设备台账查询',
                name: 'albert_deviceconfigurequeryview/Albert_DeviceConfigureQueryView',
                url: "/Albert_DeviceConfigureQueryView/",
                sortName: "DeviceSort"
            });
            const editFormFields = ref({});
            const editFormOptions = ref([]);
            const searchFormFields = ref({});
            const searchFormOptions = ref([]);
            const columns = ref([{field:'DevicePkInt',title:'设备主键',type:'int',width:110,hidden:true,require:true,align:'left'},
                       {field:'DeviceSort',title:'设备排序',type:'int',width:110,hidden:true,require:true,align:'left'},
                       {field:'DeviceCode',title:'设备编码',type:'string',width:120,require:true,align:'left',sort:true},
                       {field:'DeviceName',title:'设备名称',type:'string',width:120,require:true,align:'left'},
                       {field:'DeivceSubname',title:'设备别名',type:'string',width:120,align:'left'},
                       {field:'DeviceIsUse',title:'设备启用(Y/N)',type:'string',width:110,require:true,align:'left'},
                       {field:'DeviceType',title:'设备类型',type:'string',width:120,align:'left'},
                       {field:'DeviceStatus',title:'设备状态',type:'string',width:120,align:'left'},
                       {field:'DeviceHeartBeat',title:'设备心跳',type:'string',width:120,hidden:true,align:'left'},
                       {field:'DeivceRemark',title:'设备备注',type:'string',width:220,align:'left'},
                       {field:'DeviceStartTime',title:'设备开始运行时间',type:'datetime',width:150,hidden:true,align:'left',sort:true},
                       {field:'DeviceEndTime',title:'设备结束运行时间',type:'datetime',width:150,hidden:true,align:'left',sort:true},
                       {field:'CommunicationAddress',title:'通讯地址',type:'string',width:120,hidden:true,align:'left'},
                       {field:'CommunicationPort',title:'通讯端口',type:'int',width:110,hidden:true,align:'left'},
                       {field:'CommunicationOvertime',title:'通讯超时时间',type:'int',width:110,hidden:true,align:'left'},
                       {field:'Workshop',title:'所属车间',type:'string',width:120,hidden:true,align:'left'},
                       {field:'Brand',title:'品牌',type:'string',width:120,hidden:true,align:'left'},
                       {field:'CreateID',title:'创建ID',type:'int',width:100,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:100,hidden:true,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:150,hidden:true,require:true,align:'left',sort:true},
                       {field:'ModifyID',title:'修改ID',type:'int',width:100,hidden:true,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:100,hidden:true,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:150,hidden:true,require:true,align:'left',sort:true}]);
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
