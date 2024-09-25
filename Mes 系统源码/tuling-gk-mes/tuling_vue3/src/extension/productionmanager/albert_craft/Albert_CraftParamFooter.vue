<template>
  <div class="tabs">
    <el-tabs v-model="activeName" type="border-card" @tab-click="tabClick">
      <el-tab-pane label="工艺设备" name="Albert_PdmCraftDevice_Ref">
        <albertPdmCraftDevice ref="Albert_PdmCraftDevice_Ref" v-if="activeName === 'Albert_PdmCraftDevice_Ref'"></albertPdmCraftDevice>
      </el-tab-pane>
      <el-tab-pane label="工艺参数" name="Albert_CraftParam_Ref">
        <albertCraftParam ref="Albert_CraftParam_Ref" v-if="activeName === 'Albert_CraftParam_Ref'"></albertCraftParam>
      </el-tab-pane>
    </el-tabs>
  </div>
</template>
    <script>
import Albert_CraftParam from "@/views/productionmanager/albert_craftparam/Albert_CraftParam.vue";
import Albert_PdmCraftDevice from "@/views/productionmanager/albert_pdmcraftdevice/Albert_PdmCraftDevice.vue";

export default {
  components: {
    albertCraftParam: Albert_CraftParam,
    albertPdmCraftDevice: Albert_PdmCraftDevice,
  },
  data() {
    return {
      activeName: "Albert_PdmCraftDevice_Ref",
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
      if (this.activeName == "Albert_PdmCraftDevice_Ref") {
        this.$refs.Albert_PdmCraftDevice_Ref.$refs.grid.search();
      }

      if (this.activeName == "Albert_CraftParam_Ref") {
        this.$refs.Albert_CraftParam_Ref.$refs.grid.search();
      }
    },
  },
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
<style lang="less">
.craft-container {
  width: 100%;
  height: calc(100vh - 100px);
  display: flex;
  > .view-container {
    width: 40%;
    .fiexd-search-box {
      display: none;
    }
    .el-table {
      height: calc(100vh - 205px) !important;
    }
    .el-table__inner-wrapper {
      height: 100% !important;
    }

  }
  .tabs {
    width: 60%;
    height: 100%;
    .el-tabs__content {
      height: calc(100vh - 160px) !important;
    }
    .el-table {
      height: calc(100vh - 270px) !important;
    }
    .el-table__inner-wrapper {
      height: 100% !important;
    }
  }
  @media screen and (max-width: 1536px) {
    .el-button {
      padding: 5px !important;
      margin-top: 5px;
    }
    .search-line {
      .el-input__wrapper {
        height: 28px;
        margin-top: 3px;
      }
    }
  }

}
</style>