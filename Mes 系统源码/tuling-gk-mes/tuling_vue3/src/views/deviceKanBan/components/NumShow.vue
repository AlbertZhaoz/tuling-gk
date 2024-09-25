<template>
    <div class="num-show-container">
      <div class="num-show-title">{{name}}</div>
      <div class="num-box">
        <div class="num-jump">
          <div class="jump-item" v-for="(ele, ind) in list" :key="ind">
            <span class="small-sc" v-for="item in 10" :style="'transform: translateY(-' + 20 * (ele) + 'px);'">{{item - 1}}</span>
            <span class="big-sc" v-for="item in 10" :style="'transform: translateY(-' + 40 * (ele) + 'px);'">{{item - 1}}</span>
  
          </div>
          <!-- <div class="jump-item">
            <span v-for="item in 9">{{item}}</span>
          </div> -->
          <!-- <span>
            {{value}}
          </span> -->
        </div>
      </div>
      <div class="unit">{{unit}}</div>
    </div>
  </template>
  <script setup>
  import { ref, onMounted } from 'vue'
  const {value, name, unit} =  defineProps({
    value: Array,
    name: String,
    unit: String
  })
  const list = ref([0, 0])
  let timer = ref(null)
  onMounted(() => {
    timer.value = setTimeout(() => {
      list.value = value
      clearTimeout(timer.value)
      timer.value = null
    }, 300)
  
  })
  </script>
  <style lang="less" scoped>
  .num-show-container {
    font-size: 12px;
    line-height: 12px;
    text-align: center;
    height: 100%;
    display: flex;
    flex-direction: column;
    justify-content: center;
    // .num-show-title {
    //   padding-top: 3px;
    // }
    .num-box {
      margin: 2px 0;
    }
    .big-sc {
      display: none;
    }
    .num-jump {
      display: flex;
      justify-content: center;
      .jump-item {
        display: flex;
        flex-direction: column;
        height: 20px;
        line-height: 20px;
        width: 16px;
        background: #58c1db;
        color: #fff;
        margin: 0 1px;
        overflow: hidden;
        span {
          transform: translateY(0);
          transition-duration: 1s;
        }
        span.small-sc {
          font-size: 16px;
          display: inline-block;
          height: 20px;
          line-height: 20px;
          transform: translateY(0);
          transition-duration: 1s;
        }
      }
    }
  }
  @media screen and (min-height: 850px) {
    .num-show-container {
      font-size: 14px;
      justify-content: center;
    }
    .small-sc {
      display: none !important;
    }
    span.big-sc {
      display: inline-block !important;
    }
    .num-jump {
      margin: 10px 0
    }
    .num-show-title {
      // padding-top: 30% !important;
    }
    .jump-item {
      font-size: 30px;
      width: 20px !important;
      height: 40px !important;
      line-height: 40px !important;
      span {
        height: 40px !important;
        line-height: 40px !important;
      }
    }
  }
  </style>
  