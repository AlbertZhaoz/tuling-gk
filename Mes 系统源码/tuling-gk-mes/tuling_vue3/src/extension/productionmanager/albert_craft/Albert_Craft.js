/*****************************************************************************************
 **  Author:AlbertZhao   
 **  Wechat:zhy_cxx
 ** Call:15505240996
 *****************************************************************************************/
//此js文件是用来自定义扩展业务代码，可以扩展一些自定义页面或者重新配置生成的代码
import gridFooter from './Albert_CraftParamFooter.vue';
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
    methods: {
        //下面这些方法可以保留也可以删除
        onInit() { //框架初始化配置前，
            //示例：在按钮的最前面添加一个按钮
            //   this.buttons.unshift({  //也可以用push或者splice方法来修改buttons数组
            //     name: '按钮', //按钮名称
            //     icon: 'el-icon-document', //按钮图标vue2版本见iview文档icon，vue3版本见element ui文档icon(注意不是element puls文档)
            //     type: 'primary', //按钮样式vue2版本见iview文档button，vue3版本见element ui文档button
            //     onClick: function () {
            //       this.$Message.success('点击了按钮');
            //     }
            //   });

            // 设置只能单选
            this.single = true;
            // 框架初始化配置前，
            this.textInline = false;
            // this.tableHeight = 180;
            this.containerClassName = 'craft-container'
                // 设置修改新建、编辑弹出框字段标签的长度
            this.boxOptions.labelWidth = 140;
            // 设置查询表单 label 宽度
            this.labelWidth = 140;
            //开启固定显示查询功能，true=页面加载时查询表单也显示出来，false=点击查询时才会显示表单
            this.setFiexdSearchForm(true);
            this.buttons.shift()
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
            return true;
        },
        updateBefore(formData) {
            //编辑保存前formData为对象，包括明细表、删除行的Id
            return true;
        },
        rowClick({ row, column, event }) {
            //缓存当前选中行的主键id
            this.$store.getters.data().CraftPkInt = row.CraftPkInt;

            //清除原来选中的行
            this.$refs.table.$refs.table.clearSelection();

            //查询界面点击行事件
            this.$refs.table.$refs.table.toggleRowSelection(row); //单击行时选中当前行;

            this.$refs.gridFooter.rowClick(row);
        },
        // 只有设置了 single=true 才会生效，这边直接将当前选中的行传递过去
        // 这样就可以实现无论是单击行号还是单击行都会触发选中行事件
        rowChange(row, oldCurrentRow) {
            //缓存当前选中行的主键id
            this.$store.getters.data().CraftPkInt = row.CraftPkInt;

            //调用下面选项卡的查询
            this.$refs.gridFooter.rowClick(row);
        },
        modelOpenAfter(row) {
            //点击编辑、新建按钮弹出框后，可以在此处写逻辑，如，从后台获取数据
            //(1)判断是编辑还是新建操作： this.currentAction=='Add';
            //(2)给弹出框设置默认值
            //(3)this.editFormFields.字段='xxx';
            //如果需要给下拉框设置默认值，请遍历this.editFormOptions找到字段配置对应data属性的key值
            //看不懂就把输出看：console.log(this.editFormOptions)
            // if (this.currentAction == 'Add') {
            //     this.editFormFields.CraftCode = '由编码规则自动生成';
            // }
        }
    }
};
export default extension;