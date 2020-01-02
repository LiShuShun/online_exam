namespace Online_examination_system.Lishushun
{
    partial class RegisterFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterFrm));
            this.stu_panel = new System.Windows.Forms.Panel();
            this.departmenttxt = new System.Windows.Forms.ComboBox();
            this.majortxt = new System.Windows.Forms.ComboBox();
            this.classtxt = new System.Windows.Forms.ComboBox();
            this.notetxt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.agetxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nametxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.admintxt1 = new System.Windows.Forms.TextBox();
            this.pwdtxt2 = new System.Windows.Forms.TextBox();
            this.stu_registerbtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pwdtxt1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tea_panel = new System.Windows.Forms.Panel();
            this.note2 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.departmenttxt2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.majortxt2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.agetxt2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.nametxt2 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.admintxt = new System.Windows.Forms.TextBox();
            this.pwd2txt = new System.Windows.Forms.TextBox();
            this.tea_registerbtn = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.pwdtxt = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.teacherrad = new System.Windows.Forms.RadioButton();
            this.studentrad = new System.Windows.Forms.RadioButton();
            this.minibtn = new System.Windows.Forms.Button();
            this.Closebtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nav_panel = new System.Windows.Forms.Panel();
            this.stu_panel.SuspendLayout();
            this.tea_panel.SuspendLayout();
            this.nav_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // stu_panel
            // 
            this.stu_panel.BackColor = System.Drawing.Color.Transparent;
            this.stu_panel.Controls.Add(this.departmenttxt);
            this.stu_panel.Controls.Add(this.majortxt);
            this.stu_panel.Controls.Add(this.classtxt);
            this.stu_panel.Controls.Add(this.notetxt);
            this.stu_panel.Controls.Add(this.label13);
            this.stu_panel.Controls.Add(this.label9);
            this.stu_panel.Controls.Add(this.label4);
            this.stu_panel.Controls.Add(this.agetxt);
            this.stu_panel.Controls.Add(this.label3);
            this.stu_panel.Controls.Add(this.label2);
            this.stu_panel.Controls.Add(this.nametxt);
            this.stu_panel.Controls.Add(this.label1);
            this.stu_panel.Controls.Add(this.admintxt1);
            this.stu_panel.Controls.Add(this.pwdtxt2);
            this.stu_panel.Controls.Add(this.stu_registerbtn);
            this.stu_panel.Controls.Add(this.label8);
            this.stu_panel.Controls.Add(this.label6);
            this.stu_panel.Controls.Add(this.pwdtxt1);
            this.stu_panel.Controls.Add(this.label7);
            this.stu_panel.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.stu_panel.Location = new System.Drawing.Point(442, 121);
            this.stu_panel.Name = "stu_panel";
            this.stu_panel.Size = new System.Drawing.Size(386, 331);
            this.stu_panel.TabIndex = 10;
            // 
            // departmenttxt
            // 
            this.departmenttxt.FormattingEnabled = true;
            this.departmenttxt.Items.AddRange(new object[] {
            "信息工程系"});
            this.departmenttxt.Location = new System.Drawing.Point(141, 236);
            this.departmenttxt.Name = "departmenttxt";
            this.departmenttxt.Size = new System.Drawing.Size(160, 20);
            this.departmenttxt.TabIndex = 29;
            // 
            // majortxt
            // 
            this.majortxt.FormattingEnabled = true;
            this.majortxt.Items.AddRange(new object[] {
            "软件工程"});
            this.majortxt.Location = new System.Drawing.Point(141, 205);
            this.majortxt.Name = "majortxt";
            this.majortxt.Size = new System.Drawing.Size(160, 20);
            this.majortxt.TabIndex = 28;
            // 
            // classtxt
            // 
            this.classtxt.FormattingEnabled = true;
            this.classtxt.Items.AddRange(new object[] {
            "软件技术1班",
            "软件技术2班",
            "软件技术3班",
            "软件技术4班"});
            this.classtxt.Location = new System.Drawing.Point(141, 147);
            this.classtxt.Name = "classtxt";
            this.classtxt.Size = new System.Drawing.Size(160, 20);
            this.classtxt.TabIndex = 27;
            this.classtxt.SelectedIndexChanged += new System.EventHandler(this.classtxt_SelectedIndexChanged);
            // 
            // notetxt
            // 
            this.notetxt.Location = new System.Drawing.Point(141, 267);
            this.notetxt.Name = "notetxt";
            this.notetxt.Size = new System.Drawing.Size(160, 21);
            this.notetxt.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(60, 268);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 20);
            this.label13.TabIndex = 25;
            this.label13.Text = "备注";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(60, 237);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 20);
            this.label9.TabIndex = 23;
            this.label9.Text = "系别";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(60, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "专业";
            // 
            // agetxt
            // 
            this.agetxt.Location = new System.Drawing.Point(141, 178);
            this.agetxt.Name = "agetxt";
            this.agetxt.Size = new System.Drawing.Size(160, 21);
            this.agetxt.TabIndex = 20;
            this.agetxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.agetxt_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(60, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "年龄";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(60, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "班级";
            // 
            // nametxt
            // 
            this.nametxt.Location = new System.Drawing.Point(141, 118);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(160, 21);
            this.nametxt.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(60, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "姓名";
            // 
            // admintxt1
            // 
            this.admintxt1.Location = new System.Drawing.Point(141, 20);
            this.admintxt1.Name = "admintxt1";
            this.admintxt1.ReadOnly = true;
            this.admintxt1.Size = new System.Drawing.Size(160, 21);
            this.admintxt1.TabIndex = 11;
            this.admintxt1.TextChanged += new System.EventHandler(this.admintxt1_TextChanged);
            // 
            // pwdtxt2
            // 
            this.pwdtxt2.Location = new System.Drawing.Point(141, 85);
            this.pwdtxt2.Name = "pwdtxt2";
            this.pwdtxt2.PasswordChar = '*';
            this.pwdtxt2.Size = new System.Drawing.Size(160, 21);
            this.pwdtxt2.TabIndex = 13;
            // 
            // stu_registerbtn
            // 
            this.stu_registerbtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.stu_registerbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stu_registerbtn.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stu_registerbtn.ForeColor = System.Drawing.Color.Black;
            this.stu_registerbtn.Location = new System.Drawing.Point(141, 300);
            this.stu_registerbtn.Name = "stu_registerbtn";
            this.stu_registerbtn.Size = new System.Drawing.Size(160, 36);
            this.stu_registerbtn.TabIndex = 14;
            this.stu_registerbtn.Text = "注册";
            this.stu_registerbtn.UseVisualStyleBackColor = true;
            this.stu_registerbtn.Click += new System.EventHandler(this.registerbtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(60, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "账号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(20, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "确认密码";
            // 
            // pwdtxt1
            // 
            this.pwdtxt1.Location = new System.Drawing.Point(141, 50);
            this.pwdtxt1.Name = "pwdtxt1";
            this.pwdtxt1.PasswordChar = '*';
            this.pwdtxt1.Size = new System.Drawing.Size(160, 21);
            this.pwdtxt1.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(60, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "密码";
            // 
            // tea_panel
            // 
            this.tea_panel.BackColor = System.Drawing.Color.Transparent;
            this.tea_panel.Controls.Add(this.note2);
            this.tea_panel.Controls.Add(this.label18);
            this.tea_panel.Controls.Add(this.departmenttxt2);
            this.tea_panel.Controls.Add(this.label10);
            this.tea_panel.Controls.Add(this.majortxt2);
            this.tea_panel.Controls.Add(this.label11);
            this.tea_panel.Controls.Add(this.agetxt2);
            this.tea_panel.Controls.Add(this.label12);
            this.tea_panel.Controls.Add(this.nametxt2);
            this.tea_panel.Controls.Add(this.label14);
            this.tea_panel.Controls.Add(this.admintxt);
            this.tea_panel.Controls.Add(this.pwd2txt);
            this.tea_panel.Controls.Add(this.tea_registerbtn);
            this.tea_panel.Controls.Add(this.label15);
            this.tea_panel.Controls.Add(this.label16);
            this.tea_panel.Controls.Add(this.pwdtxt);
            this.tea_panel.Controls.Add(this.label17);
            this.tea_panel.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.tea_panel.Location = new System.Drawing.Point(40, 119);
            this.tea_panel.Name = "tea_panel";
            this.tea_panel.Size = new System.Drawing.Size(386, 333);
            this.tea_panel.TabIndex = 25;
            this.tea_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.tea_panel_Paint);
            // 
            // note2
            // 
            this.note2.Location = new System.Drawing.Point(142, 250);
            this.note2.Name = "note2";
            this.note2.Size = new System.Drawing.Size(160, 21);
            this.note2.TabIndex = 26;
            this.note2.TextChanged += new System.EventHandler(this.note2_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(72, 253);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 19);
            this.label18.TabIndex = 25;
            this.label18.Text = "备注";
            this.label18.Click += new System.EventHandler(this.label18_Click);
            // 
            // departmenttxt2
            // 
            this.departmenttxt2.Location = new System.Drawing.Point(142, 220);
            this.departmenttxt2.Name = "departmenttxt2";
            this.departmenttxt2.Size = new System.Drawing.Size(160, 21);
            this.departmenttxt2.TabIndex = 24;
            this.departmenttxt2.TextChanged += new System.EventHandler(this.departmenttxt2_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(72, 222);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 19);
            this.label10.TabIndex = 23;
            this.label10.Text = "系别";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // majortxt2
            // 
            this.majortxt2.Location = new System.Drawing.Point(142, 189);
            this.majortxt2.Name = "majortxt2";
            this.majortxt2.Size = new System.Drawing.Size(160, 21);
            this.majortxt2.TabIndex = 22;
            this.majortxt2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(72, 190);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 19);
            this.label11.TabIndex = 21;
            this.label11.Text = "专业";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // agetxt2
            // 
            this.agetxt2.Location = new System.Drawing.Point(142, 156);
            this.agetxt2.Name = "agetxt2";
            this.agetxt2.Size = new System.Drawing.Size(160, 21);
            this.agetxt2.TabIndex = 20;
            this.agetxt2.TextChanged += new System.EventHandler(this.agetxt2_TextChanged);
            this.agetxt2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.agetxt2_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(72, 158);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 19);
            this.label12.TabIndex = 19;
            this.label12.Text = "年龄";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // nametxt2
            // 
            this.nametxt2.Location = new System.Drawing.Point(142, 124);
            this.nametxt2.Name = "nametxt2";
            this.nametxt2.Size = new System.Drawing.Size(160, 21);
            this.nametxt2.TabIndex = 16;
            this.nametxt2.TextChanged += new System.EventHandler(this.nametxt2_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(72, 124);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 19);
            this.label14.TabIndex = 15;
            this.label14.Text = "姓名";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // admintxt
            // 
            this.admintxt.BackColor = System.Drawing.SystemColors.Window;
            this.admintxt.Location = new System.Drawing.Point(142, 19);
            this.admintxt.Name = "admintxt";
            this.admintxt.ReadOnly = true;
            this.admintxt.Size = new System.Drawing.Size(160, 21);
            this.admintxt.TabIndex = 11;
            this.admintxt.TextChanged += new System.EventHandler(this.admintxt_TextChanged);
            // 
            // pwd2txt
            // 
            this.pwd2txt.Location = new System.Drawing.Point(142, 87);
            this.pwd2txt.Name = "pwd2txt";
            this.pwd2txt.PasswordChar = '*';
            this.pwd2txt.Size = new System.Drawing.Size(160, 21);
            this.pwd2txt.TabIndex = 13;
            this.pwd2txt.TextChanged += new System.EventHandler(this.pwd2txt_TextChanged);
            // 
            // tea_registerbtn
            // 
            this.tea_registerbtn.BackColor = System.Drawing.Color.Transparent;
            this.tea_registerbtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.tea_registerbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tea_registerbtn.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tea_registerbtn.ForeColor = System.Drawing.Color.Black;
            this.tea_registerbtn.Location = new System.Drawing.Point(142, 289);
            this.tea_registerbtn.Name = "tea_registerbtn";
            this.tea_registerbtn.Size = new System.Drawing.Size(160, 36);
            this.tea_registerbtn.TabIndex = 14;
            this.tea_registerbtn.Text = "注册";
            this.tea_registerbtn.UseVisualStyleBackColor = false;
            this.tea_registerbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(72, 28);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 19);
            this.label15.TabIndex = 8;
            this.label15.Text = "账号";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(35, 91);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 19);
            this.label16.TabIndex = 10;
            this.label16.Text = "确认密码";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // pwdtxt
            // 
            this.pwdtxt.Location = new System.Drawing.Point(142, 50);
            this.pwdtxt.Name = "pwdtxt";
            this.pwdtxt.PasswordChar = '*';
            this.pwdtxt.Size = new System.Drawing.Size(160, 21);
            this.pwdtxt.TabIndex = 12;
            this.pwdtxt.TextChanged += new System.EventHandler(this.pwdtxt_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(72, 59);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 19);
            this.label17.TabIndex = 9;
            this.label17.Text = "密码";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(418, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(210, 24);
            this.label5.TabIndex = 15;
            this.label5.Text = "考试系统账号注册";
            // 
            // teacherrad
            // 
            this.teacherrad.AutoSize = true;
            this.teacherrad.BackColor = System.Drawing.Color.Transparent;
            this.teacherrad.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.teacherrad.ForeColor = System.Drawing.Color.Black;
            this.teacherrad.Location = new System.Drawing.Point(431, 80);
            this.teacherrad.Name = "teacherrad";
            this.teacherrad.Size = new System.Drawing.Size(69, 24);
            this.teacherrad.TabIndex = 16;
            this.teacherrad.Text = "教师";
            this.teacherrad.UseVisualStyleBackColor = false;
            this.teacherrad.CheckedChanged += new System.EventHandler(this.teacherrad_CheckedChanged);
            // 
            // studentrad
            // 
            this.studentrad.AutoSize = true;
            this.studentrad.BackColor = System.Drawing.Color.Transparent;
            this.studentrad.Checked = true;
            this.studentrad.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.studentrad.ForeColor = System.Drawing.Color.Black;
            this.studentrad.Location = new System.Drawing.Point(548, 80);
            this.studentrad.Name = "studentrad";
            this.studentrad.Size = new System.Drawing.Size(69, 24);
            this.studentrad.TabIndex = 17;
            this.studentrad.TabStop = true;
            this.studentrad.Text = "学生";
            this.studentrad.UseVisualStyleBackColor = false;
            this.studentrad.CheckedChanged += new System.EventHandler(this.studentrad_CheckedChanged);
            // 
            // minibtn
            // 
            this.minibtn.FlatAppearance.BorderSize = 0;
            this.minibtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minibtn.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.minibtn.ForeColor = System.Drawing.Color.Black;
            this.minibtn.Location = new System.Drawing.Point(622, 1);
            this.minibtn.Name = "minibtn";
            this.minibtn.Size = new System.Drawing.Size(37, 36);
            this.minibtn.TabIndex = 0;
            this.minibtn.Text = "-";
            this.minibtn.UseVisualStyleBackColor = true;
            this.minibtn.Click += new System.EventHandler(this.minibtn_Click);
            this.minibtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.minibtn_MouseDown);
            this.minibtn.MouseEnter += new System.EventHandler(this.minibtn_MouseEnter);
            this.minibtn.MouseLeave += new System.EventHandler(this.minibtn_MouseLeave);
            // 
            // Closebtn
            // 
            this.Closebtn.FlatAppearance.BorderSize = 0;
            this.Closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Closebtn.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Closebtn.ForeColor = System.Drawing.Color.Black;
            this.Closebtn.Location = new System.Drawing.Point(666, 1);
            this.Closebtn.Name = "Closebtn";
            this.Closebtn.Size = new System.Drawing.Size(37, 36);
            this.Closebtn.TabIndex = 1;
            this.Closebtn.Text = "x";
            this.Closebtn.UseVisualStyleBackColor = true;
            this.Closebtn.Click += new System.EventHandler(this.Closebtn_Click);
            this.Closebtn.MouseEnter += new System.EventHandler(this.Closebtn_MouseEnter);
            this.Closebtn.MouseLeave += new System.EventHandler(this.Closebtn_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Online_examination_system.Properties.Resources.logo;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(1, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(123, 35);
            this.panel1.TabIndex = 8;
            // 
            // nav_panel
            // 
            this.nav_panel.BackColor = System.Drawing.Color.Transparent;
            this.nav_panel.Controls.Add(this.panel1);
            this.nav_panel.Controls.Add(this.Closebtn);
            this.nav_panel.Controls.Add(this.minibtn);
            this.nav_panel.Location = new System.Drawing.Point(-3, -2);
            this.nav_panel.Name = "nav_panel";
            this.nav_panel.Size = new System.Drawing.Size(710, 40);
            this.nav_panel.TabIndex = 11;
            this.nav_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.nav_panel_Paint);
            this.nav_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.nav_panel_MouseDown);
            this.nav_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.nav_panel_MouseMove);
            // 
            // RegisterFrm
            // 
            this.AcceptButton = this.stu_registerbtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(700, 442);
            this.Controls.Add(this.tea_panel);
            this.Controls.Add(this.studentrad);
            this.Controls.Add(this.teacherrad);
            this.Controls.Add(this.nav_panel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.stu_panel);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegisterFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterFrm";
            this.stu_panel.ResumeLayout(false);
            this.stu_panel.PerformLayout();
            this.tea_panel.ResumeLayout(false);
            this.tea_panel.PerformLayout();
            this.nav_panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel stu_panel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox admintxt1;
        private System.Windows.Forms.TextBox pwdtxt2;
        private System.Windows.Forms.Button stu_registerbtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox pwdtxt1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox agetxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nametxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton teacherrad;
        private System.Windows.Forms.RadioButton studentrad;
        private System.Windows.Forms.Panel tea_panel;
        private System.Windows.Forms.TextBox departmenttxt2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox majortxt2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox agetxt2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox nametxt2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox admintxt;
        private System.Windows.Forms.TextBox pwd2txt;
        private System.Windows.Forms.Button tea_registerbtn;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox pwdtxt;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button minibtn;
        private System.Windows.Forms.Button Closebtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel nav_panel;
        private System.Windows.Forms.TextBox notetxt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox note2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox classtxt;
        private System.Windows.Forms.ComboBox majortxt;
        private System.Windows.Forms.ComboBox departmenttxt;
    }
}