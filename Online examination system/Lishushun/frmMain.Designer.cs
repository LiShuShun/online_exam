namespace Online_examination_system.Lishushun
{
    partial class frmMain
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
            this.mns = new System.Windows.Forms.MenuStrip();
            this.mnsIdentify = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsInput = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mns.SuspendLayout();
            this.SuspendLayout();
            // 
            // mns
            // 
            this.mns.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mns.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsIdentify,
            this.mnsInput,
            this.mnsExit});
            this.mns.Location = new System.Drawing.Point(0, 0);
            this.mns.Name = "mns";
            this.mns.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.mns.Size = new System.Drawing.Size(684, 25);
            this.mns.TabIndex = 2;
            this.mns.Text = "menuStrip1";
            // 
            // mnsIdentify
            // 
            this.mnsIdentify.Name = "mnsIdentify";
            this.mnsIdentify.Size = new System.Drawing.Size(68, 21);
            this.mnsIdentify.Text = "人脸识别";
            this.mnsIdentify.Click += new System.EventHandler(this.mnsIdentify_Click);
            // 
            // mnsInput
            // 
            this.mnsInput.Name = "mnsInput";
            this.mnsInput.Size = new System.Drawing.Size(68, 21);
            this.mnsInput.Text = "人脸录入";
            this.mnsInput.Click += new System.EventHandler(this.mnsInput_Click);
            // 
            // mnsExit
            // 
            this.mnsExit.Name = "mnsExit";
            this.mnsExit.Size = new System.Drawing.Size(44, 21);
            this.mnsExit.Text = "退出";
            this.mnsExit.Click += new System.EventHandler(this.mnsExit_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 403);
            this.Controls.Add(this.mns);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.mns.ResumeLayout(false);
            this.mns.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mns;
        private System.Windows.Forms.ToolStripMenuItem mnsIdentify;
        private System.Windows.Forms.ToolStripMenuItem mnsInput;
        private System.Windows.Forms.ToolStripMenuItem mnsExit;
    }
}