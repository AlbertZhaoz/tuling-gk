<template>
  <div class="chart-container" v-loading="loading">
    <div v-show="noData" class="empty" :style="'width: '+width + ';height:'+ (height)+';'">暂无数据</div>
    <div v-show="!noData" ref="myChart" :id="id" :style="'width: '+width + ';height:'+ height+';'"></div>
  </div>
</template>

<script setup>
import { ref, reactive, onMounted } from 'vue'
import * as echarts from "echarts";
const {width, height, id} =  defineProps({
  width: String,
  height: String,
  id: String
})
const emit = defineEmits(['triggerChart'])
let loading = ref(false)
let myChart = null

const initChart = (option) => {
  if (!myChart) {
    // myChart.dispose()
    myChart = echarts.init(document.getElementById(id))
    // 点击事件
    myChart.getZr().on('click', (params) => {
      console.log(params)
      let pointInPixel = [params.offsetX, params.offsetY]
      if(myChart.containPixel('grid', pointInPixel)) {
        let xIndex = myChart.convertFromPixel({seriesIndex: 0}, pointInPixel)[0]
        emit('triggerChart', xIndex)
      }
    })
  }
  // 绘制图表
  // console.log(option.option)
  myChart.setOption(option.option)
  window.addEventListener('resize', () => {
    myChart.resize()
  })
}
let noData = ref(false)
let chartOption = reactive({})
const changeData = (option) => {
  if (!option) {
    noData.value = true
  } else {
    noData.value = false
  }
  initChart({option})
}
defineExpose({changeData})
onMounted(() => {
})
</script>

<style lang="less" scoped>
.chart-container {
  height: 100%;
}
.empty {
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 40px;
  background: rgb(71 86 106 / 80%);
  opacity: 0.5;
  border-radius: 32px;
  margin: 20px 0;
  font-style: italic;
}
</style>
