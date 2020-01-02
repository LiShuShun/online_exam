namespace Online_examination_system.Lishushun
{
    partial class FindPwdFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindPwdFrm));
            this.idlab = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.admintxt = new System.Windows.Forms.TextBox();
            this.updatebtn = new System.Windows.Forms.Button();
            this.pwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Closebtn = new System.Windows.Forms.Button();
            this.minibtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // idlab
            // 
            this.idlab.AutoSize = true;
            this.idlab.BackColor = System.Drawing.Color.Transparent;
            this.idlab.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.idlab.ForeColor = System.Drawing.Color.Black;
            this.idlab.Location = new System.Drawing.Point(184, 149);
            this.idlab.Name = "idlab";
            this.idlab.Size = new System.Drawing.Size(0, 16);
            this.idlab.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(180, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "新密码：";
            // 
            // admintxt
            // 
            this.admintxt.Location = new System.Drawing.Point(285, 140);
            this.admintxt.Name = "admintxt";
            this.admintxt.Size = new System.Drawing.Size(190, 21);
            this.admintxt.TabIndex = 2;
            this.admintxt.TextChanged += new System.EventHandler(this.admintxt_TextChanged);
            // 
            // updatebtn
            // 
            this.updatebtn.BackColor = System.Drawing.Color.Transparent;
            this.updatebtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.updatebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updatebtn.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.updatebtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.updatebtn.Location = new System.Drawing.Point(285, 288);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Size = new System.Drawing.Size(190, 49);
            this.updatebtn.TabIndex = 3;
            this.updatebtn.Text = "确认修改";
            this.updatebtn.UseVisualStyleBackColor = false;
            this.updatebtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // pwd
            // 
            this.pwd.Location = new System.Drawing.Point(285, 201);
            this.pwd.Name = "pwd";
            this.pwd.Size = new System.Drawing.Size(190, 21);
            this.pwd.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(306, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 28);
            this.label1.TabIndex = 5;
            this.label1.Text = "修   改  密  码";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.Closebtn);
            this.panel1.Controls.Add(this.minibtn);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 43);
            this.panel1.TabIndex = 6;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::Online_examination_system.Properties.Resources.logo;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Location = new System.Drawing.Point(0, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(107, 40);
            this.panel2.TabIndex = 9;
            // 
            // Closebtn
            // 
            this.Closebtn.BackColor = System.Drawing.Color.Transparent;
            this.Closebtn.FlatAppearance.BorderSize = 0;
            this.Closebtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.Closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Closebtn.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Closebtn.ForeColor = System.Drawing.Color.Black;
            this.Closebtn.Location = new System.Drawing.Point(663, 0);
            this.Closebtn.Name = "Closebtn";
            this.Closebtn.Size = new System.Drawing.Size(37, 36);
            this.Closebtn.TabIndex = 3;
            this.Closebtn.Text = "×";
            this.Closebtn.UseVisualStyleBackColor = false;
            this.Closebtn.Click += new System.EventHandler(this.Closebtn_Click);
            // 
            // minibtn
            // 
            this.minibtn.BackColor = System.Drawing.Color.Transparent;
            this.minibtn.FlatAppearance.BorderSize = 0;
            this.minibtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minibtn.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.minibtn.ForeColor = System.Drawing.Color.Black;
            this.minibtn.Location = new System.Drawing.Point(619, 1);
            this.minibtn.Name = "minibtn";
            this.minibtn.Size = new System.Drawing.Size(37, 36);
            this.minibtn.TabIndex = 2;
            this.minibtn.Text = "-";
            this.minibtn.UseVisualStyleBackColor = false;
            this.minibtn.Click += new System.EventHandler(this.minibtn_Click);
            // 
            // FindPwdFrm
            // 
            this.AcceptButton = this.updatebtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(700, 442);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pwd);
            this.Controls.Add(this.updatebtn);
            this.Controls.Add(this.admintxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.idlab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FindPwdFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FindPwdFrm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label idlab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox admintxt;
        private System.Windows.Forms.Button updatebtn;
        private System.Windows.Forms.TextBox pwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Closebtn;
        private System.Windows.Forms.Button minibtn;
        private System.Windows.Forms.Panel panel2;
    }
}