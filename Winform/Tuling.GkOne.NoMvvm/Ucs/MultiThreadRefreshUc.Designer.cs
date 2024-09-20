namespace Tuling.GkOne.NoMvvm.Forms
{
    partial class MultiThreadRefreshUc
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEditTask = new DevExpress.XtraEditors.TextEdit();
            this.textEditThread = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTask.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditThread.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(24, 64);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(101, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Task 方式随机数：";
            // 
            // textEditTask
            // 
            this.textEditTask.Location = new System.Drawing.Point(158, 63);
            this.textEditTask.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textEditTask.Name = "textEditTask";
            this.textEditTask.Size = new System.Drawing.Size(102, 20);
            this.textEditTask.TabIndex = 4;
            // 
            // textEditThread
            // 
            this.textEditThread.Location = new System.Drawing.Point(158, 8);
            this.textEditThread.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textEditThread.Name = "textEditThread";
            this.textEditThread.Size = new System.Drawing.Size(102, 20);
            this.textEditThread.TabIndex = 7;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(24, 11);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(115, 14);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Thread 方式随机数：";
            // 
            // MultiThreadRefreshUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.textEditThread);
            this.Controls.Add(this.textEditTask);
            this.Controls.Add(this.labelControl1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MultiThreadRefreshUc";
            this.Size = new System.Drawing.Size(299, 107);
            ((System.ComponentModel.ISupportInitialize)(this.textEditTask.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditThread.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEditTask;
        private DevExpress.XtraEditors.TextEdit textEditThread;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}
