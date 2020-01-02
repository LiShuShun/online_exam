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
    #region 注册窗口
    public partial class RegisterFrm : Form
    {
        #region 初始化窗口
        public RegisterFrm()
        {
            InitializeComponent();
            tea_panel.Hide();
            DBSet ds = new DBSet();
            admintxt1.Text = (Convert.ToInt32(ds.StuAllId().Tables["stuaid"].Rows[0][0])+1).ToString();//获取查询stuid结果的第一个转为字符
            admintxt.Text = (Convert.ToInt32(ds.TeaAllId().Tables["teacherid"].Rows[0][0]) + 1).ToString();
            stu_panel.Location = new Point(321, 110);
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

        #region 学生注册按钮
        private void registerbtn_Click(object sender, EventArgs e)
        {
            LoginFrm logfrm = new LoginFrm();
            logfrm.Hide();
            DBSet ds = new DBSet();
            admintxt1.Text = (Convert.ToInt32(ds.StuAllId().Tables["stuaid"].Rows[0][0]) + 1).ToString();//获取查询stuid结果的第一个转为字符

            if (check_stu_null())
            {
                int id = Convert.ToInt32(admintxt1.Text);
                string name = nametxt.Text;

                string Class = "";
                int index = Convert.ToInt32(classtxt.SelectedIndex+1);
                if (index == 1)
                {
                    Class = "软件技术1班";
                }
                if (index == 2)
                {
                    Class = "软件技术2班";
                }
                if (index == 3)
                {
                    Class = "软件技术3班";
                }
                if (index == 4)
                {
                    Class = "软件技术4班";
                }
                int age = Convert.ToInt32(agetxt.Text);
                string major = "";
                int index2 = Convert.ToInt32(majortxt.SelectedIndex+1);
                if (index2 == 1)
                {
                    major = "软件工程";
                }
                string dapartment = "";
                int index3 = Convert.ToInt32(departmenttxt.SelectedIndex+1);
                if (index3 == 1)
                {
                    dapartment = "信息工程系";
                }
                string pwd = pwdtxt2.Text;

                int type = 0;
                if (teacherrad.Checked == true)
                {
                    type = 2;
                }
                else if (studentrad.Checked == true)
                {
                    type = 1;
                }
                else
                {
                    type = 0;
                }
                string note = notetxt.Text;
                string isFace = null;
                int res = ds.AddStudentInfo(name, Class, age, major, dapartment,pwd,type,note,isFace);
                if (res > 0)
                {
                    MessageBox.Show("添加成功!");
                    this.Close();
                    logfrm.Show();
                }
                else
                {
                    MessageBox.Show("添加失败!");
                }
            }
        }
        #endregion

        #region 验证注册信息非空
        public bool check_stu_null()
        {
            if (admintxt1.Text == "")
            {
                MessageBox.Show("请输入账号");
                return false;
            }
            if (pwdtxt1.Text == "")
            {
                MessageBox.Show("请输入密码");
                return false;
            }

            if (pwdtxt2.Text == "")
            {
                MessageBox.Show("请确认密码");
                return false;
            }
            else if (pwdtxt1.Text != pwdtxt2.Text)
            {
                MessageBox.Show("两次密码不一致");
                return false;
            }
            if (agetxt.Text == "")
            {
                MessageBox.Show("年龄不能为空");
                return false;
            }
            if (classtxt.Text == "")
            {
                MessageBox.Show("班级不能为空");
                return false;
            }
            if (nametxt.Text == "")
            {
                MessageBox.Show("姓名不能为空");
                return false;
            }
            if (majortxt.Text == "")
            {
                MessageBox.Show("专业不能为空");
                return false;
            }
            if (departmenttxt.Text == "")
            {
                MessageBox.Show("系别不能为空");
                return false;
            }
            return true;
        }
        #endregion

        #region 窗口控制
        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private Point mousePoint = new Point();
        private void minibtn_Click(object sender, EventArgs e)
        {
        }
        private void nav_panel_Paint(object sender, PaintEventArgs e)
        {
        }
        private void minibtn_MouseDown(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void nav_panel_MouseDown(object sender, MouseEventArgs e)
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
        private void studentrad_CheckedChanged(object sender, EventArgs e)
        {
            tea_panel.Hide();
            stu_panel.Show();
            stu_panel.Location = new Point(321, 110);
        }
        private void teacherrad_CheckedChanged(object sender, EventArgs e)
        {
            stu_panel.Hide();
            tea_panel.Show();
            tea_panel.Location = new Point(321, 110);
        }
        #endregion

        #region //教师注册按钮
        private void button1_Click(object sender, EventArgs e)
        {
            DBSet ds = new DBSet();
            admintxt.Text = (Convert.ToInt32(ds.TeaAllId().Tables["teacherid"].Rows[0][0]) + 1).ToString();
            if (check_tea_null())
            {
                int id = Convert.ToInt32(admintxt.Text);
                string name = nametxt2.Text;
                string pwd = pwd2txt.Text;
                int age = Convert.ToInt32(agetxt2.Text);
                string major = majortxt2.Text;
                string department = departmenttxt2.Text;
                string note = note2.Text;
                int type = 0;
                if (teacherrad.Checked == true)
                {
                    type = 2;
                }
                else if (studentrad.Checked == true)
                {
                    type = 1;
                }
                else
                {
                    type = 0;
                }
                int res = ds.AddTeacherInfo(name, department, age, pwd, type, note);
                if (res > 0)
                {
                    MessageBox.Show("添加成功!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("添加失败!");
                }
            }
        }
        #endregion

        #region//教师非空注册验证
        public bool check_tea_null()
        {
            if (admintxt.Text == "")
            {
                MessageBox.Show("不能为空");
                return false;
            }
            if (pwdtxt.Text == "")
            {
                MessageBox.Show("不能为空");
                return false;
            }
            if (pwd2txt.Text == "")
            {
                MessageBox.Show("不能为空");
                return false;
            }
            if (pwd2txt.Text != pwdtxt.Text)
            {
                MessageBox.Show("两次密码不一致");
                return false;
            }
            if (nametxt2.Text == "")
            {
                MessageBox.Show("姓名不能为空");
                return false;
            }
            if (agetxt2.Text == "")
            {
                MessageBox.Show("年龄不能为空");
                return false;
            }
            if (majortxt2.Text == "")
            {
                MessageBox.Show("专业不能为空");
                return false;
            }
            if (departmenttxt2.Text == "")
            {
                MessageBox.Show("系别不能为空");
                return false;
            }
            return true;
        }
        #endregion

        #region other
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
        private void nametxt2_TextChanged(object sender, EventArgs e)
        {
        }
        private void label18_Click(object sender, EventArgs e)
        {
        }
        private void departmenttxt2_TextChanged(object sender, EventArgs e)
        {
        }
        private void label10_Click(object sender, EventArgs e)
        {
        }
        private void label11_Click(object sender, EventArgs e)
        {
        }
        private void agetxt2_TextChanged(object sender, EventArgs e)
        {
        }
        private void label12_Click(object sender, EventArgs e)
        {
        }
        private void note2_TextChanged(object sender, EventArgs e)
        {
        }
        private void label14_Click(object sender, EventArgs e)
        {
        }
        private void admintxt_TextChanged(object sender, EventArgs e)
        {
        }
        private void pwd2txt_TextChanged(object sender, EventArgs e)
        {
        }
        private void label15_Click(object sender, EventArgs e)
        {
        }
        private void label16_Click(object sender, EventArgs e)
        {
        }
        private void pwdtxt_TextChanged(object sender, EventArgs e)
        {
        }
        private void label17_Click(object sender, EventArgs e)
        {
        }
        private void tea_panel_Paint(object sender, PaintEventArgs e)
        {
        }
        #endregion

        #region 窗口控制
        private void minibtn_MouseEnter(object sender, EventArgs e)
        {
            minibtn.BackColor = System.Drawing.Color.White;
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            p.SetToolTip(this.Closebtn, "最小化");
        }
        private void minibtn_MouseLeave(object sender, EventArgs e)
        {
            minibtn.BackColor = System.Drawing.Color.Transparent;
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
        #endregion

        #region 禁用用户输入
        private void agetxt2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是退格和数字，则屏蔽输入
                                                      
        }
        private void admintxt1_TextChanged(object sender, EventArgs e)
        {
        }
        #endregion

        private void agetxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是退格和数字，则屏蔽输入
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9')))
            {
                e.Handled = true;
            }
        }

        private void classtxt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    #endregion
}
