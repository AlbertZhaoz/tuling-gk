namespace SunnyScopplotS7netplus
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.uiTempture = new Sunny.UI.UIDigitalLabel();
            this.uiTurnSwitch1 = new Sunny.UI.UITurnSwitch();
            this.s7Slot = new Sunny.UI.UIIntegerUpDown();
            this.s7Rack = new Sunny.UI.UIIntegerUpDown();
            this.s7Port = new Sunny.UI.UIIntegerUpDown();
            this.s7Status = new Sunny.UI.UILight();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.s7Ip = new Sunny.UI.UIIPTextBox();
            this.uiPanel2 = new Sunny.UI.UIPanel();
            this.uiPanelData = new Sunny.UI.UIPanel();
            this.uiPanel5 = new Sunny.UI.UIPanel();
            this.uiPanel6 = new Sunny.UI.UIPanel();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.uiPanel3 = new Sunny.UI.UIPanel();
            this.uiButtonAcq = new Sunny.UI.UIButton();
            this.uiButtonMock = new Sunny.UI.UIButton();
            this.uiCheckBoxRoll = new Sunny.UI.UICheckBox();
            this.uiPanel4 = new Sunny.UI.UIPanel();
            this.gridPlc = new Sunny.UI.UIDataGridView();
            this.uiPanel1.SuspendLayout();
            this.uiPanel2.SuspendLayout();
            this.uiPanelData.SuspendLayout();
            this.uiPanel5.SuspendLayout();
            this.uiPanel6.SuspendLayout();
            this.uiPanel3.SuspendLayout();
            this.uiPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlc)).BeginInit();
            this.SuspendLayout();
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.uiTurnSwitch1);
            this.uiPanel1.Controls.Add(this.s7Slot);
            this.uiPanel1.Controls.Add(this.s7Rack);
            this.uiPanel1.Controls.Add(this.s7Port);
            this.uiPanel1.Controls.Add(this.s7Status);
            this.uiPanel1.Controls.Add(this.uiLabel3);
            this.uiPanel1.Controls.Add(this.uiLabel4);
            this.uiPanel1.Controls.Add(this.uiLabel2);
            this.uiPanel1.Controls.Add(this.uiLabel1);
            this.uiPanel1.Controls.Add(this.s7Ip);
            this.uiPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiPanel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.Location = new System.Drawing.Point(0, 35);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(1424, 70);
            this.uiPanel1.TabIndex = 1;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiTempture
            // 
            this.uiTempture.BackColor = System.Drawing.Color.Black;
            this.uiTempture.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTempture.ForeColor = System.Drawing.Color.Lime;
            this.uiTempture.Location = new System.Drawing.Point(839, 8);
            this.uiTempture.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTempture.Name = "uiTempture";
            this.uiTempture.Size = new System.Drawing.Size(134, 39);
            this.uiTempture.TabIndex = 2;
            this.uiTempture.Text = "uiDigitalLabel1";
            this.uiTempture.Value = 26.5D;
            // 
            // uiTurnSwitch1
            // 
            this.uiTurnSwitch1.BackInnerSize = 20;
            this.uiTurnSwitch1.BackSize = 30;
            this.uiTurnSwitch1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTurnSwitch1.Location = new System.Drawing.Point(1274, 2);
            this.uiTurnSwitch1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTurnSwitch1.Name = "uiTurnSwitch1";
            this.uiTurnSwitch1.Size = new System.Drawing.Size(67, 67);
            this.uiTurnSwitch1.TabIndex = 11;
            this.uiTurnSwitch1.Text = "uiTurnSwitch1";
            this.uiTurnSwitch1.ValueChanged += new Sunny.UI.UITurnSwitch.OnValueChanged(this.uiTurnSwitch1_ValueChanged);
            // 
            // s7Slot
            // 
            this.s7Slot.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.s7Slot.Location = new System.Drawing.Point(1001, 17);
            this.s7Slot.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.s7Slot.MinimumSize = new System.Drawing.Size(100, 0);
            this.s7Slot.Name = "s7Slot";
            this.s7Slot.ShowText = false;
            this.s7Slot.Size = new System.Drawing.Size(150, 29);
            this.s7Slot.TabIndex = 10;
            this.s7Slot.Text = "uiIntegerUpDown3";
            this.s7Slot.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.s7Slot.Value = 1;
            // 
            // s7Rack
            // 
            this.s7Rack.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.s7Rack.Location = new System.Drawing.Point(411, 14);
            this.s7Rack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.s7Rack.MinimumSize = new System.Drawing.Size(100, 0);
            this.s7Rack.Name = "s7Rack";
            this.s7Rack.ShowText = false;
            this.s7Rack.Size = new System.Drawing.Size(150, 29);
            this.s7Rack.TabIndex = 9;
            this.s7Rack.Text = "uiIntegerUpDown2";
            this.s7Rack.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // s7Port
            // 
            this.s7Port.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.s7Port.Location = new System.Drawing.Point(710, 16);
            this.s7Port.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.s7Port.MinimumSize = new System.Drawing.Size(100, 0);
            this.s7Port.Name = "s7Port";
            this.s7Port.ShowText = false;
            this.s7Port.Size = new System.Drawing.Size(150, 29);
            this.s7Port.TabIndex = 8;
            this.s7Port.Text = "uiIntegerUpDown1";
            this.s7Port.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.s7Port.Value = 102;
            // 
            // s7Status
            // 
            this.s7Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.s7Status.Location = new System.Drawing.Point(1369, 11);
            this.s7Status.MinimumSize = new System.Drawing.Size(1, 1);
            this.s7Status.Name = "s7Status";
            this.s7Status.Radius = 47;
            this.s7Status.Size = new System.Drawing.Size(52, 47);
            this.s7Status.State = Sunny.UI.UILightState.Off;
            this.s7Status.TabIndex = 2;
            this.s7Status.Text = "s7Status";
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel3.Location = new System.Drawing.Point(294, 16);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(110, 23);
            this.uiLabel3.TabIndex = 7;
            this.uiLabel3.Text = "西门子机架号";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel4.Location = new System.Drawing.Point(884, 19);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(110, 23);
            this.uiLabel4.TabIndex = 6;
            this.uiLabel4.Text = "西门子槽号";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel2.Location = new System.Drawing.Point(593, 18);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(110, 23);
            this.uiLabel2.TabIndex = 5;
            this.uiLabel2.Text = "西门子端口号";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(3, 16);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(110, 23);
            this.uiLabel1.TabIndex = 4;
            this.uiLabel1.Text = "西门子IP地址";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // s7Ip
            // 
            this.s7Ip.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.s7Ip.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.s7Ip.Location = new System.Drawing.Point(120, 14);
            this.s7Ip.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.s7Ip.MinimumSize = new System.Drawing.Size(1, 1);
            this.s7Ip.Name = "s7Ip";
            this.s7Ip.Padding = new System.Windows.Forms.Padding(1);
            this.s7Ip.ShowText = false;
            this.s7Ip.Size = new System.Drawing.Size(150, 29);
            this.s7Ip.TabIndex = 2;
            this.s7Ip.Text = "127.0.0.1";
            this.s7Ip.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.s7Ip.Value = ((System.Net.IPAddress)(resources.GetObject("s7Ip.Value")));
            // 
            // uiPanel2
            // 
            this.uiPanel2.Controls.Add(this.uiPanelData);
            this.uiPanel2.Controls.Add(this.uiPanel4);
            this.uiPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel2.Location = new System.Drawing.Point(0, 105);
            this.uiPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel2.Name = "uiPanel2";
            this.uiPanel2.Size = new System.Drawing.Size(1424, 842);
            this.uiPanel2.TabIndex = 2;
            this.uiPanel2.Text = null;
            this.uiPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiPanelData
            // 
            this.uiPanelData.Controls.Add(this.uiPanel5);
            this.uiPanelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanelData.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanelData.Location = new System.Drawing.Point(448, 0);
            this.uiPanelData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanelData.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanelData.Name = "uiPanelData";
            this.uiPanelData.Size = new System.Drawing.Size(976, 842);
            this.uiPanelData.TabIndex = 3;
            this.uiPanelData.Text = null;
            this.uiPanelData.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiPanel5
            // 
            this.uiPanel5.Controls.Add(this.uiPanel6);
            this.uiPanel5.Controls.Add(this.uiPanel3);
            this.uiPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel5.Location = new System.Drawing.Point(0, 0);
            this.uiPanel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel5.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel5.Name = "uiPanel5";
            this.uiPanel5.Size = new System.Drawing.Size(976, 842);
            this.uiPanel5.TabIndex = 2;
            this.uiPanel5.Text = "uiPanel5";
            this.uiPanel5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiPanel6
            // 
            this.uiPanel6.Controls.Add(this.cartesianChart1);
            this.uiPanel6.Controls.Add(this.formsPlot1);
            this.uiPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel6.Location = new System.Drawing.Point(0, 59);
            this.uiPanel6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel6.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel6.Name = "uiPanel6";
            this.uiPanel6.Size = new System.Drawing.Size(976, 783);
            this.uiPanel6.TabIndex = 1;
            this.uiPanel6.Text = null;
            this.uiPanel6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartesianChart1.Location = new System.Drawing.Point(0, 364);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(976, 419);
            this.cartesianChart1.TabIndex = 1;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // formsPlot1
            // 
            this.formsPlot1.Dock = System.Windows.Forms.DockStyle.Top;
            this.formsPlot1.Location = new System.Drawing.Point(0, 0);
            this.formsPlot1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(976, 364);
            this.formsPlot1.TabIndex = 0;
            // 
            // uiPanel3
            // 
            this.uiPanel3.Controls.Add(this.uiTempture);
            this.uiPanel3.Controls.Add(this.uiButtonAcq);
            this.uiPanel3.Controls.Add(this.uiButtonMock);
            this.uiPanel3.Controls.Add(this.uiCheckBoxRoll);
            this.uiPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiPanel3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel3.Location = new System.Drawing.Point(0, 0);
            this.uiPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel3.Name = "uiPanel3";
            this.uiPanel3.Size = new System.Drawing.Size(976, 59);
            this.uiPanel3.TabIndex = 0;
            this.uiPanel3.Text = null;
            this.uiPanel3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiButtonAcq
            // 
            this.uiButtonAcq.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonAcq.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonAcq.Location = new System.Drawing.Point(132, 8);
            this.uiButtonAcq.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonAcq.Name = "uiButtonAcq";
            this.uiButtonAcq.Size = new System.Drawing.Size(100, 35);
            this.uiButtonAcq.TabIndex = 3;
            this.uiButtonAcq.Text = "采集数据";
            this.uiButtonAcq.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonAcq.Click += new System.EventHandler(this.uiButtonAcq_Click);
            // 
            // uiButtonMock
            // 
            this.uiButtonMock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonMock.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonMock.Location = new System.Drawing.Point(13, 8);
            this.uiButtonMock.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonMock.Name = "uiButtonMock";
            this.uiButtonMock.Size = new System.Drawing.Size(100, 35);
            this.uiButtonMock.TabIndex = 2;
            this.uiButtonMock.Text = "模拟数据";
            this.uiButtonMock.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonMock.Click += new System.EventHandler(this.uiButtonMock_Click);
            // 
            // uiCheckBoxRoll
            // 
            this.uiCheckBoxRoll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCheckBoxRoll.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiCheckBoxRoll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiCheckBoxRoll.Location = new System.Drawing.Point(758, 13);
            this.uiCheckBoxRoll.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCheckBoxRoll.Name = "uiCheckBoxRoll";
            this.uiCheckBoxRoll.Size = new System.Drawing.Size(72, 29);
            this.uiCheckBoxRoll.TabIndex = 0;
            this.uiCheckBoxRoll.Text = "Roll";
            this.uiCheckBoxRoll.CheckedChanged += new System.EventHandler(this.uiCheckBoxRoll_CheckedChanged);
            // 
            // uiPanel4
            // 
            this.uiPanel4.Controls.Add(this.gridPlc);
            this.uiPanel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiPanel4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel4.Location = new System.Drawing.Point(0, 0);
            this.uiPanel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel4.Name = "uiPanel4";
            this.uiPanel4.Size = new System.Drawing.Size(448, 842);
            this.uiPanel4.TabIndex = 4;
            this.uiPanel4.Text = null;
            this.uiPanel4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gridPlc
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.gridPlc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.gridPlc.BackgroundColor = System.Drawing.Color.White;
            this.gridPlc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPlc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gridPlc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridPlc.DefaultCellStyle = dataGridViewCellStyle8;
            this.gridPlc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPlc.EnableHeadersVisualStyles = false;
            this.gridPlc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridPlc.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.gridPlc.Location = new System.Drawing.Point(0, 0);
            this.gridPlc.Name = "gridPlc";
            this.gridPlc.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPlc.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridPlc.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.gridPlc.RowTemplate.Height = 23;
            this.gridPlc.SelectedIndex = -1;
            this.gridPlc.Size = new System.Drawing.Size(448, 842);
            this.gridPlc.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.gridPlc.TabIndex = 0;
            this.gridPlc.SelectIndexChange += new Sunny.UI.UIDataGridView.OnSelectIndexChange(this.gridPlc_SelectIndexChange);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1424, 947);
            this.Controls.Add(this.uiPanel2);
            this.Controls.Add(this.uiPanel1);
            this.Name = "Form1";
            this.Text = "图灵西门子采集系统";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 829, 496);
            this.uiPanel1.ResumeLayout(false);
            this.uiPanel2.ResumeLayout(false);
            this.uiPanelData.ResumeLayout(false);
            this.uiPanel5.ResumeLayout(false);
            this.uiPanel6.ResumeLayout(false);
            this.uiPanel3.ResumeLayout(false);
            this.uiPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPlc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIIPTextBox s7Ip;
        private Sunny.UI.UIDigitalLabel uiTempture;
        private Sunny.UI.UITurnSwitch uiTurnSwitch1;
        private Sunny.UI.UIIntegerUpDown s7Slot;
        private Sunny.UI.UIIntegerUpDown s7Rack;
        private Sunny.UI.UIIntegerUpDown s7Port;
        private Sunny.UI.UIPanel uiPanel2;
        private Sunny.UI.UIPanel uiPanelData;
        private Sunny.UI.UIPanel uiPanel4;
        private Sunny.UI.UIDataGridView gridPlc;
        private Sunny.UI.UILight s7Status;
        private Sunny.UI.UIPanel uiPanel5;
        private Sunny.UI.UIPanel uiPanel6;
        private ScottPlot.FormsPlot formsPlot1;
        private Sunny.UI.UIPanel uiPanel3;
        private Sunny.UI.UIButton uiButtonAcq;
        private Sunny.UI.UIButton uiButtonMock;
        private Sunny.UI.UICheckBox uiCheckBoxRoll;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
    }
}

