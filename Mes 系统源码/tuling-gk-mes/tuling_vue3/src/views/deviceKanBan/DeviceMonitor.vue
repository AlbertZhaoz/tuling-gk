<template>
  <div class="device-look-container view-container">
    <div class="view-header">
      <div class="desc-text">
        <i class="el-icon-s-grid" />
        <span>设备监控</span>
      </div>
      <div class="info-box">
        <div class="info">产品型号：{{workOrder.productName}}</div>
        <div class="info">计划产量：{{workOrder.workorderPlan}}</div>
        <div class="info">完成产量：{{workOrder.workorderActual}}</div>
        <div class="info">合格产量：{{workOrder.workorderOK}}</div>
      </div>
    </div>
    <div class="main">
      <div class="main-left">
        <div class="equ-num">
          <div class="main-title">
            <el-icon :size="20">
              <Postcard />
            </el-icon>
            <span>今日设备运行数量</span>
          </div>
          <div class="progress-box">
            <div class="deviceNormalRateProgress" v-for="(item, index) in deviceNormalRateList" :key="index">
              <div class="deviceNormalInfo">
                {{ item.name }}:
                <span class="value">{{ item.value }}</span>
              </div>
              <div>
                <el-progress :percentage="item.value / valuePlus * 100" :color="item.color" :show-text="false" :stroke-width="20" :status="item.status"></el-progress>
              </div>
            </div>
          </div>
        </div>
        <div class="equ-tem">
          <div class="main-title">
            <el-icon :size="20">
              <Postcard />
            </el-icon>
            <span>能耗管控</span>
          </div>
          <div class="gas-box">
            <div class="gas-item" v-for="(item, ind) in gasList" :key="ind">
              <NumShow :name="item.name" :value="item.valueArr" :unit="'立方米'"></NumShow>
            </div>
          </div>
          <div class="elec-box">
            <div class="elec-item" v-for="(item, ind) in elecList" :key="ind">
              <NumShow :name="item.name" :value="item.valueArr" :unit="'千瓦时'"></NumShow>
            </div>
          </div>
        </div>
      </div>
      <div class="main-right">
        <!-- <div class="tab-title">今日设备运行数量</div> -->
        <div class="scroll-box" id="scrollBox" @mouseenter="scrollHover" @mouseleave="scrollOut">
          <div class="equ-list" id="equList">
            <el-row :gutter="10">
              <el-col :xs="24" :sm="24" :md="24" :lg="12" :xl="8" v-for="(item, ind) in equList" :key="ind">
                <div class="equ-item">
                  <div class="equ-row">
                    <div>
                      <el-button type="success" size="small" round :icon="Select" v-if="item.deviceDBStatus === 'Y'">{{item.deviceDBName}}</el-button>
                      <el-button type="danger" size="small" round :icon="Close" v-if="item.deviceDBStatus === 'N'">{{item.deviceDBName}}</el-button>
                      <el-button type="warning" size="small" round :icon="SwitchButton" v-if="item.deviceDBStatus === 2">{{item.deviceDBName}}</el-button>
                    </div>
                    <div class="equ-time">
                      运行时间
                      <span class="value">{{getHour(item.deviceDBStartTime)}}</span>
                      <span>小时</span>
                      <!-- <span v-show="!item.equipmentBootTime">暂无数据</span> -->
                    </div>
                  </div>
                  <div class="equ-row">
                    <div class="equ-info">
                      当前节拍
                      <span class="value">{{item.productBeat}}</span>件
                    </div>
                    <div class="equ-info">
                      总计产量
                      <span class="value">{{item.productQuantity}}</span>件
                    </div>
                    <div class="equ-info">
                      是否维修
                      <span class="value">{{item.isRepairStatus ? item.isRepairStatus : '不维修' }}</span>
                    </div>
                  </div>
                </div>
              </el-col>
            </el-row>
          </div>
          <!-- <div class="equ-list" id="equList">
            <div class="equ-item" v-for="(item, key) in equList" :index="item.name">
              <div class="equ-row">
                <div>
                  <el-button type="success" size="small" round :icon="Select" v-if="item.status === 0">{{item.name}}</el-button>
                  <el-button type="danger" size="small" round :icon="Close" v-if="item.status === 1">{{item.name}}</el-button>
                  <el-button type="warning" size="small" round :icon="SwitchButton" v-if="item.status === 2">{{item.name}}</el-button>
                </div>
                <div class="equ-time">运行时间<span class="value">{{item.runTime}}</span>小时</div>
              </div>
              <div class="equ-row">
                <div class="equ-info">合格产量<span class="value">{{item.okAmount}}</span>件</div>
                <div class="equ-info">产量<span class="value">{{item.amount}}</span>件</div>
                <div class="equ-info">合格率<span class="value ">{{(item.okAmount/item.amount * 100).toFixed(2)}}%</span></div>
              </div>
            </div>
          </div>-->
        </div>
        <!-- </el-scrollbar> -->
      </div>
    </div>
  </div>
