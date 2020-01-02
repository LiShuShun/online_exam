using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Online_examination_system.Lijianhua;
//无边框拖动的命名空间
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Threading;

namespace Online_examination_system.Lijianhua
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 数据处理类实例化
        /// </summary>
        Dal dl = new Dal();


        /// <summary>
        /// 关闭键和取消按钮
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
        /// 非空验证
        /// </summary>
        /// <returns></returns>
        private bool isEmpty()
        {
            if (AddAdmin_pal.Visible)
            {
                for (int i = 0; i < AddAdmin_pal.Controls.Count; i++)
                {
                    if (AddAdmin_pal.Controls[i].Text.Equals(""))
                    {
                        MessageBox.Show("信息不全");
                        return false;
                    }
                }
            }
            if (AddStudent_pal.Visible)
            {
                for (int i = 0; i < AddStudent_pal.Controls.Count; i++)
                {
                    if (AddStudent_pal.Controls[i].Text.Equals(""))
                    {
                        MessageBox.Show("信息不全");
                        return false;
                    }
                }
            }
            if (AddTeacher_pal.Visible)
            {
                for (int i = 0; i < AddTeacher_pal.Controls.Count; i++)
                {
                    if (AddTeacher_pal.Controls[i].Text.Equals(""))
                    {
                        MessageBox.Show("信息不全");
                        return false;
                    }
                }
            }
            if (UpdataQuestions_pal.Visible)
            {
                for (int i = 0; i < UpdataQuestions_pal.Controls.Count - 1; i++)
                {
                    if (UpdataQuestions_pal.Controls[i].Text.Equals(""))
                    {
                        MessageBox.Show("信息不全");
                        return false;
                    }
                }
            }
            return true;
        }


        /// <summary>
        /// 确认按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Confirm_btn_Click(object sender, EventArgs e)
        {
            if (isEmpty())
            {
                DialogResult res = MessageBox.Show("确定添加！！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {

                    if (AddAdmin_pal.Visible)
                    {

                        //把当前框类的值赋给实体类
                        //staticModle.adminid = this.adminid_txt.Text;
                        staticModle.adminname = this.adminname_txt.Text;
                        staticModle.password = this.Adminpassword_txt.Text;
                        if (dl.AddInfo(static_SQL_CRUD.AddAdminInfo()) > 0)
                        {
                            MessageBox.Show("添加成功");
                            //刷新主页面
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("添加失败");
                        }
                    }
                    if (AddStudent_pal.Visible)
                    {
                        //把当前框类的值赋给实体类
                        //staticModle.stuid = this.stuid_txt.Text;
                        staticModle.stuname = this.stuname_txt.Text;
                        staticModle.stuclass = this.stuclass_txt.Text;
                        staticModle.stuage = int.Parse(this.stuage_txt.Text);
                        staticModle.major = this.major_txt.Text;
                        staticModle.dapartment = this.dapartment_txt.Text;
                        staticModle.password = this.Studentpassword_txt.Text;
                        staticModle.note = this.StudentNote_txt.Text;
                        if (dl.AddInfo(static_SQL_CRUD.AddStudenthInfo()) > 0)
                        {
                            MessageBox.Show("添加成功");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("添加失败");
                        }
                    }
                    if (AddTeacher_pal.Visible)
                    {
                        //把当前框类的值赋给实体类
                        //staticModle.teacherid = this.teacherid_txt.Text;
                        staticModle.teaname = this.teaname_txt.Text;
                        staticModle.department = this.department_txt.Text;
                        staticModle.teacherage = this.teacherage_txt.Text;
                        staticModle.password = this.Teacherpassword_txt.Text;
                        staticModle.note = this.Teachernote_txt.Text;
                        if (dl.AddInfo(static_SQL_CRUD.AddTeacherInfo()) > 0)
                        {
                            MessageBox.Show("添加成功");
                            this.DialogResult = DialogResult.OK;
                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show("添加失败");
                        }


                    }
                }
            }
        }


        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddStudent_Load(object sender, EventArgs e)
        {
            //窗口圆角化
            this.Region = new Admin(null, null).Round(this.Width, this.Height, 20);



            //当修改页面显示时，在加载相应的信息 如果是添加信息时，该页面就不会加载信息
            if (this.AddStudent_pal.Visible && this.Updata_btn.Visible)
            {
                //修改页面加载学生的信息
                Modle model = dl.showInfoSingle(static_SQL_CRUD.StudentInfoSingle());

                //学生信息
                this.stuid_txt.Text = model.stuid;
                this.stuname_txt.Text = model.stuname;
                this.stuclass_txt.Text = model.stuclass;
                this.stuage_txt.Text = model.stuage;
                this.major_txt.Text = model.major;
                this.dapartment_txt.Text = model.dapartment;
                this.Studentpassword_txt.Text = model.password;
                this.StudentNote_txt.Text = model.note;
            }
            if (this.AddTeacher_pal.Visible && this.Updata_btn.Visible)
            {
                //修改页面加载老师的信息
                Modle teacherInfo = dl.showInfoSingle(static_SQL_CRUD.TeacherInfoSingle());
                //老师信息
                this.teacherid_txt.Text = teacherInfo.teacherid;
                this.teaname_txt.Text = teacherInfo.teaname;
                this.teacherage_txt.Text = teacherInfo.teacherage;
                this.department_txt.Text = teacherInfo.department;
                this.teacherage_txt.Text = teacherInfo.teacherage;
                this.Teacherpassword_txt.Text = teacherInfo.password;
                this.Teachernote_txt.Text = teacherInfo.note;
            }

        }


        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Updata_btn_Click(object sender, EventArgs e)
        {
            if (isEmpty())
            {
                DialogResult res = MessageBox.Show("确定修改！！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {
                    //获取当前窗口的信息并修改
                    //判断那个页面显示就获取那个页面的值
                    if (this.AddStudent_pal.Visible)
                    {
                        staticModle.stuid = this.stuid_txt.Text;
                        staticModle.stuname = this.stuname_txt.Text;
                        staticModle.stuclass = this.stuclass_txt.Text;
                        staticModle.stuage = Convert.ToInt32(this.stuage_txt.Text);
                        staticModle.major = this.major_txt.Text;
                        staticModle.dapartment = this.dapartment_txt.Text;
                        staticModle.password = this.Studentpassword_txt.Text;
                        staticModle.note = this.StudentNote_txt.Text;
                        if (dl.Updta(static_SQL_CRUD.UpdataStudent()) > 0)
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
                    if (this.AddTeacher_pal.Visible)
                    {
                        staticModle.teacherid = this.teacherid_txt.Text;
                        staticModle.teaname = this.teaname_txt.Text;
                        staticModle.teacherage = this.teacherage_txt.Text;
                        staticModle.department = this.department_txt.Text;
                        staticModle.teacherage = this.teacherage_txt.Text;
                        staticModle.password = this.Teacherpassword_txt.Text;
                        staticModle.note = this.Teachernote_txt.Text;
                        if (dl.Updta(static_SQL_CRUD.UpdataTeacher()) > 0)
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

                    if (this.UpdataQuestions_pal.Visible)
                    {
                         staticModle.subject = this.subjects_txt.Text;
                         staticModle.questiontype = this.questionType_cob.Text;
                        staticModle.questionText = this.question_txt.Text;
                        staticModle.correctAnswer = this.correctAnswer_txt.Text;
                        staticModle.wrongAnswer = this.wrongAnswer_txt.Text;
                        staticModle.score = (double)this.score_num.Value;

                        if (dl.Updta(static_SQL_CRUD.updataQuestions()) > 0)
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
    private void nav_pal_MouseDown(object sender, MouseEventArgs e)
    {
        ReleaseCapture();
        SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
    }

    #endregion


}
}