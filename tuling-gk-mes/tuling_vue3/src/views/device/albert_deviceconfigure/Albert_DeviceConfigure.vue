<!--
*Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/device/albert_deviceconfigure/Albert_DeviceConfigure.js此处编写
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
    import extend from "@/extension/device/albert_deviceconfigure/Albert_DeviceConfigure.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'DevicePkInt',
                footer: "Foots",
                cnName: '设备台账',
                name: 'albert_deviceconfigure/Albert_DeviceConfigure',
                url: "/Albert_DeviceConfigure/",
                sortName: "DeviceSort"
            });
            const editFormFields = ref({"DeviceSort":"","DeviceCode":"","DeviceName":"","DeivceSubname":"","DeviceIsUse":"","CommunicationAddress":"","CommunicationPort":"","CommunicationOvertime":"","DeviceType":"","DeviceHeartBeat":"","DeivceRemark":"","Workshop":"","Brand":""});
            const editFormOptions = ref([[{"title":"设备排序","required":true,"field":"DeviceSort","type":"number"},
                               {"title":"设备编码","field":"DeviceCode","disabled":true},
                               {"title":"设备名称","required":true,"field":"DeviceName","type":"text"},
                               {"title":"设备别名","field":"DeivceSubname","type":"text"}],
                              [{"dataKey":"DeviceIsUse","data":[],"title":"设备启用(Y/N)","required":true,"field":"DeviceIsUse","type":"select"},
                               {"title":"通讯地址","field":"CommunicationAddress","type":"text"},
                               {"title":"通讯端口","field":"CommunicationPort","type":"number"},
                               {"title":"通讯超时时间","field":"CommunicationOvertime","type":"number"}],
                              [{"dataKey":"DeviceType","data":[],"title":"设备类型","field":"DeviceType","type":"select"},
                               {"dataKey":"DeviceIsUse","data":[],"title":"设备心跳","field":"DeviceHeartBeat","type":"select"},
                               {"title":"设备备注","field":"DeivceRemark","type":"text"},
                               {"dataKey":"BasicWorkshop","data":[],"title":"所属车间","field":"Workshop","type":"select"}],
                              [{"dataKey":"Brand","data":[],"title":"品牌","field":"Brand","type":"select"}]]);
            const searchFormFields = ref({"DeviceCode":"","DeviceName":"","DeivceSubname":"","DeviceIsUse":""});
            const searchFormOptions = ref([[{"title":"设备编码","field":"DeviceCode","type":"like"},{"title":"设备名称","field":"DeviceName","type":"like"},{"title":"设备别名","field":"DeivceSubname","type":"like"},{"dataKey":"DeviceIsUse","data":[],"title":"设备启用(Y/N)","field":"DeviceIsUse","type":"select"}]]);
            const columns = ref([{field:'DevicePkInt',title:'设备主键',type:'int',width:120,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'DeviceSort',title:'设备排序',type:'int',sort:true,width:120,hidden:true,require:true,align:'left'},
                       {field:'DeviceCode',title:'设备编码',type:'string',width:120,readonly:true,align:'left',sort:true},
                       {field:'DeviceName',title:'设备名称',type:'string',width:120,require:true,align:'left'},
                       {field:'DeivceSubname',title:'设备别名',type:'string',width:120,align:'left'},
                       {field:'DeviceIsUse',title:'设备启用(Y/N)',type:'string',bind:{ key:'DeviceIsUse',data:[]},width:120,require:true,align:'left'},
                       {field:'CommunicationAddress',title:'通讯地址',type:'string',width:120,align:'left'},
                       {field:'CommunicationPort',title:'通讯端口',type:'int',width:120,align:'left'},
                       {field:'CommunicationOvertime',title:'通讯超时时间',type:'int',width:120,hidden:true,align:'left'},
                       {field:'DeviceType',title:'设备类型',type:'string',bind:{ key:'DeviceType',data:[]},width:120,hidden:true,align:'left'},
                       {field:'DeviceStatus',title:'设备状态',type:'string',bind:{ key:'DeviceIsUse',data:[]},width:120,hidden:true,align:'left'},
                       {field:'DeviceHeartBeat',title:'设备心跳',type:'string',bind:{ key:'DeviceIsUse',data:[]},width:120,hidden:true,align:'left'},
                       {field:'DeivceRemark',title:'设备备注',type:'string',width:120,hidden:true,align:'left'},
                       {field:'Workshop',title:'所属车间',type:'string',bind:{ key:'BasicWorkshop',data:[]},width:120,hidden:true,align:'left'},
                       {field:'Brand',title:'品牌',type:'string',bind:{ key:'Brand',data:[]},width:120,hidden:true,align:'left'},
                       {field:'DeviceStartTime',title:'设备开始运行时间',type:'datetime',width:120,hidden:true,align:'left',sort:true},
                       {field:'DeviceEndTime',title:'设备结束运行时间',type:'datetime',width:120,hidden:true,align:'left',sort:true},
                       {field:'CreateID',title:'创建ID',type:'int',width:120,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:120,hidden:true,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:120,hidden:true,require:true,align:'left',sort:true},
                       {field:'ModifyID',title:'修改ID',type:'int',width:120,hidden:true,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:120,hidden:true,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:120,hidden:true,require:true,align:'left',sort:true}]);
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
