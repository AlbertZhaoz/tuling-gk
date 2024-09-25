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
      src: "http://139.196.89.233:3000/d/P8Mc03mnz/brother-mes?orgId=1&from=1681796600218&to=1681797500218",
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