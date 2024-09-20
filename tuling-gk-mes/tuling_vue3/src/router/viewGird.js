let viewgird = [{
        path: '/Sys_Log',
        name: 'sys_Log',
        component: () =>
            import ('@/views/system/Sys_Log.vue')
    },
    {
        path: '/Sys_User',
        name: 'Sys_User',
        component: () =>
            import ('@/views/system/Sys_User.vue')
    },
    {
        path: '/permission',
        name: 'permission',
        component: () =>
            import ('@/views/system/Permission.vue')
    },

    {
        path: '/Sys_Dictionary',
        name: 'Sys_Dictionary',
        component: () =>
            import ('@/views/system/Sys_Dictionary.vue')
    },
    {
        path: '/Sys_Role',
        name: 'Sys_Role',
        component: () =>
            import ('@/views/system/Sys_Role.vue')
    }, {
        path: '/Sys_Role1',
        name: 'Sys_Role1',
        component: () =>
            import ('@/views/system/Sys_Role1.vue')
    }, {
        path: '/Sys_DictionaryList',
        name: 'Sys_DictionaryList',
        component: () =>
            import ('@/views/system/Sys_DictionaryList.vue')
    }, {
        path: '/FormDesignOptions',
        name: 'FormDesignOptions',
        component: () =>
            import ('@/views/system/form/FormDesignOptions.vue')
    }, {
        path: '/FormCollectionObject',
        name: 'FormCollectionObject',
        component: () =>
            import ('@/views/system/form/FormCollectionObject.vue')
    }, {
        path: '/Sys_WorkFlow',
        name: 'Sys_WorkFlow',
        component: () =>
            import ('@/views/system/flow/Sys_WorkFlow.vue')
    }, {
        path: '/Sys_WorkFlowStep',
        name: 'Sys_WorkFlowStep',
        component: () =>
            import ('@/views/system/flow/Sys_WorkFlowStep.vue')
    }, {
        path: '/Sys_WorkFlowTable',
        name: 'Sys_WorkFlowTable',
        component: () =>
            import ('@/views/system/flow/Sys_WorkFlowTable.vue')
    }, {
        path: '/Sys_WorkFlowTableStep',
        name: 'Sys_WorkFlowTableStep',
        component: () =>
            import ('@/views/system/flow/Sys_WorkFlowTableStep.vue')
    }, {
        path: '/Sys_QuartzOptions',
        name: 'Sys_QuartzOptions',
        component: () =>
            import ('@/views/system/quartz/Sys_QuartzOptions.vue')
    }, {
        path: '/Sys_QuartzLog',
        name: 'Sys_QuartzLog',
        component: () =>
            import ('@/views/system/quartz/Sys_QuartzLog.vue')
    }, {
        path: '/Albert_DeviceType',
        name: 'Albert_DeviceType',
        component: () =>
            import ('@/views/device/albert_devicetype/Albert_DeviceType.vue')
    }, {
        path: '/Albert_DeviceConfigure',
        name: 'Albert_DeviceConfigure',
        component: () =>
            import ('@/views/device/albert_deviceconfigure/Albert_DeviceConfigure.vue')
    }, {
        path: '/Albert_DeviceMaintainance',
        name: 'Albert_DeviceMaintainance',
        component: () =>
            import ('@/views/device/albert_devicemaintainance/Albert_DeviceMaintainance.vue')
    }, {
        path: '/Albert_DeviceRepair',
        name: 'Albert_DeviceRepair',
        component: () =>
            import ('@/views/device/albert_devicerepair/Albert_DeviceRepair.vue')
    }, {
        path: '/Albert_DeviceMaintainanceList',
        name: 'Albert_DeviceMaintainanceList',
        component: () =>
            import ('@/views/device/albert_devicemaintainancelist/Albert_DeviceMaintainanceList.vue')
    }, {
        path: '/Albert_DeviceRepairList',
        name: 'Albert_DeviceRepairList',
        component: () =>
            import ('@/views/device/albert_devicerepairlist/Albert_DeviceRepairList.vue')
    }, {
        path: '/Albert_DeviceDBRequestType',
        name: 'Albert_DeviceDBRequestType',
        component: () =>
            import ('@/views/device/albert_devicedbrequesttype/Albert_DeviceDBRequestType.vue')
    }, {
        path: '/Albert_DeviceDataType',
        name: 'Albert_DeviceDataType',
        component: () =>
            import ('@/views/device/albert_devicedatatype/Albert_DeviceDataType.vue')
    }, {
        path: '/Albert_BasicWorkshop',
        name: 'Albert_BasicWorkshop',
        component: () =>
            import ('@/views/basicdata/albert_basicworkshop/Albert_BasicWorkshop.vue')
    }, {
        path: '/Albert_DeviceBrand',
        name: 'Albert_DeviceBrand',
        component: () =>
            import ('@/views/device/albert_devicebrand/Albert_DeviceBrand.vue')
    }, {
        path: '/Albert_InboundOrder',
        name: 'Albert_InboundOrder',
        component: () =>
            import ('@/views/inbound/albert_inboundorder/Albert_InboundOrder.vue')
    }, {
        path: '/Albert_InboundOrderList',
        name: 'Albert_InboundOrderList',
        component: () =>
            import ('@/views/inbound/albert_inboundorderlist/Albert_InboundOrderList.vue')
    }, {
        path: '/Albert_DeviceConfigureQueryView',
        name: 'Albert_DeviceConfigureQueryView',
        component: () =>
            import ('@/views/device/albert_deviceconfigurequeryview/Albert_DeviceConfigureQueryView.vue')
    }, {
        path: '/Albert_BasicNumberRule',
        name: 'Albert_BasicNumberRule',
        component: () =>
            import ('@/views/basicdata/albert_basicnumberrule/Albert_BasicNumberRule.vue')
    }, {
        path: '/Albert_BasicQCode',
        name: 'Albert_BasicQCode',
        component: () =>
            import ('@/views/basicdata/albert_basicqcode/Albert_BasicQCode.vue')
    }, {
        path: '/Albert_InboundOrderOuter',
        name: 'Albert_InboundOrderOuter',
        component: () =>
            import ('@/views/inbound/albert_inboundorderouter/Albert_InboundOrderOuter.vue')
    }, {
        path: '/Albert_InboundOrderOuterList',
        name: 'Albert_InboundOrderOuterList',
        component: () =>
            import ('@/views/inbound/albert_inboundorderouterlist/Albert_InboundOrderOuterList.vue')
    }, {
        path: '/Albert_Swagger',
        name: 'Albert_Swagger',
        component: () =>
            import ('@/views/systemtool/albert_swagger/Albert_Swagger.vue')
    }, {
        path: '/Albert_RFID',
        name: 'Albert_RFID',
        component: () =>
            import ('@/views/dataquery/albert_rfid/Albert_RFID.vue')
    }, {
        path: '/Albert_Alarm',
        name: 'Albert_Alarm',
        component: () =>
            import ('@/views/dataquery/albert_alarm/Albert_Alarm.vue')
    }, {
        path: '/WorkStationInfo',
        name: 'WorkStationInfo',
        meta: {
            keepAlive: false
        },
        component: () =>
            import ('@/views/workStationInfo/WorkStationInfo.vue')
    }, {
        path: '/Albert_Access',
        name: 'Albert_Access',
        component: () =>
            import ('@/views/dataquery/albert_access/Albert_Access.vue')
    }, {
        path: '/Albert_DeviceConfigureMuchPage',
        name: 'Albert_DeviceConfigureMuchPage',
        component: () =>
            import ('@/extension/device/albert_deviceconfigure/Albert_DeviceConfigureMuchPage.vue')
    }, {
        path: '/Albert_Craft',
        name: 'Albert_Craft',
        component: () =>
            import ('@/views/productionmanager/albert_craft/Albert_Craft.vue')
    }, {
        path: '/Albert_PdmWorkorder',
        name: 'Albert_PdmWorkorder',
        component: () =>
            import ('@/views/productionmanager/albert_pdmworkorder/Albert_PdmWorkorder.vue')
    }, {
        path: '/Albert_PdmProduct',
        name: 'Albert_PdmProduct',
        component: () =>
            import ('@/views/productionmanager/albert_pdmproduct/Albert_PdmProduct.vue')
    }, {
        path: '/Albert_DataFirst',
        name: 'Albert_DataFirst',
        component: () =>
            import ('@/views/dataquery/albert_datafirst/Albert_DataFirst.vue')
    }, {
        path: '/Albert_DataSecond',
        name: 'Albert_DataSecond',
        component: () =>
            import ('@/views/dataquery/albert_datasecond/Albert_DataSecond.vue')
    }, {
        path: '/Albert_DataFirstRework',
        name: 'Albert_DataFirstRework',
        component: () =>
            import ('@/views/dataquery/albert_datafirstrework/Albert_DataFirstRework.vue')
    }, {
        path: '/Albert_DataSecondRework',
        name: 'Albert_DataSecondRework',
        component: () =>
            import ('@/views/dataquery/albert_datasecondrework/Albert_DataSecondRework.vue')
    }, {
        path: '/Albert_DeviceStationConfigure',
        name: 'Albert_DeviceStationConfigure',
        component: () =>
            import ('@/views/device/albert_devicestationconfigure/Albert_DeviceStationConfigure.vue')
    }, {
        path: '/Albert_DataReworkConfiguration',
        name: 'Albert_DataReworkConfiguration',
        component: () =>
            import ('@/views/dataquery/albert_datareworkconfigview/Albert_DataReworkConfigView.vue')
    },
    {
        path: '/grafana',
        name: 'grafana',
        component: () =>
            import ('@/views/systemtool/grafana/grafana.vue')
    }, {
        path: '/dotnetify',
        name: 'dotnetify',
        component: () =>
            import ('@/views/systemtool/dotnetify/dotnetify.vue')
    }, {
        path: '/Albert_CraftParam',
        name: 'Albert_CraftParam',
        component: () =>
            import ('@/views/productionmanager/albert_craftparam/Albert_CraftParam.vue')
    }, {
        path: '/Albert_PdmCraftDevice',
        name: 'Albert_PdmCraftDevice',
        component: () =>
            import ('@/views/productionmanager/albert_pdmcraftdevice/Albert_PdmCraftDevice.vue')
    }, {
        path: '/Albert_PdmCraftParamHistory',
        name: 'Albert_PdmCraftParamHistory',
        component: () =>
            import ('@/views/productionmanager/albert_pdmcraftparamhistory/Albert_PdmCraftParamHistory.vue')
    }, {
        path: '/Albert_EmEnergyMananger',
        name: 'Albert_EmEnergyMananger',
        component: () =>
            import ('@/views/energymanager/albert_emenergymananger/Albert_EmEnergyMananger.vue')
    }, {
        path: '/Albert_EmEnergyRealQuery',
        name: 'Albert_EmEnergyRealQuery',
        component: () =>
            import ('@/views/energymanager/albert_emenergyrealquery/Albert_EmEnergyRealQuery.vue')
    }, {
        path: '/Albert_DeviceStationConfigureView',
        name: 'Albert_DeviceStationConfigureView',
        component: () =>
            import ('@/views/device/albert_devicestationconfigureview/Albert_DeviceStationConfigureView.vue')
    }
    ,{
        path: '/tbl_record_data_240',
        name: 'tbl_record_data_240',
        component: () => import('@/views/dataquery/tbl_record_data_240/tbl_record_data_240.vue')
    }    ,{
        path: '/tbl_record_data_230',
        name: 'tbl_record_data_230',
        component: () => import('@/views/dataquery/tbl_record_data_230/tbl_record_data_230.vue')
    }    ,{
        path: '/tbl_record_data_250',
        name: 'tbl_record_data_250',
        component: () => import('@/views/dataquery/tbl_record_data_250/tbl_record_data_250.vue')
    }    ,{
        path: '/tbl_record_data_290',
        name: 'tbl_record_data_290',
        component: () => import('@/views/dataquery/tbl_record_data_290/tbl_record_data_290.vue')
    }    ,{
        path: '/tbl_record_data_300',
        name: 'tbl_record_data_300',
        component: () => import('@/views/dataquery/tbl_record_data_300/tbl_record_data_300.vue')
    }    ,{
        path: '/albert_dataerror',
        name: 'albert_dataerror',
        component: () => import('@/views/dataquery/albert_dataerror/albert_dataerror.vue')
    }    ,{
        path: '/albert_deviceplus',
        name: 'albert_deviceplus',
        component: () => import('@/views/device/albert_deviceplus/albert_deviceplus.vue')
    }]

export default viewgird