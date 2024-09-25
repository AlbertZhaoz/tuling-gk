<template>
  <el-container>
    <!-- 头部 -->
    <el-header style="line-height: 60px;">
      <el-row>
        <el-col :span="6">{{currentTime}}</el-col>
        <el-col :span="12" style="text-align: center;font-size: 26px;letter-spacing: 1px;font-weight: 700;">生产管理系统看板</el-col>
        <el-col :span="6" class="productModel">产品型号：{{productModel }}</el-col>
      </el-row>
    </el-header>
    <!-- 主题部分 -->
    <el-main>
      <el-row>
        <!-- 左侧echarts -->
        <!--  -->
        <el-col :span="6">
          <!-- 一周产量 -->
          <div id="drug" class="drug unifiedStyle borderSky" ref="drugRefs"></div>
          <div class="drug-empty-tip" v-if="drugEmpty">当天暂无相关数据</div>
          <!-- 产品分析 -->
          <div id="personStatistics" class="unifiedStyle borderSky" ref="personStatisticsRefs"></div>
          <!-- <div id="productionLine" class="unifiedStyle borderSky" ref="productionLineRefs"></div> -->
          <div class="device unifiedStyle1 borderSky" id="device">
            <span class="deviceTitle" id="deviceTitle">设备监控</span>
            <div class="deviceContainer" id="deviceContainer">
              <div v-for="(item,index) in deviceData.result" :key="index" style="display:flex;padding: 5px;" class="borderSky">
                <div class="textFlex">
                  <div>设备名称:{{item.deviceName || ''}}</div>
                  <div>IP:{{item.communicationAddress || ''}}</div>
                  <div>端口号:{{item.communicationPort || ''}}</div>
                  <div>活动时间:{{item.modifyDate ? item.modifyDate.slice(0,10) : ''}}</div>
                </div>
                <div class="circle" :style="{background:item.deviceIsUse == 'Y' ? 'green' : 'red'}"></div>
              </div>
            </div>
          </div>
        </el-col>
        <el-col :span="12">
          <div class="dataDisplay">
            <!-- 数据展示 -->
            <div class="displayContainer" id="displayContainer">
              <!-- 上半部分数据 -->
              <div class="plannedProduction" id="plannedProduction">
                <div class="plannedtext" id="plannedtext">
                  <span>计划产量</span>
                  <span>{{productData.workorderPlan}}</span>
                </div>
                <div class="plannedtext" id="plannedtext">
                  <span>实际产量</span>
                  <span>{{productData.workorderActual}}</span>
                </div>
                <div class="plannedtext" id="plannedtext">
                  <span>完成率</span>
                  <span>{{productData.workorderSchedule + '%'}}</span>
                </div>
              </div>
              <!-- 下半部分数据 -->
              <div class="qualified" id="qualified">
                <div class="plannedtext">
                  <span>合格件数</span>
                  <span>{{productData.workorderOK}}</span>
                </div>
                <div class="plannedtext">
                  <span>不合格数</span>
                  <span>{{productData.workorderNG}}</span>
                </div>
                <div class="plannedtext">
                  <span>合格率</span>
                  <span>{{productData.workorderPassRate + '%'}}</span>
                </div>
              </div>
            </div>
            <!-- 工站监测 -->
            <div class="dbMonitoring">
              <div class="dbMonitoringTitle">
                <span>工站监测</span>
              </div>
              <div class="dbMonitoringText">
                <div v-for="(item,index) in dbMonitoringData" :key="index" style="display:flex;padding: 5px;" class="borderSky dbMonitoringTextFlex">
                  <div class="textFlex">
                    <div>工站名称:{{item.deviceDBName}}</div>
                    <div>工站用途:{{item.deviceDBSubname}}</div>
                    <div>开机时间:{{item.deviceDBStartTime ? item.deviceDBStartTime.slice(0,10) : ''}}</div>
                  </div>
                  <div class="circle" :style="{background:item.deviceDBStatus == 'Y' ? 'green' : 'red'}"></div>
                </div>
              </div>
              <!-- 翻页 -->
              <div class="pagination">
                <span v-for="item in Math.ceil(dbtotal/16)" :key="item" @click="dbMonitoring(item,16)" class="pageSpan"></span>
              </div>
            </div>
          </div>
        </el-col>
        <el-col :span="6">
          <div class="dataStatistics borderSky">
            <!-- 实际生产状况 -->
            <el-table :data="tableData" class="productionTable" :header-row-style="{background: '#409EFF !important'}" ref="table">
              <!-- <el-table-column prop="workorderCode" label="工单" align="center" /> -->
              <el-table-column prop="productCode" label="产品编码" align="center" />
              <el-table-column prop="opFinalResult" label="最终结果" align="center" />
            </el-table>
          </div>
        </el-col>
      </el-row>
    </el-main>
  </el-container>
