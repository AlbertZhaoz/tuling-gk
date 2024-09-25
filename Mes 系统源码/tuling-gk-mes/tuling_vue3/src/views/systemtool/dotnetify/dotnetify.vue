<template>
  <div class="grafana">
    <iframe :src="src" frameborder="no"></iframe>
  </div>
</template>
<script>
import axios from "axios";
export default {
  data() {
    return {
      // 直接请求后端的url
      src: "http://127.0.0.1:9991/pulse",
    };
  },
};
</script>
<style>
.grafana {
  height: 1200px;
}
.grafana iframe {
  height: 100%;
  width: 100%;
}
</style>