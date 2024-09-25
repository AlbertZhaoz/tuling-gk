<template>
  <div class="tabs">
    <el-tabs v-model="activeName" type="border-card" @tab-click="tabClick">
      <el-tab-pane label="入库列表管理" name="Albert_InboundOrder_Ref">
        <inboundOrder ref="Albert_InboundOrder_Ref"></inboundOrder>
      </el-tab-pane>
    </el-tabs>
  </div>
</template>
<script>
import Albert_InboundOrder from '@/views/inbound/albert_inboundorderlist/Albert_InboundOrderList.vue';

export default {
  components: {
    'inboundOrder': Albert_InboundOrder
  },
  data() {
    return {
      activeName: 'Albert_InboundOrder_Ref'
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
      this.$refs.Albert_InboundOrder_Ref.$refs.grid.search();
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