namespace Online_examination_system.Liaobingquan
{
    partial class FrmCheckTest
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lab_subject = new System.Windows.Forms.Label();
            this.lab_name = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.But_CheckFinish = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 22F);
            this.label1.Location = new System.Drawing.Point(485, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "批改试卷";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14F);
            this.label2.Location = new System.Drawing.Point(285, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "科目：";
            // 
            // lab_subject
            // 
            this.lab_subject.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lab_subject.AutoSize = true;
            this.lab_subject.Font = new System.Drawing.Font("宋体", 14F);
            this.lab_subject.Location = new System.Drawing.Point(348, 61);
            this.lab_subject.Name = "lab_subject";
            this.lab_subject.Size = new System.Drawing.Size(0, 24);
            this.lab_subject.TabIndex = 1;
            // 
            // lab_name
            // 
            this.lab_name.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lab_name.AutoSize = true;
            this.lab_name.Font = new System.Drawing.Font("宋体", 14F);
            this.lab_name.Location = new System.Drawing.Point(890, 67);
            this.lab_name.Name = "lab_name";
            this.lab_name.Size = new System.Drawing.Size(0, 24);
            this.lab_name.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14F);
            this.label4.Location = new System.Drawing.Point(774, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "试卷名称：";
            // 
            // But_CheckFinish
            // 
            this.But_CheckFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.But_CheckFinish.Location = new System.Drawing.Point(1057, 643);
            this.But_CheckFinish.Name = "But_CheckFinish";
            this.But_CheckFinish.Size = new System.Drawing.Size(91, 44);
            this.But_CheckFinish.TabIndex = 4;
            this.But_CheckFinish.Text = "批改完成";
            this.But_CheckFinish.UseVisualStyleBackColor = true;
            this.But_CheckFinish.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmCheckTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1160, 702);
            this.Controls.Add(this.But_CheckFinish);
            this.Controls.Add(this.lab_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lab_subject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmCheckTest";
            this.Text = "批改试卷窗口";
            this.Load += new System.EventHandler(this.FrmCheckTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lab_subject;
        private System.Windows.Forms.Label lab_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button But_CheckFinish;
    }
}