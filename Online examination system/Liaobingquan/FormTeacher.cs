using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace Online_examination_system.Liaobingquan
{



    public partial class FormTeacher : Form
    {
        DBset db = new DBset();
        Teacher_list t;
        TheQuestionBank q;
        string WrongAnswer = "";
        string Answer = "";

        public FormTeacher()
        {
            x = this.Width;

            y = this.Height;

            setTag(this);
            InitializeComponent();


        }
        int isOK = 1;//矢量变量
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int IParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        /// <summary>
        /// 给要拖动的控件添加mouseDown事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
       public void FormTeacher_Load(object sender, EventArgs e)
        {
            t = db.SelfInfo(Pass.passData);

            button2.BackgroundImage = Online_examination_system.Properties.Resources.QQ图片201912091545612;
            string lastname = t.name.ToString();
            Lab_Prompt.Text = "尊敬的" + lastname.Substring(0, 1) + "老师，欢迎使用本系统！！";
            DGV_Test.DataSource = db.TestManger().Tables["Examination_list"];
            DGV_Topic.DataSource = db.TopicManger().Tables["TheQuestionBank"];
            DGV_Result.DataSource = db.TestManger().Tables["Examination_list"];
            DGV_CheckTest.DataSource = db.CheckTestManger().Tables["EndExamSocre"];
            this.Com_Subject.DataSource = db.Subject().Tables["class_schedule"];
            this.Com_Subject.DisplayMember = "coursename";
            





        }
        /// <summary>
        /// 退出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// 最小化按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private float x;//定义当前窗体的宽度

        private float y;//定义当前窗体的高度

        private void setTag(Control cons)
        {

            foreach (Control con in cons.Controls)
            {

                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;

                if (con.Controls.Count > 0)
                {

                    setTag(con);


                }

            }

        }



        /// <summary>
        /// 最大化按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button2_Click_1(object sender, EventArgs e)
        {

            if (isOK % 2 == 1)
            {
                this.WindowState = FormWindowState.Maximized;
                button2.BackgroundImage = Online_examination_system.Properties.Resources.QQ图片20191209150209;

            }
            if (isOK % 2 == 0)
            {
                this.WindowState = FormWindowState.Normal;

                button2.BackgroundImage = Online_examination_system.Properties.Resources.QQ图片201912091545612;


            }
            isOK++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Lab_Prompt.Location = new System.Drawing.Point(Lab_Prompt.Location.X + 1, Lab_Prompt.Location.Y);
            if (Lab_Prompt.Location.X > this.Width / 2 + 400)
            {
                timer1.Enabled = false;
                timer2.Enabled = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Lab_Prompt.Location = new System.Drawing.Point(Lab_Prompt.Location.X - 1, Lab_Prompt.Location.Y);
            if (Lab_Prompt.Location.X < this.Width / 2 - 200)
            {
                timer1.Enabled = true;
                timer2.Enabled = false;
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {

            DGV_Test.DataSource = db.TestSerch(txt_SerchTest.Text).Tables["Examination_list"];

        }
        //返回按钮
        private void but_Back_Click(object sender, EventArgs e)
        {
            DGV_Test.DataSource = db.TestManger().Tables["Examination_list"];
            pal_DGv.Visible = true;
            pal_AddTest.Visible = false;
        }

        private void btn_SavePwd_Click(object sender, EventArgs e)
        {

            int res = db.UpdatePwd(txt_UserName.Text, txt_Updatepwd.Text);

            if (txt_Inlitialpwd.Text == "")
            {
                MessageBox.Show("请输入密码");
            }
            else if (txt_Inlitialpwd.Text != t.pwd.ToString())
            {
                MessageBox.Show("初始密码错误！");
            }
            else if (txt_Updatepwd.Text != txt_RepeatPwd.Text)
            {
                MessageBox.Show("两次密码不一致");
            }
            else
            {
                if (res > 0)
                {
                    MessageBox.Show("修改成功！");
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void DGV_Test_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)

            {

                if (this.DGV_Test.Columns[e.ColumnIndex].HeaderText == "操作")

                {


                    StringFormat sf = StringFormat.GenericDefault.Clone() as StringFormat;//设置重绘入单元格的字体样式
                    sf.FormatFlags = StringFormatFlags.DisplayFormatControl;
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Trimming = StringTrimming.EllipsisCharacter;

                    e.PaintBackground(e.CellBounds, false);//重绘边框
                    //设置要写入字体的大小
                    System.Drawing.Font myFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    SizeF sizeDel = e.Graphics.MeasureString("删除", myFont);
                    SizeF sizeMod = e.Graphics.MeasureString("添加", myFont);
                    SizeF sizeLook = e.Graphics.MeasureString("修改", myFont);

                    float fDel = sizeDel.Width / (sizeDel.Width + sizeMod.Width + sizeLook.Width); //
                    float fMod = sizeMod.Width / (sizeDel.Width + sizeMod.Width + sizeLook.Width);
                    float fLook = sizeLook.Width / (sizeDel.Width + sizeMod.Width + sizeLook.Width);
                    //设置每个“按钮的边界”
                    RectangleF rectDel = new RectangleF(e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Width * fDel, e.CellBounds.Height);
                    RectangleF rectMod = new RectangleF(rectDel.Right, e.CellBounds.Top, e.CellBounds.Width * fMod, e.CellBounds.Height);
                    RectangleF rectLook = new RectangleF(rectMod.Right, e.CellBounds.Top, e.CellBounds.Width * fLook, e.CellBounds.Height);
                    e.Graphics.DrawString("删除", myFont, Brushes.Blue, rectDel, sf); //绘制“按钮”
                    e.Graphics.DrawString("添加", myFont, Brushes.Blue, rectMod, sf);
                    e.Graphics.DrawString("修改", myFont, Brushes.Blue, rectLook, sf);
                    e.Handled = true;
                }

            }
        }

        private void DGV_Test_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                Point curPosition = e.Location;//当前鼠标在当前单元格中的坐标
                if (this.DGV_Test.Columns[e.ColumnIndex].HeaderText == "操作")
                {
                    Graphics g = this.DGV_Test.CreateGraphics();
                    System.Drawing.Font myFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    SizeF sizeDel = g.MeasureString("删除", myFont);
                    SizeF sizeMod = g.MeasureString("修改", myFont);
                    SizeF sizeLook = g.MeasureString("查看", myFont);
                    float fDel = sizeDel.Width / (sizeDel.Width + sizeMod.Width + sizeLook.Width);
                    float fMod = sizeMod.Width / (sizeDel.Width + sizeMod.Width + sizeLook.Width);
                    float fLook = sizeLook.Width / (sizeDel.Width + sizeMod.Width + sizeLook.Width);
                    Rectangle rectTotal = new Rectangle(0, 0, this.DGV_Test.Columns[e.ColumnIndex].Width, this.DGV_Test.Rows[e.RowIndex].Height);
                    RectangleF rectDel = new RectangleF(rectTotal.Left, rectTotal.Top, rectTotal.Width * fDel, rectTotal.Height);
                    RectangleF rectMod = new RectangleF(rectDel.Right, rectTotal.Top, rectTotal.Width * fMod, rectTotal.Height);
                    RectangleF rectLook = new RectangleF(rectMod.Right, rectTotal.Top, rectTotal.Width * fLook, rectTotal.Height);
                    //判断当前鼠标在哪个“按钮”范围内

                    if (rectDel.Contains(curPosition))//删除
                    {


                        string b = DGV_Test.CurrentRow.Cells["Column1"].Value.ToString();


                        DialogResult isok = MessageBox.Show("确定删除！！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (isok == DialogResult.OK)
                        {
                            int res = db.DeleteTest(b);
                            if (res > 0)
                            {
                                DGV_Test.DataSource = db.TestManger().Tables["Examination_list"];
                                MessageBox.Show("删除成功");
                            }
                        }



                        else
                        {
                            MessageBox.Show("删除失败");
                        }
                    }

                    else if (rectMod.Contains(curPosition))//修改

                        MessageBox.Show("修改");

                    else if (rectLook.Contains(curPosition))//查看
                        MessageBox.Show("查看");
                }
            }
        }



        private void btn_AddTEst_Click(object sender, EventArgs e)
        {



            if (txt_testName.Text == "" || Com_Subject.Text == "" || Com_exameObject.Text == "")
            {

                MessageBox.Show("请填写完整信息");
            }
            else
            {
                string name = txt_testName.Text;
                string Subjects = Com_Subject.Text;
                string objects = Com_exameObject.Text;
                DateTime time = Convert.ToDateTime(dateTimePicker1.Text);
                string questionID = "";//题号
                int countTrue = -1;//勾选框为true的题的数量
                for (int i = 0; i < this.DGV_Topiclist.RowCount; i++)
                {

                    //判断勾选项是否被勾选
                    if (this.DGV_Topiclist.Rows[i].Cells["Column8"].FormattedValue.ToString().ToUpper() == "TRUE")
                    {
                        countTrue++;
                    }

                }
                //把值一一获取
                for (int i = 0; i < this.DGV_Topiclist.RowCount; i++)
                {
                    if (this.DGV_Topiclist.Rows[i].Cells["Column8"].FormattedValue.ToString().ToUpper() == "TRUE")
                    {
                        //前面都是加等  “值，” 的形式
                        if (i <= countTrue - 1)
                        {
                            questionID += this.DGV_Topiclist.Rows[i].Cells["Column4"].Value.ToString() + ",";
                        }
                        //最后一个就是加等于 “值” 的形式了
                        if (i == countTrue)
                        {
                            questionID += this.DGV_Topiclist.Rows[i].Cells["Column4"].Value.ToString();
                            countTrue = -1;
                        }
                    }

                }
                int res = db.Addtest(name, Subjects, objects, time, questionID);
                if (res > 0)
                {

                    MessageBox.Show("添加成功！");

                    DGV_Test.DataSource = db.TestManger().Tables["Examination_list"];
                    pal_DGv.Visible = true;
                    pal_AddTest.Visible = false;


                }

            }


        }


        private void button6_Click(object sender, EventArgs e)
        {
            pal_AddTest.Visible = true;
            pal_DGv.Visible = false;
            DGV_Topiclist.DataSource = db.DGvTopiclist().Tables["TheQuestionBank"];





        }

        private void btn_Canceltest_Click(object sender, EventArgs e)
        {
            DGV_Test.DataSource = db.TestManger().Tables["Examination_list"];
            pal_DGv.Visible = true;
            pal_AddTest.Visible = false;


        }

        private void DGV_Topiclist_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        { //不是序号列和标题列时才执行
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                //checkbox 勾上
                if ((bool)DGV_Topiclist.Rows[e.RowIndex].Cells[5].EditedFormattedValue == true)
                {
                    //选中改为不选中
                    this.DGV_Topiclist.Rows[e.RowIndex].Cells[5].Value = false;
                }
                else
                { //不选中改为选中 
                    this.DGV_Topiclist.Rows[e.RowIndex].Cells[5].Value = true;
                }
            }
        }

        private void nav_Click(object sender, EventArgs e)
        {


            txt_UserName.Text = Pass.passData;
            txt_No.Text = t.id;
            txt_Name.Text = t.name;


            Panel pal = (Panel)sender;
            // MessageBox.Show(this.nav_pal.Controls.Count.ToString());

            for (int i = 0; i < this.nav_pal.Controls.Count - 1; i++)
            {

                if (i != this.nav_pal.Controls.IndexOf(pal))//这里的判断条件要写不是当前控件为真
                {
                    //判断不是当前点击pal控件的其他pal控件变色
                    this.nav_pal.Controls[i].BackColor = Color.Transparent;
                    //不是对应的内容页面就不显示
                    this.mainPage_pal.Controls[i].Visible = false;
                }
                else
                {
                    //点击本身，本身就变色
                    this.nav_pal.Controls[i].BackColor = Color.FromArgb(30, 39, 44);
                    //对应的内容页面就显示
                    this.mainPage_pal.Controls[i].Visible = true;
                }
            }
        }

        private void DGV_Topic_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)

            {

                if (this.DGV_Topic.Columns[e.ColumnIndex].HeaderText == "操作")

                {

                    StringFormat sf = StringFormat.GenericDefault.Clone() as StringFormat;//设置重绘入单元格的字体样式
                    sf.FormatFlags = StringFormatFlags.DisplayFormatControl;
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Trimming = StringTrimming.EllipsisCharacter;
                    e.PaintBackground(e.CellBounds, false);//重绘边框
                    //设置要写入字体的大小
                    System.Drawing.Font myFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    SizeF sizeDel = e.Graphics.MeasureString("编辑", myFont);
                    SizeF sizeMod = e.Graphics.MeasureString("删除", myFont);


                    float fDel = sizeDel.Width / (sizeDel.Width + sizeMod.Width); //
                    float fMod = sizeMod.Width / (sizeDel.Width + sizeMod.Width);

                    //设置每个“按钮的边界”
                    RectangleF rectDel = new RectangleF(e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Width * fDel, e.CellBounds.Height);
                    RectangleF rectMod = new RectangleF(rectDel.Right, e.CellBounds.Top, e.CellBounds.Width * fMod, e.CellBounds.Height);

                    e.Graphics.DrawString("编辑", myFont, Brushes.Blue, rectDel, sf); //绘制“按钮”
                    e.Graphics.DrawString("删除", myFont, Brushes.Blue, rectMod, sf);

                    e.Handled = true;
                }

            }
        }

        private void DGV_Topic_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                Point curPosition = e.Location;//当前鼠标在当前单元格中的坐标
                if (this.DGV_Topic.Columns[e.ColumnIndex].HeaderText == "操作")
                {
                    Graphics g = this.DGV_Test.CreateGraphics();
                    System.Drawing.Font myFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    SizeF sizeDel = g.MeasureString("编辑", myFont);
                    SizeF sizeMod = g.MeasureString("删除", myFont);

                    float fDel = sizeDel.Width / (sizeDel.Width + sizeMod.Width);
                    float fMod = sizeMod.Width / (sizeDel.Width + sizeMod.Width);

                    Rectangle rectTotal = new Rectangle(0, 0, this.DGV_Topic.Columns[e.ColumnIndex].Width, this.DGV_Topic.Rows[e.RowIndex].Height);
                    RectangleF rectDel = new RectangleF(rectTotal.Left, rectTotal.Top, rectTotal.Width * fDel, rectTotal.Height);
                    RectangleF rectMod = new RectangleF(rectDel.Right, rectTotal.Top, rectTotal.Width * fMod, rectTotal.Height);

                    //判断当前鼠标在哪个“按钮”范围内
                    string b = DGV_Topic.CurrentRow.Cells["dataGridViewTextBoxColumn1"].Value.ToString();
                    if (rectDel.Contains(curPosition))//编辑
                    {

                        pal_UpdateTopic.Visible = true;
                        q = db.Redact(b);
                        txt_type.Text = q.questionType;
                        txt_Object.Text = q.subjectname;
                        txt_Teacher.Text = t.name;
                        txt_Answer.Text = q.correctAnswer;
                        txt_TopicInfo.Text = q.questionText;
                        numericUpDown1.Text = q.sorce.ToString();
                    }
                    else if (rectMod.Contains(curPosition))//删除
                    {
                        DialogResult isok = MessageBox.Show("确定删除！！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (isok == DialogResult.OK)
                        {
                            int res = db.DeleteTopic(b);
                            if (res > 0)
                            {
                                DGV_Topic.DataSource = db.TopicManger().Tables["TheQuestionBank"];
                                MessageBox.Show("删除成功！");
                            }
                        }
                        else
                        {
                            MessageBox.Show("删除失败！");
                        }


                    }
                }
            }

        }

        private void DGV_Result_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)

            {

                if (this.DGV_Result.Columns[e.ColumnIndex].HeaderText == "成绩")

                {

                    StringFormat sf = StringFormat.GenericDefault.Clone() as StringFormat;//设置重绘入单元格的字体样式
                    sf.FormatFlags = StringFormatFlags.DisplayFormatControl;
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Trimming = StringTrimming.EllipsisCharacter;
                    e.PaintBackground(e.CellBounds, false);//重绘边框
                    //设置要写入字体的大小
                    System.Drawing.Font myFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    SizeF sizeDel = e.Graphics.MeasureString("查看", myFont);
                    float fDel = sizeDel.Width / (sizeDel.Width); //
                    //设置每个“按钮的边界”
                    RectangleF rectDel = new RectangleF(e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Width * fDel, e.CellBounds.Height);
                    e.Graphics.DrawString("查看", myFont, Brushes.Blue, rectDel, sf); //绘制“按钮”
                    e.Handled = true;
                }

            }
        }

        private void DGV_Result_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                Point curPosition = e.Location;//当前鼠标在当前单元格中的坐标
                if (this.DGV_Result.Columns[e.ColumnIndex].HeaderText == "成绩")
                {
                    Graphics g = this.DGV_Test.CreateGraphics();
                    System.Drawing.Font myFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    SizeF sizeDel = g.MeasureString("查看", myFont);


                    float fDel = sizeDel.Width / (sizeDel.Width);


                    Rectangle rectTotal = new Rectangle(0, 0, this.DGV_Result.Columns[e.ColumnIndex].Width, this.DGV_Result.Rows[e.RowIndex].Height);
                    RectangleF rectDel = new RectangleF(rectTotal.Left, rectTotal.Top, rectTotal.Width * fDel, rectTotal.Height);


                    //判断当前鼠标在哪个“按钮”范围内
                    string examname = DGV_Result.CurrentRow.Cells["dataGridViewTextBoxColumn5"].Value.ToString();
                    if (rectDel.Contains(curPosition))//查看
                    {
                        DGV_StudentRsult.DataSource = db.StudentResult(examname).Tables["EndExamSocre"];
                        Pal_StudentResult.Visible = true;

                    }



                }
            }
        }


        private void button5_Click_1(object sender, EventArgs e)
        {
            pal_UpdateTopic.Visible = false;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string id = DGV_Topic.CurrentRow.Cells["dataGridViewTextBoxColumn1"].Value.ToString();
            int res = db.UpdateTopic(txt_Object.Text, txt_type.Text, txt_TopicInfo.Text, txt_Answer.Text, txt_remark.Text, Convert.ToInt32(numericUpDown1.Text), Convert.ToInt32(id));
            if (res > 0)
            {
                DGV_Topic.DataSource = db.TopicManger().Tables["TheQuestionBank"];
                MessageBox.Show("保存成功！");
                pal_UpdateTopic.Visible = false;

            }
        }

        private void btn_SaveAdd_Click(object sender, EventArgs e)
        {
            //清零题目数据
            for (int a = 0; a < pal_choose.Controls.Count; a++)
            {

                if (pal_choose.Controls[a] is TextBox)
                {
                    TextBox text = pal_choose.Controls[a] as TextBox;
                    text.Text = "";
                }

            }

            int time = 0;
            for (int i = 0; i < pal_choose.Controls.Count; i++)
            {
                if (pal_choose.Controls[i] is RadioButton)
                {
                    RadioButton radio = pal_choose.Controls[i] as RadioButton;
                    if (radio.Checked)
                    {
                        Answer += radio.Text;
                    }
                    if (!radio.Checked)
                    {
                        time++;
                        if (time < 3)
                        {
                            WrongAnswer += radio.Text + ",";
                        }
                        if (time == 3)
                        {
                            WrongAnswer += radio.Text;
                        }


                    }

                }


            }
            if (!pal_choose.Visible)
            {
                if (txt_AddObject.Text.Equals("") || txt_AddRemark.Text.Equals("") || txt_AddObject.Text.Equals("") || txt_AddTopicAnswer.Text.Equals("") || txt_AddTopicInfo.Text.Equals("") || txt_AddObject.Text.Equals(""))
                {
                    MessageBox.Show("请输入完整题目信息！");


                }
                else
                {
                    int res = db.AddTopic(txt_AddObject.Text, Com_TopicType.Text, txt_AddTopicInfo.Text, txt_AddTopicAnswer.Text, txt_AddRemark.Text, Convert.ToDouble(numericUpDown2.Text));
                    if (res > 0)
                    {
                        DGV_Topic.DataSource = db.TopicManger().Tables["TheQuestionBank"];
                        MessageBox.Show("添加题目成功！");

                        for (int i = 0; i < this.nav_textbox.Controls.Count; i++)
                        {
                            this.nav_textbox.Controls[i].Text = "";

                        }

                        pal_AddTopic.Visible = false;
                    }
                    else
                    {

                        MessageBox.Show("添加题目失败！");
                    }
                }
            }
            else
            {
                if (txt_AddObject.Text.Equals("") || txt_Answer1.Equals("") || txt_Answer2.Equals("") || txt_Answer3.Equals("") || txt_Answer4.Equals("") || txt_AddTopicInfo.Text.Equals("") || txt_AddObject.Text.Equals(""))
                {
                    MessageBox.Show("请输入完整题目信息！");


                }
                else
                {
                    int res = db.AddTopic(txt_AddObject.Text, Com_TopicType.Text, txt_AddTopicInfo.Text, Answer, WrongAnswer, Convert.ToDouble(numericUpDown2.Text));
                    if (res > 0)
                    {
                        DGV_Topic.DataSource = db.TopicManger().Tables["TheQuestionBank"];
                        MessageBox.Show("添加题目成功！");
                        for (int i = 0; i < this.nav_textbox.Controls.Count; i++)
                        {
                            this.nav_textbox.Controls[i].Text = "";

                        }
                        pal_AddTopic.Visible = false;

                    }
                    else
                    {

                        MessageBox.Show("添加题目失败！");
                    }
                }

            }

        }

        private void btn_AddTopic_Click(object sender, EventArgs e)
        {

            pal_AddTopic.Visible = true;

        }

        private void btn_CancelAdd_Click(object sender, EventArgs e)
        {
            pal_AddTopic.Visible = false;
        }

        private void txt_Serch_TextChanged(object sender, EventArgs e)
        {
            if (txt_Serch.Text == "")
            {
                pal_serchTopic.Visible = false;
            }
            else
            {
                int res = db.srchTopiccount(txt_Serch.Text);
                pal_serchTopic.Visible = true;
                string name = "lab_Topic";
                this.pal_serchTopic.Controls.Clear();
                if (res > 0)
                {

                    for (int i = 0; i < res; i++)
                    {
                        Label lab = new Label();
                        lab.Name = name + i;
                        lab.Text = "";
                        lab.Text = db.Redactt(txt_Serch.Text).Tables["TheQuestionBank"].Rows[i][0].ToString();
                        lab.Location = new Point(0, i * 25);//第二个panel位置
                        lab.AutoSize = true;
                        lab.Click += new EventHandler(this.lab_Click);
                        this.pal_serchTopic.Controls.Add(lab);
                        //调用添加标签控件的方法
                    }
                }
                else
                {
                    this.pal_serchTopic.Visible = false;
                }

            }

        }

        private void lab_Click(object sender, EventArgs e)
        {
            Label lab = (Label)sender;
            txt_Serch.Text = lab.Text;
            pal_serchTopic.Visible = false;
        }

        private void btn_serchTopic_Click(object sender, EventArgs e)
        {
            pal_serchTopic.Visible = false;
            if (txt_Serch.Text == "" || db.srchTopiccount(txt_Serch.Text) == 0)
            {
                MessageBox.Show("没有满足此条件的查询");
            }
            else
            {
                DGV_Topic.DataSource = db.SerchTopic(txt_Serch.Text).Tables["TheQuestionBank"];
            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pal_UpdateTopic.Visible = false;
            pal_AddTopic.Visible = false;
            DGV_Topic.DataSource = db.TopicManger().Tables["TheQuestionBank"];

        }

        private void txt_AddTopicInfo_TextChanged(object sender, EventArgs e)
        {
        }

        private void btn_ResultBack_Click(object sender, EventArgs e)
        {
            Pal_StudentResult.Hide();
            DGV_Result.DataSource = db.TestManger().Tables["Examination_list"];
        }

        private void Pal_StudentResult_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            CountImg count = new CountImg();
            count.Show();

        }

        private void Com_Subject_TextChanged(object sender, EventArgs e)
        {
            DGV_Topiclist.DataSource = db.dgvtopicserch(Com_Subject.Text).Tables["TheQuestionBank"];
        }
        private void RadioButtom_Leave(object sender, EventArgs e)
        {
            RB_Anwser1.Text = txt_Answer1.Text;
            RB_Anwser2.Text = txt_Answer2.Text;
            RB_Anwser3.Text = txt_Answer3.Text;
            RB_Anwser4.Text = txt_Answer4.Text;


        }

        private void Com_TopicType_TextChanged(object sender, EventArgs e)
        {
            if (Com_TopicType.Text.Equals("选择题"))
            {
                pal_choose.Visible = true;
            }
            else
            {
                pal_choose.Visible = false;
            }

        }



        private void DGV_CheckTest_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)

            {

                if (this.DGV_CheckTest.Columns[e.ColumnIndex].HeaderText == "操作")

                {
                    StringFormat sf = StringFormat.GenericDefault.Clone() as StringFormat;//设置重绘入单元格的字体样式
                    sf.FormatFlags = StringFormatFlags.DisplayFormatControl;
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Trimming = StringTrimming.EllipsisCharacter;
                    e.PaintBackground(e.CellBounds, false);//重绘边框
                                                           //设置要写入字体的大小
                    System.Drawing.Font myFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    SizeF sizeDel = e.Graphics.MeasureString("批改", myFont);
                    float fDel = sizeDel.Width / (sizeDel.Width); //
                                                                  //设置每个“按钮的边界”
                    RectangleF rectDel = new RectangleF(e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Width * fDel, e.CellBounds.Height);
                    e.Graphics.DrawString("批改", myFont, Brushes.Blue, rectDel, sf); //绘制“按钮”
                    e.Handled = true;
                }

            }






        }


        private void DGV_CheckTest_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                Point curPosition = e.Location;//当前鼠标在当前单元格中的坐标
                if (this.DGV_CheckTest.Columns[e.ColumnIndex].HeaderText == "操作")
                {

                    Graphics g = this.DGV_CheckTest.CreateGraphics();
                    System.Drawing.Font myFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    SizeF sizeDel = g.MeasureString("批改", myFont);
                    float fDel = sizeDel.Width / (sizeDel.Width);
                    Rectangle rectTotal = new Rectangle(0, 0, this.DGV_CheckTest.Columns[e.ColumnIndex].Width, this.DGV_CheckTest.Rows[e.RowIndex].Height);
                    RectangleF rectDel = new RectangleF(rectTotal.Left, rectTotal.Top, rectTotal.Width * fDel, rectTotal.Height);


                    //判断当前鼠标在哪个“按钮”范围内

                    if (rectDel.Contains(curPosition))//查看
                    {
                        //   sizeDel = g.MeasureString("已批改", myFont);
                        DataSet ds = new DataSet();
                     
                        if (DGV_CheckTest.CurrentRow.Cells["Column12"].Value.ToString().Equals("已批改       "))
                        {

                            MessageBox.Show("该试卷以批改");

                        }
                        else
                        {
                            Pass.EndexamnationId = Convert.ToInt32(DGV_CheckTest.CurrentRow.Cells["dataGridViewTextBoxColumn9"].Value);
                            Pass.EndexamnationSubject = DGV_CheckTest.CurrentRow.Cells["dataGridViewTextBoxColumn10"].Value.ToString();
                            FrmCheckTest ff = new FrmCheckTest();
                            ff.Show();
                            this.Close();
                        }




                    }


                }
            }
        }
        private void DGV_CheckTest_CellEnter(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void btn_Click(object sender, EventArgs e)
        {



        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            DialogResult isok = MessageBox.Show("确定注销吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (isok == DialogResult.OK)
            {
                this.Close();
                this.Dispose();
                Lishushun.LoginFrm log = new Lishushun.LoginFrm();
                log.Show();
            }


        }

        private void DGV_CheckTest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void Com_exameDepartment_TextChanged(object sender, EventArgs e)
        {
          
            //    if (Com_exameDepartment.Text== "信息工程系")
            //    {
            //        Com_exameObject.Items[0] = "软件技术";
            //        Com_exameObject.Items[1] = "数字媒体应用技术";
            //        Com_exameObject.Items[2] = "计算机应用技术";
            //        Com_exameObject.Items[3] = "移动应用开发";
            //        Com_exameObject.Items[4] = "计算机网络技术";
            //    }
            //    if (Com_exameDepartment.Text == "土木建筑系")
            //    {
            //        Com_exameObject.Items[0] = "建筑室内设计";
            //        Com_exameObject.Items[1] = "建筑工程技术";
            //        Com_exameObject.Items[2] = "工程造价";
            //        Com_exameObject.Items[3] = "排水工程技术";
            //        Com_exameObject.Items[4] = "建设工程监理";
            //    }
            //    if (Com_exameDepartment.Text == "水利工程系")
            //    {
            //        Com_exameObject.Items[0] = "水利水电工程技术";
            //        Com_exameObject.Items[1] = "水利水电工程管理";
            //        Com_exameObject.Items[2] = "水文与水资源工程";
            //        Com_exameObject.Items[3] = "水利水电建筑工程";
            //        Com_exameObject.Items[4] = "水文测报技术";
            //        Com_exameObject.Items[5] = "水电站电器设备";
            //        Com_exameObject.Items[6] = "水利工程";
            //    }
            //    if (Com_exameDepartment.Text == "金融管理系")
            //    {
            //        Com_exameObject.Items[0] = "财务管理";
            //        Com_exameObject.Items[1] = "物流管理";

                
            //}
         
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
    }
}
