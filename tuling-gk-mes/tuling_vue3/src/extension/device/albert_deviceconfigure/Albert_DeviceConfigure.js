//自定义的组件
import gridFooter from './Albert_DeviceConfigure_Footer.vue';

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
    text: "只需要一些简单配置实现一对多",
    methods: {
        //下面这些方法可以保留也可以删除
        onInit() {
            // 框架初始化配置前，
            this.textInline = false;
            this.tableHeight = 150;

            // 弹出框标签间隔
            this.labelWidth = 140;
            this.boxOptions.labelWidth = 140;
            //开启固定显示查询功能，true=页面加载时查询表单也显示出来，false=点击查询时才会显示表单
            //this.setFiexdSearchForm(true);

            // 添加按钮只支持 render 的形式
            this.columns.push({
                field: "操作",
                title: "操作",
                type: "",
                width: 120,
                // 这里调用 getRender 方法,直接从文档复制
                render: (h, { row, column, index }) => {
                    return h("div", { style: {} }, [
                        h("div", {}, [
                            h(
                                "span", {
                                class: [
                                    "el-icon-edit el-tag el-tag--success el-tag--light",
                                ],
                                style: {
                                    cursor: "pointer",
                                    "margin-right": "8px",
                                },
                                onClick: (e) => {
                                    e.stopPropagation();
                                    this.edit(row);
                                },
                            },
                                "编辑"
                            ),
                            h(
                                "span", {
                                class: [
                                    "el-icon-delete el-tag el-tag--danger el-tag--light",
                                ],
                                style: {
                                    cursor: "pointer",
                                    "margin-right": "8px",
                                },
                                onClick: (e) => {
                                    e.stopPropagation();
                                    //删除行
                                    this.del(row);
                                },
                            },
                                "删除"
                            ),
                            h(
                                "span", {
                                class: [
                                    "el-icon-s-promotion el-tag el-tag--warning el-tag--light",
                                ],
                                style: {
                                    cursor: "pointer",
                                },
                                onClick: (e) => {
                                    e.stopPropagation();
                                    //强制结束编辑
                                    index = -1;
                                    this.$message.success("保存成功");
                                },
                            },
                                "保存"
                            ),
                        ]),
                    ]);
                },
            },);
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
            this.$store.getters.data().DevicePkInt = row.DevicePkInt;

            //清除原来选中的行
            this.$refs.table.$refs.table.clearSelection();

            //查询界面点击行事件
            this.$refs.table.$refs.table.toggleRowSelection(row, true); //单击行时选中当前行;

            //调用下面选项卡的查询
            //见Demo_ProductGridFooter.vue文件rowClick方法
            this.$refs.gridFooter.rowClick(row);
        },

    },
};
export default extension;