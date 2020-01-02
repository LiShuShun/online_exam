using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Online_examination_system.Liuyingjie
{
    public partial class Student_Test_Questions : Form
    {

        public Student_Test_Questions()
        {
            InitializeComponent();
        }

        StuDB SDB = new StuDB();
        #region 数据库操作
        string str = "Data Source=.;Initial Catalog=OnlineExamSys;Integrated Security=True";//连接数据源
        SqlConnection conn = null; //连接数据库
        SqlCommand comd = null;//执行操作
        SqlDataAdapter pter = null;//数据适配器
        DataSet ds = null; //数据集
        string sql = null;

        private void QESResult()
        {
            DataSet ScoreDs = SDB.ExamScore();
            DataSet QuestionScoreDS = SDB.ExamQuestionScore();
            int ResultScore = 0;

            ds = SDB.ExamQuestions();

            DialogResult isok = MessageBox.Show("是否确认完成考试！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (isok == DialogResult.OK)
            {
                //遍历出动态生成选择题控件
                foreach (Control control in Controls)
                {
                    //实例化panel控件
                    Panel pan = control as Panel;
                    //如果这是panel控件
                    if (pan is Panel)
                    {
                        //有多少题循环多少次
                        for (int i = 0; i < ds.Tables["TheQuestionBank"].Rows.Count; i++)
                        {
                            //如果panel属性名为pani
                            if (pan.Name == "pan" + i)
                            {
                                //遍历里面的所有控件
                                foreach (Control con in pan.Controls)
                                {
                                    //给单选按钮实例化
                                    RadioButton rdo = con as RadioButton;
                                    //给答案文本框实例化
                                    TextBox txtAnswer = con as TextBox;
                                    //如果这是单选按钮
                                    if (rdo is RadioButton)
                                    {
                                        //如果被选中
                                        if (rdo.Checked)
                                        {
                                            //MessageBox.Show(rdo.Text);
                                            //循环查看题表的内容，如果选择的单选按钮的值是试题表里的正确答案
                                            if (rdo.Text == ScoreDs.Tables["TheQuestionBank"].Rows[i][0].ToString())
                                            {
                                                //正确得分
                                                ResultScore += Convert.ToInt32(QuestionScoreDS.Tables["TheQuestionBank"].Rows[i][0]);
                                            }
                                        }
                                    }
                                    //如果这是答案文本框
                                    if (txtAnswer is TextBox)
                                    {

                                        if (ds.Tables["TheQuestionBank"].Rows[i][2].ToString().Equals("填空题"))
                                        {
                                            UserInfo._FillQES[i] = txtAnswer.Text;

                                            conn = new SqlConnection(str);
                                            sql = string.Format(@"update TheQuestionBank set wrongAnswer = '{0}' where  questionID between {1} and {2}"
                                                               , UserInfo._FillQES[i], UserInfo._ExamQuestion[i], UserInfo._ExamQuestion[i]);
                                            comd = new SqlCommand(sql, conn);
                                            try
                                            {
                                                conn.Open();
                                                int result = comd.ExecuteNonQuery();

                                            }
                                            catch (Exception)
                                            {

                                            }
                                            finally { conn.Close(); conn.Dispose(); }
                                        }
                                        if (ds.Tables["TheQuestionBank"].Rows[i][2].ToString().Equals("解答题"))
                                        {
                                            UserInfo._AnswerQES[i] = txtAnswer.Text;

                                            conn = new SqlConnection(str);
                                            sql = string.Format(@"update TheQuestionBank set wrongAnswer = '{0}' where  questionID between {1} and {2}"
                                                               , UserInfo._AnswerQES[i], UserInfo._ExamQuestion[i], UserInfo._ExamQuestion[i]);
                                            comd = new SqlCommand(sql, conn);
                                            try
                                            {
                                                conn.Open();
                                                int result = comd.ExecuteNonQuery();

                                            }
                                            catch (Exception)
                                            {

                                            }
                                            finally { conn.Close(); conn.Dispose(); }
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
                //录入考试成绩
                UserInfo._Examscore = ResultScore;
                //调用分数查询类录入分数
                SDB.StuExamGetInfo();
                MessageBox.Show("提交成功！考试已完成！");
                this.Close();
            }
            else
            {
            }
        }
        /// <summary>
        /// 用户答题提交按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            QESResult();
        }

        #endregion

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        TimeSpan dtTo = new TimeSpan(0, 90, 0); //设置开始时间
        Label label1 = new Label();
        private void Student_Test_Questions_Load(object sender, EventArgs e)
        {
            label1.Width = 280;
            label1.Height = 50;
            label1.Location = new Point(1000, 50);
            label1.Font = new System.Drawing.Font("微软雅黑", 18, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            timer1.Interval = 1000;//设置每次间隔1s
            timer1.Enabled = true;

            //调用动态添加控件方法
            AddPanel();

        }

        #region 动态添加控件
        public void AddPanel()
        {

            StuDB stu = new StuDB();
            ds = stu.ExamQuestions();
            DataSet ExamInfo = stu.ExamInfo();
            int count = 0;
            string name = "pan";

            #region 试卷头部

            //试卷头部最外层panel
            Panel panHead = new Panel();
            panHead.Name = "pan_Head";
            panHead.Width = 1519;
            panHead.Height = 150;
            panHead.BackColor = Color.FromArgb(192, 255, 255);
            this.Controls.Add(panHead);

            //添加倒计时控件
            panHead.Controls.Add(label1);

            //添加标题部分
            Label examName = new Label();
            examName.AutoSize = false;
            examName.Width = 350;
            examName.Height = 50;
            examName.Font = new System.Drawing.Font("微软雅黑", 25, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            examName.Location = new Point(600, 10);//第二个panel位置
            examName.Text = ExamInfo.Tables["Examination_list"].Rows[UserInfo.ExamName][1].ToString();
            panHead.Controls.Add(examName);

            //提交按钮
            Button btn = new Button();
            btn.Name = "btn_Submit";
            btn.Text = "提交";
            btn.Width = 86;
            btn.Height = 38;
            btn.Location = new Point(1000, 100);
            //btn.Anchor = AnchorStyles.Top|AnchorStyles.Right;
            btn.Font = new System.Drawing.Font("微软雅黑", 13, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            btn.Click += new System.EventHandler(button1_Click);
            panHead.Controls.Add(btn);

            //考生姓名
            Label lab = new Label();
            lab.Width = 250;
            lab.Height = 30;
            lab.Font = new System.Drawing.Font("微软雅黑", 22, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            lab.Text = "考生姓名：" + UserInfo._StuName;
            lab.Location = new Point(30, 50);
            panHead.Controls.Add(lab);

            //考生学号
            Label lab2 = new Label();
            lab2.Width = 250;
            lab2.Height = 30;
            lab2.Font = new System.Drawing.Font("微软雅黑", 22, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            lab2.Text = "考生学号：" + UserInfo._LogId;
            lab2.Location = new Point(30, 100);
            panHead.Controls.Add(lab2);

            //考试科目
            Label lab3 = new Label();
            lab3.Width = 250;
            lab3.Height = 30;
            lab3.Font = new System.Drawing.Font("微软雅黑", 22, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            lab3.Text = "考试科目：" + UserInfo._Examsuject;
            lab3.Location = new Point(600, 100);
            panHead.Controls.Add(lab3);

            #endregion

            #region 试卷题部分

            //添加选择题标题
            for (int i = 0; i < ds.Tables["TheQuestionBank"].Rows.Count; i++)
            {
                if (ds.Tables["TheQuestionBank"].Rows[i][2].ToString().Equals("选择题"))
                {
                    Label examName1 = new Label();
                    examName1.AutoSize = false;
                    examName1.Width = 300;
                    examName1.Height = 28;
                    examName1.Font = new System.Drawing.Font("微软雅黑", 17, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    examName1.Location = new Point(250, 170);//第二个panel位置
                    examName1.Text = "选择题";
                    this.Controls.Add(examName1);
                    break;
                }
            }

            //选择题部分
            for (int i = 0; i < ds.Tables["TheQuestionBank"].Rows.Count; i++)
            {
                if (ds.Tables["TheQuestionBank"].Rows[i][2].ToString().Equals("选择题"))
                {
                    //panle部分
                    Panel pan = new Panel();
                    pan.Name = name + i;
                    //pan.Text = name + i;
                    pan.Width = 2000;
                    pan.Height = 200;
                    //pan.BackColor = Color.Red;
                    pan.Location = new Point(300, 200 + count * 200);//第二个panel位置
                    RadioButton aa = new RadioButton();
                    aa.Text = "sca";
                    aa.Name = "aaa" + 1;

                    count++;
                    //题干部分
                    Label questionTxt = new Label();
                    questionTxt.AutoSize = false;
                    questionTxt.Width = 2000;
                    questionTxt.Text = count + "、" + ds.Tables["TheQuestionBank"].Rows[i][3].ToString() + "(" + ds.Tables["TheQuestionBank"].Rows[i][6].ToString() + "分）";//把值赋给lable
                    questionTxt.Font = new System.Drawing.Font("微软雅黑", 13, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

                    //选项部分
                    List<RadioButton> radioButton = new List<RadioButton>();//button控件
                    RadioButton anwer = null;
                    
                    int Y = 0;

                    //答案选项文本
                    string CorrentAnswer = ds.Tables["TheQuestionBank"].Rows[i][4].ToString();
                    string WrongAnswer = ds.Tables["TheQuestionBank"].Rows[i][5].ToString();
                    string[] CorrentAnswerSingle = CorrentAnswer.Split(',');//正确答案文本
                    string[] WrongAnswerSingle = WrongAnswer.Split(',');//错误答案文本

                    for (int j = 0; j < CorrentAnswerSingle.Length + WrongAnswerSingle.Length; j++)//条件为答案个数  添加radiobutton控件
                    {
                        Y += 30;
                        anwer = new RadioButton();
                        anwer.AutoSize = false;
                        anwer.Width = 1000;
                        anwer.Name = "rdo" + j;
                        anwer.Location = new Point(50, 20 + Y);
                        radioButton.Add(anwer);
                    }

                    List<int> random = new List<int>();//存随机数的
                    for (int h = 0; h < CorrentAnswerSingle.Length; h++)
                    {
                        int suiji = new Random().Next(0, CorrentAnswerSingle.Length + CorrentAnswerSingle.Length );
                        random.Add(suiji);
                        radioButton[suiji].Text = CorrentAnswerSingle[h];
                        radioButton[suiji].Font = new System.Drawing.Font("微软雅黑", 12, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    }

                    for (int j = 0; j < WrongAnswerSingle.Length; j++)
                    {
                        for (int g = 0; g < radioButton.Count; g++)
                        {
                            if (radioButton[g].Text == "")
                            {
                                radioButton[g].Text = WrongAnswerSingle[j];
                                radioButton[g].Font = new System.Drawing.Font("微软雅黑", 12, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                                break;
                            }
                        }
                    }

                    //调用添加标签控件的方法

                    pan.Controls.Add(questionTxt);

                    for (int k = 0; k < radioButton.Count; k++)//答案的个数
                    {

                        pan.Controls.Add(radioButton[k]);
                    }
                    this.Controls.Add(pan);
                }
            }


            //填空题标题
            for (int i = 0; i < ds.Tables["TheQuestionBank"].Rows.Count; i++)
            {
                if (ds.Tables["TheQuestionBank"].Rows[i][2].ToString().Equals("填空题"))
                {
                    Label examName2 = new Label();
                    examName2.AutoSize = false;
                    examName2.Width = 300;
                    examName2.Height = 28;
                    examName2.Font = new System.Drawing.Font("微软雅黑", 17, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    examName2.Location = new Point(250, 200 + count * 200);//第二个panel位置
                    examName2.Text = "填空题";
                    this.Controls.Add(examName2);
                    break;
                }
            }

            //填空题部分
            for (int i = 0; i < ds.Tables["TheQuestionBank"].Rows.Count; i++)
            {
                if (ds.Tables["TheQuestionBank"].Rows[i][2].ToString().Equals("填空题"))
                {
                    //panle部分
                    Panel pan = new Panel();
                    pan.Name = name + i;
                    //pan.Text = name + i;
                    pan.Width = 2000;
                    pan.Height = 200;
                    //pan.BackColor = Color.Red;
                    pan.Location = new Point(300, 240 + count * 200);//第二个panel位置
                    RadioButton aa = new RadioButton();
                    aa.Text = "sca";
                    aa.Name = "aaa" + 1;

                    count++;
                    //题干部分
                    Label questionTxt = new Label();
                    questionTxt.AutoSize = false;
                    questionTxt.Width = 2000;
                    questionTxt.Text = count + "、" + ds.Tables["TheQuestionBank"].Rows[i][3].ToString() + "(" + ds.Tables["TheQuestionBank"].Rows[i][6].ToString() + "分）";//把值赋给lable
                    questionTxt.Font = new System.Drawing.Font("微软雅黑", 13, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

                    //答题的地方
                    TextBox txtAnswer = new TextBox();
                    txtAnswer.Width = 300;
                    txtAnswer.Height = 100;
                    txtAnswer.AutoSize = false;
                    txtAnswer.Multiline = true;
                    txtAnswer.Location = new Point(50, 50);
                    txtAnswer.Font = new System.Drawing.Font("微软雅黑", 12, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    txtAnswer.BackColor = Color.Yellow;
                    string CorrentAnswer = ds.Tables["TheQuestionBank"].Rows[i][4].ToString();
                    string[] CorrentAnswerSingle = CorrentAnswer.Split(',');//正确答案文本

                    pan.Controls.Add(txtAnswer);
                    pan.Controls.Add(questionTxt);
                    this.Controls.Add(pan);

                }

            }


            //解答题标题
            for (int i = 0; i < ds.Tables["TheQuestionBank"].Rows.Count; i++)
            {
                if (ds.Tables["TheQuestionBank"].Rows[i][2].ToString().Equals("解答题"))
                {
                    Label examName3 = new Label();
                    examName3.AutoSize = false;
                    examName3.Width = 300;
                    examName3.Height = 28;
                    examName3.Font = new System.Drawing.Font("微软雅黑", 17, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    examName3.Location = new Point(250, 240 + count * 200);//第二个panel位置
                    examName3.Text = "解答题";
                    this.Controls.Add(examName3);
                    break;
                }
            }
            //解答题部分
            for (int i = 0; i < ds.Tables["TheQuestionBank"].Rows.Count; i++)
            {
                if (ds.Tables["TheQuestionBank"].Rows[i][2].ToString().Equals("解答题"))
                {
                    //panle部分
                    Panel pan = new Panel();
                    pan.Name = name + i;
                    //pan.Text = name + i;
                    pan.Width = 2000;
                    pan.Height = 200;
                    //pan.BackColor = Color.Red;
                    pan.Location = new Point(300, 280 + count * 200);//第二个panel位置
                    RadioButton aa = new RadioButton();
                    aa.Text = "sca";
                    aa.Name = "aaa" + 1;

                    count++;
                    //题干部分
                    Label questionTxt = new Label();
                    questionTxt.AutoSize = false;
                    questionTxt.Width = 2000;
                    questionTxt.Text = count + "、" + ds.Tables["TheQuestionBank"].Rows[i][3].ToString() + "(" + ds.Tables["TheQuestionBank"].Rows[i][6].ToString() + "分）";
                    questionTxt.Font = new System.Drawing.Font("微软雅黑", 13, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

                    //解答题答题部分
                    TextBox txtAnswer = new TextBox();
                    txtAnswer.Width = 300;
                    txtAnswer.Height = 100;
                    txtAnswer.AutoSize = false;
                    txtAnswer.Multiline = true;
                    txtAnswer.Location = new Point(50, 50);
                    txtAnswer.Font = new System.Drawing.Font("微软雅黑", 12, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    txtAnswer.BackColor = Color.Yellow;

                    pan.Controls.Add(txtAnswer);
                    pan.Controls.Add(questionTxt);
                    this.Controls.Add(pan);

                }
            }

        }


        #endregion 

        #endregion
        /// <summary>
        /// 考试倒计时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {

            dtTo = dtTo.Subtract(new TimeSpan(0, 0, 1));
            label1.BackColor = Color.FromArgb(192, 255, 255);
            label1.Text = "考试剩余时间：" + dtTo.Hours.ToString() + ":" + dtTo.Minutes.ToString() + ":" + dtTo.Seconds;

            if (dtTo.TotalSeconds == 0.0)//当倒计时完毕
            {
                timer1.Enabled = false;   //其中可自行添加相应的提示框或者方法函数

                DataSet ScoreDs = SDB.ExamScore();
                DataSet QuestionScoreDS = SDB.ExamQuestionScore();
                int ResultScore = 0;

                //遍历出动态生成选择题控件
                foreach (Control control in Controls)
                {
                    //实例化panel控件
                    Panel pan = control as Panel;
                    //如果这是panel控件
                    if (pan is Panel)
                    {
                        //有多少题循环多少次
                        for (int i = 0; i < ds.Tables["TheQuestionBank"].Rows.Count; i++)
                        {
                            //如果panel属性名为pani
                            if (pan.Name == "pan" + i)
                            {
                                //遍历里面的所有控件
                                foreach (Control con in pan.Controls)
                                {
                                    //给单选按钮实例化
                                    RadioButton rdo = con as RadioButton;
                                    //给答案文本框实例化
                                    TextBox txtAnswer = con as TextBox;
                                    //如果这是单选按钮
                                    if (rdo is RadioButton)
                                    {
                                        //如果被选中
                                        if (rdo.Checked)
                                        {
                                            //MessageBox.Show(rdo.Text);
                                            //循环查看题表的内容，如果选择的单选按钮的值是试题表里的正确答案
                                            if (rdo.Text == ScoreDs.Tables["TheQuestionBank"].Rows[i][0].ToString())
                                            {
                                                //正确得分
                                                ResultScore += Convert.ToInt32(QuestionScoreDS.Tables["TheQuestionBank"].Rows[i][0]);
                                            }
                                        }
                                    }
                                    //如果这是答案文本框
                                    if (txtAnswer is TextBox)
                                    {
                                        if (ds.Tables["TheQuestionBank"].Rows[i][2].ToString().Equals("填空题"))
                                        {
                                            UserInfo._FillQES[i] = txtAnswer.Text;
                                        }
                                        if (ds.Tables["TheQuestionBank"].Rows[i][2].ToString().Equals("解答题"))
                                        {
                                            UserInfo._AnswerQES[i] = txtAnswer.Text;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                //录入考试成绩
                UserInfo._Examscore = ResultScore;
                //调用分数查询类录入分数
                SDB.StuExamGetInfo();
                MessageBox.Show("考试时间到！已为您自动提交试卷！");
                this.Close();
            }

        }
    }

}
