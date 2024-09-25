<template>
  <div class="kanban">
      <!-- <iframe :src="src" frameborder="no"></iframe> -->
      <kanbanVue v-if="isShow" ref="kanbanRefs"></kanbanVue>
  </div>
</template>
<script>
  import kanbanVue from './kanban.vue';
  export default {
  data () {
    return {
      isShow: true
      //src: "http://139.196.89.233:9992/"
      //src: "http://127.0.0.1:5000/run:albert?reportName=%E5%A4%A7%E5%B1%8F/yt043_%E7%9C%8B%E6%9D%BF.cr"
      // src: "http://139.196.89.233:5000/run:albert?reportName=%E5%A4%A7%E5%B1%8F/yt043_%E7%9C%8B%E6%9D%BF.cr"
    }
  },
  components: {
    kanbanVue
  },
  beforeRouteLeave() {
    this.isShow = false
    const childComponent = this.$refs.kanbanRefs
    childComponent.$nextTick(() => {
      childComponent.$el.remove()
    })
    
  }
}
</script>
<style>
  .kanban{
      /* height: 1200px; */
      height: 100%;
  }
  .kanban iframe{
      height: 100%;
      width: 100%;
  }
  /* .el-scrollbar__view {
    height: 100%;
  } */
</style>