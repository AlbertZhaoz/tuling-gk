<template>
  <div>
    <div class="title">实时能耗分析</div>
    <div class="container">
      <div id="electricityChart"></div>
      <div id="gasChart"></div>
    </div>
  </div>
</template>
 
<script>
import * as echarts from "echarts";
import { onMounted } from "vue";
import http from "@/../src/api/http.js";

export default {
  //此处只是测试一下setup，暂时不考虑响应式的问题。
  setup() {
    let electricityChart;
    let gasChart;

    let electricityOption = {
      tooltip: {
        trigger: "axis",
        axisPointer: {
          // Use axis to trigger tooltip
          type: "shadow", // 'shadow' as default; can also be 'line' or 'shadow'
        },
      },
      legend: {},
      grid: {
        left: "3%",
        right: "4%",
        bottom: "3%",
        containLabel: true,
      },
      xAxis: {
        type: "value",
      },
      yAxis: {
        type: "category",
        data: ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"],
      },
      series: [
        {
          name: "Direct",
          type: "bar",
          stack: "total",
          label: {
            show: true,
          },
          emphasis: {
            focus: "series",
          },
          data: [320, 302, 301, 334, 390, 330, 320],
        },
        {
          name: "Mail Ad",
          type: "bar",
          stack: "total",
          label: {
            show: true,
          },
          emphasis: {
            focus: "series",
          },
          data: [120, 132, 101, 134, 90, 230, 210],
        },
        {
          name: "Affiliate Ad",
          type: "bar",
          stack: "total",
          label: {
            show: true,
          },
          emphasis: {
            focus: "series",
          },
          data: [220, 182, 191, 234, 290, 330, 310],
        },
        {
          name: "Video Ad",
          type: "bar",
          stack: "total",
          label: {
            show: true,
          },
          emphasis: {
            focus: "series",
          },
          data: [150, 212, 201, 154, 190, 330, 410],
        },
        {
          name: "Search Engine",
          type: "bar",
          stack: "total",
          label: {
            show: true,
          },
          emphasis: {
            focus: "series",
          },
          data: [820, 832, 901, 934, 1290, 1330, 1320],
        },
      ],
    };

    // 气表配置
    let gasOption = {
      tooltip: {
        trigger: "axis",
        axisPointer: {
          // Use axis to trigger tooltip
          type: "shadow", // 'shadow' as default; can also be 'line' or 'shadow'
        },
      },
      legend: {},
      grid: {
        left: "3%",
        right: "4%",
        bottom: "3%",
        containLabel: true,
      },
      xAxis: {
        type: "value",
      },
      yAxis: {
        type: "category",
        data: ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"],
      },
      series: [
        {
          name: "Direct",
          type: "bar",
          stack: "total",
          label: {
            show: true,
          },
          emphasis: {
            focus: "series",
          },
          data: [320, 302, 301, 334, 390, 330, 320],
        },
        {
          name: "Mail Ad",
          type: "bar",
          stack: "total",
          label: {
            show: true,
          },
          emphasis: {
            focus: "series",
          },
          data: [120, 132, 101, 134, 90, 230, 210],
        },
        {
          name: "Affiliate Ad",
          type: "bar",
          stack: "total",
          label: {
            show: true,
          },
          emphasis: {
            focus: "series",
          },
          data: [220, 182, 191, 234, 290, 330, 310],
        },
        {
          name: "Video Ad",
          type: "bar",
          stack: "total",
          label: {
            show: true,
          },
          emphasis: {
            focus: "series",
          },
          data: [150, 212, 201, 154, 190, 330, 410],
        },
        {
          name: "Search Engine",
          type: "bar",
          stack: "total",
          label: {
            show: true,
          },
          emphasis: {
            focus: "series",
          },
          data: [820, 832, 901, 934, 1290, 1330, 1320],
        },
      ],
    };

    onMounted(() => {
      fetchEletricityData();
      fetchGasData();
    });

    async function fetchEletricityData() {
      console.log("fetchEletricityData");
      try {
        const response = await http.get(
          "/api/Albert_EmEnergyRealQuery/GetEletricityRealData",
          {},
          true
        );
        if (response.status) {
          const data = response.data;
          let electricityYAxisData = [];
          let electricityMorningXAxisData = [];
          let electricityAfternoonXAxisData = [];

          data.forEach((item) => {
            if (!electricityYAxisData.includes(item.dateDay)) {
              electricityYAxisData.push(item.dateDay);
            }
            if (item.period === "0") {
              electricityMorningXAxisData.push(item.actualSumValue);
            } else {
              electricityAfternoonXAxisData.push(item.actualSumValue);
            }
          });

          initEletricityChart(
            electricityYAxisData,
            electricityMorningXAxisData,
            electricityAfternoonXAxisData
          );
        }
      } catch (error) {
        console.log(error);
      }
    }

    function initEletricityChart(
      electricityYAxisData,
      electricityMorningXAxisData,
      electricityAfternoonXAxisData
    ) {
      electricityChart = echarts.init(
        document.getElementById("electricityChart")
      );

      // 电表配置
      electricityOption = {
        tooltip: {
          trigger: "axis",
          axisPointer: {
            type: "shadow",
          },
        },
        legend: {},
        grid: {
          left: "3%",
          right: "4%",
          bottom: "3%",
          containLabel: true,
        },
        xAxis: {
          type: "value",
        },
        yAxis: {
          type: "category",
          data: electricityYAxisData,
        },
        series: [
          {
            name: "上午",
            type: "bar",
            stack: "total",
            label: {
              show: true,
            },
            emphasis: {
              focus: "series",
            },
            data: electricityMorningXAxisData,
          },
          {
            name: "下午",
            type: "bar",
            stack: "total",
            label: {
              show: true,
            },
            emphasis: {
              focus: "series",
            },
            data: electricityAfternoonXAxisData,
          },
        ],
      };

      electricityChart.setOption(electricityOption);
    }

    async function fetchGasData() {
      try {
        const response = await http.get(
          "/api/Albert_EmEnergyRealQuery/GetGasRealData",
          {},
          true
        );
        if (response.status) {
          const data = response.data;
          let gasYAxisData = [];
          let gasMorningXAxisData = [];
          let gasAfternoonXAxisData = [];

          data.forEach((item) => {
            if (!gasYAxisData.includes(item.dateDay)) {
              gasYAxisData.push(item.dateDay);
            }
            if (item.period === "0") {
              gasMorningXAxisData.push(item.actualSumValue);
            } else {
              gasAfternoonXAxisData.push(item.actualSumValue);
            }
          });

          initGasChart(
            gasYAxisData,
            gasMorningXAxisData,
            gasAfternoonXAxisData
          );
        }
      } catch (error) {
        console.log(error);
      }
    }

    function initGasChart(
      gasYAxisData,
      gasMorningXAxisData,
      gasAfternoonXAxisData
    ) {
      gasChart = echarts.init(document.getElementById("gasChart"));

      // 电表配置
      gasOption = {
        tooltip: {
          trigger: "axis",
          axisPointer: {
            type: "shadow",
          },
        },
        legend: {},
        grid: {
          left: "3%",
          right: "4%",
          bottom: "3%",
          containLabel: true,
        },
        xAxis: {
          type: "value",
        },
        yAxis: {
          type: "category",
          data: gasYAxisData,
        },
        series: [
          {
            name: "上午",
            type: "bar",
            stack: "total",
            label: {
              show: true,
            },
            emphasis: {
              focus: "series",
            },
            data: gasMorningXAxisData,
          },
          {
            name: "下午",
            type: "bar",
            stack: "total",
            label: {
              show: true,
            },
            emphasis: {
              focus: "series",
            },
            data: gasAfternoonXAxisData,
          },
        ],
      };

      gasChart.setOption(gasOption);
    }
    return {
      fetchEletricityData,
      fetchGasData,
    };
  },
};
// 电表配置
</script>
 
<style scoped lang='less'>
.title {
  font-size: 20px;
  font-weight: bold;
  margin-bottom: 20px;
  // 水平居中
  text-align: center;
  color: #1890ff;
}
.container {
  display: flex;
  // 横向排列
  flex-direction: row;
  // 两个图表平分
  justify-content: space-between;

  #electricityChart {
    height: 300px;
    width: 50%;
    margin: 0 20px;
    border: 1px solid #eee;
  }
  #gasChart {
    width: 50%;
    height: 300px;
    margin-right: 20px;
    border: 1px solid #eee;
  }
}
</style>