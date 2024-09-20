<template>
  <vol-box :lazy="true" v-model="model" title="选择工艺路线" :height="800" :width="1500" :padding="5">
    <CraftQueryViewEle ref="CraftQueryViewEle_Ref"></CraftQueryViewEle>

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
import CraftQueryView from "@/views/productionmanager/albert_craft/Albert_Craft.vue";

//这里使用的vue2语法，也可以写成vue3语法
export default {
  components: {
    "vol-box": VolBox,
    CraftQueryViewEle: CraftQueryView,
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
        this.$refs.CraftQueryViewEle_Ref.$refs.grid.getSelectRows();
      if (!chooseRow.length) {
        return this.$message.error("请选择一条数据");
      } else {
        // 用来查看返回的数据
        // this.$message.error(Json.stringify(chooseRow));
        // 调用页面查询,这本 $parent 拿到的是 Albert_DeviceMaintainanceList.vuew 界面
        this.$emit("parentCall", ($parent) => {
          $parent.editFormFields.CraftPkInt = chooseRow[0].CraftPkInt;
          $parent.editFormFields.CraftCode = chooseRow[0].CraftCode;
          $parent.editFormFields.CraftName = chooseRow[0].CraftName;
          this.model = false;
        });
      }
    },
  },
};
</script>