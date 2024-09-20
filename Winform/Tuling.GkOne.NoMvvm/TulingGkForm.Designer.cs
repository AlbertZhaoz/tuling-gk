namespace Tuling.GkOne.NoMvvm
{
    partial class TulingGkForm
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
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnLog = new DevExpress.XtraBars.BarButtonItem();
            this.btnGdi = new DevExpress.XtraBars.BarButtonItem();
            this.btnScreen = new DevExpress.XtraBars.BarButtonItem();
            this.btnMis = new DevExpress.XtraBars.BarButtonItem();
            this.btnCmd = new DevExpress.XtraBars.BarButtonItem();
            this.btnPython = new DevExpress.XtraBars.BarButtonItem();
            this.btnAutoUpdate = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnCatch = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.multiThreadRefreshUcOne = new Tuling.GkOne.NoMvvm.Forms.MultiThreadRefreshUc();
            this.panelContainer = new DevExpress.XtraEditors.PanelControl();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItemVersion = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 32, 35, 32);
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnLog,
            this.btnGdi,
            this.btnScreen,
            this.btnMis,
            this.btnCmd,
            this.btnPython,
            this.btnAutoUpdate,
            this.btnRefresh,
            this.btnCatch});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ribbonControl1.MaxItemId = 11;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.OptionsMenuMinWidth = 385;
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage3,
            this.ribbonPage2});
            this.ribbonControl1.Size = new System.Drawing.Size(983, 147);
            // 
            // btnLog
            // 
            this.btnLog.Caption = "分页日志";
            this.btnLog.Id = 1;
            this.btnLog.ImageOptions.Image = global::Tuling.GkOne.NoMvvm.Properties.Resources.formatastable_16x16;
            this.btnLog.ImageOptions.LargeImage = global::Tuling.GkOne.NoMvvm.Properties.Resources.formatastable_32x32;
            this.btnLog.Name = "btnLog";
            this.btnLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btnGdi
            // 
            this.btnGdi.Caption = "GDI 绘制";
            this.btnGdi.Id = 2;
            this.btnGdi.ImageOptions.Image = global::Tuling.GkOne.NoMvvm.Properties.Resources.edit_16x16;
            this.btnGdi.ImageOptions.LargeImage = global::Tuling.GkOne.NoMvvm.Properties.Resources.edit_32x32;
            this.btnGdi.Name = "btnGdi";
            this.btnGdi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick_1);
            // 
            // btnScreen
            // 
            this.btnScreen.Caption = "自动截图";
            this.btnScreen.Id = 3;
            this.btnScreen.ImageOptions.Image = global::Tuling.GkOne.NoMvvm.Properties.Resources.picturebox_16x16;
            this.btnScreen.ImageOptions.LargeImage = global::Tuling.GkOne.NoMvvm.Properties.Resources.picturebox_32x32;
            this.btnScreen.Name = "btnScreen";
            this.btnScreen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnScreen_ItemClick);
            // 
            // btnMis
            // 
            this.btnMis.Caption = "交互式模块";
            this.btnMis.Id = 4;
            this.btnMis.ImageOptions.Image = global::Tuling.GkOne.NoMvvm.Properties.Resources.solution_16x16;
            this.btnMis.ImageOptions.LargeImage = global::Tuling.GkOne.NoMvvm.Properties.Resources.solution_32x32;
            this.btnMis.Name = "btnMis";
            this.btnMis.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMis_ItemClick);
            // 
            // btnCmd
            // 
            this.btnCmd.Caption = "代码生成";
            this.btnCmd.Id = 5;
            this.btnCmd.ImageOptions.Image = global::Tuling.GkOne.NoMvvm.Properties.Resources.comment_16x16;
            this.btnCmd.ImageOptions.LargeImage = global::Tuling.GkOne.NoMvvm.Properties.Resources.comment_32x32;
            this.btnCmd.Name = "btnCmd";
            this.btnCmd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCmd_ItemClick);
            // 
            // btnPython
            // 
            this.btnPython.Caption = "Python 调用";
            this.btnPython.Id = 6;
            this.btnPython.ImageOptions.Image = global::Tuling.GkOne.NoMvvm.Properties.Resources.errorbars_16x16;
            this.btnPython.ImageOptions.LargeImage = global::Tuling.GkOne.NoMvvm.Properties.Resources.errorbars_32x32;
            this.btnPython.Name = "btnPython";
            this.btnPython.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPython_ItemClick);
            // 
            // btnAutoUpdate
            // 
            this.btnAutoUpdate.Caption = "自动更新";
            this.btnAutoUpdate.Id = 7;
            this.btnAutoUpdate.ImageOptions.Image = global::Tuling.GkOne.NoMvvm.Properties.Resources.contentautoarrange_16x16;
            this.btnAutoUpdate.ImageOptions.LargeImage = global::Tuling.GkOne.NoMvvm.Properties.Resources.contentautoarrange_32x32;
            this.btnAutoUpdate.Name = "btnAutoUpdate";
            this.btnAutoUpdate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAutoUpdate_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "多线程刷新";
            this.btnRefresh.Id = 9;
            this.btnRefresh.ImageOptions.Image = global::Tuling.GkOne.NoMvvm.Properties.Resources.refresh_16x16;
            this.btnRefresh.ImageOptions.LargeImage = global::Tuling.GkOne.NoMvvm.Properties.Resources.refresh_32x32;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnCatch
            // 
            this.btnCatch.Caption = "手动截图";
            this.btnCatch.Id = 10;
            this.btnCatch.ImageOptions.Image = global::Tuling.GkOne.NoMvvm.Properties.Resources.importimage_16x16;
            this.btnCatch.ImageOptions.LargeImage = global::Tuling.GkOne.NoMvvm.Properties.Resources.importimage_32x32;
            this.btnCatch.Name = "btnCatch";
            this.btnCatch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCatch_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "系统大全";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRefresh);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLog);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnGdi);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPython);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCmd);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Winform 基础使用";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "系统通讯";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnMis);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "通讯";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "系统工具";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnScreen);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnCatch);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnAutoUpdate);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "工具";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.multiThreadRefreshUcOne);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 147);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(281, 446);
            this.panelControl1.TabIndex = 1;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.labelControl1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(2, 413);
            this.panelControl3.Margin = new System.Windows.Forms.Padding(2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(277, 31);
            this.panelControl3.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(16, 12);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "数据准备中...";
            // 
            // multiThreadRefreshUcOne
            // 
            this.multiThreadRefreshUcOne.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.multiThreadRefreshUcOne.Dock = System.Windows.Forms.DockStyle.Top;
            this.multiThreadRefreshUcOne.Location = new System.Drawing.Point(2, 2);
            this.multiThreadRefreshUcOne.Margin = new System.Windows.Forms.Padding(1);
            this.multiThreadRefreshUcOne.Name = "multiThreadRefreshUcOne";
            this.multiThreadRefreshUcOne.Size = new System.Drawing.Size(277, 98);
            this.multiThreadRefreshUcOne.TabIndex = 0;
            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(281, 147);
            this.panelContainer.Margin = new System.Windows.Forms.Padding(2);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(702, 446);
            this.panelContainer.TabIndex = 2;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "DevExpress Style";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barStaticItemVersion});
            this.barManager1.MaxItemId = 1;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItemVersion)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barStaticItemVersion
            // 
            this.barStaticItemVersion.Caption = "程序版本";
            this.barStaticItemVersion.Id = 0;
            this.barStaticItemVersion.Name = "barStaticItemVersion";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(983, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 593);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(983, 24);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 593);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(983, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 593);
            // 
            // TulingGkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 617);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "TulingGkForm";
            this.Ribbon = this.ribbonControl1;
            this.Text = "TulingGkForm";
            this.Load += new System.EventHandler(this.TulingGkForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnLog;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnGdi;
        private DevExpress.XtraBars.BarButtonItem btnScreen;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem btnMis;
        private DevExpress.XtraBars.BarButtonItem btnCmd;
        private DevExpress.XtraBars.BarButtonItem btnPython;
        private DevExpress.XtraBars.BarButtonItem btnAutoUpdate;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelContainer;
        private Forms.MultiThreadRefreshUc multiThreadRefreshUcOne;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.BarButtonItem btnCatch;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem barStaticItemVersion;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}

