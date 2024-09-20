/*****************************************************************************************
**  Author:jxx 2022
**  QQ:283591387
**完整文档见：http://v2.volcore.xyz/document/api 【代码生成页面ViewGrid】
**常用示例见：http://v2.volcore.xyz/document/vueDev
**后台操作见：http://v2.volcore.xyz/document/netCoreDev
*****************************************************************************************/
//此js文件是用来自定义扩展业务代码，可以扩展一些自定义页面或者重新配置生成的代码

//自定义的组件
import gridFooter from './Albert_InboundOrder_Footer.vue';

let extension = {
  components: {
    //查询界面扩展组件
    gridHeader: '',
    gridBody: '',
    gridFooter: gridFooter,
    //新建、编辑弹出框扩展组件
    modelHeader: '',
    modelBody: '',
    modelFooter: ''
  },
  tableAction: '', //指定某张表的权限(这里填写表名,默认不用填写)
  buttons: { view: [], box: [], detail: [] }, //扩展的按钮
  text:"只需要一些简单配置实现一对多",
  methods: {
    //下面这些方法可以保留也可以删除
    onInit() {
      //框架初始化配置前，
      this.textInline = false;
      this.tableHeight = 300;
    },
    searchAfter(result) {
      //查询后，清空原来记录选中行的id
      // this.$store.getters.data().ProductId = null;
      return true;
    },
    //操作步骤1：主表点击事件加载明细数据
    rowClick({ row, column, event }) {
      //vuex

      //缓存当前选中行的主键id
      this.$store.getters.data().InboundOrderPkInt = row.InboundOrderPkInt;

      //清除原来选中的行
      this.$refs.table.$refs.table.clearSelection();

      //查询界面点击行事件
      this.$refs.table.$refs.table.toggleRowSelection(row, true); //单击行时选中当前行;

       //调用下面选项卡的查询
       //见Demo_ProductGridFooter.vue文件rowClick方法
      this.$refs.gridFooter.rowClick(row);
    }
  }
};
export default extension;