namespace Online_examination_system.Lishushun
{
    partial class LoginFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginFrm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.admintxt = new System.Windows.Forms.TextBox();
            this.pwdtxt = new System.Windows.Forms.TextBox();
            this.combType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.log_panel = new System.Windows.Forms.Panel();
            this.FaceLogbtn = new System.Windows.Forms.Button();
            this.ForgetPwd = new System.Windows.Forms.Label();
            this.entry_btn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.idlab = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.color1panel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.nav_panel = new System.Windows.Forms.Panel();
            this.Closebtn = new System.Windows.Forms.Button();
            this.minibtn = new System.Windows.Forms.Button();
            this.log_panel.SuspendLayout();
            this.color1panel.SuspendLayout();
            this.nav_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::Online_examination_system.Properties.Resources.logo;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(123, 40);
            this.panel1.TabIndex = 8;
            // 
            // admintxt
            // 
            this.admintxt.Location = new System.Drawing.Point(201, 155);
            this.admintxt.Name = "admintxt";
            this.admintxt.Size = new System.Drawing.Size(184, 21);
            this.admintxt.TabIndex = 5;
            this.admintxt.TextChanged += new System.EventHandler(this.admintxt_TextChanged);
            this.admintxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.admintxt_KeyPress);
            // 
            // pwdtxt
            // 
            this.pwdtxt.Location = new System.Drawing.Point(201, 203);
            this.pwdtxt.Name = "pwdtxt";
            this.pwdtxt.PasswordChar = '*';
            this.pwdtxt.Size = new System.Drawing.Size(184, 21);
            this.pwdtxt.TabIndex = 4;
            this.pwdtxt.TextChanged += new System.EventHandler(this.pwdtxt_TextChanged);
            // 
            // combType
            // 
            this.combType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combType.FormattingEnabled = true;
            this.combType.Location = new System.Drawing.Point(201, 99);
            this.combType.Name = "combType";
            this.combType.Size = new System.Drawing.Size(184, 20);
            this.combType.TabIndex = 8;
            this.combType.SelectedIndexChanged += new System.EventHandler(this.combType_SelectedIndexChanged);
            this.combType.Click += new System.EventHandler(this.combType_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(40, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "用户类型 :";
            // 
            // log_panel
            // 
            this.log_panel.BackColor = System.Drawing.Color.Transparent;
            this.log_panel.Controls.Add(this.FaceLogbtn);
            this.log_panel.Controls.Add(this.ForgetPwd);
            this.log_panel.Controls.Add(this.entry_btn);
            this.log_panel.Controls.Add(this.label5);
            this.log_panel.Controls.Add(this.label4);
            this.log_panel.Controls.Add(this.combType);
            this.log_panel.Controls.Add(this.label1);
            this.log_panel.Controls.Add(this.label3);
            this.log_panel.Controls.Add(this.idlab);
            this.log_panel.Controls.Add(this.pwdtxt);
            this.log_panel.Controls.Add(this.admintxt);
            this.log_panel.Location = new System.Drawing.Point(251, 40);
            this.log_panel.Name = "log_panel";
            this.log_panel.Size = new System.Drawing.Size(450, 423);
            this.log_panel.TabIndex = 6;
            // 
            // FaceLogbtn
            // 
            this.FaceLogbtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.FaceLogbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FaceLogbtn.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FaceLogbtn.Location = new System.Drawing.Point(202, 307);
            this.FaceLogbtn.Name = "FaceLogbtn";
            this.FaceLogbtn.Size = new System.Drawing.Size(183, 37);
            this.FaceLogbtn.TabIndex = 14;
            this.FaceLogbtn.Text = "人脸扫描登录";
            this.FaceLogbtn.UseVisualStyleBackColor = true;
            this.FaceLogbtn.Click += new System.EventHandler(this.FaceLogbtn_Click);
            // 
            // ForgetPwd
            // 
            this.ForgetPwd.AutoSize = true;
            this.ForgetPwd.BackColor = System.Drawing.Color.Transparent;
            this.ForgetPwd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForgetPwd.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForgetPwd.ForeColor = System.Drawing.Color.Black;
            this.ForgetPwd.Location = new System.Drawing.Point(355, 357);
            this.ForgetPwd.Name = "ForgetPwd";
            this.ForgetPwd.Size = new System.Drawing.Size(89, 19);
            this.ForgetPwd.TabIndex = 12;
            this.ForgetPwd.Text = "忘记密码";
            this.ForgetPwd.Click += new System.EventHandler(this.ForgetPwd_Click);
            // 
            // entry_btn
            // 
            this.entry_btn.BackColor = System.Drawing.Color.Transparent;
            this.entry_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.entry_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.entry_btn.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.entry_btn.Location = new System.Drawing.Point(202, 254);
            this.entry_btn.Margin = new System.Windows.Forms.Padding(2);
            this.entry_btn.Name = "entry_btn";
            this.entry_btn.Size = new System.Drawing.Size(183, 37);
            this.entry_btn.TabIndex = 11;
            this.entry_btn.Text = "登  录";
            this.entry_btn.UseVisualStyleBackColor = false;
            this.entry_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(52, 358);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "注册用户";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(141, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "在线考试管理系统";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(40, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "密    码 :";
            // 
            // idlab
            // 
            this.idlab.AutoSize = true;
            this.idlab.BackColor = System.Drawing.Color.Transparent;
            this.idlab.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.idlab.ForeColor = System.Drawing.Color.Black;
            this.idlab.Location = new System.Drawing.Point(40, 160);
            this.idlab.Name = "idlab";
            this.idlab.Size = new System.Drawing.Size(0, 19);
            this.idlab.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(0, 0);
            this.panel2.TabIndex = 8;
            // 
            // color1panel
            // 
            this.color1panel.BackColor = System.Drawing.Color.Transparent;
            this.color1panel.Controls.Add(this.panel3);
            this.color1panel.Location = new System.Drawing.Point(0, 40);
            this.color1panel.Name = "color1panel";
            this.color1panel.Size = new System.Drawing.Size(249, 403);
            this.color1panel.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = global::Online_examination_system.Properties.Resources.logo;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel3.Location = new System.Drawing.Point(55, 32);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(284, 323);
            this.panel3.TabIndex = 8;
            // 
            // nav_panel
            // 
            this.nav_panel.BackColor = System.Drawing.Color.Transparent;
            this.nav_panel.Controls.Add(this.Closebtn);
            this.nav_panel.Controls.Add(this.minibtn);
            this.nav_panel.Location = new System.Drawing.Point(-1, 0);
            this.nav_panel.Name = "nav_panel";
            this.nav_panel.Size = new System.Drawing.Size(710, 40);
            this.nav_panel.TabIndex = 7;
            this.nav_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.nav_panel_Paint);
            this.nav_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.nav_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.nav_panel_MouseMove);
            // 
            // Closebtn
            // 
            this.Closebtn.BackColor = System.Drawing.Color.Transparent;
            this.Closebtn.FlatAppearance.BorderSize = 0;
            this.Closebtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.Closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Closebtn.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Closebtn.ForeColor = System.Drawing.Color.Black;
            this.Closebtn.Location = new System.Drawing.Point(665, -1);
            this.Closebtn.Name = "Closebtn";
            this.Closebtn.Size = new System.Drawing.Size(37, 36);
            this.Closebtn.TabIndex = 1;
            this.Closebtn.Text = "×";
            this.Closebtn.UseVisualStyleBackColor = false;
            this.Closebtn.Click += new System.EventHandler(this.Closebtn_Click);
            this.Closebtn.MouseEnter += new System.EventHandler(this.Closebtn_MouseEnter);
            this.Closebtn.MouseLeave += new System.EventHandler(this.Closebtn_MouseLeave);
            this.Closebtn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Closebtn_MouseMove);
            // 
            // minibtn
            // 
            this.minibtn.BackColor = System.Drawing.Color.Transparent;
            this.minibtn.FlatAppearance.BorderSize = 0;
            this.minibtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minibtn.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.minibtn.ForeColor = System.Drawing.Color.Black;
            this.minibtn.Location = new System.Drawing.Point(621, 0);
            this.minibtn.Name = "minibtn";
            this.minibtn.Size = new System.Drawing.Size(37, 36);
            this.minibtn.TabIndex = 0;
            this.minibtn.Text = "-";
            this.minibtn.UseVisualStyleBackColor = false;
            this.minibtn.Click += new System.EventHandler(this.minibtn_Click);
            this.minibtn.MouseEnter += new System.EventHandler(this.minibtn_MouseEnter);
            this.minibtn.MouseLeave += new System.EventHandler(this.minibtn_MouseLeave);
            this.minibtn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.minibtn_MouseMove);
            // 
            // LoginFrm
            // 
            this.AcceptButton = this.entry_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(700, 442);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.log_panel);
            this.Controls.Add(this.color1panel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.nav_panel);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "在线考试系统";
            this.Load += new System.EventHandler(this.LoginFrm_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LoginFrm_MouseMove);
            this.log_panel.ResumeLayout(false);
            this.log_panel.PerformLayout();
            this.color1panel.ResumeLayout(false);
            this.nav_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel log_panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label idlab;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel color1panel;
        public System.Windows.Forms.TextBox admintxt;
        private System.Windows.Forms.Panel nav_panel;
        private System.Windows.Forms.Button Closebtn;
        private System.Windows.Forms.Button minibtn;
        public System.Windows.Forms.TextBox pwdtxt;
        public System.Windows.Forms.ComboBox combType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button entry_btn;
        private System.Windows.Forms.Label ForgetPwd;
        private System.Windows.Forms.Button FaceLogbtn;
        private System.Windows.Forms.Panel panel3;
    }
}