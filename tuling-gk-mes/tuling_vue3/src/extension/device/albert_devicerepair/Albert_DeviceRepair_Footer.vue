<template>
  <div class="tabs">
    <el-tabs v-model="activeName" type="border-card" @tab-click="tabClick">
      <el-tab-pane label="设备维修列表" name="Albert_DeviceRepairList_Ref">
        <albertDeviceRepairListEle ref="Albert_DeviceRepairList_Ref"></albertDeviceRepairListEle>
      </el-tab-pane>
    </el-tabs>
  </div>
</template>
<script>
import Albert_DeviceRepairList from '@/views/device/albert_devicerepairlist/Albert_DeviceRepairList.vue';

export default {
  components: {
    'albertDeviceRepairListEle': Albert_DeviceRepairList
  },
  data() {
    return {
      activeName: 'Albert_DeviceRepairList_Ref'
    };
  },
  methods: {
    tabClick(params) {
      console.log('选项卡点击事件');
    },
    rowClick(row) {
      //主表(产品管理)点击行事件
     
      //操作步骤2：调用两张表明细表的查询方法
      
      //浮脉查询条件配置，见Demo_ProductColor.js、Demo_ProductSize.js文件
      this.$refs.Albert_DeviceRepairList_Ref.$refs.grid.search();
    }
  }
};
</script>
<style scoped>
.tabs {
  padding: 15px;
}
.tabs >>> .el-tabs {
  box-shadow: none;
}
.tabs >>> .el-tabs__content {
  padding: 0 !important;
  padding-bottom: 15px;
}
</style>