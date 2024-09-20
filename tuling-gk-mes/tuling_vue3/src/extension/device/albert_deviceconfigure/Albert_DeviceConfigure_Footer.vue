<template>
  <div class="tabs">
    <el-tabs v-model="activeName" type="border-card" @tab-click="tabClick">
      <el-tab-pane label="工站台账" name="AlbertDeviceConfigure_Ref">
        <albertDeviceStationConfigure ref="AlbertDeviceConfigure_Ref"></albertDeviceStationConfigure>
      </el-tab-pane>
    </el-tabs>
  </div>
</template>
<script>
import Albert_DeviceStationConfigure from '@/views/device/albert_devicestationconfigure/Albert_DeviceStationConfigure.vue';

export default {
  components: {
    'albertDeviceStationConfigure': Albert_DeviceStationConfigure,
  },
  data() {
    return {
      activeName: 'AlbertDeviceConfigure_Ref',
    };
  },
  methods: {
    tabClick(params) {
      //console.log('选项卡点击事件');
    },
    rowClick(row) {
      //主表(产品管理)点击行事件

      //操作步骤2：调用两张表明细表的查询方法

      //浮脉查询条件配置，见Demo_ProductColor.js、Demo_ProductSize.js文件
      this.$refs.AlbertDeviceConfigure_Ref.$refs.grid.search();
    }
  }
};
</script>
<style scoped>
.tabs {
  padding: 15px;
}

.tabs>>>.el-tabs {
  box-shadow: none;
}

.tabs>>>.el-tabs__content {
  padding: 0 !important;
  padding-bottom: 15px;
}
</style>