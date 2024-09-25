<template>
  <div class="work-station-info-container view-container">
    <div class="view-header">
      <div class="desc-text">
        <i class="el-icon-s-grid" />
        <span>工站交互信息</span>
      </div>
      <div class="info-box">
        <el-button type="primary" @click="runQuery" v-show="!timerQuery">定时刷新数据</el-button>
        <el-button type="primary" plain @click="clearTimer" v-show="timerQuery">停止刷新数据</el-button>
        <el-button type="primary" @click="getRfidList(activeName)">刷新数据</el-button>
        <el-button type="success" plain @click="clearInfo">清除所有交互信息</el-button>
      </div>
    </div>
    <div class="main">
      <el-tabs v-model="activeName" @tab-click="handleClick">
        <el-tab-pane v-for="(item, index) in activeNames" :label="'环形'+ item + '线'" :name="item" :key="index">
          <!-- <el-tab-pane label="1" name="1"> -->
          <div class="station-list">
            <el-row :gutter="20">
              <el-col :span="4">
                <div v-for="(rfidItem, index) in rfidList" :key="index">
                  <el-button :type="currentRfidModel && rfidItem.rfid === currentRfidModel.rfid ? 'primary' : ''" plain style="width:80%" @click="handleClickRfid(rfidItem)">托盘号:{{rfidItem.rfid}}</el-button>
                </div>
              </el-col>
              <el-col :span="20">
                <el-row :gutter="20">
                  <el-col :xs="24" :sm="24" :md="12" :lg="8" :xl="6" v-for="(stationItem, index) in filteredStationList" :key="index">
                    <div class="station-item">
                      <div class="station-name">{{stationItem.deviceDBName}}</div>
                      <div class="station-info-list">
                        <el-scrollbar style="height: 100%" v-if="currentRfidModel">
                          <div class="station-info-item">加工类型：{{currentRfidModel.productFunction}}</div>
                          <div class="station-info-item">加工内容：{{currentRfidModel.productContent}}</div>
                          <div class="station-info-item">
                            产品码：{{currentRfidModel.productCode
                            }}
                          </div>
                          <div class="station-info-item">
                            最终站：{{currentRfidModel.opFinalStation
                            }}
                          </div>
                          <div class="station-info-item">
                            最终结果：{{currentRfidModel.opFinalResult
                            }}
                          </div>
                          <div class="station-info-item">
                            最终结果：{{currentRfidModel.opFinalResult
                            }}
                          </div>
                          <div class="station-info-item">
                            读取托盘号：{{getRfidCommonProp(stationItem.deviceDBName).Get_RFID
                            }}
                          </div>
                          <div class="station-info-item">
                            下发结果：{{getRfidCommonProp(stationItem.deviceDBName).Get_RFID
                            }}
                          </div>
                        </el-scrollbar>
                      </div>
                      <div class="no-data">暂无数据</div>
                    </div>
                  </el-col>
                </el-row>
              </el-col>
            </el-row>
          </div>
        </el-tab-pane>
      </el-tabs>
    </div>
  </div>
</template>
<script setup>
import { ref, reactive, onMounted, nextTick, computed } from "vue";
import { onBeforeRouteLeave } from "vue-router";
import http from "@/api/http.js";
import { ElMessage } from "element-plus";

let activeNames = ref(["1", "2"]);
let activeName = ref("1");
let timerQuery = ref(null);
// 定时执行
const runQuery = () => {
  if (timerQuery.value) {
    clearTimer();
  }
  timerQuery.value = setInterval(() => {
    getInfoList();
  }, 1000);
};
// 清除定时执行
const clearTimer = () => {
  if (timerQuery.value) {
    clearInterval(timerQuery.value);
    timerQuery.value = null;
  }
};
// 清除所有交互信息
const clearInfo = async () => {
  const res = await http.get("/api/Albert_RFID/GetClearPlcSignal");
  if (res.status) {
    ElMessage.success(res.message || "清除所有交互信息成功");
    getRfidList(activeName.value);
  } else {
    ElMessage.error(res.message || "清除所有交互信息失败");
  }
};

// rfid列表
let rfidList = ref([]);
let stationList = ref([]);
// 工站信息列表
let rfidInfoList = ref([]);

// 获取rfid列表
const getRfidList = async (lineId) => {
  const res = await http.get(
    "/api/Albert_RFID/GetAllRfidFromCache?lineId=" + lineId
  );
  if (res.status) {
    rfidList.value = res.data;
    getStationList();
    // console.log('currentRfidModel', currentRfidModel.value);
    if (!currentRfidModel.value) {
      currentRfidModel.value = rfidList.value[0];
    }
    handleClickRfid(currentRfidModel.value);
    return filteredStationList;
  } else {
    ElMessage.error(res.message || "请求环形" + lineId + "线托盘列表失败");
  }
};

const getStationList = async () => {
  const res = await http.get("/api/BaseKanban/GetStationListForRfid");
  if (res.status) {
    stationList.value = res.data;
  } else {
    ElMessage.error(res.message || "获取在制工艺下的所有工站失败");
  }
};

