using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_examination_system.Lijianhua
{
    public partial class UpdataExamAndQuestionsInfo : Form
    {
        string[] questions = null;//存题号的
        public UpdataExamAndQuestionsInfo(string[] questionsId)
        {
            InitializeComponent();
            questions = questionsId;
        }

        Dal dl = new Dal();





        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdataExamAndQuestionsInfo_Load(object sender, EventArgs e)
        {
            //加载动画
            //for (int j = 0; j < 100; j++)
            //{
            //    this.Size = new Size(this.Width - 100 + j, this.Height - 100 + j);
            //    this.Location = new Point(this.Location.X - 100 + j, this.Location.Y - 100 + j);
            //    this.Opacity = j * 0.01;
            //    Thread.Sleep(2);
            //}

            //窗口圆角化
            this.Region = new Admin(null, null).Round(this.Width, this.Height, 20);



            //勾选之前创建好了的题
            for (int i = 0; i < this.questions_dataView.RowCount; i++)
            {

                for (int j = 0; j < questions.Length; j++)
                {
                    if (this.questions_dataView.Rows[i].Cells[1].Value.ToString() == questions[j])
                    {
                        this.questions_dataView.Rows[i].Cells[0].Value = true;
                        continue;
                    }
                }
            }
        }



        #region 无边框拖动事件
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

        #endregion



        /// <summary>
        /// 修改考试内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateExam_btn_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("确定修改！！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {

                staticModle.examId = Convert.ToInt32(this.examID_txt.Text);
                staticModle.examname = this.examName_txt.Text;
                staticModle.subjects = this.examSubject_com.Text;
                staticModle.examdatet = Convert.ToDateTime(this.examTime_dtp.Text);
                staticModle.examObject = this.examObject_com.Text;
                string questions = "";//题号

                for (int i = 0; i < this.questions_dataView.RowCount; i++)
                {
                    //判断勾选项是否被勾选
                    if (this.questions_dataView.Rows[i].Cells[0].FormattedValue.ToString().ToUpper() == "TRUE")
                    {
                        questions += this.questions_dataView.Rows[i].Cells[1].Value.ToString() + ",";
                    }

                }

                staticModle.questions = questions.Substring(0, questions.Length - 1);


                if (dl.Updta(static_SQL_CRUD.updateExamInfo()) > 0)
                {
                    MessageBox.Show("修改成功！！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }
                else
                {
                    MessageBox.Show("修改失败！！");
                }
            }


        }


        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 100, j = 0; i > -1; i--, j++)
            {
                this.Size = new Size(this.Width - j, this.Height - j);
                this.Location = new Point(this.Location.X - j, this.Location.Y - j);
                this.Opacity = i * 0.01;
                Thread.Sleep(2);
            }

            this.Hide();
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancel_btn_Click(object sender, EventArgs e)
        {
            //this.Opacity = 0.5;
            for (int i = 100, j = 0; i > -1; i--, j++)
            {
                this.Size = new Size(this.Width - j, this.Height - j);
                this.Location = new Point(this.Location.X - j, this.Location.Y - j);
                this.Opacity = i * 0.01;
                Thread.Sleep(2);
            }
            
            this.Hide();
        }
    }
}
