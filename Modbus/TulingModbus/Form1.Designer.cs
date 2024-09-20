namespace TulingModbus
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
            this.btnConnect = new Sunny.UI.UIButton();
            this.btnCollect = new Sunny.UI.UIButton();
            this.ucThermometer1 = new HZH_Controls.Controls.UCThermometer();
            this.ucArrowLoss = new HZH_Controls.Controls.UCArrow();
            this.ucThermometer2 = new HZH_Controls.Controls.UCThermometer();
            this.ucMeter1 = new HZH_Controls.Controls.UCMeter();
            this.ucMeter2 = new HZH_Controls.Controls.UCMeter();
            this.ucSignalLamp1 = new HZH_Controls.Controls.UCSignalLamp();
            this.ucConveyor1 = new HZH_Controls.Controls.UCConveyor();
            this.ucBlower1 = new HZH_Controls.Controls.UCBlower();
            this.ucValve1 = new HZH_Controls.Controls.UCValve();
            this.ucConduit1 = new HZH_Controls.Controls.UCConduit();
            this.ucBlower2 = new HZH_Controls.Controls.UCBlower();
            this.ucValve2 = new HZH_Controls.Controls.UCValve();
            this.ucConduit2 = new HZH_Controls.Controls.UCConduit();
            this.ucConduit3 = new HZH_Controls.Controls.UCConduit();
            this.ucConduit4 = new HZH_Controls.Controls.UCConduit();
            this.ucSignalLamp2 = new HZH_Controls.Controls.UCSignalLamp();
            this.ucWave1 = new HZH_Controls.Controls.UCWave();
            this.ucConveyor2 = new HZH_Controls.Controls.UCConveyor();
            this.ucValve3 = new HZH_Controls.Controls.UCValve();
            this.ucConduit5 = new HZH_Controls.Controls.UCConduit();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConnect.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConnect.Location = new System.Drawing.Point(36, 61);
            this.btnConnect.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(127, 35);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "连接称重设备";
            this.btnConnect.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnCollect
            // 
            this.btnCollect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCollect.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCollect.Location = new System.Drawing.Point(191, 61);
            this.btnCollect.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCollect.Name = "btnCollect";
            this.btnCollect.Size = new System.Drawing.Size(127, 35);
            this.btnCollect.TabIndex = 1;
            this.btnCollect.Text = "实时采集数据";
            this.btnCollect.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCollect.Click += new System.EventHandler(this.btnCollect_Click);
            // 
            // ucThermometer1
            // 
            this.ucThermometer1.GlassTubeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.ucThermometer1.LeftTemperatureUnit = HZH_Controls.Controls.TemperatureUnit.C;
            this.ucThermometer1.Location = new System.Drawing.Point(1008, 379);
            this.ucThermometer1.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ucThermometer1.MercuryColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucThermometer1.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucThermometer1.Name = "ucThermometer1";
            this.ucThermometer1.RightTemperatureUnit = HZH_Controls.Controls.TemperatureUnit.C;
            this.ucThermometer1.Size = new System.Drawing.Size(88, 292);
            this.ucThermometer1.SplitCount = 1;
            this.ucThermometer1.TabIndex = 3;
            this.ucThermometer1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // ucArrowLoss
            // 
            this.ucArrowLoss.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucArrowLoss.BorderColor = null;
            this.ucArrowLoss.Direction = HZH_Controls.Controls.ArrowDirection.Right;
            this.ucArrowLoss.ForeColor = System.Drawing.Color.White;
            this.ucArrowLoss.Location = new System.Drawing.Point(576, 268);
            this.ucArrowLoss.Name = "ucArrowLoss";
            this.ucArrowLoss.Size = new System.Drawing.Size(100, 50);
            this.ucArrowLoss.TabIndex = 4;
            this.ucArrowLoss.Text = "缺料方向";
            // 
            // ucThermometer2
            // 
            this.ucThermometer2.GlassTubeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.ucThermometer2.LeftTemperatureUnit = HZH_Controls.Controls.TemperatureUnit.C;
            this.ucThermometer2.Location = new System.Drawing.Point(1008, 61);
            this.ucThermometer2.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ucThermometer2.MercuryColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucThermometer2.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucThermometer2.Name = "ucThermometer2";
            this.ucThermometer2.RightTemperatureUnit = HZH_Controls.Controls.TemperatureUnit.C;
            this.ucThermometer2.Size = new System.Drawing.Size(88, 245);
            this.ucThermometer2.SplitCount = 1;
            this.ucThermometer2.TabIndex = 5;
            this.ucThermometer2.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // ucMeter1
            // 
            this.ucMeter1.BoundaryLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter1.ExternalRoundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter1.FixedText = "";
            this.ucMeter1.InsideRoundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter1.Location = new System.Drawing.Point(314, 178);
            this.ucMeter1.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ucMeter1.MeterDegrees = 150;
            this.ucMeter1.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucMeter1.Name = "ucMeter1";
            this.ucMeter1.PointerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter1.ScaleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter1.ScaleValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter1.Size = new System.Drawing.Size(220, 92);
            this.ucMeter1.SplitCount = 10;
            this.ucMeter1.TabIndex = 6;
            this.ucMeter1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter1.TextFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucMeter1.TextLocation = HZH_Controls.Controls.MeterTextLocation.None;
            this.ucMeter1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // ucMeter2
            // 
            this.ucMeter2.BoundaryLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter2.ExternalRoundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter2.FixedText = null;
            this.ucMeter2.InsideRoundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter2.Location = new System.Drawing.Point(223, 350);
            this.ucMeter2.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ucMeter2.MeterDegrees = 150;
            this.ucMeter2.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucMeter2.Name = "ucMeter2";
            this.ucMeter2.PointerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter2.ScaleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter2.ScaleValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter2.Size = new System.Drawing.Size(216, 128);
            this.ucMeter2.SplitCount = 10;
            this.ucMeter2.TabIndex = 7;
            this.ucMeter2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter2.TextFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucMeter2.TextLocation = HZH_Controls.Controls.MeterTextLocation.None;
            this.ucMeter2.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // ucSignalLamp1
            // 
            this.ucSignalLamp1.IsHighlight = true;
            this.ucSignalLamp1.IsShowBorder = false;
            this.ucSignalLamp1.LampColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))))};
            this.ucSignalLamp1.Location = new System.Drawing.Point(55, 245);
            this.ucSignalLamp1.Name = "ucSignalLamp1";
            this.ucSignalLamp1.Size = new System.Drawing.Size(50, 50);
            this.ucSignalLamp1.TabIndex = 8;
            this.ucSignalLamp1.TwinkleSpeed = 0;
            // 
            // ucConveyor1
            // 
            this.ucConveyor1.ConveyorColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucConveyor1.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.ucConveyor1.ConveyorHeight = 50;
            this.ucConveyor1.ConveyorSpeed = 100;
            this.ucConveyor1.Inclination = 0D;
            this.ucConveyor1.Location = new System.Drawing.Point(270, 268);
            this.ucConveyor1.Name = "ucConveyor1";
            this.ucConveyor1.Size = new System.Drawing.Size(300, 50);
            this.ucConveyor1.TabIndex = 9;
            // 
            // ucBlower1
            // 
            this.ucBlower1.BlowerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucBlower1.EntranceDirection = HZH_Controls.Controls.BlowerEntranceDirection.None;
            this.ucBlower1.ExitDirection = HZH_Controls.Controls.BlowerExitDirection.Right;
            this.ucBlower1.FanColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucBlower1.Location = new System.Drawing.Point(36, 147);
            this.ucBlower1.Name = "ucBlower1";
            this.ucBlower1.Size = new System.Drawing.Size(92, 92);
            this.ucBlower1.TabIndex = 10;
            this.ucBlower1.TurnAround = HZH_Controls.Controls.TurnAround.None;
            this.ucBlower1.TurnSpeed = 100;
            // 
            // ucValve1
            // 
            this.ucValve1.AsisBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucValve1.AxisColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucValve1.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucValve1.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.ucValve1.LiquidSpeed = 100;
            this.ucValve1.Location = new System.Drawing.Point(123, 136);
            this.ucValve1.Name = "ucValve1";
            this.ucValve1.Opened = true;
            this.ucValve1.Size = new System.Drawing.Size(160, 56);
            this.ucValve1.SwitchColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucValve1.TabIndex = 11;
            this.ucValve1.ValveColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucValve1.ValveStyle = HZH_Controls.Controls.ValveStyle.Horizontal_Top;
            // 
            // ucConduit1
            // 
            this.ucConduit1.ConduitColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucConduit1.ConduitStyle = HZH_Controls.Controls.ConduitStyle.Vertical_Left_None;
            this.ucConduit1.ConduitWidth = 50;
            this.ucConduit1.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucConduit1.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.ucConduit1.LiquidSpeed = 100;
            this.ucConduit1.Location = new System.Drawing.Point(276, 161);
            this.ucConduit1.Name = "ucConduit1";
            this.ucConduit1.Size = new System.Drawing.Size(23, 128);
            this.ucConduit1.TabIndex = 12;
            // 
            // ucBlower2
            // 
            this.ucBlower2.BlowerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucBlower2.EntranceDirection = HZH_Controls.Controls.BlowerEntranceDirection.None;
            this.ucBlower2.ExitDirection = HZH_Controls.Controls.BlowerExitDirection.Right;
            this.ucBlower2.FanColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucBlower2.Location = new System.Drawing.Point(682, 178);
            this.ucBlower2.Name = "ucBlower2";
            this.ucBlower2.Size = new System.Drawing.Size(92, 92);
            this.ucBlower2.TabIndex = 13;
            this.ucBlower2.TurnAround = HZH_Controls.Controls.TurnAround.None;
            this.ucBlower2.TurnSpeed = 100;
            // 
            // ucValve2
            // 
            this.ucValve2.AsisBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucValve2.AxisColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucValve2.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucValve2.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.ucValve2.LiquidSpeed = 100;
            this.ucValve2.Location = new System.Drawing.Point(771, 166);
            this.ucValve2.Name = "ucValve2";
            this.ucValve2.Opened = true;
            this.ucValve2.Size = new System.Drawing.Size(160, 56);
            this.ucValve2.SwitchColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucValve2.TabIndex = 14;
            this.ucValve2.ValveColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucValve2.ValveStyle = HZH_Controls.Controls.ValveStyle.Horizontal_Top;
            // 
            // ucConduit2
            // 
            this.ucConduit2.ConduitColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucConduit2.ConduitStyle = HZH_Controls.Controls.ConduitStyle.Vertical_Left_None;
            this.ucConduit2.ConduitWidth = 50;
            this.ucConduit2.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucConduit2.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.ucConduit2.LiquidSpeed = 100;
            this.ucConduit2.Location = new System.Drawing.Point(930, 192);
            this.ucConduit2.Name = "ucConduit2";
            this.ucConduit2.Size = new System.Drawing.Size(23, 128);
            this.ucConduit2.TabIndex = 15;
            // 
            // ucConduit3
            // 
            this.ucConduit3.ConduitColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucConduit3.ConduitStyle = HZH_Controls.Controls.ConduitStyle.Vertical_None_None;
            this.ucConduit3.ConduitWidth = 50;
            this.ucConduit3.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucConduit3.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.ucConduit3.LiquidSpeed = 100;
            this.ucConduit3.Location = new System.Drawing.Point(930, 308);
            this.ucConduit3.Name = "ucConduit3";
            this.ucConduit3.Size = new System.Drawing.Size(23, 170);
            this.ucConduit3.TabIndex = 16;
            // 
            // ucConduit4
            // 
            this.ucConduit4.ConduitColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucConduit4.ConduitStyle = HZH_Controls.Controls.ConduitStyle.Horizontal_None_Up;
            this.ucConduit4.ConduitWidth = 50;
            this.ucConduit4.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucConduit4.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.ucConduit4.LiquidSpeed = 100;
            this.ucConduit4.Location = new System.Drawing.Point(468, 472);
            this.ucConduit4.Name = "ucConduit4";
            this.ucConduit4.Size = new System.Drawing.Size(485, 23);
            this.ucConduit4.TabIndex = 17;
            // 
            // ucSignalLamp2
            // 
            this.ucSignalLamp2.IsHighlight = true;
            this.ucSignalLamp2.IsShowBorder = false;
            this.ucSignalLamp2.LampColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))))};
            this.ucSignalLamp2.Location = new System.Drawing.Point(703, 272);
            this.ucSignalLamp2.Name = "ucSignalLamp2";
            this.ucSignalLamp2.Size = new System.Drawing.Size(50, 50);
            this.ucSignalLamp2.TabIndex = 18;
            this.ucSignalLamp2.TwinkleSpeed = 0;
            // 
            // ucWave1
            // 
            this.ucWave1.BubbleIntervalTime = 500;
            this.ucWave1.BubbleSpeed = 0;
            this.ucWave1.Location = new System.Drawing.Point(55, 533);
            this.ucWave1.Name = "ucWave1";
            this.ucWave1.Size = new System.Drawing.Size(898, 154);
            this.ucWave1.TabIndex = 19;
            this.ucWave1.Text = "ucWave1";
            this.ucWave1.WaveColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ucWave1.WaveHeight = 30;
            this.ucWave1.WaveSleep = 50;
            this.ucWave1.WaveWidth = 200;
            // 
            // ucConveyor2
            // 
            this.ucConveyor2.ConveyorColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucConveyor2.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Forward;
            this.ucConveyor2.ConveyorHeight = 50;
            this.ucConveyor2.ConveyorSpeed = 100;
            this.ucConveyor2.Inclination = 0D;
            this.ucConveyor2.Location = new System.Drawing.Point(189, 455);
            this.ucConveyor2.Name = "ucConveyor2";
            this.ucConveyor2.Size = new System.Drawing.Size(300, 50);
            this.ucConveyor2.TabIndex = 20;
            // 
            // ucValve3
            // 
            this.ucValve3.AsisBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucValve3.AxisColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucValve3.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucValve3.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.ucValve3.LiquidSpeed = 100;
            this.ucValve3.Location = new System.Drawing.Point(83, 443);
            this.ucValve3.Name = "ucValve3";
            this.ucValve3.Opened = true;
            this.ucValve3.Size = new System.Drawing.Size(115, 56);
            this.ucValve3.SwitchColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucValve3.TabIndex = 21;
            this.ucValve3.ValveColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucValve3.ValveStyle = HZH_Controls.Controls.ValveStyle.Horizontal_Top;
            // 
            // ucConduit5
            // 
            this.ucConduit5.ConduitColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucConduit5.ConduitStyle = HZH_Controls.Controls.ConduitStyle.Vertical_None_Right;
            this.ucConduit5.ConduitWidth = 50;
            this.ucConduit5.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucConduit5.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.ucConduit5.LiquidSpeed = 100;
            this.ucConduit5.Location = new System.Drawing.Point(65, 301);
            this.ucConduit5.Name = "ucConduit5";
            this.ucConduit5.Size = new System.Drawing.Size(23, 194);
            this.ucConduit5.TabIndex = 22;
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Location = new System.Drawing.Point(349, 61);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(127, 35);
            this.uiButton1.TabIndex = 23;
            this.uiButton1.Text = "模拟采集数据";
            this.uiButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1117, 706);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.ucConduit5);
            this.Controls.Add(this.ucValve3);
            this.Controls.Add(this.ucConveyor2);
            this.Controls.Add(this.ucWave1);
            this.Controls.Add(this.ucSignalLamp2);
            this.Controls.Add(this.ucConduit4);
            this.Controls.Add(this.ucConduit3);
            this.Controls.Add(this.ucConduit2);
            this.Controls.Add(this.ucValve2);
            this.Controls.Add(this.ucBlower2);
            this.Controls.Add(this.ucConduit1);
            this.Controls.Add(this.ucValve1);
            this.Controls.Add(this.ucBlower1);
            this.Controls.Add(this.ucConveyor1);
            this.Controls.Add(this.ucSignalLamp1);
            this.Controls.Add(this.ucMeter2);
            this.Controls.Add(this.ucMeter1);
            this.Controls.Add(this.ucThermometer2);
            this.Controls.Add(this.ucArrowLoss);
            this.Controls.Add(this.ucThermometer1);
            this.Controls.Add(this.btnCollect);
            this.Controls.Add(this.btnConnect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIButton btnConnect;
        private Sunny.UI.UIButton btnCollect;
        private HZH_Controls.Controls.UCThermometer ucThermometer1;
        private HZH_Controls.Controls.UCArrow ucArrowLoss;
        private HZH_Controls.Controls.UCThermometer ucThermometer2;
        private HZH_Controls.Controls.UCMeter ucMeter1;
        private HZH_Controls.Controls.UCMeter ucMeter2;
        private HZH_Controls.Controls.UCSignalLamp ucSignalLamp1;
        private HZH_Controls.Controls.UCConveyor ucConveyor1;
        private HZH_Controls.Controls.UCBlower ucBlower1;
        private HZH_Controls.Controls.UCValve ucValve1;
        private HZH_Controls.Controls.UCConduit ucConduit1;
        private HZH_Controls.Controls.UCBlower ucBlower2;
        private HZH_Controls.Controls.UCValve ucValve2;
        private HZH_Controls.Controls.UCConduit ucConduit2;
        private HZH_Controls.Controls.UCConduit ucConduit3;
        private HZH_Controls.Controls.UCConduit ucConduit4;
        private HZH_Controls.Controls.UCSignalLamp ucSignalLamp2;
        private HZH_Controls.Controls.UCWave ucWave1;
        private HZH_Controls.Controls.UCConveyor ucConveyor2;
        private HZH_Controls.Controls.UCValve ucValve3;
        private HZH_Controls.Controls.UCConduit ucConduit5;
        private Sunny.UI.UIButton uiButton1;
    }
}