// 获取工站信息
const getInfoList = () => {
  let req = [];
  filteredStationList.value.forEach((item) => {
    req.push(
      http.get("/api/Albert_RFID/GetPlcSignal?stationName=" + item.deviceDBName)
    );
  });
  let errMsg = "";
  // console.log(req)
  Promise.all(req)
    .then((res) => {
      // console.log(res)
      let newStaionInfo = [];
      res.forEach((item, index) => {
        let list = [];
        if (item.status) {
          list = item.data;
        }
        newStaionInfo.push(list);
      });
      console.log(newStaionInfo, rfidInfoList.value);
      rfidInfoList.value = newStaionInfo;
    })
    .catch((e) => {
      clearTimer();
    });
};

const handleClick = (tab, event) => {
  console.log(tab, event, activeName.value);
  currentRfidModel.value = null;
  nextTick(() => {
    getRfidList(activeName.value);
  });
};

const currentRfidModel = ref(null);

const handleClickRfid = (rfidModel) => {
  currentRfidModel.value = rfidModel;
};

const filteredStationList = computed(() => {
  if (currentRfidModel.value == null) {
    return stationList.value; // 初始状态显示所有数据
  }

  let filterStationList = stationList.value.filter((item) => {
    if (currentRfidModel.value.rfid < 50) {
      return item.deviceDBPkInt < 16;
    } else {
      return item.deviceDBPkInt > 16;
    }
  });
  return filterStationList;
});

const getRfidCommonProp = (stationName) => {
  // 使用字符串模板动态构建属性名
  const getRfidProperty = `${stationName.toLowerCase()}R_Get_RFID`;
  const sendReadProperty = `${stationName.toLowerCase()}R_Send_Read`;

  // 动态访问属性
  return {
    Get_RFID: currentRfidModel.value[getRfidProperty],
    Send_Read: currentRfidModel.value[sendReadProperty],
  };
};

onBeforeRouteLeave((to, from, next) => {
  console.log("to", to);
  clearTimer();
  next();
});
onMounted(() => {
  getRfidList(activeName.value);
});
</script>
<style lang="less">
.work-station-info-container {
  padding: 15px;
  font-size: 14px;
  height: calc(100vh - 100px);
  box-sizing: border-box;
  display: flex;
  flex-direction: column;
  .view-header {
    height: 45px;
    position: relative;
    padding-bottom: 11px;
    display: flex;
    justify-content: space-between;
    .search-line {
      min-width: 150px;
    }
    .search-line > div {
      margin-left: 5px;
      margin-right: 10px;
    }
    .search-line > div > div {
      width: 200px;
      text-align: left;
    }
    .search-line > div:first-child {
      flex: 1;
    }
    .search-line > div .ivu-select-dropdown {
      max-height: 300px;
    }
    .btn-group {
      white-space: nowrap;
      button {
        margin-left: 10px;
        // padding: 5px 16px;
      }
    }
    .btn-group .ivu-dropdown-item {
      text-align: left !important;
    }
    .btn-group .ivu-dropdown-item:not(:last-child) {
      border-bottom: 1px dotted #eee;
    }
    .desc-text {
      margin-top: 5px;
      font-weight: bold;
      margin-bottom: 3px;
      font-size: 14px;
      color: #313131;
      white-space: nowrap;
      border-bottom: 2px solid #646565;
      i {
        font-size: 16px;
        position: relative;
        top: 1px;
        margin-right: 2px;
      }
    }
    .search-box {
      background: #fefefe;
      margin-top: 45px;
      border: 1px solid #ececec;
      position: absolute;
      z-index: 999;
      left: 0;
      right: 0;
      padding: 25px 40px;
      padding-bottom: 0;
      box-shadow: 0px 7px 18px -12px #bdc0bb;
    }
    .notice {
      font-size: 13px;
      color: #6b6b6b;
      overflow: hidden;
      text-overflow: ellipsis;
      white-space: nowrap;
      position: relative;
      top: 12px;
      flex: 1;
      left: 10px;
      margin-right: 20px;
    }
    .info-box {
      display: flex;
      justify-content: flex-end;
      width: 350px;
      margin-top: 9px;
    }
  }
  .main {
    // padding: 0 20px;
    .el-col {
      margin: 0 0 24px 0;
      // height: 230px;
    }
    .station-list {
      // display: flex;
      // flex-wrap: wrap;
      margin: 12px;
      .station-item {
        // min-height: 100px;
        height: 300px;
        box-sizing: border-box;
        // width: 360px;
        // flex: 0 0 auto;
        // border: 1px solid #cccccc;
        // height: 100%;
        border: 1px solid rgba(0, 0, 0, 0.12);
        // box-shadow: 0px 0px 12px rgba(0, 0, 0, 0.12);
        // margin: 30px 0 30px 0;
        padding: 16px 0;
        border-radius: 4px;
        position: relative;
        .station-name {
          color: #303133;
          line-height: 22px;
          height: 28px;
          font-size: 16px;
          font-weight: 400;
          padding: 0 12px 6px;
          margin-bottom: 12px;
          border-bottom: 1px solid #e4e7ed;
        }
        .station-info-list {
          // min-height: 19px;
          position: absolute;
          height: 230px;
          padding: 0 12px 0 12px;
          width: 100%;
          color: #909399;
          font-size: 14px;
          background: #fff;
          z-index: 1;
          .station-info-item {
            margin: 4px 0;
          }
        }
        .no-data {
          position: absolute;
          top: 58px;
          left: 12px;
          z-index: 0;
          color: #909399;
        }
      }
    }
  }

  .is-plain:hover,
  .is-plain:focus {
    color: #409eff;
    border-color: #a0cfff;
    background-color: #ecf5ff;
  }
}
</style>
