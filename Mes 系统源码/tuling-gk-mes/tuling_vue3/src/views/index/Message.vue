<template>
  <div class="message-container">
    <el-button @click="clearAllMessage">清除所有消息</el-button>
    <div class="item" v-for="(item, index) in list" :key="index">
      <div class="title">{{ item.title }}({{ item.date }})</div>
      <div class="content">{{ item.message }}</div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    list: {
      type: Array,
      default: () => {
        return [];
      },
    },
  },
  methods: {
    clearAllMessage() {
      this.$emit('clearAllMessage')
    }
  },
  created() {
    // if (!this.list.length) {
    //   this.list.push({
    //     title: "",
    //     message: "",
    //     date: "",
    //   });
    // }
  },
};
</script>
<style scoped lang="less">
.message-container {
  .title {
    padding-bottom: 10px;
  }
  .item {
    border-bottom: 1px solid #eee;
    padding: 10px 20px;
  }
  .content {
    color: #7e7e7e;
    font-size: 13px;
  }
}
</style>
