// 导入组件
import modelHeader from './Albert_DeviceMaintainanceChoose.vue';

let extension = {
    components: {
        //查询界面扩展组件
        gridHeader: '',
        gridBody: '',
        gridFooter: '',
        //新建、编辑弹出框扩展组件
        modelHeader: modelHeader,
        modelBody: '',
        modelFooter: ''
    },
    tableAction: '', //指定某张表的权限(这里填写表名,默认不用填写)
    buttons: { view: [], box: [], detail: [] }, //扩展的按钮
    methods: {
        //下面这些方法可以保留也可以删除
        onInit() { //框架初始化配置前，
            if (this.$route.path == '/Albert_DeviceMaintainance') {
                this.load = false;
            }

            // 弹出框标签间隔
            this.labelWidth = 500;
            this.boxOptions.labelWidth = 140;

            this.editFormOptions.forEach(options => {
                options.forEach(item => {
                    if (item.field == "DeviceCode") {

                        // 固定写法 extra
                        item.extra = {
                            style: 'color:red;cursor: pointer;', //设置样式
                            icon: 'el-icon-link', //显示图标
                            text: '选择设备', //显示文本
                            //触发事件
                            click: (item) => {
                                //this.$message.error('点击标签触发的事件');
                                this.$refs.modelHeader.open();
                            }
                        }
                    }
                });

            });
        },
        onInited() {
            //框架初始化配置后
            //如果要配置明细表,在此方法操作
            //this.detailOptions.columns.forEach(column=>{ });
        },
        searchBefore(param) {
            //界面查询前,可以给param.wheres添加查询参数
            //返回false，则不会执行查询
            return true;
        },
        searchAfter(result) {
            //查询后，result返回的查询数据,可以在显示到表格前处理表格的值
            return true;
        },
        addBefore(formData) {
            //新建保存前formData为对象，包括明细表，可以给给表单设置值，自己输出看formData的值
            formData.mainData.MaintainancePkInt = this.$store.getters.data().MaintainancePkInt;
            return true;
        },
        updateBefore(formData) {
            //编辑保存前formData为对象，包括明细表、删除行的Id
            return true;
        },
        rowClick({ row, column, event }) {
            //查询界面点击行事件
            // this.$refs.table.$refs.table.toggleRowSelection(row); //单击行时选中当前行;
        },
        modelOpenAfter(row) {
            //点击编辑、新建按钮弹出框后，可以在此处写逻辑，如，从后台获取数据
            //(1)判断是编辑还是新建操作： this.currentAction=='Add';
            //(2)给弹出框设置默认值
            //(3)this.editFormFields.字段='xxx';
            //如果需要给下拉框设置默认值，请遍历this.editFormOptions找到字段配置对应data属性的key值
        }
    }
};
export default extension;