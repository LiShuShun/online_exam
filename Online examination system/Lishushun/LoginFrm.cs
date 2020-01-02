using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;

namespace Online_examination_system.Lishushun
{
    #region 登录窗口
    public partial class LoginFrm : Form
    {
        #region 初始化窗口
        public LoginFrm()
        {
            InitializeComponent();
        }
        #endregion

        #region 登录窗口加载
        private void LoginFrm_Load(object sender, EventArgs e)
        {
            DBSet ds = new DBSet();
            combType.DataSource = ds.authority().Tables["authority"];
            combType.DisplayMember = "purviewname";
            combType.ValueMember = "purviewid";
            admintxt.Focus();

            // entry_btn.Region = Round(entry_btn.Width, entry_btn.Height, 30);//登录圆角化
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

        #region 登录按钮
        private void button1_Click(object sender, EventArgs e)
        {
            Pass.passData = admintxt.Text;
            selectNumber();
            string admint = admintxt.Text;
            string pwd = pwdtxt.Text;
            int type = Convert.ToInt32(combType.SelectedValue);

            DBSet db = new DBSet();
            DataSet ds = new DataSet();
            if (CheckNull())
            {
                //学生
                if (type == 1)
                {
                    ds = db.StudentList(admint, pwd, type);
                    int student = ds.Tables["studentlist"].Rows.Count; //count返回整形
                    if (student > 0)
                    {
                        this.Hide();
                        Liuyingjie.Student_Frm stu = new Liuyingjie.Student_Frm();
                        stu.Show();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("账号或密码错误");
                    }
                }
                //教师
                if (type == 2)
                {
                    ds = db.TeacherList(admint, pwd, type);
                    int teacher = ds.Tables["teacherlist"].Rows.Count; //count返回整形
                    if (teacher > 0)
                    {
                        this.Hide();
                        Liaobingquan.FormTeacher tea = new Liaobingquan.FormTeacher();
                        tea.Show();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("账号或密码错误");
                    }
                }
                //管理员
                if (type == 3)
                {
                    ds = db.AdminList(admint, pwd, type);
                    int admin = ds.Tables["adminlist"].Rows.Count; //count返回整形
                    if (admin > 0)
                    {
                        this.Hide();
                        Lijianhua.Admin adm = new Lijianhua.Admin(admint, pwd);
                        adm.Show();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("账号或密码错误");
                    }
                }
            }
        }
        #endregion

        #region 账户类型下拉框
        public int selectNumber()
        {
            int type = Convert.ToInt32(combType.SelectedValue);
            return type;
        }
        #endregion

        #region 验证登录信息非空
        public bool CheckNull()
        {
            int type = Convert.ToInt32(combType.SelectedValue);
            if (admintxt.Text == "" && type == 1)
            {
                MessageBox.Show("学号不能为空");
                return false;
            }
            if (admintxt.Text == "" && type == 2)
            {
                MessageBox.Show("教职工号不能为空");
                return false;
            }
            if (admintxt.Text == "" && type == 3)
            {
                MessageBox.Show("管理员号不能为空");
                return false;
            }

            if (pwdtxt.Text == "")
            {
                MessageBox.Show("请输入密码");
                this.admintxt.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region 窗口最小化
        private void label4_Click(object sender, EventArgs e)
        { }
        private void minibtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region 关闭Button
        private void Closebtn_Click(object sender, EventArgs e)
        {
            // MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            //DialogResult dr = MessageBox.Show("确定退出吗", "对话框", messButton);
            //if (dr == DialogResult.OK)//如果点击“确定”按钮
            //{
            Application.Exit();
            //}
            //else//如果点击“取消”按钮
            //{
            // }
        }
        #endregion

        #region 窗口移动
        private Point mousePoint = new Point();
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.mousePoint.X = e.X;
            this.mousePoint.Y = e.Y;
        }

        private void nav_panel_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                this.Top = Control.MousePosition.Y - mousePoint.Y;
                this.Left = Control.MousePosition.X - mousePoint.X;
            }
        }