</template>
<script setup>
import { ref, onMounted, onBeforeMount, nextTick } from "vue";
import { onBeforeRouteLeave } from "vue-router";
import http from "@/api/http";
import {
  Check,
  CircleCheck,
  Odometer,
  Select,
  SwitchButton,
  Close,
  Postcard,
} from "@element-plus/icons-vue";
import { ElScrollbar } from "element-plus";
import NumShow from "./components/NumShow.vue";

const deviceNormalRateList = ref([
  {
    name: "运行设备",
    value: 0,
    status: "success",
  },
  {
    name: "停机设备",
    value: 0,
    status: "warning",
  },
  {
    name: "异常设备",
    value: 0,
    status: "exception",
  },
]);
let valuePlus = ref(0);
const equList = ref([]);
const getEquNum = async () => {
  valuePlus.value = 0;
  const res = await http.get("/api/Albert_DeviceMonitor/GetOperation", {}, "");
  if (res.status) {
    res.data.forEach((ele) => {
      valuePlus.value += ele.equipmentCount;
      switch (ele.equipmentStatus) {
        case "Y":
          deviceNormalRateList.value[0].value = ele.equipmentCount;
          break;
        case "N":
          deviceNormalRateList.value[1].value = ele.equipmentCount;
          break;
        default:
          deviceNormalRateList.value[2].value = ele.equipmentCount;
          break;
      }
    });
  } else {
    // mesage
  }
};
const getEquList = async () => {
  const res = await http.get("/api/BaseKanban/GetPdmCraftStationList", {}, "");
  if (res.status) {
    equList.value = res.data || [];
  } else {
    // message
  }
  // 滚动
  nextTick(() => {
    upScroll();
  });
};
// const scrollbarRef = ref<InstanceType<typeof ElScrollbar>>()
let timer = ref(null);
const upScroll = (scrollTop) => {
  const viewHeight = document.getElementById("scrollBox").offsetHeight;
  const scrollObject = document.getElementById("scrollBox").scrollHeight;
  console.log(viewHeight, viewHeight, scrollObject);
  if (viewHeight < scrollObject) {
    let height = scrollTop || 0;
    timer.value = setInterval(() => {
      height += 1;
      if (height >= scrollObject - viewHeight + 20) {
        clearInterval(timer.value);
        height = 0;
        document.getElementById("equList").scrollIntoView({
          behavior: "smooth",
          block: "start",
        });
        upScroll();
      }
      document.getElementById("scrollBox").scrollTo({
        top: height,
        // behavior: 'smooth',
      });
    }, 60);
  }
};
const scrollHover = () => {
  if (timer.value) {
    clearInterval(timer.value);
  }
};
const scrollOut = () => {
  console.log("333321", document.getElementById("scrollBox").scrollTop);
  upScroll(document.getElementById("scrollBox").scrollTop);
};
// 仪表盘数据
const gasList = ref([]);
const elecList = ref([]);

