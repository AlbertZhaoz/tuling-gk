<template>
  <div class="torque-chart-container">
    <el-dialog v-model="dialogVisible" :title="'产品码（轴承） ' + productCode + '：Op120扭矩曲线'">
      <FormatChart ref="torqueChartRef" id="torqueChart" width="100%" height="400px"></FormatChart>
    </el-dialog>
  </div>

</template>
<script setup>
import { ref, onMounted, nextTick } from 'vue'
import FormatChart from '@/components/formatChart/FormatChart.vue'
const dialogVisible = ref(false)
const chartData = ref([])
const productCode = ref('')
const torqueChartRef = ref(null)
// 暴露给父元素方法
const openDialog = (data, prdCode) => {
  productCode.value = prdCode
  dialogVisible.value = true
  let dataArr = data.split(',')
  let numArr = []
  dataArr.forEach((ele) => {
    numArr.push(Number(ele))
  })
  chartData.value = numArr
  let option = {
    tooltip: {
      trigger: "axis",
      axisPointer: {
        type: "shadow"
      },
      formatter: (data) => {
        console.log(data)
        let actVal = data[0].axisValue
        let res = `
          <div>${actVal}</div>
        `
        return res
      }
    },
    xAxis: {
        type: 'category',
        data: dataArr,
        show: false,
    },
    yAxis: {
      scale: true,
      minInterval: 0.000000001,
      // axisLine: {
      //   show: true,
      //   // onZero: true,
      //   lineStyle: {
      //     color: '#d8d8d8'
      //   }
      // }
    },
    grid: {
      show: false,
      top: 20,
      left: "0%",
      right: "0%",
      bottom: "0",
      containLabel: true,
    },
    series: [
        {
            // data: [1.320, 1.800],
            data: numArr,
            type: 'line',
            smooth: true,
        }
      ]
  }
  nextTick(() => {
    torqueChartRef.value.changeData(option)
  })
}
defineExpose({openDialog})
</script>
