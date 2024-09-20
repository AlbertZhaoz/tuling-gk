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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.uiTempture = new Sunny.UI.UIDigitalLabel();
            this.uiBattery1 = new Sunny.UI.UIBattery();
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
            this.uiPanel4 = new Sunny.UI.UIPanel();
            this.gridPlc = new Sunny.UI.UIDataGridView();
            this.uiPanel3 = new Sunny.UI.UIPanel();
            this.uiPanel6 = new Sunny.UI.UIPanel();
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.uiCheckBoxRoll = new Sunny.UI.UICheckBox();
            this.uiButtonMock = new Sunny.UI.UIButton();
            this.uiButtonAcq = new Sunny.UI.UIButton();
            this.uiPanel1.SuspendLayout();
            this.uiPanel2.SuspendLayout();
            this.uiPanelData.SuspendLayout();
            this.uiPanel5.SuspendLayout();
            this.uiPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlc)).BeginInit();
            this.uiPanel3.SuspendLayout();
            this.uiPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.uiTempture);
            this.uiPanel1.Controls.Add(this.uiBattery1);
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
            this.uiPanel1.Size = new System.Drawing.Size(1424, 121);
            this.uiPanel1.TabIndex = 1;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiTempture
            // 
            this.uiTempture.BackColor = System.Drawing.Color.Black;
            this.uiTempture.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTempture.ForeColor = System.Drawing.Color.Lime;
            this.uiTempture.Location = new System.Drawing.Point(1242, 9);
            this.uiTempture.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTempture.Name = "uiTempture";
            this.uiTempture.Size = new System.Drawing.Size(166, 42);
            this.uiTempture.TabIndex = 2;
            this.uiTempture.Text = "uiDigitalLabel1";
            this.uiTempture.Value = 26.5D;
            // 
            // uiBattery1
            // 
            this.uiBattery1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiBattery1.Location = new System.Drawing.Point(1184, 9);
            this.uiBattery1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiBattery1.Name = "uiBattery1";
            this.uiBattery1.Size = new System.Drawing.Size(52, 26);
            this.uiBattery1.TabIndex = 12;
            this.uiBattery1.Text = "uiBattery1";
            // 
            // uiTurnSwitch1
            // 
            this.uiTurnSwitch1.BackInnerSize = 60;
            this.uiTurnSwitch1.BackSize = 70;
            this.uiTurnSwitch1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTurnSwitch1.Location = new System.Drawing.Point(597, 9);
            this.uiTurnSwitch1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTurnSwitch1.Name = "uiTurnSwitch1";
            this.uiTurnSwitch1.Size = new System.Drawing.Size(110, 109);
            this.uiTurnSwitch1.TabIndex = 11;
            this.uiTurnSwitch1.Text = "uiTurnSwitch1";
            this.uiTurnSwitch1.ValueChanged += new Sunny.UI.UITurnSwitch.OnValueChanged(this.uiTurnSwitch1_ValueChanged);
            // 
            // s7Slot
            // 
            this.s7Slot.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.s7Slot.Location = new System.Drawing.Point(411, 66);
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
            this.s7Rack.Location = new System.Drawing.Point(411, 16);
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
            this.s7Port.Location = new System.Drawing.Point(120, 60);
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
            this.s7Status.Location = new System.Drawing.Point(746, 21);
            this.s7Status.MinimumSize = new System.Drawing.Size(1, 1);
            this.s7Status.Name = "s7Status";
            this.s7Status.Radius = 72;
            this.s7Status.Size = new System.Drawing.Size(72, 79);
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
            this.uiLabel4.Location = new System.Drawing.Point(294, 66);
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
            this.uiLabel2.Location = new System.Drawing.Point(3, 60);
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
            this.s7Ip.Location = new System.Drawing.Point(120, 13);
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
            this.uiPanel2.Location = new System.Drawing.Point(0, 156);
            this.uiPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel2.Name = "uiPanel2";
            this.uiPanel2.Size = new System.Drawing.Size(1424, 733);
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
            this.uiPanelData.Size = new System.Drawing.Size(976, 733);
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
            this.uiPanel5.Size = new System.Drawing.Size(976, 733);
            this.uiPanel5.TabIndex = 2;
            this.uiPanel5.Text = "uiPanel5";
            this.uiPanel5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.uiPanel4.Size = new System.Drawing.Size(448, 733);
            this.uiPanel4.TabIndex = 4;
            this.uiPanel4.Text = null;
            this.uiPanel4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gridPlc
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.gridPlc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridPlc.BackgroundColor = System.Drawing.Color.White;
            this.gridPlc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPlc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridPlc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridPlc.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridPlc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPlc.EnableHeadersVisualStyles = false;
            this.gridPlc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridPlc.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.gridPlc.Location = new System.Drawing.Point(0, 0);
            this.gridPlc.Name = "gridPlc";
            this.gridPlc.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPlc.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridPlc.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gridPlc.RowTemplate.Height = 23;
            this.gridPlc.SelectedIndex = -1;
            this.gridPlc.Size = new System.Drawing.Size(448, 733);
            this.gridPlc.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.gridPlc.TabIndex = 0;
            this.gridPlc.SelectIndexChange += new Sunny.UI.UIDataGridView.OnSelectIndexChange(this.gridPlc_SelectIndexChange);
            // 
            // uiPanel3
            // 
            this.uiPanel3.Controls.Add(this.uiButtonAcq);
            this.uiPanel3.Controls.Add(this.uiButtonMock);
            this.uiPanel3.Controls.Add(this.uiCheckBoxRoll);
            this.uiPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiPanel3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel3.Location = new System.Drawing.Point(0, 0);
            this.uiPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel3.Name = "uiPanel3";
            this.uiPanel3.Size = new System.Drawing.Size(976, 142);
            this.uiPanel3.TabIndex = 0;
            this.uiPanel3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiPanel6
            // 
            this.uiPanel6.Controls.Add(this.formsPlot1);
            this.uiPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel6.Location = new System.Drawing.Point(0, 142);
            this.uiPanel6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel6.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel6.Name = "uiPanel6";
            this.uiPanel6.Size = new System.Drawing.Size(976, 591);
            this.uiPanel6.TabIndex = 1;
            this.uiPanel6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formsPlot1
            // 
            this.formsPlot1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlot1.Location = new System.Drawing.Point(0, 0);
            this.formsPlot1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(976, 591);
            this.formsPlot1.TabIndex = 0;
            // 
            // uiCheckBoxRoll
            // 
            this.uiCheckBoxRoll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCheckBoxRoll.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiCheckBoxRoll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiCheckBoxRoll.Location = new System.Drawing.Point(810, 18);
            this.uiCheckBoxRoll.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCheckBoxRoll.Name = "uiCheckBoxRoll";
            this.uiCheckBoxRoll.Size = new System.Drawing.Size(150, 29);
            this.uiCheckBoxRoll.TabIndex = 0;
            this.uiCheckBoxRoll.Text = "Roll";
            this.uiCheckBoxRoll.CheckedChanged += new System.EventHandler(this.uiCheckBoxRoll_CheckedChanged);
            // 
            // uiButtonMock
            // 
            this.uiButtonMock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonMock.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonMock.Location = new System.Drawing.Point(40, 18);
            this.uiButtonMock.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonMock.Name = "uiButtonMock";
            this.uiButtonMock.Size = new System.Drawing.Size(100, 35);
            this.uiButtonMock.TabIndex = 2;
            this.uiButtonMock.Text = "模拟数据";
            this.uiButtonMock.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonMock.Click += new System.EventHandler(this.uiButtonMock_Click);
            // 
            // uiButtonAcq
            // 
            this.uiButtonAcq.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonAcq.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonAcq.Location = new System.Drawing.Point(40, 73);
            this.uiButtonAcq.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonAcq.Name = "uiButtonAcq";
            this.uiButtonAcq.Size = new System.Drawing.Size(100, 35);
            this.uiButtonAcq.TabIndex = 3;
            this.uiButtonAcq.Text = "采集数据";
            this.uiButtonAcq.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonAcq.Click += new System.EventHandler(this.uiButtonAcq_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1424, 889);
            this.Controls.Add(this.uiPanel2);
            this.Controls.Add(this.uiPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 829, 496);
            this.uiPanel1.ResumeLayout(false);
            this.uiPanel2.ResumeLayout(false);
            this.uiPanelData.ResumeLayout(false);
            this.uiPanel5.ResumeLayout(false);
            this.uiPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPlc)).EndInit();
            this.uiPanel3.ResumeLayout(false);
            this.uiPanel6.ResumeLayout(false);
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
        private Sunny.UI.UIBattery uiBattery1;
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
    }
}

