/*****************************************************************************************
 **  Author:AlbertZhao   
 **  Wechat:zhy_cxx
 ** Call:15505240996
 *****************************************************************************************/
//此js文件是用来自定义扩展业务代码，可以扩展一些自定义页面或者重新配置生成的代码

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
        onInit() { //框架初始化配置前，
            // 查询标签长度设置
            this.labelWidth = 140;
            // 编辑便签长度设置
            this.boxOptions.labelWidth = 140;
            // 表格增加一列
            this.columns.push({
                title: '操作',
                hidden: false,
                align: "center",
                fixed: 'right',
                width: 120,
                render: (h, { row, column, index }) => {
                    return h(
                        "div", { style: { 'font-size': '13px', 'cursor': 'pointer', 'color': '#409eff' } }, [
                        h(
                            "a", {
                                style: { 'margin-right': '15px' },
                                onClick: (e) => {
                                    e.stopPropagation()
                                    this.changeLockState(row, 'lock');
                                }
                            }, "屏蔽"
                        ),
                        h(
                            "a", {
                                style: { 'margin-right': '15px' },
                                onClick: (e) => {
                                    e.stopPropagation()
                                    this.changeLockState(row, 'open');
                                }
                            }, "打开"
                        ),
             
                  
                    ])
                }
            });
        },
        onInited() {
            //框架初始化配置后
            //如果要配置明细表,在此方法操作
            //this.detailOptions.columns.forEach(column=>{ });
            this.buttons.splice(1, 0, {
                name: '一键下发',
                icon: 'SwitchFilled',
                type: 'success',
                // 箭头函数写法
                onClick: () => {
                    this.http.post('/api/Albert_CraftParam/SendCraftParams', this.$refs.table.getSelected(), true).then((x) => {
                        if (!x.status) {
                            return this.$message.error(x.message);
                        } else {
                            this.$Message.success("参数一键下发成功");
                        }
                    });
                }
            });
        },
        searchBefore(param) {
            //界面查询前,可以给param.wheres添加查询参数
            //返回false，则不会执行查询
            //操作步骤3：主表点击行时,设置查询条件
            if (this.$route.path == '/Albert_Craft') {
                //产品管理界面必须选中行数据后才能查询
                if (!this.$store.getters.data().CraftPkInt) {
                    // this.$message.error('请选中产品行数据');
                    return false;
                }
                //查询选中行的数据
                param.wheres.push({
                    name: 'CraftPkInt', //查询字段
                    value: this.$store.getters.data().CraftPkInt //查询值为主表的主键id值
                });
            }
            return true;
        },
        searchAfter(result) {
            //查询后，result返回的查询数据,可以在显示到表格前处理表格的值
            return true;
        },
        addBefore(formData) {
            //新建保存前formData为对象，包括明细表，可以给给表单设置值，自己输出看formData的值
            formData.mainData.CraftPkInt = this.$store.getters.data().CraftPkInt;
            return true;
        },
        updateBefore(formData) {
            //编辑保存前formData为对象，包括明细表、删除行的Id
            return true;
        },
        rowClick({ row, column, event }) {
            //查询界面点击行事件
            // this.$refs.table.$refs.table.toggleRowSelection(row); //单击行时选中当前行;
            // 获取选中行

        },
        modelOpenAfter(row) {
            //点击编辑、新建按钮弹出框后，可以在此处写逻辑，如，从后台获取数据
            //(1)判断是编辑还是新建操作： this.currentAction=='Add';
            //(2)给弹出框设置默认值
            //(3)this.editFormFields.字段='xxx';
            //如果需要给下拉框设置默认值，请遍历this.editFormOptions找到字段配置对应data属性的key值
            //看不懂就把输出看：console.log(this.editFormOptions)
            //操作步骤4：打开弹出框时判断是否为新建操作，新建时必须让选中行数据
            //新建时产品管理界面必须选中行数据后才能弹出框
            if (this.$route.path == '/Albert_DeviceConfigure') {
                if (this.currentAction == 'Add') {
                    if (!this.$store.getters.data().CraftPkInt) {
                        this.$message.error('请选中工艺行数据');
                        return false;
                    }
                }
            }
            return true;
        },
        changeLockState(row, name) {
            if (name === 'lock') {
                this.$message.info('点击了屏蔽');
            } else {
                this.$message.info('点击了打开');
            }
        }
    }
};
export default extension;