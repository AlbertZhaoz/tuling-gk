<template>
  <vol-box :lazy="true" v-model="model" title="选择设备" :height="800" :width="1500" :padding="5">
    <DeviceConfigureQueryViewEle ref="DeviceConfigureQueryViewEle_Ref"></DeviceConfigureQueryViewEle>

    <template #footer>
      <div>
        <el-button type="primary" size="mini" @click="onSelect">确认</el-button>
        <el-button type="default" size="mini" @click="model = false">关闭</el-button>
      </div>
    </template>
  </vol-box>
</template>
<script>
import VolBox from "@/components/basic/VolBox.vue";

// 弹出框显示 DeviceConfigure 列表用来维护设备
import DeviceConfigureQueryView from "@/views/device/albert_devicestationconfigure/Albert_DeviceStationConfigure.vue";

//这里使用的vue2语法，也可以写成vue3语法
export default {
  components: {
    "vol-box": VolBox,
    DeviceConfigureQueryViewEle: DeviceConfigureQueryView,
  },
  methods: {},
  data() {
    return {
      model: false, //弹出框的显示隐藏
    };
  },
  methods: {
    open() {
      this.model = true; //弹出框显示
    },
    onSelect() {
      let chooseRow =
        this.$refs.DeviceConfigureQueryViewEle_Ref.$refs.grid.getSelectRows();
      if (!chooseRow.length) {
        return this.$message.error("请选择一条数据");
      } else {
        // 用来查看返回的数据
        //this.$message.error(Json.stringify(chooseRow));
        // 调用页面查询,这本 $parent 拿到的是 Albert_DeviceMaintainanceList.vuew 界面
        this.$emit("parentCall", ($parent) => {
          $parent.editFormFields.DevicePkInt =
            chooseRow[chooseRow.length - 1].DevicePkInt;
          $parent.editFormFields.DeviceDBPkInt =
            chooseRow[chooseRow.length - 1].DeviceDBPkInt;
          $parent.editFormFields.DeviceDBName =
            chooseRow[chooseRow.length - 1].DeviceDBName;
          $parent.editFormFields.CraftSort =
            chooseRow[chooseRow.length - 1].DeviceDBSort;
          $parent.editFormFields.DeviceDBSubname =
            chooseRow[chooseRow.length - 1].DeviceDBSubname;
          $parent.editFormFields.DeviceDBIsUse =
            chooseRow[chooseRow.length - 1].DeviceDBIsUse;
          console.log(chooseRow[chooseRow.length - 1]);
          $parent.editFormFields.DeviceDBStatus =
            chooseRow[chooseRow.length - 1].DeviceDBStatus;
          $parent.editFormFields.DeviceDBStartTime =
            chooseRow[chooseRow.length - 1].DeviceDBStartTime;
          $parent.editFormFields.DeviceDBEndTime =
            chooseRow[chooseRow.length - 1].DeviceDBEndTime;
          $parent.editFormFields.DeviceDBRemark =
            chooseRow[chooseRow.length - 1].DeivceDBRemark;
          this.model = false;
        });
      }
    },
  },
};
</script>