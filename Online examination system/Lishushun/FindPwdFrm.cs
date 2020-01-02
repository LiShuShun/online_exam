using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_examination_system.Lishushun
{
    #region 找回密码窗口
    public partial class FindPwdFrm : Form
    {
        #region  窗口初始化
        public FindPwdFrm(string stuid)
        {
            InitializeComponent();
            DataAccess.Finpwd fPwd = new DataAccess.Finpwd(stuid);
            fPwd.Id = stuid;
            idlab.Text = fPwd.Id;
        }
        #endregion

        #region 解决窗体闪烁
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        #endregion

        #region 关闭Button
        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 窗口最小化
        private void minibtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region 窗口MouseDown

        private Point mousePoint = new Point();
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.mousePoint.X = e.X;
            this.mousePoint.Y = e.Y;
        }
        #endregion

        #region 窗口MouseMove
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                this.Top = Control.MousePosition.Y - mousePoint.Y;
                this.Left = Control.MousePosition.X - mousePoint.X;
            }
        }
        #endregion

        #region 修改学号按钮

        private void admintxt_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkNotNull())
            {
                int result = 0;
                string id = idlab.Text;
                int admin = Convert.ToInt32(admintxt.Text);
                string password = pwd.Text;
                DBSet ds = new DBSet();

                if (id == "学号")
                {
                    //修改学生
                    result = ds.UpStudentPwd(password, admin);
                    if (result > 0)
                    {
                        MessageBox.Show("修改成功");
                        this.Close();
                    }
                }
                else if (id == "教职工号")
                {
                    //修改教师
                    result = ds.UpTeacherPwd(password, admin);
                    if (result > 0)
                    {
                        MessageBox.Show("修改成功");
                        this.Close();
                    }
                }
                else if (id == "管理员号")
                {
                    //修改管理员
                    result = ds.UpAdminPwd(password, admin);
                    if (result > 0)
                    {
                        MessageBox.Show("修改成功");
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("账号不存在");
                }
            }
        }
        #endregion

        #region 非空判断
        public bool checkNotNull()
        {
            if (admintxt.Text == "" && idlab.Text == "学号")
            {
                MessageBox.Show("学号不能为空");
                return false;
            }
            if (admintxt.Text == "" && idlab.Text == "教职工号")
            {
                MessageBox.Show("教职工号不能为空");
                return false;
            }
            if (admintxt.Text == "" && idlab.Text == "管理员号")
            {
                MessageBox.Show("管理员号不能为空");
                return false;
            }
            else if (pwd.Text == "")
            {
                MessageBox.Show("密码不能为空");
                return false;
            }
            return true;
        }
        #endregion
    }
    #endregion
}