</template>

<script>
import * as echarts from "echarts";
export default {
  data() {
    return {
      deviceData: [],
      dbMonitoringData: [],
      pageNum: 1,
      pageSize: 16,
      timer: null,
      currentTime: "",
      tableData: [],
      dbtotal: 0,
      productData: {},
      timerId: null,
      currentIndex: 1,
      dbTime: null,
      allTime: null,
      alarmText: "各设备运行正常",
      productModel: "产品I型",
      drugEmpty: false,
    };
  },
  mounted() {
    this.reloadData();
    this.setFontSize();
    window.addEventListener("resize", this.setFontSize);
    // 30秒重启接口和定时器
    this.allTime = setInterval(() => {
      // 清除定时器
      clearInterval(this.timer);
      clearInterval(this.timerId);
      clearInterval(this.dbTime);
      this.reloadData();
    }, 30000);
  },
  methods: {
    reloadData() {
      //时间
      this.getCurrentTime();
      this.timer = setInterval(() => {
        this.getCurrentTime(); // 更新计算属性，触发视图更新
      }, 1000);
      // 获取设备台账
      this.http.get("/api/Albert_Kanban/GetDeviceList").then((res) => {
        if (!res.status) return this.$message.error("获取设备台账信息失败");
        this.deviceData = res.data;
      });
      // 一周产量
      this.initDrugChart();
      // 产品型号
      this.getProductModel();
      // DB块监测
      this.dbMonitoring(1, 16);
      // 产品分析
      this.initPersonChart();
      // 计划产量和实际产量
      this.getProduction();
      // 告警信息
      this.getAlarmInfo();
      // 右侧表数据
      this.getTableData();
      this.dbTime = setInterval(() => {
        this.dbMonitoring(this.currentIndex, 16);
      }, 2000);
    },
    // 右侧表数据
    getTableData() {
      this.http.get("/api/Albert_Kanban/GetHistoryData").then((res) => {
        if (!res.status) return this.$message.error("获取表格数据失败");
        this.tableData = res.data;
        this.timerId = setInterval(this.updateTableData, 1000);
      });
    },
    updateTableData() {
      const row = this.tableData.shift();
      this.tableData.push(row);
    },
    // 计算属性，返回当前时间
    getCurrentTime() {
      const now = new Date();
      const year = now.getFullYear();
      const month = now.getMonth() + 1;
      const day = now.getDate();
      const hour = now.getHours();
      const minute = now.getMinutes();
      const second = now.getSeconds();
      this.currentTime = `${year}年${month}月${day}日 ${hour}时${minute}分${second}秒`;
    },
    // 计划产量和实际产量
    getProduction() {
      this.http.get("/api/Albert_Kanban/GetQuantity").then((res) => {
        if (!res.status) return this.$message.error("获取产量失败");
        this.productData = res.data;
      });
    },

    getAlarmInfo() {
      this.http.get("/api/Albert_Kanban/GetAlarm").then((res) => {
        if (!res.status) return this.$message.error("获取告警信息失败");
        // console.log("@@@@AlarmInfo", res.data);
        this.alarmText = res.data
          .map(
            (item) => `${item.deviceName}-${item.alarmNote}-${item.alarmType}`
          )
          .join(";");
      });
    },

    // 产品型号
    getProductModel() {
      this.http.get("/api/Albert_Kanban/GetProductModel").then((res) => {
        if (!res.status) return this.$message.error("获取产品型号失败");
        this.productModel = res.data.productName;
      });
    },
    // 根据在制工艺来筛选出在制看板
    dbMonitoring(pageNum, pageSize) {
      this.http
        .get(
          "/api/Albert_Kanban/GetStationListByPageAsync?pageNumber=" +
            pageNum +
            "&pageSize=" +
            pageSize +
            ""
        )
        .then((res) => {
          if (!res.status) return this.$message.error("获取设备台账信息失败");
          this.dbMonitoringData = res.data.stationList;
          this.dbtotal = res.data.stationCount;
          document.querySelectorAll(".pageSpan").forEach((item, index) => {
            if (index == pageNum - 1) {
              item.style.background = "#0ff";
            } else {
              item.style.background = "#ccc";
            }
          });
          this.currentIndex = pageNum + 1;
          if (this.currentIndex > Math.ceil(this.dbtotal / 16)) {
            this.currentIndex = 1;
          }
        });
    },
    // 一周产量
    initDrugChart() {
      this.http.get("/api/Albert_Kanban/GetHourQuantity").then((res) => {
        if (!res.status) return this.$message.error("获取小时产量失败");
        let xData = [];
        let sData = [];
        let sort = "hour";
        res.data.sort((a, b) => {
          const dataA = new Date(a[sort]);
          const dataB = new Date(b[sort]);
          return dataB - dataA;
        });
        res.data.forEach((item) => {
          xData.unshift(item.hour);
          sData.unshift(item.productCount);
        });
        this.drugEmpty = xData.length || sData.length ? false : true;
        let drugChart = echarts.init(document.getElementById("drug"));
        let option = {
          title: {
            text: "小时产量",
            textStyle: {
              color: "#fff",
            },
            left: "center",
            top: "top",
          },
          grid: {
            top: "20%",
            left: "5%",
            right: "5%",
            bottom: "5%",
            containLabel: true,
          },
          xAxis: {
            data: xData,
            axisLabel: {
              color: "#fff",
            },
          },
          yAxis: {
            axisLabel: {
              color: "#fff",
            },
          },
          series: [
            {
              type: "bar",
              data: sData,
              label: {
                show: true,
                position: "top",
                color: "#ccc",
                fontSize: 14,
              },
            },
          ],
        };
        drugChart.setOption(option);
        // window.addEventListener('resize', () => {
        //     drugChart.resize(); // 调用 chart 的 resize 方法
        // });
      });
    },
    // 产品分析
    initPersonChart() {
      this.http.get("/api/Albert_Kanban/GetQuantity").then((res) => {
        if (!res.status) return this.$message.error("获取产量分析失败");
        let drugChart = echarts.init(
          document.getElementById("personStatistics")
        );
        let option = {
          title: {
            text: "产品分析",
            textStyle: {
              color: "#fff",
            },
            left: "center",
            top: "top",
          },
          grid: {
            top: "20%",
            left: "5%",
            right: "5%",
            bottom: "5%",
            containLabel: true,
          },
          tooltip: {
            trigger: "item",
          },
          legend: {
            orient: "vertical",
            left: "left",
            top: "center",
            textStyle: {
              color: "#fff",
            },
          },
          series: [
            {
              name: "产品分析",
              type: "pie",
              radius: ["40%", "70%"],
              avoidLabelOverlap: false,
              label: {
                show: true,
                position: "inside",
                formatter: "{d}%",
                textStyle: {
                  fontSize: 14,
                  color: "#fff",
                },
              },
              emphasis: {
                label: {
                  show: true,
                  fontSize: 40,
                  fontWeight: "bold",
                },
              },
              labelLine: {
                show: false,
              },
              data: [
                { value: res.data.workorderOK, name: "合格数" },
                { value: res.data.workorderNG, name: "不合格数" },
              ],
            },
          ],
        };
        drugChart.setOption(option);
        // window.addEventListener('resize', () => {
        //     drugChart.resize(); // 调用 chart 的 resize 方法
        // });
      });
    },
    setFontSize() {
      // this.$nextTick(() => {
      // 设备监控title
      const deviceTitle = document.getElementById("deviceTitle");
      const deviceHeight = deviceTitle.parentNode.offsetHeight;
      const devicWidth = deviceTitle.parentNode.offsetWidth;
      deviceTitle.style.fontSize =
        Math.min(deviceHeight, devicWidth) * 0.1 + "px";
      // 设备监控
      const deviceContainer = document.getElementById("deviceContainer");
      const deviceContainerHeight = deviceContainer.offsetHeight;
      const deviceContainerWidth = deviceContainer.offsetWidth;
      deviceContainer.style.fontSize =
        Math.min(deviceContainerHeight, deviceContainerWidth) * 0.1 + "px";
      // // 数据
      const plannedtext = document.getElementsByClassName("plannedtext");
      Array.from(plannedtext).forEach((item) => {
        item.style.fontSize =
          Math.min(item.offsetHeight, item.offsetWidth) * 0.3 + "px";
      });
      // // 工站监测title
      const dbMonitoringTitle =
        document.getElementsByClassName("dbMonitoringTitle")[0];
      const dbMonitoringTitleHeight = dbMonitoringTitle.parentNode.offsetHeight;
      const dbMonitoringTitleWidth = dbMonitoringTitle.parentNode.offsetWidth;
      dbMonitoringTitle.style.fontSize =
        Math.min(dbMonitoringTitleHeight, dbMonitoringTitleWidth) * 0.04 + "px";
      // // 工站监测数据
      const dbMonitoringTextFlex = document.getElementsByClassName(
        "dbMonitoringTextFlex"
      );
      Array.from(dbMonitoringTextFlex).forEach((item) => {
        item.style.fontSize =
          Math.min(item.offsetHeight, item.offsetWidth) * 0.12 + "px";
      });
      // 一周产量
      const drugRefs = echarts.getInstanceByDom(this.$refs.drugRefs);
      drugRefs && drugRefs.resize();
      // // 产品分析
      const personStatisticsRefs = echarts.getInstanceByDom(
        this.$refs.personStatisticsRefs
      );
      personStatisticsRefs && personStatisticsRefs.resize();
      // // 圆圈大小
      // const circle = document.getElementsByClassName('circle')
      // // const circleHeight = circle[0].parentNode.offsetHeight
      // Array.from(circle).forEach(item => {
      //     console.log(item,'pp');
      //     item.style.width =  item.parentNode.offsetWidth* 0.2 + 'px'
      //     item.style.height =  item.parentNode.offsetHeight* 0.3 + 'px'
      // })
      // })
    },
  },
  beforeUnmount() {
    // 清除定时器
    console.log(333);
    clearInterval(this.timer);
    clearInterval(this.timerId);
    clearInterval(this.dbTime);
    clearInterval(this.allTime);
    window.removeEventListener("resize", this.setFontSize);
  },
};
</script>

