let extension = {
    components: {
        //查询界面扩展组件
        gridHeader: '',
        gridBody: '',
        gridFooter: '',
        //新建、编辑弹出框扩展组件
        modelHeader: '',
        modelBody: '',
        modelFooter: ''
    },
    tableAction: '', //指定某张表的权限(这里填写表名,默认不用填写)
    buttons: { view: [], box: [], detail: [] }, //扩展的按钮
    methods: {
        //下面这些方法可以保留也可以删除
        onInit() {
            //框架初始化配置前，
            //this.tableHeight = 270;
            //页面打开时不加载数据
            if (this.$route.path == '/Albert_DeviceConfigure') {
                this.load = false;
            }

            //可以重新定义明表的按钮
            // console.log(this.buttons);
            // this.buttons.forEach((btn) => {
            //   if (btn.value == '自己看console.log的值') {
            //     btn.hidden = true; //隐藏按钮
            //   }
            // });
            //或者添加其他按钮
            //   this.buttons.unshift({  //也可以用push或者splice方法来修改buttons数组
            //     name: '按钮', //按钮名称
            //     icon: 'el-icon-document', //按钮图标vue2版本见iview文档icon，vue3版本见element ui文档icon(注意不是element puls文档)
            //     type: 'primary', //按钮样式vue2版本见iview文档button，vue3版本见element ui文档button
            //     onClick: function () {
            //       this.$Message.success('点击了按钮');
            //     }
            //   });

            // 弹出框标签间隔
            this.labelWidth = 140;
            this.boxOptions.labelWidth = 140;

        },
        onInited() {
            //框架初始化配置后
            //如果要配置明细表,在此方法操作
            //this.detailOptions.columns.forEach(column=>{ });

            // 查询标签过长
            this.labelWidth = 140;
            // 编辑便签过长
            this.boxOptions.labelWidth = 140;
        },
        searchBefore(param) {
            //明细表查询前方法

            //操作步骤3：主表点击行时,设置查询条件
            if (this.$route.path == '/Albert_DeviceConfigure') {
                //产品管理界面必须选中行数据后才能查询
                if (!this.$store.getters.data().DevicePkInt) {
                    // this.$message.error('请选中产品行数据');
                    return false;
                }
                //查询选中行的数据
                param.wheres.push({
                    name: 'DevicePkInt', //查询字段
                    value: this.$store.getters.data().DevicePkInt //查询值为主表的主键id值
                });
            }
            return true;
        },
        addBefore(params) {
            //新建保存前
            //操作步骤5：将主表选行的值添加到明细表中(注意代码生成器，明细表的ProductId字段必须设置编辑为0，并生成下model)

            params.mainData.DevicePkInt = this.$store.getters.data().DevicePkInt;
            //查询后，result返回的查询数据,可以在显示到表格前处理表格的值
            return true;
        },
        modelOpenBeforeAsync() {
            //操作步骤4：打开弹出框时判断是否为新建操作，新建时必须让选中行数据

            //新建时产品管理界面必须选中行数据后才能弹出框
            if (this.$route.path == '/Albert_DeviceConfigure') {
                if (this.currentAction == 'Add') {
                    if (!this.$store.getters.data().DevicePkInt) {
                        this.$message.error('请选中产品行数据');
                        return false;
                    }
                }
            }
            return true;
        }
    }
};
export default extension;