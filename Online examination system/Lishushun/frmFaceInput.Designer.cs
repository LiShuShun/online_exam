namespace Online_examination_system.Lishushun
{
    partial class frmFaceInput
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
            this.labHint = new System.Windows.Forms.Label();
            this.btnInput = new System.Windows.Forms.Button();
            this.txtUid = new System.Windows.Forms.TextBox();
            this.labUid = new System.Windows.Forms.Label();
            this.vspInput = new AForge.Controls.VideoSourcePlayer();
            this.SuspendLayout();
            // 
            // labHint
            // 
            this.labHint.AutoSize = true;
            this.labHint.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labHint.Location = new System.Drawing.Point(509, 176);
            this.labHint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labHint.Name = "labHint";
            this.labHint.Size = new System.Drawing.Size(143, 12);
            this.labHint.TabIndex = 14;
            this.labHint.Text = "输入对应ID ，只能是数字";
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(515, 206);
            this.btnInput.Margin = new System.Windows.Forms.Padding(2);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(91, 35);
            this.btnInput.TabIndex = 13;
            this.btnInput.Text = "录入";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // txtUid
            // 
            this.txtUid.Location = new System.Drawing.Point(549, 150);
            this.txtUid.Margin = new System.Windows.Forms.Padding(2);
            this.txtUid.Name = "txtUid";
            this.txtUid.Size = new System.Drawing.Size(92, 21);
            this.txtUid.TabIndex = 12;
            this.txtUid.TextChanged += new System.EventHandler(this.txtUid_TextChanged);
            // 
            // labUid
            // 
            this.labUid.AutoSize = true;
            this.labUid.Location = new System.Drawing.Point(496, 153);
            this.labUid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labUid.Name = "labUid";
            this.labUid.Size = new System.Drawing.Size(23, 12);
            this.labUid.TabIndex = 11;
            this.labUid.Text = "ID:";
            // 
            // vspInput
            // 
            this.vspInput.Location = new System.Drawing.Point(46, 50);
            this.vspInput.Margin = new System.Windows.Forms.Padding(2);
            this.vspInput.Name = "vspInput";
            this.vspInput.Size = new System.Drawing.Size(424, 318);
            this.vspInput.TabIndex = 10;
            this.vspInput.Text = "videoSourcePlayer1";
            this.vspInput.VideoSource = null;
            this.vspInput.Click += new System.EventHandler(this.vspInput_Click);
            // 
            // frmFaceInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 403);
            this.Controls.Add(this.labHint);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.txtUid);
            this.Controls.Add(this.labUid);
            this.Controls.Add(this.vspInput);
            this.Name = "frmFaceInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFaceInput";
            this.Load += new System.EventHandler(this.frmFaceInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labHint;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.TextBox txtUid;
        private System.Windows.Forms.Label labUid;
        private AForge.Controls.VideoSourcePlayer vspInput;
    }
}