<template>
    <div class="swagger">
        <iframe :src="src" frameborder="no"></iframe>
    </div>
</template>
<script>
    import axios from 'axios'
    export default {
    data () {
      return {
        // 直接请求后端的url
        src: axios.defaults.baseURL
      }
    }
  }
</script>
<style>
    .swagger{
        height:1200px;
    }
    .swagger iframe{
        height: 100%;
        width: 100%;
    }
</style>