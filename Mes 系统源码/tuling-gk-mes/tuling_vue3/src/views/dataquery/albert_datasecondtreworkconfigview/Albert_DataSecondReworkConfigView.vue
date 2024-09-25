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
      devicePkInt: 2,
      reworkNumber: 2,
    };
  },
  components: {
    reworkConfig,
  },
};
</script>

<style>
</style>