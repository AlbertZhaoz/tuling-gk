using OPCAutomation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPCDADemo
{
    public partial class Form1 : Form
    {
        private OPCServer opcServer;
        private OPCGroup group;
        private OPCItem item;


        public Form1()
        {
            InitializeComponent();
            InitOpc();
        }

        private void InitOpc()
        {
            opcServer = new OPCServer();
            opcServer.Connect("Kepware.KEPServerEX.V6");
            // // 遍历标签
            // var browser = opcServer.CreateBrowser();
            // browser.ShowBranches();
            // browser.ShowLeafs(true);
            //
            // // 遍历节点
            // foreach (var item in browser)
            // {
            //     label1.Text += item.ToString()+"\n";
            // }

            // 数据读写
            var groups = opcServer.OPCGroups;
            group = groups.Add("Tuling");
            var items = group.OPCItems;
            item = items.AddItem("Modbus设备类型.ModbusSlaveOne.温度数据",10);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 读取数据
                // [In] short Source, 1 2  OPCDevice OPCCache
                // [In] int NumItems,
                // [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4), In] ref Array ServerHandles,
                // [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] out Array Values,
                // [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] out Array Errors,
                // [MarshalAs(UnmanagedType.Struct), Optional] out object Qualities,
                // [MarshalAs(UnmanagedType.Struct), Optional] out object TimeStamps);
                var serverHandles = new int[2]{0,item.ServerHandle};
                var serverHandleArray = (Array)serverHandles;
                var values = new object[2];
                var valuesArray = (Array)values;
                var errors = new string[2];
                var errorsArray = (Array)errors;

                // 同步读取数据
                // group.SyncRead((short)OPCAutomation.OPCDataSource.OPCDevice,
                //     1,
                //     ref serverHandleArray,
                //     out valuesArray,
                //     out errorsArray,
                //     out var qualities, // OPCAutomation.OPCQuality.OPCQualityGood
                //     out var timeStamps);
                //
                // label1.Text = string.Empty;
                //
                // // 显示读取的数据
                // for (int i = 1; i <= valuesArray.Length; i++)
                // {
                //     label1.Text += valuesArray.GetValue(i).ToString()+"\n";
                // }

                // 异步读取数据
                // [In] int NumItems,
                // [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4), In] ref Array ServerHandles,
                // [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] out Array Errors,
                // [In] int TransactionID,
                //     out int CancelID);
                // group.IsSubscribed = true;
                // group.AsyncRead(1,
                //     ref serverHandleArray,
                //     out errorsArray,
                //     12,
                //     out var cacelId);
                // group.AsyncReadComplete += Group_AsyncReadComplete;

                // 订阅模式
                // group.IsSubscribed = true;
                // group.DataChange += Group_DataChange;

                // 同步写入
                // var random = new Random();
                // var randomValue = random.Next(1,10);
                // var valueWrites = new object[2]{ 0,randomValue};
                // var valuesWritesArray = (Array)valueWrites;
                // group.SyncWrite(1,ref serverHandleArray,ref valuesWritesArray,out errorsArray);

                // 异步写入
                var random = new Random();
                var randomValue = random.Next(1,10);
                var valueWrites = new object[2]{ 0,randomValue};
                var valuesWritesArray = (Array)valueWrites;
                group.IsSubscribed = true;
                group.AsyncWrite(1,ref serverHandleArray,ref valuesWritesArray,out errorsArray,
                    10,out var cancelId);
                group.AsyncWriteComplete += Group_AsyncWriteComplete;
            }
            catch (Exception exception)
            {
               MessageBox.Show(exception.Message);
            }
        }

        private void Group_AsyncWriteComplete(int TransactionID, int NumItems, ref Array ClientHandles, ref Array Errors)
        {
            // 如果你想要获取 error 详细的错误信息
            opcServer.GetErrorString(1);
        }

        private void Group_DataChange(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            try
            {
                label1.Text = string.Empty;
            
                // 显示读取的数据
                for (int i = 1; i <= ItemValues.Length; i++)
                {
                    label1.Text += ItemValues.GetValue(i).ToString()+"\n";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void Group_AsyncReadComplete(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps, ref Array Errors)
        {
            label1.Text = string.Empty;
            
            // 显示读取的数据
            for (int i = 1; i <= ItemValues.Length; i++)
            {
                label1.Text += ItemValues.GetValue(i).ToString()+"\n";
            }
        }
    }
}
