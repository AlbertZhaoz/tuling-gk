using DevExpress.XtraEditors;
using HslCommunication.Profinet.Siemens;
using Masuit.Tools;
using System;
using System.IO;
using System.Windows.Forms;
using TulingHsl.Helper;
using TulingHsl.Models;

namespace TulingHsl.Forms
{
    public partial class AddDeviceForm : XtraForm
    {
        public AddDeviceForm()
        {
            InitializeComponent();
            InitUi();
        }

        private void InitUi()
        {
            comboxType.Properties.Items.AddRange(Enum.GetValues(typeof(SiemensPLCS)));
            textGetExcel.Text = AppDomain.CurrentDomain.BaseDirectory + DeviceConst.CONFIG + DeviceConst.EXCEL_GET;
            textSetExcel.Text = AppDomain.CurrentDomain.BaseDirectory + DeviceConst.CONFIG + DeviceConst.EXCEL_SET;
            comboxType.SelectedIndex = 0;
        }

        private void uiTextBoxGetExcel_DoubleClick(object sender, EventArgs e)
        {
            xtraOpenFileDialog1.InitialDirectory = GetExcelPath();
            xtraOpenFileDialog1.Filter = DeviceConst.EXCEL_FILTER;
            xtraOpenFileDialog1.FileName = DeviceConst.EXCEL_GET;

            if (xtraOpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textGetExcel.Text = xtraOpenFileDialog1.FileName;
            }
        }

        private void textSetExcel_DoubleClick(object sender, EventArgs e)
        {
            xtraOpenFileDialog1.InitialDirectory = GetExcelPath();
            xtraOpenFileDialog1.Filter = DeviceConst.EXCEL_FILTER;
            xtraOpenFileDialog1.FileName = DeviceConst.EXCEL_SET;

            if (xtraOpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textSetExcel.Text = xtraOpenFileDialog1.FileName;
            }
        }

        private string GetExcelPath()
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory + DeviceConst.CONFIG;

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            return dir;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (textIp.Text.IsNullOrEmpty())
            {
                MessageBox.Show("请输入IP地址");
                textIp.Focus();
                return;
            }

            if (DeviceCommunication.Instance.CmdPing(textIp.Text, out var strErr))
            {
                MessageBox.Show("测试成功");
            }
            else
            {
                MessageBox.Show(strErr);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var existS7 = DeviceCommunication.Instance.S7Devices
                .FindIndex(x=>x.Name == textName.Text);

            if (existS7>-1)
            {
                MessageBox.Show("设备名称已存在,请重命名");
                textName.Focus();   
                return;
            }

            var s7Device = new S7Device()
            {
                Id = Guid.NewGuid(),
                Name = textName.Text,
                Type = (SiemensPLCS)comboxType.SelectedItem,
                Ip = textIp.Text,
                Port = textPort.Value,
                HeartAddress = textHeartAddress.Text,
                GetExcelPath = textGetExcel.Text,
                SetExcelPath = textSetExcel.Text,
            };
            DeviceCommunication.Instance.S7Devices.Add(s7Device);
            DeviceCommunication.Instance.SaveAllS7Device();
            DeviceCommunication.Instance.TulingLog.WriteInfo(textName.Text+" 添加成功");
            this.DialogResult = DialogResult.OK;
        }
    }
}