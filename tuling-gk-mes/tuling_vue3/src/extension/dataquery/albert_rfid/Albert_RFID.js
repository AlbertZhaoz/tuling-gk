/*****************************************************************************************
 **  Author:AlbertZhao   
 **  Wechat:zhy_cxx
 ** Call:15505240996
 *****************************************************************************************/
//此js文件是用来自定义扩展业务代码，可以扩展一些自定义页面或者重新配置生成的代码
import http from '@/api/http.js'
import rfid from './rfidimg'
import { ElProgress } from 'element-plus'
let extension = {
    components: {
        //查询界面扩展组件
        gridHeader: '',
        gridBody: '',
        gridFooter: rfid,
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
            this.containerClassName = 'rfid-container'
            // 单选
            this.single = true
            // this.columns.push({
            //         field: "progress",
            //         title: "进度条",
            //         width: 120,
            //         render: (h, { row, column, index }) => {
            //             return [
            //                 h(ElProgress, {
            //                     "stroke-width": 26,
            //                     "text-inside": true,
            //                     percentage: 60,
            //                     format: () => {
            //                         return "完成" + 60 + "%"
            //                     }
            //                 }),
            //             ]
            //         }
            //     })
            //示例：在按钮的最前面添加一个按钮
            this.buttons.push({  //也可以用push或者splice方法来修改buttons数组
                name: '重置RFID占用', //按钮名称
                icon: 'el-icon-document', //按钮图标vue2版本见iview文档icon，vue3版本见element ui文档icon(注意不是element puls文档)
                type: 'primary', //按钮样式vue2版本见iview文档button，vue3版本见element ui文档button
                onClick: function () {
                    this.resetRFID()
                }
            });

            //示例：设置修改新建、编辑弹出框字段标签的长度
            // this.boxOptions.labelWidth = 150;
            this.columns.push({
                title: '操作',
                hidden: false,
                align: "center",
                fixed: 'right',
                width: 80,
                render: (h, { row, column, index }) => {
                    return h(
                        "div", { style: { 'font-size': '13px', 'cursor': 'pointer', 'color': '#409eff' } }, [
                        h(
                            "a", {
                            onClick: (e) => {
                                e.stopPropagation()
                                this.resetSingleRFID(row.RFID)
                            }
                        }, `解绑`
                        )
                        
                    ])
                }
            })
        },
        onInited() {
            // this.height = this.height - 300
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
            // 查询无结果时都为N
            if (result.length == 0) {
                this.$refs.gridBody.showData = {
                    SteelBall: 'N',
                    PlugCap: 'N',
                    Nut: 'N',
                    Spring: 'N',
                    Bearing: 'N',
                    Case: 'N'
                }
            } else {
                // 取查出的第一个
                this.$refs.gridBody.showData = result[0]
            }
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
            //查询界面点击行事件
            this.$refs.table.$refs.table.toggleRowSelection(row); //单击行时选中当前行;
            let select = this.$refs.table.getSelected()
            if (JSON.stringify(select) == '[]') {
                this.$refs.gridBody.showData = {
                    SteelBall: 'N',
                    PlugCap: 'N',
                    Nut: 'N',
                    Spring: 'N',
                    Bearing: 'N',
                    Case: 'N'
                }
            } else {
                let { SteelBall, PlugCap, Nut, Spring, Bearing, Case } = select[0]
                this.$refs.gridFooter.showData = { SteelBall, PlugCap, Nut, Spring, Bearing, Case }
            }
            console.log(select[0], this.$refs.gridFooter)
        },
        modelOpenAfter(row) {
            //点击编辑、新建按钮弹出框后，可以在此处写逻辑，如，从后台获取数据
            //(1)判断是编辑还是新建操作： this.currentAction=='Add';
            //(2)给弹出框设置默认值
            //(3)this.editFormFields.字段='xxx';
            //如果需要给下拉框设置默认值，请遍历this.editFormOptions找到字段配置对应data属性的key值
            //看不懂就把输出看：console.log(this.editFormOptions)
        },
        // 重置RFID占用
        async resetRFID () {
            // this.$Message.success('点击了按钮');
            const res = await this.http.get("/api/Albert_RFID/GetResetRfidIsUse")
            if (res.status) {
                this.$Message.success('重置成功');
            } else {
                this.$Message.success('重置失败');
            }
        },
        async resetSingleRFID (rfid) {
            const res = await this.http.get("/api/Albert_RFID/GetResetSingleRfidIsUse?rfidNumber=" + rfid)
            if (res.status) {
                this.$Message.success(res.message || '解绑成功');
            } else {
                this.$Message.success(res.message || '解绑失败');
            }
        }
    }
};
export default extension;