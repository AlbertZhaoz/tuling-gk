<template>
  <div>
    <el-container>
      <el-header style="line-height: 60px;">
        <el-row>
          <el-col style="text-align: center;font-size: 26px;letter-spacing: 1px;font-weight: 700;">设备监控</el-col>
        </el-row>
      </el-header>
      <el-main>
        <el-row>
          <!-- 工站监测 -->
          <div class="dbMonitoring">
            <div v-for="(item,index) in dbMonitoringData" :key="index" :style="{'border-color':item.isRepairStatus === '待维修' ?  'yellow':'skyblue'}" class="borderSky containerDevice">
              <div class="textFlex">
                <div>工站名称:{{item.deviceDBName}}</div>
                <div>工站用途:{{item.deviceDBSubname}}</div>
                <div>工站节拍:{{item.productBeat}}</div>
                <div>工站产量:{{item.productQuantity}}</div>
                <div>开机时间:{{item.deviceDBStartTime.slice(0,10)}}</div>
                <div>维修状态:{{item.isRepairStatus}}</div>
                <div>维修人:{{item.isRepairPerson}}</div>
                <div>维修时间:{{ item.isRepairStartTime === null ? item.isRepairStartTime:item.isRepairStartTime.slice(0,10)}}</div>
              </div>
              <div class="circle" :style="{background:item.deviceDBStatus == 'Y' ? 'green' : 'red'}"></div>
            </div>
          </div>
        </el-row>
      </el-main>
    </el-container>
  </div>
</template>
 
<script>
import { onMounted, ref, onBeforeUnmount } from "vue";
import http from "@/../src/api/http.js";

export default {
  setup() {
    let productModel = ref("I型产品");
    let dbMonitoringData = ref([]);
    let dbtotal = ref(0);
    let currentIndex = ref(0);
    let timer;

    onMounted(() => {
      dbMonitoring(1, 16);
      timer = setInterval(() => {
        dbMonitoring(1, 16);
      }, 60000);
    });

    onBeforeUnmount(() => {
      if (timer != null) {
        // 清除定时器
        clearInterval(timer);
      }
    });

    // 都是获取在制工艺对应的设备
    // 并将设备信息同步展示在设备看板中
    function dbMonitoring(pageNum, pageSize) {
      http.get("/api/BaseKanban/GetPdmCraftStationList").then((res) => {
        if (!res.status) return this.$message.error("获取在制设备失败");
        dbMonitoringData.value = res.data;
      });
    }

    return {
      productModel,
      dbMonitoringData,
      dbtotal,
      currentIndex,
    };
  },
};
// 电表配置
</script>
 
<style scoped lang='less'>
.el-container {
  box-sizing: border-box;
  background-image: url("../assets/imgs/KanBan/Kanban_Background.png");
  background-repeat: no-repeat;
  background-size: 100% 100%;
  color: white;
  height: 100vh;
  .el-main {
    box-sizing: border-box;
  }
  .el-header {
    border-bottom: 2px solid skyblue;
  }

  .dbMonitoring {
    display: flex;
    // justify-content: space-between;
    flex-wrap: wrap;
    font-size: 17px;
    .containerDevice {
      width: 220px;
      margin: 10px;
      display: flex;
      padding: 5px;
    }
    .circle {
      width: 30px;
      height: 30px;
      border-radius: 50%;
      margin-left: 4px;
    }
  }
}

.runTimeStyle {
  margin-top: 15px;
  height: 200px; /* 确保父容器有固定的高度 */
  width: 100%;
}

.borderSky {
  border: 2px solid skyblue;
  border-radius: 10px;
}
</style>