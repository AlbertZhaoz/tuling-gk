namespace TulingHsl.UserControls
{
    partial class S7DeviceUc
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uiLightStatus = new Sunny.UI.UILight();
            this.labelName = new DevExpress.XtraEditors.LabelControl();
            this.labelIp = new DevExpress.XtraEditors.LabelControl();
            this.labelType = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.uiCheckBox1 = new Sunny.UI.UICheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiLightStatus
            // 
            this.uiLightStatus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLightStatus.Location = new System.Drawing.Point(159, 10);
            this.uiLightStatus.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLightStatus.Name = "uiLightStatus";
            this.uiLightStatus.Radius = 35;
            this.uiLightStatus.Size = new System.Drawing.Size(35, 35);
            this.uiLightStatus.TabIndex = 0;
            this.uiLightStatus.Text = "uiLight1";
            // 
            // labelName
            // 
            this.labelName.Location = new System.Drawing.Point(5, 14);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(70, 14);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "labelControl1";
            // 
            // labelIp
            // 
            this.labelIp.Location = new System.Drawing.Point(5, 65);
            this.labelIp.Name = "labelIp";
            this.labelIp.Size = new System.Drawing.Size(70, 14);
            this.labelIp.TabIndex = 2;
            this.labelIp.Text = "labelControl2";
            // 
            // labelType
            // 
            this.labelType.Location = new System.Drawing.Point(5, 39);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(70, 14);
            this.labelType.TabIndex = 3;
            this.labelType.Text = "labelControl2";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelControl1.Controls.Add(this.uiCheckBox1);
            this.panelControl1.Controls.Add(this.labelName);
            this.panelControl1.Controls.Add(this.labelType);
            this.panelControl1.Controls.Add(this.uiLightStatus);
            this.panelControl1.Controls.Add(this.labelIp);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(207, 89);
            this.panelControl1.TabIndex = 4;
            // 
            // uiCheckBox1
            // 
            this.uiCheckBox1.CheckBoxSize = 30;
            this.uiCheckBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCheckBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiCheckBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiCheckBox1.Location = new System.Drawing.Point(155, 50);
            this.uiCheckBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCheckBox1.Name = "uiCheckBox1";
            this.uiCheckBox1.Size = new System.Drawing.Size(47, 36);
            this.uiCheckBox1.TabIndex = 4;
            this.uiCheckBox1.CheckedChanged += new System.EventHandler(this.uiCheckBox1_CheckedChanged);
            // 
            // S7DeviceUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "S7DeviceUc";
            this.Size = new System.Drawing.Size(207, 89);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILight uiLightStatus;
        private DevExpress.XtraEditors.LabelControl labelName;
        private DevExpress.XtraEditors.LabelControl labelIp;
        private DevExpress.XtraEditors.LabelControl labelType;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private Sunny.UI.UICheckBox uiCheckBox1;
    }
}