        private void LoginFrm_MouseMove(object sender, MouseEventArgs e)
        {
        }
        #endregion

        #region other 
        private void button2_Click(object sender, EventArgs e)
        {
            this.log_panel.Show();
        }
        private void admintxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9')))
            {
                e.Handled = true;
            }
        }

        private void rbtn_Click(object sender, EventArgs e)
        {
            this.log_panel.Hide();
        }

        private void rbtn2_Click(object sender, EventArgs e)
        {
        }

        private void lbtn2_Click(object sender, EventArgs e)
        {
            this.log_panel.Show();
        }

        private void registerbtn_Click(object sender, EventArgs e)
        {
        }
        private void reg_panel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
            LoginFrm log = new LoginFrm();
            log.Hide();
            RegisterFrm register = new RegisterFrm();
            register.Show();
        }

        #endregion

        #region 学生信息窗口登录信息
        private void combType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserInfo._Power = combType.Text;
            if (combType.Text == "学生")
            {
                idlab.Text = "学    号 :";
            }
            if (combType.Text == "教师")
            {
                idlab.Text = "教职工号 :";
            }
            if (combType.Text == "管理员")
            {
                idlab.Text = "管理员号 :";
            }
        }

        private void admintxt_TextChanged(object sender, EventArgs e)
        {
            UserInfo._LogId = admintxt.Text;
        }

        private void pwdtxt_TextChanged(object sender, EventArgs e)
        {
            UserInfo._Password = pwdtxt.Text;
        }
        #endregion

        #region 窗口控制按钮
        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //最小化按钮
        private void min_btn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void exit_btn_MouseEnter(object sender, EventArgs e)
        {
        }
        private void exit_btn_MouseLeave(object sender, EventArgs e)
        {
        }
        private void min_btn_MouseEnter(object sender, EventArgs e)
        {
        }
        private void min_btn_MouseLeave(object sender, EventArgs e)
        {
        }
        #endregion

        #region 窗口控制按钮2
        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Closebtn_MouseEnter(object sender, EventArgs e)
        {
            Closebtn.BackColor = System.Drawing.Color.White;
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            p.SetToolTip(this.Closebtn, "关闭");
        }
        private void Closebtn_MouseLeave(object sender, EventArgs e)
        {
            Closebtn.BackColor = System.Drawing.Color.Transparent;
        }
        private void minibtn_MouseEnter(object sender, EventArgs e)
        {
            minibtn.BackColor = System.Drawing.Color.White;
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            p.SetToolTip(this.minibtn, "最小化");
        }
        private void minibtn_MouseLeave(object sender, EventArgs e)
        {
            minibtn.BackColor = System.Drawing.Color.Transparent;
        }
        private void Closebtn_MouseMove(object sender, MouseEventArgs e)
        {
        }
        private void minibtn_MouseMove(object sender, MouseEventArgs e)
        {
        }
        #endregion

        #region 找回密码
        private void ForgetPwd_Click(object sender, EventArgs e)
        {
            //找回密码账户类型匹配
            int type = Convert.ToInt32(combType.SelectedValue);
            if (type == 1)
            {
                string stuId = "学号";
                FindPwdFrm fpf = new FindPwdFrm(stuId);
                fpf.Show();
            }
            else if (type == 2)
            {
                string teaId = "教职工号";
                FindPwdFrm fpf = new FindPwdFrm(teaId);
                fpf.Show();
            }
            else if (type == 3)
            {
                string manageId = "管理员号";
                FindPwdFrm fpf = new FindPwdFrm(manageId);
                fpf.Show();
            }
        }
        private void nav_panel_Paint(object sender, PaintEventArgs e)
        {
        }

        #endregion

        private void combType_Click(object sender, EventArgs e)
        {
        }

        private void FaceLogbtn_Click(object sender, EventArgs e)
        {
            frmMain fac = new frmMain();
            fac.Show();
        }
    }
    #endregion
}
