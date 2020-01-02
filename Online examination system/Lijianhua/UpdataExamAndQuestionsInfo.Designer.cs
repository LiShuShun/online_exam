namespace Online_examination_system.Lijianhua
{
    partial class UpdataExamAndQuestionsInfo
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
            this.UpdateExam_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.examName_txt = new System.Windows.Forms.TextBox();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.examSubject_com = new System.Windows.Forms.ComboBox();
            this.examTime_dtp = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.chooseQuestionsType_cob = new System.Windows.Forms.ComboBox();
            this.questions_dataView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.examObject_com = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.examID_txt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.questions_dataView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UpdateExam_btn
            // 
            this.UpdateExam_btn.Location = new System.Drawing.Point(943, 547);
            this.UpdateExam_btn.Name = "UpdateExam_btn";
            this.UpdateExam_btn.Size = new System.Drawing.Size(93, 38);
            this.UpdateExam_btn.TabIndex = 0;
            this.UpdateExam_btn.Text = "修改";
            this.UpdateExam_btn.UseVisualStyleBackColor = true;
            this.UpdateExam_btn.Click += new System.EventHandler(this.UpdateExam_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "考试名称：";
            // 
            // examName_txt
            // 
            this.examName_txt.Location = new System.Drawing.Point(189, 113);
            this.examName_txt.Name = "examName_txt";
            this.examName_txt.Size = new System.Drawing.Size(710, 25);
            this.examName_txt.TabIndex = 2;
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(943, 616);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(93, 38);
            this.cancel_btn.TabIndex = 0;
            this.cancel_btn.Text = "取消";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "考试科目：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "考试时间：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(105, 309);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "考试对象：";
            // 
            // examSubject_com
            // 
            this.examSubject_com.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.examSubject_com.FormattingEnabled = true;
            this.examSubject_com.Items.AddRange(new object[] {
            "Java",
            "C#",
            "JavaScript",
            "PHP",
            "Python",
            "C++",
            "GO",
            "HTML+CSS"});
            this.examSubject_com.Location = new System.Drawing.Point(189, 171);
            this.examSubject_com.Name = "examSubject_com";
            this.examSubject_com.Size = new System.Drawing.Size(710, 23);
            this.examSubject_com.TabIndex = 4;
            // 
            // examTime_dtp
            // 
            this.examTime_dtp.Location = new System.Drawing.Point(189, 242);
            this.examTime_dtp.Name = "examTime_dtp";
            this.examTime_dtp.Size = new System.Drawing.Size(710, 25);
            this.examTime_dtp.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(105, 370);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "选择试题：";
            // 
            // chooseQuestionsType_cob
            // 
            this.chooseQuestionsType_cob.FormattingEnabled = true;
            this.chooseQuestionsType_cob.Items.AddRange(new object[] {
            "全部",
            "选择题",
            "填空题",
            "解答题"});
            this.chooseQuestionsType_cob.Location = new System.Drawing.Point(189, 370);
            this.chooseQuestionsType_cob.Name = "chooseQuestionsType_cob";
            this.chooseQuestionsType_cob.Size = new System.Drawing.Size(121, 23);
            this.chooseQuestionsType_cob.TabIndex = 7;
            this.chooseQuestionsType_cob.Text = "全部";
            // 
            // questions_dataView
            // 
            this.questions_dataView.AllowUserToAddRows = false;
            this.questions_dataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.questions_dataView.BackgroundColor = System.Drawing.Color.White;
            this.questions_dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.questions_dataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.questions_dataView.Location = new System.Drawing.Point(189, 402);
            this.questions_dataView.Name = "questions_dataView";
            this.questions_dataView.RowTemplate.Height = 27;
            this.questions_dataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.questions_dataView.Size = new System.Drawing.Size(705, 252);
            this.questions_dataView.TabIndex = 8;
            // 
            // Column1
            // 
            this.Column1.FalseValue = "false";
            this.Column1.HeaderText = "选择";
            this.Column1.Name = "Column1";
            this.Column1.TrueValue = "true";
            // 
            // examObject_com
            // 
            this.examObject_com.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.examObject_com.FormattingEnabled = true;
            this.examObject_com.Items.AddRange(new object[] {
            "大一软件班",
            "大二软件班",
            "大三软件班"});
            this.examObject_com.Location = new System.Drawing.Point(189, 309);
            this.examObject_com.Name = "examObject_com";
            this.examObject_com.Size = new System.Drawing.Size(710, 23);
            this.examObject_com.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(105, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "考试ID：";
            // 
            // examID_txt
            // 
            this.examID_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.examID_txt.Location = new System.Drawing.Point(189, 58);
            this.examID_txt.Name = "examID_txt";
            this.examID_txt.ReadOnly = true;
            this.examID_txt.Size = new System.Drawing.Size(710, 25);
            this.examID_txt.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1132, 37);
            this.panel1.TabIndex = 9;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(1088, -7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 44);
            this.button1.TabIndex = 10;
            this.button1.Text = "×";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UpdataExamAndQuestionsInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1129, 682);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.questions_dataView);
            this.Controls.Add(this.chooseQuestionsType_cob);
            this.Controls.Add(this.examTime_dtp);
            this.Controls.Add(this.examObject_com);
            this.Controls.Add(this.examSubject_com);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.examID_txt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.examName_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.UpdateExam_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UpdataExamAndQuestionsInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdataExamAndQuestionsInfo";
            this.Load += new System.EventHandler(this.UpdataExamAndQuestionsInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.questions_dataView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UpdateExam_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox chooseQuestionsType_cob;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        public System.Windows.Forms.TextBox examName_txt;
        public System.Windows.Forms.ComboBox examSubject_com;
        public System.Windows.Forms.DateTimePicker examTime_dtp;
        public System.Windows.Forms.DataGridView questions_dataView;
        public System.Windows.Forms.ComboBox examObject_com;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox examID_txt;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
    }
}