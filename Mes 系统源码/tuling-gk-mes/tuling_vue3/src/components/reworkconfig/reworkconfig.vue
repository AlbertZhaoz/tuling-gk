<template>
  <el-row class="padding">
    <!-- <el-col :span="16"> -->
    <el-col :span="24">
      <div class="operateButton">
        <span v-if="reworkNumber == 1">1线产品码: </span>
        <span v-if="reworkNumber == 2">2线壳体码: </span>
        <el-input v-model="productCode" class="productCode" />
        <el-button type="primary" @click="searchByCode">查询</el-button>
        <el-button type="primary" @click="modifyMesssge('set')">置位</el-button>
        <el-button type="primary" @click="modifyMesssge('change')">修改</el-button>
      </div>
      <el-steps :active="stepActive(index + 1)" v-for="(item,index) in secondStepsData" :key="index">
        <el-step v-for="(item1,index1) in item" :key="index1" :status="(index1+1 <= stepActive(index +1)) ? 'finish' : 'wait'" @click.enter="setActive(index+1,index1+1,item1)" :title="item1.deviceDBSubname">
          <template v-slot:icon>
            <div class="el-step__icon-inner">{{item1.deviceDBName}}</div>
          </template>
        </el-step>
      </el-steps>        
    </el-col>
    <!-- <el-col :span="8">
      <DataFirstReworkViewVue v-if="reworkNumber == 1" ref="dataFirstReworkViewVueRefs"></DataFirstReworkViewVue>
      <DataSecondReworkViewVue v-else ref="dataFirstReworkViewVueRefs"></DataSecondReworkViewVue>
    </el-col> -->
  </el-row>
</template>

<script>
import { ElMessageBox } from 'element-plus';
// import DataFirstReworkViewVue from "../../views/dataquery/albert_datafirstreworkview/Albert_DataFirstReworkView.vue";
// import DataSecondReworkViewVue from "../../views/dataquery/albert_datasecondreworkview/Albert_DataSecondReworkView.vue";
export default {
  data() {
    return {
      productCode: "", //产品码
      active: 0, // 激活步骤,
      oneStepsData: [], //一维数组数据
      rowStepSize: 10, //每行最大数量
      secondStepsData: [], //二维数组数据
      stepsCount: [], //el-steps组数
      lastStepName: "", //圆圈中显示数据
    };
  },
  // components: {
  //   DataFirstReworkViewVue,
  //   DataSecondReworkViewVue,
  // },
  props: {
    devicePkInt: Number,
    reworkNumber: Number,
  },
  created() {
    // 获取步骤数据
    this.http
      .get(
        "/api/Albert_Kanban/GetStationListByDevicePkIntAsync?devicePkInt=" +
          this.devicePkInt
      )
      .then((res) => {
        if (!res.status) return this.$message.error(res.message);
        this.oneStepsData = res.data;
        // 一维数组数据转二维数组
        this.stepsCount = Math.ceil(
          this.oneStepsData.length / this.rowStepSize
        );
        for (let index = 0; index < this.stepsCount; index++) {
          let newArr = this.oneStepsData.slice(
            index * this.rowStepSize,
            index * this.rowStepSize + this.rowStepSize
          );
          this.secondStepsData.push(newArr);
        }
      });
    this.$store.getters.data().productCode = this.productCode;
  },
  methods: {
    // 计算当前激活步骤
    stepActive(index) {
      return this.active - index * this.rowStepSize > 0
        ? this.rowStepSize
        : this.active - (index - 1) * this.rowStepSize > 0
        ? this.active - (index - 1) * this.rowStepSize
        : 0;
    },
    // 设置当前步骤
    setActive(index, index1, value) {
      this.lastStepName = value.deviceDBName;
      this.active = (index - 1) * this.rowStepSize + index1;
    },
    // 查询
    searchByCode() {
      this.$store.getters.data().productCode = this.productCode;
      this.http
        .get(
          "/api/Albert_DataFirst/GetLastStation?reworkNumber=" +
            this.reworkNumber +
            "&productCode=" +
            this.productCode
        )
        .then((res) => {
          if (!res.status) {
            this.active = 0;
            return this.$message.error(res.message);
          }
          this.active = res.data.deviceDBSort;
          // this.$refs.dataFirstReworkViewVueRefs.$refs.grid.search();
        });
    },
    // 修改{和置位弹窗
    modifyMesssge (value) {
      if (!this.productCode) {
        this.$message.warning("不存在产品码");
        return;
      }
      if (value === 'change' && !this.lastStepName) {
        this.$message.warning("未选择最终站");
        return;
      }
      let message = '';
      if (value === 'set') {
        message = '是否确定将' + this.productCode + '产品' + '置位?';
      } else {
        message = '是否确定将' + this.productCode + '的最终站改为' + this.lastStepName + '?';
      }
      ElMessageBox.alert(message, '提示', {
        confirmButtonText: 'OK',
        callback: (action) => {
          if (action !== 'confirm') {
            return;
          }
          this.modify(value);
        }
      })
    },
    // 修改和置位
    modify(value) {
      let lastStepName = value == "set" ? this.oneStepsData[0].deviceDBName : this.lastStepName
      // if (value == "set") {
      //   this.lastStepName = this.oneStepsData[0].deviceDBName;
      // }
      this.http
        .get(
          "/api/Albert_DataFirst/SendLastStation?reworkNumber=" +
            this.reworkNumber +
            "&productCode=" +
            this.productCode +
            "&lastStepName=" +
            lastStepName
        )
        .then((res) => {
          if (!res.status) return this.$message.error(res.message);
          if (value == "set") {
            this.active = 1;
            // this.$refs.dataFirstReworkViewVueRefs.$refs.grid.search();
            return this.$message.success("置位成功");
          }
          this.$message.success("修改成功");
          this.searchByCode();
          // this.$refs.dataFirstReworkViewVueRefs.$refs.grid.search();
        });
    },
  },
};
</script>

<style lang="less" scoped>
.padding {
  padding: 20px;
  box-sizing: border-box;
}
.el-col-16 {
  padding: 20px;
}
.el-col > .el-col {
  max-height: calc(100vh - 95px);
  overflow-y: auto;
}
.operateButton {
  margin-bottom: 20px;
}
.productCode {
  width: 150px;
  margin-right: 10px;
}
/* 设置占据主轴空间大小 */
.el-step.is-horizontal {
  // flex-basis: 16% !important;
  flex-basis: 10% !important;
}
::v-deep .el-step__icon {
  width: 60px;
  height: 60px;
  border-radius: 50% !important;
  border: 2px solid !important;
  border-color: inherit !important;
}
.el-step.is-horizontal ::v-deep .el-step__line {
  top: 29px !important;
}
::v-deep .el-step__head.is-finish {
  color: inherit;
  .el-step__icon,
  .el-step__line {
    background-color: var(--el-color-primary);
  }
}
</style>
