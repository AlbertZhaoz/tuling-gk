<template>
  <div>
    <reworkConfig :devicePkInt="devicePkInt" :reworkNumber="reworkNumber"></reworkConfig>
  </div>
</template>

<script>
import reworkConfig from "@/components/reworkconfig/reworkconfig.vue";
export default {
  data() {
    return {
      devicePkInt: 1,
      reworkNumber: 1,
    };
  },
  components: {
    reworkConfig,
  },
};
</script>

<style>
</style>