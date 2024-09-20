namespace ScottPlot.Demo.WinForms
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            cookbookButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            versionLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            richTextBox1 = new System.Windows.Forms.RichTextBox();
            panel1 = new System.Windows.Forms.Panel();
            demoListControl1 = new DemoListControl();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // cookbookButton
            // 
            cookbookButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            cookbookButton.BackColor = System.Drawing.Color.FromArgb(235, 240, 161);
            cookbookButton.Location = new System.Drawing.Point(13, 41);
            cookbookButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            cookbookButton.Name = "cookbookButton";
            cookbookButton.Size = new System.Drawing.Size(163, 127);
            cookbookButton.TabIndex = 0;
            cookbookButton.Text = "Launch ScottPlot Cookbook";
            cookbookButton.UseVisualStyleBackColor = false;
            cookbookButton.Click += CookbookButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            label1.Location = new System.Drawing.Point(26, 19);
            label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(276, 42);
            label1.TabIndex = 2;
            label1.Text = "ScottPlot Demo";
            // 
            // versionLabel
            // 
            versionLabel.Location = new System.Drawing.Point(30, 73);
            versionLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            versionLabel.Name = "versionLabel";
            versionLabel.Size = new System.Drawing.Size(208, 54);
            versionLabel.TabIndex = 3;
            versionLabel.Text = "version 9.9.99";
            versionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(191, 41);
            label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(256, 127);
            label3.TabIndex = 5;
            label3.Text = "Simple examples that demonstrate the primary features of ScottPlot";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cookbookButton);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new System.Drawing.Point(22, 134);
            groupBox1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            groupBox1.Size = new System.Drawing.Size(461, 183);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "ScottPlot Cookbook";
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            richTextBox1.Location = new System.Drawing.Point(35, 362);
            richTextBox1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new System.Drawing.Size(446, 448);
            richTextBox1.TabIndex = 30;
            richTextBox1.Text = "These examples demonstrate advanced capabilities of the Windows Forms ScottPlot control (FormsPlot)\n\nSource code for this application can be found on https://ScottPlot.NET/demo";
            richTextBox1.Click += WebsiteLink_Click;
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.Controls.Add(demoListControl1);
            panel1.Location = new System.Drawing.Point(503, 0);
            panel1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(938, 986);
            panel1.TabIndex = 8;
            // 
            // demoListControl1
            // 
            demoListControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            demoListControl1.Location = new System.Drawing.Point(9, 19);
            demoListControl1.Margin = new System.Windows.Forms.Padding(9, 6, 9, 6);
            demoListControl1.Name = "demoListControl1";
            demoListControl1.Size = new System.Drawing.Size(919, 952);
            demoListControl1.TabIndex = 0;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 28F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1439, 986);
            Controls.Add(richTextBox1);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Controls.Add(versionLabel);
            Controls.Add(label1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            Name = "FormMain";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ScottPlot Demo (WinForms)";
            groupBox1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button cookbookButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel panel1;
        private DemoListControl demoListControl1;
    }
}