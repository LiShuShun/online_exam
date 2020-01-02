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

namespace Online_examination_system.Liaobingquan
{
    public partial class FrmCheckTest : Form
    {
        public FrmCheckTest()
        {
            InitializeComponent();
        }
        #region 数据库操作
        string str = "Data Source=.;Initial Catalog=OnlineExamSys;Integrated Security=True";
        DataSet ds = null;
        SqlCommand comd = null;
        SqlConnection conn = null;
        SqlDataAdapter pter = null;
        Endexaminfo Endexaminfo = new Endexaminfo();
        string[] a;


        DBset db = new DBset();
        public void AddPanel()
        {
            
            conn = new SqlConnection(str);
            comd = new SqlCommand(String.Format(@"select t.questions from dbo.Examination_list t where t.examId={0}", Pass.EndexamnationId), conn);
            try
            {
                conn.Open();
                SqlDataReader dr = comd.ExecuteReader();

                if (dr.Read())
                {
                  a = dr["questions"].ToString().Split(',');
                    
                    for (int i = 0; i < a.Length; i++)
                    {
                 
                    UserInfo._ExamQuestion[i] = a[i];
                    }
                }
            }
            finally
            {
                conn.Close();

            };





            #endregion
        #region 动态生成控件
            ds = db.ExamQuestions();
            string name = "pan";
            int count = 0;
            for (int i = 0; i < ds.Tables["TheQuestionBank"].Rows.Count; i++)
            {
                //题干部分
                Label questionTxt = new Label();
                questionTxt.AutoSize = false;
                questionTxt.Width = 500;
                //questionTxt.BackColor = Color.Blue;
                questionTxt.Font = new System.Drawing.Font("微软雅黑", 11, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                questionTxt.Text = count+1 + "、" + ds.Tables["TheQuestionBank"].Rows[i][3].ToString() + "(" + ds.Tables["TheQuestionBank"].Rows[i][6].ToString() + "分）";//把值赋给lable
                questionTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Left
              | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)))));
                //学生答案标题
                Label Anwsertopic = new Label();
                Anwsertopic.AutoSize = false;
                //Anwsertopic.BackColor = Color.Blue;
                
                Anwsertopic.Font = new System.Drawing.Font("微软雅黑", 11, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                Anwsertopic.Location = new Point(10, 102);//第二个panel位置
                Anwsertopic.Text ="学生答案：";//把值赋给lable
                Anwsertopic.Anchor = ((System.Windows.Forms.AnchorStyles.Left));
                //学生答案
                TextBox Anwser = new TextBox();
                Anwser.Width = 500;
                Anwser.AutoSize = true;
                //Anwser.BackColor = Color.Yellow;
                Anwser.Font = new System.Drawing.Font("微软雅黑", 11, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                Anwser.Location = new Point(110, 102);//第二个panel位置

                Anwser.Text = ds.Tables["TheQuestionBank"].Rows[i][5].ToString(); ;//把值赋给lable
                Anwser.ReadOnly = true;
                
                Anwser.Anchor = ((System.Windows.Forms.AnchorStyles.Left ));



                //装题的panel
                Panel pan = new Panel();
                pan.Name = name + i;
                pan.Width = 500;
                pan.Anchor = ((System.Windows.Forms.AnchorStyles.Top));
                pan.Height = 200;
                //pan.BackColor = Color.Red;
                pan.Location = new Point(50, 120 + count *350);//第二个panel位置
                pan.AutoSize = true;
                
            

                NumericUpDown number = new NumericUpDown();
                number.Anchor = ((System.Windows.Forms.AnchorStyles)(((( System.Windows.Forms.AnchorStyles.Top )))));
                number.Width = 100;
                number.Height = 40;
                number.Location = new Point(-30, 172);//第二个panel位置
                number.Leave += new EventHandler(this.number_MouseLeave);


                count++;
                this.Controls.Add(pan);
                pan.Controls.Add(questionTxt);
                pan.Controls.Add(Anwsertopic);
                pan.Controls.Add(number);
                pan.Controls.Add(Anwser);
            }
        

        }
        #endregion
        #region
        private void FrmCheckTest_Load(object sender, EventArgs e)
        {
          
            lab_name.Text = Pass.EndexamnationSubject;
            AddPanel();
           
        }

  

        private void number_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {

            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int score = UserInfo._Examscore;
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is Panel)
                {
                    Panel Panel = this.Controls[i] as Panel;
                    for (int j = 0; j < Panel.Controls.Count; j++)
                    {
                        if (Panel.Controls[j] is NumericUpDown)
                        {
                            NumericUpDown numericUpDown = Panel.Controls[j] as NumericUpDown;
                
                                score += Convert.ToInt32(numericUpDown.Value);  
                        }
                    }
                    

                }
            }
            
            if (db.UpdateScore(score)>0)
            {
                FormTeacher t = new FormTeacher();
                t.Show();
                this.Close();

              

            }
        }
        #endregion 获取数据
    }
}