const getTemperData = async () => {
  const resE = await http.get(
    "/api/Albert_DeviceMonitor/GetEmenergyQuery",
    {},
    ""
  );
  if (resE.status) {
    resE.data.forEach((ele) => {
      const valueNum = Number(ele.actualValue).toFixed(0);
      const valueArr = valueNum.toString().split("");
      if (ele.electricOrGas === "电表") {
        elecList.value.push({
          name: ele.name,
          value: ele.actualValue,
          valueArr,
        });
      } else if (ele.electricOrGas === "气表") {
        gasList.value.push({
          name: ele.name,
          value: ele.actualValue,
          valueArr,
        });
      }
    });
  } else {
    // mesage
  }
};
const getHour = (start) => {
  if (!start) {
    return 0;
  }
  const startT = new Date(start).getTime();
  const nowT = new Date().getTime();
  // 毫秒
  const time = nowT - startT;
  // 秒 time / 1000
  // 分钟 time / 1000 / 60
  // 小时 time / 1000 / 60 / 60
  return Math.floor(time / 1000 / 60 / 60);
};
// 工单数据
const workOrder = ref({});
const getWorkOrder = async () => {
  const resE = await http.get(
    "/api/Albert_DeviceMonitor/GetPdmWorkOrder",
    {},
    ""
  );

  if (resE.status) {
    workOrder.value = resE.data || [];
  } else {
    // mesage
  }
};
onBeforeRouteLeave((to, from, next) => {
  clearInterval(timer.value);
  timer.value = ref(null);
  next();
});
onMounted(() => {
  getEquNum();
  getEquList();
  getTemperData();
  getWorkOrder();
});
</script>
<style lang="less" scoped>
@import "@/components/basic/ViewGrid/ViewGrid.less";
.device-look-container {
  padding-top: 15px;
  // min-width: 1200px;
  width: 100%;
  .view-header {
    // display: flex;
    justify-content: space-between;
    .info-box {
      display: flex;
      .info {
        height: 34px;
        line-height: 34px;
        font-size: 13px;
        color: #6b6b6b;
        overflow: hidden;
        white-space: nowrap;
        margin-right: 20px;
      }
    }
  }
  .main {
    display: flex;
    padding: 0 15px;
    height: calc(100vh - 160px);
    justify-content: space-between;
    min-width: 1000px;
    width: 100%;
    box-sizing: border-box;
    min-height: 550px;
    .main-title {
      display: inline-flex;
      align-items: center;
      font-size: 14px;
      span {
        margin-left: 5px;
      }
    }
    .main-left {
      // width: 30%;
      width: 480px;
      flex-direction: column;
      justify-content: space-between;
      display: flex;
      .equ-num {
        height: 30%;
        .progress-box {
          display: flex;
          flex-direction: column;
          height: 88%;
          justify-content: space-around;
          padding: 0 0 4%;
        }
        .deviceNormalRateProgress {
          margin: 3px 0;
        }
        .deviceNormalInfo {
          font-size: 12px;
          color: #7d7a7a;
          .value {
            font-size: 16px;
            color: #333;
            margin: 0 3px 0 5px;
            font-style: italic;
          }
        }
      }
      .equ-tem {
        height: 66%;
        // border: 1px solid #ccc;
        .temple-humidity-box {
          // height: calc((100% - 20px) / 2);
          height: 210px;
          display: flex;
          .temple {
            .tem-name {
              text-align: center;
              font-size: 12px;
              padding-top: 10px;
            }
            width: 20%;
            // border: 1px solid #ccc;
            box-shadow: 0 0 10px #d8d8d8 inset;
            border-radius: 20px;
            // background: #000;
          }
        }
        .gas-box,
        .elec-box {
          display: flex;
          height: calc((100% - 50px) / 2);
          .gas-item,
          .elec-item {
            margin: 10px;
            width: 40%;
            box-shadow: 0 0 10px #d8d8d8 inset;
            border-radius: 20px;
          }
        }
        .temple-box {
          height: calc((100% - 20px) / 4);
          display: flex;
          .temple {
            width: 20%;
          }
        }
      }
    }
    .main-right {
      width: calc(100% - 500px);
      // border: 1px solid #ccc;
      box-sizing: border-box;
      // border: 1px solid #ccc;
      // padding: 10px 0;
      .scroll-box {
        height: 100%;
        overflow: scroll;
        padding: 0 10px;
        scrollbar-width: none;
      }
      .scroll-box::-webkit-scrollbar {
        display: none;
      }
      // .equ-list::after {
      //   content: '';
      //   flex: auto;
      // }
      .equ-list {
        .equ-item {
          border: 1px solid #d8d8d8;
          padding: 8px 10px;
          box-shadow: 4px 4px 1px 0px #ccc;
          border-radius: 12px;
          position: relative;
          // width: 320px;
          margin: 5px 0 7px;
          .equ-row {
            display: flex;
            align-items: center;
            justify-content: space-between;
            font-size: 14px;
            color: #7d7a7a;
            .value {
              font-size: 16px;
              color: #333;
              margin: 0 3px 0 5px;
              font-style: italic;
            }
            .big {
              // position: absolute;
              right: 2px;
              bottom: -6px;
              span {
                font-size: 30px;
              }
            }
            :deep(.el-button) {
              font-size: 14px !important;
              height: 24px !important;
              font-weight: bolder;
            }
            .equ-info {
              margin-top: 6px;
              white-space: nowrap;
            }
            .equ-info:nth-child(2) {
              margin: 6px 5px 0 5px;
            }
            .equ-info:nth-child(3) {
              // margin-right: 60px;
            }
          }
        }
      }
    }
    .equ-num,
    .equ-tem,
    .main-right {
      box-sizing: border-box;
      padding: 10px;
      box-shadow: 3px 3px 10px 0 #d8d8d8;
      border-radius: 6px;
    }
  }
}
@media screen and (max-width: 1800px) {
  :deep(.el-progress) {
    height: 10px;
  }
  :deep(.el-progress-bar__outer) {
    height: 10px !important;
  }
}
@media screen and (min-width: 1800px) {
  .equ-item {
    // width: 346px;
    margin: 5px 10px 7px;
  }
  .main-right {
    width: calc(100% - 520px);
  }
  .deviceNormalInfo {
    font-size: 14px !important;
  }
  .progress-box {
    padding: 4% 0;
  }
  :deep(.el-progress) {
    height: 20px;
  }
  :deep(.el-progress-bar__outer) {
    height: 20px !important;
  }
}
</style>
