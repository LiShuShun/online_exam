namespace Online_examination_system.Lishushun
{
    partial class frmFaceIdentify
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
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.labGroup = new System.Windows.Forms.Label();
            this.txtMatchingScore = new System.Windows.Forms.TextBox();
            this.labMatchingScore = new System.Windows.Forms.Label();
            this.txtUid = new System.Windows.Forms.TextBox();
            this.labUid = new System.Windows.Forms.Label();
            this.btnIdentify = new System.Windows.Forms.Button();
            this.vspIdentify = new AForge.Controls.VideoSourcePlayer();
            this.SuspendLayout();
            // 
            // txtGroup
            // 
            this.txtGroup.Location = new System.Drawing.Point(564, 128);
            this.txtGroup.Margin = new System.Windows.Forms.Padding(2);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(92, 21);
            this.txtGroup.TabIndex = 17;
            this.txtGroup.Visible = false;
            // 
            // labGroup
            // 
            this.labGroup.AutoSize = true;
            this.labGroup.Location = new System.Drawing.Point(500, 130);
            this.labGroup.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labGroup.Name = "labGroup";
            this.labGroup.Size = new System.Drawing.Size(53, 12);
            this.labGroup.TabIndex = 16;
            this.labGroup.Text = "用户组：";
            this.labGroup.Visible = false;
            // 
            // txtMatchingScore
            // 
            this.txtMatchingScore.Location = new System.Drawing.Point(564, 245);
            this.txtMatchingScore.Margin = new System.Windows.Forms.Padding(2);
            this.txtMatchingScore.Name = "txtMatchingScore";
            this.txtMatchingScore.Size = new System.Drawing.Size(92, 21);
            this.txtMatchingScore.TabIndex = 15;
            this.txtMatchingScore.Visible = false;
            // 
            // labMatchingScore
            // 
            this.labMatchingScore.AutoSize = true;
            this.labMatchingScore.Location = new System.Drawing.Point(500, 248);
            this.labMatchingScore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labMatchingScore.Name = "labMatchingScore";
            this.labMatchingScore.Size = new System.Drawing.Size(53, 12);
            this.labMatchingScore.TabIndex = 14;
            this.labMatchingScore.Text = "匹配度：";
            this.labMatchingScore.Visible = false;
            // 
            // txtUid
            // 
            this.txtUid.Location = new System.Drawing.Point(564, 184);
            this.txtUid.Margin = new System.Windows.Forms.Padding(2);
            this.txtUid.Name = "txtUid";
            this.txtUid.Size = new System.Drawing.Size(92, 21);
            this.txtUid.TabIndex = 13;
            this.txtUid.Visible = false;
            // 
            // labUid
            // 
            this.labUid.AutoSize = true;
            this.labUid.Location = new System.Drawing.Point(500, 187);
            this.labUid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labUid.Name = "labUid";
            this.labUid.Size = new System.Drawing.Size(53, 12);
            this.labUid.TabIndex = 12;
            this.labUid.Text = "用户名：";
            this.labUid.Visible = false;
            // 
            // btnIdentify
            // 
            this.btnIdentify.Location = new System.Drawing.Point(526, 296);
            this.btnIdentify.Margin = new System.Windows.Forms.Padding(2);
            this.btnIdentify.Name = "btnIdentify";
            this.btnIdentify.Size = new System.Drawing.Size(91, 35);
            this.btnIdentify.TabIndex = 11;
            this.btnIdentify.Text = "识别";
            this.btnIdentify.UseVisualStyleBackColor = true;
            this.btnIdentify.Visible = false;
            this.btnIdentify.Click += new System.EventHandler(this.btnIdentify_Click);
            // 
            // vspIdentify
            // 
            this.vspIdentify.Location = new System.Drawing.Point(120, 55);
            this.vspIdentify.Margin = new System.Windows.Forms.Padding(2);
            this.vspIdentify.Name = "vspIdentify";
            this.vspIdentify.Size = new System.Drawing.Size(428, 326);
            this.vspIdentify.TabIndex = 10;
            this.vspIdentify.Text = "videoSourcePlayer1";
            this.vspIdentify.VideoSource = null;
            this.vspIdentify.Click += new System.EventHandler(this.vspIdentify_Click);
            // 
            // frmFaceIdentify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 403);
            this.Controls.Add(this.txtGroup);
            this.Controls.Add(this.labGroup);
            this.Controls.Add(this.txtMatchingScore);
            this.Controls.Add(this.labMatchingScore);
            this.Controls.Add(this.txtUid);
            this.Controls.Add(this.labUid);
            this.Controls.Add(this.btnIdentify);
            this.Controls.Add(this.vspIdentify);
            this.Name = "frmFaceIdentify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFaceIdentify";
            this.Load += new System.EventHandler(this.frmFaceIdentify_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.Label labGroup;
        private System.Windows.Forms.TextBox txtMatchingScore;
        private System.Windows.Forms.Label labMatchingScore;
        private System.Windows.Forms.TextBox txtUid;
        private System.Windows.Forms.Label labUid;
        private System.Windows.Forms.Button btnIdentify;
        private AForge.Controls.VideoSourcePlayer vspIdentify;
    }
}