<style lang="less" scoped>
.el-container {
    box-sizing: border-box;
    background-image: url("../assets/imgs/KanBan/Kanban_Background.png");
    background-repeat: no-repeat;
    background-size: 100% 100%;
    color: white;
    height: 100%;
    .el-main {
        // min-width: 380px;
        .el-row {
            height: 100%;
            min-height: 438px;
            min-width: 1378px;
            .el-col {
                height: 100%;
                .device {
                    min-height: 105px;
                    padding: 4px;
                    .deviceTitle {
                        // font-size: 20px;
                        font-weight: 600;
                    }
                    .deviceContainer {
                        display: grid;
                        height: calc(100% - 32px);
                        grid-template-columns: repeat(2,50%);
                        grid-template-rows: 100%;
                        min-height: 70px;
                        .circle {
                            width: 30px;
                            height: 30px;
                            border-radius: 50%;
                            margin-left: 4px;
                        }
                    }
                }
                .dataDisplay,.dataStatistics{
                    display: grid;
                    height: 100%;
                    grid-template-columns: 100%;
                }
                .dataDisplay {
                    grid-template-rows: 30% 70%;
                    .displayContainer {
                        display: grid;
                        grid-template-rows: repeat(2,40%);
                        .plannedProduction,.qualified {
                            height: 100%;
                            display: grid;
                            grid-template-rows: 100%;
                            grid-template-columns: repeat(3,33.3333333%);
                            .plannedtext {
                                border: 2px solid skyblue;
                                border-radius: 10px;
                                display:flex;
                                flex-direction: column;
                                justify-content: space-around;
                                align-items: center; 
                                // font-size: 24px;
                            }
                        }
                    }
                    .dbMonitoring {
                        border: 2px solid skyblue;
                        border-radius: 10px;
                        .dbMonitoringTitle {
                            height: 5%;
                            // font-size: 22px;
                            text-align: center;
                            margin-bottom: 3px;
                        }
                        .pagination {
                            display: flex;
                            justify-content: center;
                            align-items: center;
                            height: 5%;
                            span {
                                position: relative;
                                display: block;
                                width: 10px;
                                height: 10px;
                                border-radius: 50%;
                                background-color: #ccc;
                                margin-right: 10px;
                                cursor: pointer;
                            }
                            span:first-child {
                                background-color: #0ff;
                            }
                        }
                    }
                }
                .dataStatistics {                  
                    .productionTable {
                        background-color: transparent;
                        width: 100%;
                        height: 100%;
                        font-size:18px;
                    }
                }
            }
            
        }
    }
}
.dbMonitoringText {
    display: grid;
    height: 90%;
    grid-template-rows: repeat(4,25%);
    grid-template-columns: repeat(4,25%);
    .circle {
        width: 30px;
        height: 30px;
        border-radius: 50%;
        margin-left: 4px;
    }
}
.el-header {
    border-bottom: 2px solid skyblue;
}

.productModel{
  text-align: center;
}

.unifiedStyle {
    height: 38%;
    // min-height: 136px;
}
.unifiedStyle1 {
    height: 24%
    // min-height: 136px;
}
@keyframes scrolling {
    from {
        right: 0;
    }
    to {
        right: 100%;
    }
}
.borderSky {
    border: 2px solid skyblue;
    border-radius: 10px;
}
.textFlex {
    display: flex;
    flex-direction: column;
    justify-content: space-between;
}
.el-table__header-wrapper {
  background-color: #409EFF; /* 自定义列头背景颜色 */
}
.el-table {
    --el-table-header-bg-color: transparent !important;
    --el-table-header-text-color: #fff;
    --el-table-border-color: none;
    --el-table-tr-bg-color: none;
    --el-table-text-color: none;
    --el-table-row-hover-bg-color: skyblue !important;
}
</style>

<style lang="less">
.el-scrollbar__view {
  height: 100%;
}
</style>
<style lang="less" scoped>
.drug-empty-tip {
  position: absolute;
  top: 18%;
  width: 25%;
  text-align: center;
  opacity: 0.3;
}
</style>
