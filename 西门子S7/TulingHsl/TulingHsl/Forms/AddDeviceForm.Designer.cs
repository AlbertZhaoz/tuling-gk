namespace TulingHsl.Forms
{
    partial class AddDeviceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDeviceForm));
            this.comboxType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.textIp = new Sunny.UI.UIIPTextBox();
            this.textPort = new Sunny.UI.UIIntegerUpDown();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.textHeartAddress = new Sunny.UI.UITextBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.textGetExcel = new Sunny.UI.UITextBox();
            this.textSetExcel = new Sunny.UI.UITextBox();
            this.xtraOpenFileDialog1 = new DevExpress.XtraEditors.XtraOpenFileDialog(this.components);
            this.btnTest = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.textName = new Sunny.UI.UITextBox();
            ((System.ComponentModel.ISupportInitialize)(this.comboxType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // comboxType
            // 
            this.comboxType.Location = new System.Drawing.Point(99, 73);
            this.comboxType.Name = "comboxType";
            this.comboxType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.comboxType.Properties.Appearance.Options.UseFont = true;
            this.comboxType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboxType.Size = new System.Drawing.Size(155, 24);
            this.comboxType.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(18, 73);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(75, 18);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "设备类型：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(285, 79);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(75, 18);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "设备地址：";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(18, 128);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(75, 18);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "设备端口：";
            // 
            // textIp
            // 
            this.textIp.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.textIp.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textIp.Location = new System.Drawing.Point(372, 75);
            this.textIp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textIp.MinimumSize = new System.Drawing.Size(1, 1);
            this.textIp.Name = "textIp";
            this.textIp.Padding = new System.Windows.Forms.Padding(1);
            this.textIp.ShowText = false;
            this.textIp.Size = new System.Drawing.Size(150, 24);
            this.textIp.TabIndex = 5;
            this.textIp.Text = "127.0.0.1";
            this.textIp.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.textIp.Value = ((System.Net.IPAddress)(resources.GetObject("textIp.Value")));
            // 
            // textPort
            // 
            this.textPort.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textPort.Location = new System.Drawing.Point(99, 123);
            this.textPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textPort.MinimumSize = new System.Drawing.Size(100, 0);
            this.textPort.Name = "textPort";
            this.textPort.ShowText = false;
            this.textPort.Size = new System.Drawing.Size(155, 24);
            this.textPort.TabIndex = 6;
            this.textPort.Text = "uiIntegerUpDown1";
            this.textPort.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.textPort.Value = 102;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(285, 127);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(75, 18);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "心跳地址：";
            // 
            // textHeartAddress
            // 
            this.textHeartAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textHeartAddress.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textHeartAddress.Location = new System.Drawing.Point(372, 123);
            this.textHeartAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textHeartAddress.MinimumSize = new System.Drawing.Size(1, 16);
            this.textHeartAddress.Name = "textHeartAddress";
            this.textHeartAddress.Padding = new System.Windows.Forms.Padding(5);
            this.textHeartAddress.ShowText = false;
            this.textHeartAddress.Size = new System.Drawing.Size(150, 24);
            this.textHeartAddress.TabIndex = 8;
            this.textHeartAddress.Text = "DB1.DBX1";
            this.textHeartAddress.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.textHeartAddress.Watermark = "";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(18, 179);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(75, 18);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "设备读取：";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(18, 223);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(75, 18);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "设备下发：";
            // 
            // textGetExcel
            // 
            this.textGetExcel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textGetExcel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textGetExcel.Location = new System.Drawing.Point(99, 178);
            this.textGetExcel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textGetExcel.MinimumSize = new System.Drawing.Size(1, 16);
            this.textGetExcel.Name = "textGetExcel";
            this.textGetExcel.Padding = new System.Windows.Forms.Padding(5);
            this.textGetExcel.ReadOnly = true;
            this.textGetExcel.ShowText = false;
            this.textGetExcel.Size = new System.Drawing.Size(423, 24);
            this.textGetExcel.TabIndex = 9;
            this.textGetExcel.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.textGetExcel.Watermark = "";
            this.textGetExcel.DoubleClick += new System.EventHandler(this.uiTextBoxGetExcel_DoubleClick);
            // 
            // textSetExcel
            // 
            this.textSetExcel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textSetExcel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textSetExcel.Location = new System.Drawing.Point(100, 221);
            this.textSetExcel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textSetExcel.MinimumSize = new System.Drawing.Size(1, 16);
            this.textSetExcel.Name = "textSetExcel";
            this.textSetExcel.Padding = new System.Windows.Forms.Padding(5);
            this.textSetExcel.ReadOnly = true;
            this.textSetExcel.ShowText = false;
            this.textSetExcel.Size = new System.Drawing.Size(423, 24);
            this.textSetExcel.TabIndex = 10;
            this.textSetExcel.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.textSetExcel.Watermark = "";
            this.textSetExcel.DoubleClick += new System.EventHandler(this.textSetExcel_DoubleClick);
            // 
            // xtraOpenFileDialog1
            // 
            this.xtraOpenFileDialog1.FileName = "xtraOpenFileDialog1";
            // 
            // btnTest
            // 
            this.btnTest.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnTest.Appearance.Options.UseFont = true;
            this.btnTest.Location = new System.Drawing.Point(100, 272);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(120, 35);
            this.btnTest.TabIndex = 11;
            this.btnTest.Text = "连接测试";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Location = new System.Drawing.Point(348, 272);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 35);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(18, 23);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(75, 18);
            this.labelControl7.TabIndex = 13;
            this.labelControl7.Text = "设备名称：";
            // 
            // textName
            // 
            this.textName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textName.Location = new System.Drawing.Point(100, 23);
            this.textName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textName.MinimumSize = new System.Drawing.Size(1, 16);
            this.textName.Name = "textName";
            this.textName.Padding = new System.Windows.Forms.Padding(5);
            this.textName.ShowText = false;
            this.textName.Size = new System.Drawing.Size(422, 24);
            this.textName.TabIndex = 0;
            this.textName.Text = "西门子设备001";
            this.textName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.textName.Watermark = "";
            // 
            // AddDeviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 338);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.textSetExcel);
            this.Controls.Add(this.textGetExcel);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.textHeartAddress);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.textPort);
            this.Controls.Add(this.textIp);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.comboxType);
            this.Name = "AddDeviceForm";
            this.Text = "AddDeviceForm";
            ((System.ComponentModel.ISupportInitialize)(this.comboxType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit comboxType;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private Sunny.UI.UIIPTextBox textIp;
        private Sunny.UI.UIIntegerUpDown textPort;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private Sunny.UI.UITextBox textHeartAddress;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private Sunny.UI.UITextBox textGetExcel;
        private Sunny.UI.UITextBox textSetExcel;
        private DevExpress.XtraEditors.XtraOpenFileDialog xtraOpenFileDialog1;
        private DevExpress.XtraEditors.SimpleButton btnTest;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private Sunny.UI.UITextBox textName;
    }
}