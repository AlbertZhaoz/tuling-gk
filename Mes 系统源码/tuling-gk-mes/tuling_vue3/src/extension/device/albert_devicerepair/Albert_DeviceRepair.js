// 设备维修
// 自定义的组件
import * as dateUtil from "../../../uitils/dateFormatUtil.js";
import gridFooter from './Albert_DeviceRepair_Footer.vue';

let extension = {
    components: {
        // 查询界面扩展组件
        gridHeader: '',
        gridBody: '',
        gridFooter: gridFooter,
        // 新建、编辑弹出框扩展组件
        modelHeader: '',
        modelBody: '',
        modelFooter: ''
    },
    tableAction: '', // 指定某张表的权限(这里填写表名,默认不用填写)
    buttons: { view: [], box: [], detail: [] }, //扩展的按钮
    text: "设备维修",
    methods: {
        //下面这些方法可以保留也可以删除
        onInit() {
            //框架初始化配置前，
            this.textInline = false;
            this.tableHeight = 300;
            //隐藏checkbox列(默认是显示的)
            //this.ck = false;
            //显示序号(默认隐藏)
            //this.columnIndex = true;
            // 从表配置同上
            // this.detailOptions.ck = false;
            // this.detailOptions.columnIndex = true;

            // 查询间隔
            this.labelWidth = 140;
            // 弹出框标签间隔
            this.boxOptions.labelWidth = 140;
            // 开启固定显示查询功能
            this.setFiexdSearchForm(true);

            // 想添加按钮只支持 render 的形式
            // this.columns.push({
            //     field: "操作",
            //     title: "操作",
            //     type: "",
            //     width: 160,
            //     // 这里调用 getRender 方法,直接从文档复制
            //     render: (h, { row, column, index }) => {
            //         return h("div", { style: {} }, [
            //             h("div", {}, [
            //                 h(
            //                     "span", {
            //                         class: [
            //                             "el-icon-edit el-tag el-tag--success el-tag--light",
            //                         ],
            //                         style: {
            //                             cursor: "pointer",
            //                             "margin-right": "8px",
            //                         },
            //                         onClick: (e) => {
            //                             e.stopPropagation();
            //                             this.edit(row);
            //                         },
            //                     },
            //                     "编辑"
            //                 ),
            //                 h(
            //                     "span", {
            //                         class: [
            //                             "el-icon-delete el-tag el-tag--danger el-tag--light",
            //                         ],
            //                         style: {
            //                             cursor: "pointer",
            //                             "margin-right": "8px",
            //                         },
            //                         onClick: (e) => {
            //                             e.stopPropagation();
            //                             //删除行
            //                             this.del(row);
            //                         },
            //                     },
            //                     "删除"
            //                 ),
            //                 h(
            //                     "span", {
            //                         class: [
            //                             "el-icon-s-promotion el-tag el-tag--warning el-tag--light",
            //                         ],
            //                         style: {
            //                             cursor: "pointer",
            //                         },
            //                         onClick: (e) => {
            //                             e.stopPropagation();
            //                             //强制结束编辑
            //                             index = -1;
            //                             this.$message.success("保存成功");
            //                         },
            //                     },
            //                     "保存"
            //                 ),
            //             ]),
            //         ]);
            //     },
            // }, );

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
            this.$store.getters.data().RepairPkInt = row.RepairPkInt;

            this.$message.success("选中行的主键id：" + row.RepairPkInt);

            //清除原来选中的行
            this.$refs.table.$refs.table.clearSelection();

            //查询界面点击行事件
            this.$refs.table.$refs.table.toggleRowSelection(row, true); //单击行时选中当前行;
            //调用下面选项卡的查询
            //见Demo_ProductGridFooter.vue文件rowClick方法
            this.$refs.gridFooter.rowClick(row);
        },
        //点击编辑/新建按钮弹出框后，可以在此处写逻辑，如，从后台获取数据
        // 设置维修开始时间为当前时间
        modelOpenAfter(row) {
            this.editFormOptions.forEach(options => {
                options.forEach(item => {
                    if (this.currentAction == "Add") {
                        if (item.field == "RepairStartDate") {
                            // 格式化时间字符串使用方法见 js 封装函数 utils/dateFormUtil.js
                            this.editFormFields.RepairStartDate = dateUtil.getNowDate();
                        }

                        // 判断字段是否包含某字符串 
                        if (item.field == "RepairCode") {
                            this.editFormFields.RepairCode = dateUtil.formatTimeStamp(new Date(), "yyyyMMddhhmmss") + Math.floor(Math.random() * 1000);
                            //this.editFormFields.RepairCode = "自动生成";
                        }
                    }
                })
            });
        },


    }
};
export default extension;