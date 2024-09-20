namespace Tuling.GkOne.NoMvvm.Forms
{
    partial class CatchForm
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
            this.SuspendLayout();
            // 
            // CatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 360);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CatchForm";
            this.Text = "CatchForm";
            this.Load += new System.EventHandler(this.CatchForm_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CatchForm_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CatchForm_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CatchForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CatchForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CatchForm_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}