<template>
  <div class="rework-config-container">
    <AlbertDataFirstReworkConfigView></AlbertDataFirstReworkConfigView>
    <el-divider class="divide" />
    <AlbertDataSecondReworkConfigView></AlbertDataSecondReworkConfigView>
  </div>
</template>

<script setup>
import AlbertDataFirstReworkConfigView from'@/views/dataquery/albert_datafirstreworkconfigview/Albert_DataFirstReworkConfigView.vue'
import AlbertDataSecondReworkConfigView from '@/views/dataquery/albert_datasecondtreworkconfigview/Albert_DataSecondReworkConfigView.vue'
</script>
<style lang="less">
.rework-config-container {
  .divide {
    width: 98%;
    margin: 24px 1%;
  }
}
</style>