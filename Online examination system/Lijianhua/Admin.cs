using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//无边框拖动的命名空间
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;


//正则表达式命名空间
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Threading;

namespace Online_examination_system.Lijianhua
{
    public partial class Admin : Form
    {
        #region 窗口阴影代码
        const int CS_DROPSHADOW = 0x20000;
        const int GCL_STYLE = (-26);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);
        #endregion

        public Admin(string account, string pwd)
        {
            InitializeComponent();
            staticModle.currentAccount = account;
            staticModle.currentPwd = pwd;

            //窗口阴影代码
           SetClassLong(this.Handle, GCL_STYLE, GetClassLong(this.Handle, GCL_STYLE) | CS_DROPSHADOW);

        }
        


        //把Dal数据处理层实例化出来，方便调用它里面的属性和方法
        Dal dl = new Dal();

        //把Modle属性层实例化出来，方便调用它里面的属性
        Modle modle = new Modle();


        /// <summary>
        /// 窗口加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Admin_Load(object sender, EventArgs e)
        {
            //主内容控件跟随窗口变大而变大事件
            AutoScale(this);

            
            this.DialogResult = DialogResult.OK;
            //一开始就把数据库的学生、老师、管理员表值添加到学生页面的DataGridView中
            Baind();
            


            //把当前管理员的基本信息显示出来
            Modle modle = dl.showInfoSingle(static_SQL_CRUD.AdminId());
            this.ID_txt.Text = modle.adminid;
            this.Name_txt.Text = modle.adminname;
            this.password_txt.Text = modle.password;
            this.UserType_txt.Text = "管理员";



            //显示当前课程管理的科目
            this.CourseChoose_cob.DataSource = dl.ShowInfo(static_SQL_CRUD.AllInfoOfCourse).Tables["info"];
            this.CourseChoose_cob.DisplayMember = "coursename";
            this.CourseChoose_cob.ValueMember = "courseid";


            //把文本框圆角化
            //this.TeacherSearchBar_txt.Region = Round(this.TeacherSearchBar_txt.Width, this.TeacherSearchBar_txt.Height, 20);
            //0this.StudentSearchBar_txt.Region = Round(this.StudentSearchBar_txt.Width, this.StudentSearchBar_txt.Height, 20);


            //创建考试时，要添加试题，一开始把所有题都显示再在这个dataview里面
            this.questions_dataView.DataSource = dl.ShowInfo(static_SQL_CRUD.AllInfoOfQuestionsBank).Tables["info"];

            //录题库时，要显示当前题库已存在的题
            this.questionsDisplay.DataSource = dl.ShowInfo(static_SQL_CRUD.AllInfoOfQuestionsBank).Tables["info"];





            //显示考试数据
            this.examDisplay_data.DataSource = dl.ShowInfo(static_SQL_CRUD.AllInfoOfExam).Tables["info"];

            if (this.examDisplay_data.RowCount > 0)
            {
                this.examDisplay_data.Visible = true;
                this.isDisplayExam_txt.Visible = false;
            }
            else
            {
                this.examDisplay_data.Visible = false;
                this.isDisplayExam_txt.Visible = true;
            }





        }
        //把数据库的学生表值添加到学生页面的DataGridView中
        public void Baind()
        {
            this.Student_data.DataSource = dl.ShowInfo(static_SQL_CRUD.AllInfoOfStudent).Tables["info"];
            //把数据库的老师表值添加到老师页面的DataGridView中
            this.Teacher_data.DataSource = dl.ShowInfo(static_SQL_CRUD.AllInfoOfTeacher).Tables["info"];
            //把数据库的管理员表值添加到管理员页面的DataGridView中
            this.Admin_data.DataSource = dl.ShowInfo(static_SQL_CRUD.AllInfoOfAdmin).Tables["info"];
            //题库表
            this.questionsDisplay.DataSource = dl.ShowInfo(static_SQL_CRUD.AllInfoOfQuestionsBank).Tables["info"];

            this.examDisplay_data.DataSource = dl.ShowInfo(static_SQL_CRUD.AllInfoOfExam).Tables["info"];
        }


        #region 按钮圆角化
        // 圆角代码 第一个参数是该元素的宽，第二个参数是元素的高，第三个参数是圆角半径
        public Region Round(int width, int height, int _Radius)
        {
            System.Drawing.Drawing2D.GraphicsPath oPath = new System.Drawing.Drawing2D.GraphicsPath();
            int x = 1;
            int y = 1;
            int thisWidth = width;
            int thisHeight = height;
            int angle = _Radius;
            if (angle > 0)
            {
                System.Drawing.Graphics g = CreateGraphics();
                oPath.AddArc(x, y, angle, angle, 180, 90); // 左上角
                oPath.AddArc(thisWidth - angle, y, angle, angle, 270, 90); // 右上角
                oPath.AddArc(thisWidth - angle, thisHeight - angle, angle, angle, 0, 90); // 右下角
                oPath.AddArc(x, thisHeight - angle, angle, angle, 90, 90); // 左下角

                oPath.CloseAllFigures();
                return new System.Drawing.Region(oPath);
            }
            // -----------------------------------------------------------------------------------------------
            else
            {
                oPath.AddLine(x + angle, y, thisWidth - angle, y); // 顶端
                oPath.AddLine(thisWidth, y + angle, thisWidth, thisHeight - angle); // 右边
                oPath.AddLine(thisWidth - angle, thisHeight, x + angle, thisHeight); // 底边
                oPath.AddLine(x, y + angle, x, thisHeight - angle); // 左边
                oPath.CloseAllFigures();
                return new System.Drawing.Region(oPath);
            }
        }

        /// <summary>
        /// 按钮圆角绘制事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            //TextBox txt = (TextBox)sender;
            btn.Region = Round(btn.Width, btn.Height, 30);
            //txt.Region = Round(txt.Width, txt.Height);

        }
        #endregion


        #region 无边框后导航栏拖动事件 2019/12/07  李健华
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
        private void pan_herderStrip_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        #endregion 

        #region 三大键处理事件 2019/12/07  李健华
        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 最小化按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void min_btn_Click(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Minimized;
            
        }

        /// <summary>
        /// 最大化按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        bool isMax = true;//矢量变量
        private void max_btn_Click(object sender, EventArgs e)
        {
            if (isMax)
            {
                this.WindowState = FormWindowState.Maximized;
                this.max_btn.Text = "▣";
                isMax = false;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.max_btn.Text = "☐";
                isMax = true;
            }

        }

        #endregion 

        //#region 导航栏健的Hover事件 2019/12/07  李健华
        //private void nav_mousehover(object sender, EventArgs e)
        //{
        //    //把本身点击的对象实例化出来
        //    Panel pal = (Panel)sender;
        //    //点击本身，本身就变色
        //    pal.BackColor = Color.White;
        //}

        //private void nav_mouseLeave(object sender, EventArgs e)
        //{
        //    //把本身点击的对象实例化出来
        //    Panel pal = (Panel)sender;
        //    //点击本身，本身就变色
        //    pal.BackColor = Color.Transparent;
        //}
        //#endregion


        /// <summary>
        /// 导航键的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nav_click(object sender, EventArgs e)
        {
            
            //把本身点击的对象实例化出来
            //object pal = null;

            //if (sender is Panel)
            //{
            //    pal = (Panel)sender;
            //}
            //else if (sender is Label)
            //{
            //    pal = (Label)sender;
            //}

            Panel pal = (Panel)sender;

            for (int i = 0; i < this.nav_pal.Controls.Count; i++)
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
            Admin_Load(null, null);
        }


        #region 主内容区适应屏幕
        /// <summary> 
        /// 控件随窗体自动缩放 
        /// </summary> 
        /// <param name="frm"></param> 
        public static void AutoScale(Admin frm)
        {
            frm.Tag = frm.Width.ToString() + "," + frm.Height.ToString();
            frm.SizeChanged += new EventHandler(frm_SizeChanged);
        }

        static void frm_SizeChanged(object sender, EventArgs e)
        {
            string[] tmp = ((Admin)sender).Tag.ToString().Split(',');
            float width = (float)((Admin)sender).Width / (float)Convert.ToInt16(tmp[0]);
            float heigth = (float)((Admin)sender).Height / (float)Convert.ToInt16(tmp[1]);

            ((Form)sender).Tag = ((Admin)sender).Width.ToString() + "," + ((Admin)sender).Height;

            foreach (Control control in ((Admin)sender).mainPage_pal.Controls)
            {
                control.Scale(new SizeF(width, heigth));

            }
        }


        #endregion






        /// <summary>
        /// 查看密码的小眼睛按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        bool isDisplay = true;
        private void eye_btn_Click(object sender, EventArgs e)
        {
            if (isDisplay)
            {
                password_txt.PasswordChar = new char();
                eye_btn.BackgroundImage = Online_examination_system.Properties.Resources.closeEyes;
                isDisplay = false;
                return;
            }
            if (!isDisplay)
            {
                password_txt.PasswordChar = '*';//清空PasswordChar文本
                eye_btn.BackgroundImage = Online_examination_system.Properties.Resources.openEye;
                isDisplay = true;
                return;
            }
        }




        /// <summary>
        /// 搜索框按Enter键即搜索事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBar_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //把本身实例化出来
                TextBox txt = (TextBox)sender;

                //把当前搜索框里面的内容存到一个静态类里面
                staticModle.SearchContent = txt.Text;

                //当框类不为空才执行搜索
                if (!txt.Text.Equals(""))
                {
                    //如果是学生就搜索学生表
                    if (txt.Name == "StudentSearchBar_txt")
                    {
                        //把模糊搜索学生表值添加到学生页面的DataGridView中
                        this.Student_data.DataSource = dl.ShowInfo(static_SQL_CRUD.StudentFuzzySearch()).Tables["info"];
                    }
                    if (txt.Name == "TeacherSearchBar_txt")
                    {
                        //把模糊搜索学生表值添加到学生页面的DataGridView中
                        this.Teacher_data.DataSource = dl.ShowInfo(static_SQL_CRUD.TeacherFuzzySearch()).Tables["info"];
                    }

                }
                else//为空时，就搜索全部信息
                {
                    //如果是学生就搜索学生表
                    if (txt.Name == "StudentSearchBar_txt")
                    {

                        //把模糊搜索学生表值添加到学生页面的DataGridView中
                        this.Student_data.DataSource = dl.ShowInfo(static_SQL_CRUD.AllInfoOfStudent).Tables["info"];
                    }
                    if (txt.Name == "TeacherSearchBar_txt")
                    {
                        //把模糊搜索学生表值添加到学生页面的DataGridView中
                        this.Teacher_data.DataSource = dl.ShowInfo(static_SQL_CRUD.AllInfoOfTeacher).Tables["info"];
                    }
                }
            }
        }



        /// <summary>
        /// 搜索栏按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Search_btn_Click(object sender, EventArgs e)
        {

            //把本身实例化出来
            Button btn = (Button)sender;

            //当框类不为空执行相应搜索
            if (!StudentSearchBar_txt.Text.Equals("") || !TeacherSearchBar_txt.Text.Equals(""))
            {
                //如果是学生就搜索学生表
                if (btn.Name.Equals("StudentSearch_btn"))
                {
                    staticModle.SearchContent = StudentSearchBar_txt.Text;
                    //把模糊搜索学生表值添加到学生页面的DataGridView中
                    this.Student_data.DataSource = dl.ShowInfo(static_SQL_CRUD.StudentFuzzySearch()).Tables["info"];
                }
                if (btn.Name.Equals("TeacherSearch_btn"))
                {
                    staticModle.SearchContent = TeacherSearchBar_txt.Text;
                    //把模糊搜索学生表值添加到学生页面的DataGridView中
                    this.Teacher_data.DataSource = dl.ShowInfo(static_SQL_CRUD.TeacherFuzzySearch()).Tables["info"];
                }

            }
            else//为空时，就搜索全部信息
            {
                //如果是学生就搜索学生表
                if (btn.Name.Equals("StudentSearch_btn"))
                {
                    //把模糊搜索学生表值添加到学生页面的DataGridView中
                    this.Student_data.DataSource = dl.ShowInfo(static_SQL_CRUD.AllInfoOfStudent).Tables["info"];
                }
                //如果是老师就搜索老师表
                if (btn.Name == "TeacherSearch_btn")
                {
                    //把模糊搜索学生表值添加到学生页面的DataGridView中
                    this.Teacher_data.DataSource = dl.ShowInfo(static_SQL_CRUD.AllInfoOfTeacher).Tables["info"];
                }
            }
        }


        /// <summary>
        /// 添加信息事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddInfo_Click(object sender, EventArgs e)
        {
            //把当前点击本身实例化出来
            Button btn = (Button)sender;
            //把添加信息的界面new出来
            AddStudent addInfo = new AddStudent();
            addInfo.Updata_btn.Visible = false;
            addInfo.updataInfo_lable.Visible = false;
            switch (btn.Name)
            {
                case "AddStudent_btn":

                    //获取当前dataview中最后一行的值在加1，这样就是自动增加学号了
                    addInfo.stuid_txt.Text = (Convert.ToInt32(dl.ShowInfo(static_SQL_CRUD.AllInfoOfStudent).Tables["info"].Rows[dl.ShowInfo(static_SQL_CRUD.AllInfoOfStudent).Tables["info"].Rows.Count - 1][0]) + 1).ToString();

                    addInfo.AddStudent_pal.Visible = true;
                    //addInfo.ShowDialog();
                    if (addInfo.ShowDialog() == DialogResult.OK)
                    {
                        Baind();
                    }

                    break;

                case "AddTeacher_btn":
                    addInfo.teacherid_txt.Text = (Convert.ToInt32(dl.ShowInfo(static_SQL_CRUD.AllInfoOfTeacher).Tables["info"].Rows[dl.ShowInfo(static_SQL_CRUD.AllInfoOfTeacher).Tables["info"].Rows.Count - 1][0]) + 1).ToString();
                    addInfo.AddTeacher_pal.Visible = true;
                    if (addInfo.ShowDialog() == DialogResult.OK)
                    {
                        Baind();
                    }
                    break;

                case "AddAdmin_btn":
                    addInfo.adminid_txt.Text = (Convert.ToInt32(dl.ShowInfo(static_SQL_CRUD.AllInfoOfAdmin).Tables["info"].Rows[dl.ShowInfo(static_SQL_CRUD.AllInfoOfAdmin).Tables["info"].Rows.Count - 1][0]) + 1).ToString();
                    addInfo.AddAdmin_pal.Visible = true;
                    if (addInfo.ShowDialog() == DialogResult.OK)
                    {
                        Baind();
                    }
                    break;
            }
        }




        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdataInfo_Click(object sender, EventArgs e)
        {
            //把当前点击本身实例化出来
            Button btn = (Button)sender;
            //把修改页面new出来
            AddStudent updata = new AddStudent();
            //确认按钮不显示
            updata.Confirm_btn.Visible = false;
            updata.addInfo_lable.Visible = false;
            //修改时ID不能修改
            updata.stuid_txt.ReadOnly = true;
            updata.teacherid_txt.ReadOnly = true;

            int checkedCount = 0;//checked的行数

            switch (btn.Name)
            {
                case "UpdataStudent_btn":

                    for (int i = 0; i < this.Student_data.Rows.Count; i++)
                    {
                        if (this.Student_data.Rows[i].Cells[0].FormattedValue.ToString().ToUpper() == "TRUE")
                        {
                            checkedCount++;
                        }
                    }

                    if (checkedCount == 1)
                    {


                        for (int i = 0; i < this.Student_data.Rows.Count; i++)
                        {
                            if (this.Student_data.Rows[i].Cells[0].FormattedValue.ToString().ToUpper() == "TRUE")
                            {
                                //获取当前选中行的关键字段存到用户字段静态类中
                                staticModle.DU = new List<string>();
                                staticModle.DU.Add(this.Student_data.Rows[i].Cells[1].Value.ToString());
                                updata.AddStudent_pal.Visible = true;
                                updata.AddTeacher_pal.Visible = false;
                                updata.AddAdmin_pal.Visible = false;
                            }
                        }



                        //刷新
                        if (updata.ShowDialog() == DialogResult.OK)
                        {
                            Baind();
                        }

                    }
                    else if (checkedCount <= 0)
                    {
                        MessageBox.Show("请选中要修改的信息!!");
                    }
                    else { MessageBox.Show("只能单个修改！！"); }
                    checkedCount = 0;
                    break;

                case "TeacherUpdata_btn":
                    for (int i = 0; i < this.Teacher_data.Rows.Count; i++)
                    {
                        if (this.Teacher_data.Rows[i].Cells[0].FormattedValue.ToString().ToUpper() == "TRUE")
                        {
                            checkedCount++;
                        }
                    }
                    if (checkedCount == 1)
                    {

                        for (int i = 0; i < this.Teacher_data.Rows.Count; i++)
                        {
                            if (this.Teacher_data.Rows[i].Cells[0].FormattedValue.ToString().ToUpper() == "TRUE")
                            {
                                //获取当前选中行的关键字段存到用户字段静态类中
                                staticModle.DU = new List<string>();
                                staticModle.DU.Add(this.Teacher_data.Rows[i].Cells[1].Value.ToString());
                                updata.AddTeacher_pal.Visible = true;
                                updata.AddStudent_pal.Visible = false;
                                updata.AddAdmin_pal.Visible = false;
                            }
                        }



                        //刷新
                        if (updata.ShowDialog() == DialogResult.OK)
                        {
                            Baind();
                        }


                    }
                    else if (checkedCount <= 0)
                    {
                        MessageBox.Show("请选中要修改的信息!!");
                    }
                    else { MessageBox.Show("只能单个修改！！"); }
                    checkedCount = 0;
                    break;

                case "AdminUpdataInfo_btn":
                    DialogResult res = MessageBox.Show("确定修改！！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (res == DialogResult.OK)
                    {
                        //点击修改就把当前文本框的值赋给staticModle类里
                        staticModle.adminid = this.ID_txt.Text;
                        staticModle.adminname = this.Name_txt.Text;
                        staticModle.password = this.password_txt.Text;
                        if (dl.Updta(static_SQL_CRUD.UpdataAdmin()) > 0)
                        {
                            MessageBox.Show("修改成功！！");
                        }
                        else
                        {
                            MessageBox.Show("修改失败！！");
                        }
                    }
                    break;

            }
            


        }





        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteInfo_Click(object sender, EventArgs e)
        {
            //把点击本身实例化出来
            Button btn = (Button)sender;
            //存放选中行的ID
            List<string> DeleteKeys = new List<string>();
            int returnCount = 0;//返回影响行数

            int checkedCount = 0;//checked的行数




            switch (btn.Name)
            {
                case "DeleteStudent_btn":
                    if (this.Student_data.SelectedRows.Count > 0)
                    {
                        for (int i = 0; i < this.Student_data.Rows.Count; i++)
                        {
                            if (this.Student_data.Rows[i].Cells[0].FormattedValue.ToString().ToUpper() == "TRUE")
                            {
                                checkedCount++;
                            }
                        }
                        DialogResult res = MessageBox.Show("确定删除" + checkedCount + "条信息！！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (res == DialogResult.OK)
                        {
                            //获取当前选中行的关键字段存到一个集合里面
                            for (int i = 0; i < this.Student_data.Rows.Count; i++)
                            {
                                if (this.Student_data.Rows[i].Cells[0].FormattedValue.ToString().ToUpper() == "TRUE")
                                {
                                    DeleteKeys.Add(this.Student_data.Rows[i].Cells[1].Value.ToString());
                                }

                            }

                            //逐条删除
                            for (int i = 0; i < DeleteKeys.Count; i++)
                            {
                                returnCount += dl.Dalete(static_SQL_CRUD.DeleteStudent(DeleteKeys[i]));
                            }
                            if (returnCount > 0)
                            {
                                MessageBox.Show("成功删除" + returnCount + "条数据!!");
                                this.Student_data.DataSource = dl.ShowInfo(static_SQL_CRUD.AllInfoOfStudent).Tables["info"];
                                returnCount = 0;//重置返回影响数
                            }
                            else
                            {
                                MessageBox.Show("删除失败！");
                            }
                            checkedCount = 0;//重置选中数

                        }
                    }
                    else
                    {
                        MessageBox.Show("请选中要修改的信息!!");
                    }
                    break;
                case "Deleteteacher_btn":
                    if (this.Teacher_data.SelectedRows.Count > 0)
                    {
                        for (int i = 0; i < this.Teacher_data.Rows.Count; i++)
                        {
                            if (this.Teacher_data.Rows[i].Cells[0].FormattedValue.ToString().ToUpper() == "TRUE")
                            {
                                checkedCount++;
                            }
                        }
                        DialogResult res = MessageBox.Show("确定删除" + checkedCount + "条信息！！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (res == DialogResult.OK)
                        {
                            //获取当前选中行的关键字段存到一个集合里面
                            //依次吧选中行的ID赋给数组
                            for (int i = 0; i < this.Teacher_data.Rows.Count; i++)
                            {
                                if (this.Teacher_data.Rows[i].Cells[0].FormattedValue.ToString().ToUpper() == "TRUE")
                                {
                                    DeleteKeys.Add(this.Teacher_data.Rows[i].Cells[1].Value.ToString());
                                }

                            }

                            //逐条删除
                            for (int i = 0; i < DeleteKeys.Count; i++)
                            {
                                returnCount += dl.Dalete(static_SQL_CRUD.DeleteTeacher(DeleteKeys[i]));
                            }
                            if (returnCount > 0)
                            {
                                MessageBox.Show("成功删除" + returnCount + "条数据!!");
                                //把数据库的老师表值添加到老师页面的DataGridView中
                                this.Teacher_data.DataSource = dl.ShowInfo(static_SQL_CRUD.AllInfoOfTeacher).Tables["info"];
                                returnCount = 0;//重置返回影响数
                            }
                            else
                            {
                                MessageBox.Show("删除失败！");
                            }
                            checkedCount = 0;

                        }
                    }
                    else
                    {
                        MessageBox.Show("请选中要修改的信息!!");
                    }
                    break;
                case "DeleteAdmin_btn":


                    //还要判断一层，就是不能删除自己，如果是自己的账号不进入if！！

                    //外面还有一层判断就是如果管理员个数只有一个时不能进行删除了
                    if (this.Admin_data.Rows.Count > 1)
                    {
                        //获取选中的行数
                        for (int i = 0; i < this.Admin_data.Rows.Count; i++)
                        {
                            if (this.Admin_data.Rows[i].Cells[0].FormattedValue.ToString().ToUpper() == "TRUE")
                            {
                                checkedCount++;
                            }
                        }


                        if (checkedCount > 0 && checkedCount < this.Admin_data.Rows.Count)
                        {
                            DialogResult res = MessageBox.Show("确定删除" + checkedCount + "条信息！！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (res == DialogResult.OK)
                            {
                                //获取当前选中行的关键字段存到一个集合里面
                                for (int i = 0; i < this.Admin_data.Rows.Count; i++)
                                {
                                    if (this.Admin_data.Rows[i].Cells[0].FormattedValue.ToString().ToUpper() == "TRUE")
                                    {
                                        DeleteKeys.Add(this.Admin_data.Rows[i].Cells[1].Value.ToString());
                                    }

                                }

                                //逐条删除
                                for (int i = 0; i < DeleteKeys.Count; i++)
                                {
                                    returnCount += dl.Dalete(static_SQL_CRUD.DeleteAdmin(DeleteKeys[i]));
                                }
                                if (returnCount > 0)
                                {
                                    MessageBox.Show("成功删除" + returnCount + "条数据!!");
                                    //把数据库的管理员表值添加到管理员页面的DataGridView中
                                    this.Admin_data.DataSource = dl.ShowInfo(static_SQL_CRUD.AllInfoOfAdmin).Tables["info"];
                                    returnCount = 0;//重置返回影响数
                                }
                                else
                                {
                                    MessageBox.Show("删除失败！");
                                }
                                checkedCount = 0;

                            }
                        }
                        else if (checkedCount == this.Admin_data.Rows.Count)
                        {
                            MessageBox.Show("至少保留一名管理员！！");
                        }
                        else
                        {
                            MessageBox.Show("请选中要删除的管理员!!");
                        }

                    }

                    else
                    {
                        MessageBox.Show("至少保留一个管理员！！");
                    }

                    break;

            }


        }

        /// <summary>
        /// 录入题库事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool regTxt()//文本框验证
        {
            for (int i = 0; i < inputQuestionsArea_pan.Controls.Count; i++)
            {
                if (inputQuestionsArea_pan.Controls[i].Text.Equals("")) { MessageBox.Show("信息不全！！"); return false; }
                if (inputQuestionsArea_pan.Controls[i].Name.Equals("correctAnswer_txt") || inputQuestionsArea_pan.Controls[i].Name.Equals("wrongAnswer_txt"))
                {
                    string anwerText = inputQuestionsArea_pan.Controls[i].Text;
                    //验证字符串是否正确，str.Contains(",,") 指表示该字符串是否含有",,"
                    if (anwerText.Substring(0, 1).Equals(",") || anwerText.Substring(anwerText.Length - 1, 1).Equals(",") || anwerText.Contains(",,"))
                    {
                        MessageBox.Show("输入的答案格式不对！！    例：值1,值2,值3");
                        inputQuestionsArea_pan.Controls[i].BackColor = Color.Red;
                        return false;
                    }
                    else
                    {
                        inputQuestionsArea_pan.Controls[i].BackColor = Color.White;
                    }
                }
                
            }
            if (this.score_num.Text.Equals("0.0"))
            {
                MessageBox.Show("分数未设置！！");
                return false;
            }
            return true;
        }
        private void entry_btn_Click(object sender, EventArgs e)
        {
            if (regTxt())
            {
                DialogResult res = MessageBox.Show("确定录入该题！！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {
                    //获取当前的题框的内容
                    staticModle.subject = this.subjects_txt.Text.ToString();
                    staticModle.questiontype = this.questionType_cob.Text;
                    staticModle.questionText = this.question_txt.Text;
                    staticModle.correctAnswer = this.correctAnswer_txt.Text;
                    staticModle.wrongAnswer = this.wrongAnswer_txt.Text;
                    staticModle.score = Convert.ToDouble(this.score_num.Text);
                    if (dl.AddInfo(static_SQL_CRUD.AddQuestions()) > 0)
                    {
                        MessageBox.Show("添加成功！！");

                        //清除文本框类容
                        clearProblem_btn_Click(null, null);

                        //刷新
                        this.questionsDisplay.DataSource = dl.ShowInfo(static_SQL_CRUD.AllInfoOfQuestionsBank).Tables["info"];
                    }
                    else
                    {
                        MessageBox.Show("添加失败！！");
                    }
                }
            }



        }

        /// <summary>
        /// 录题清空文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearProblem_btn_Click(object sender, EventArgs e)
        {
            this.question_txt.Text = "";
            this.correctAnswer_txt.Text = "";
            this.wrongAnswer_txt.Text = "";
        }

        /// <summary>
        /// 删除题库里的题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除该题ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("确定删除该题！！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                if (dl.Dalete(static_SQL_CRUD.deleteQuestions(Convert.ToInt32(this.questionsDisplay.SelectedRows[0].Cells[0].Value.ToString()))) > 0)
                {
                    MessageBox.Show("删除成功！！");
                    this.questionsDisplay.DataSource = dl.ShowInfo(static_SQL_CRUD.AllInfoOfQuestionsBank).Tables["info"];
                }
                else
                {
                    MessageBox.Show("删除失败！！");
                }
            }

        }

        /// <summary>
        /// 修改该题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 修改该题ToolStripMenuItem_Click(object sender, EventArgs e)
        {
                AddStudent updataQuestions = new AddStudent();

                //相应内容显示
                updataQuestions.UpdataQuestions_lab.Visible = true;
                updataQuestions.Updata_btn.Visible = true;
                updataQuestions.Confirm_btn.Visible = false;
                updataQuestions.addInfo_lable.Visible = false;
                updataQuestions.UpdataQuestions_pal.Visible = true;
                updataQuestions.AddTeacher_pal.Visible = false;
                updataQuestions.AddStudent_pal.Visible = false;
                updataQuestions.AddAdmin_pal.Visible = false;


                //显示当前信息
                updataQuestions.subjects_txt.Text = this.questionsDisplay.SelectedRows[0].Cells[1].Value.ToString();
                updataQuestions.questionType_cob.Text = this.questionsDisplay.SelectedRows[0].Cells[2].Value.ToString();
                updataQuestions.question_txt.Text = this.questionsDisplay.SelectedRows[0].Cells[3].Value.ToString();
                updataQuestions.correctAnswer_txt.Text = this.questionsDisplay.SelectedRows[0].Cells[4].Value.ToString();
                updataQuestions.wrongAnswer_txt.Text = this.questionsDisplay.SelectedRows[0].Cells[5].Value.ToString();
                updataQuestions.score_num.Value =  Convert.ToDecimal(this.questionsDisplay.SelectedRows[0].Cells[6].Value);


            //get到把关键字段
            staticModle.questionId =  Convert.ToInt32(this.questionsDisplay.SelectedRows[0].Cells[0].Value);

            //刷新
            if (updataQuestions.ShowDialog() == DialogResult.OK)
            {
                Baind();
            }
        }




        /// <summary>
        /// 创建考试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createExamination_Click(object sender, EventArgs e)
        {
           
            DialogResult res = MessageBox.Show("确定创建！！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {

                //获取该考试的内容
                staticModle.examname = this.examname_txt.Text;
                staticModle.subjects = this.CourseChoose_cob.Text;
                staticModle.examdatet = Convert.ToDateTime(this.examdate_dtp.Text);
                staticModle.examObject = this.examObject_txt.Text;
                string questions = "";//题号

                for (int i = 0; i < this.questions_dataView.RowCount; i++)
                {
                    //判断勾选项是否被勾选
                    if (this.questions_dataView.Rows[i].Cells[0].FormattedValue.ToString().ToUpper() == "TRUE")
                    {
                        questions += this.questions_dataView.Rows[i].Cells[1].Value.ToString() + ",";
                    }

                }
                
                staticModle.questions = questions.Substring(0, questions.Length-1);


              

                if (dl.AddInfo(static_SQL_CRUD.createExamination()) > 0)
                {
                    MessageBox.Show("创建成功！！");
                    //刷新examDisplay_data
                    this.examDisplay_data.DataSource = dl.ShowInfo(static_SQL_CRUD.AllInfoOfExam).Tables["info"];
                    if (this.examDisplay_data.RowCount > 0)
                    {
                        this.examDisplay_data.Visible = true;
                        this.isDisplayExam_txt.Visible = false;
                    }
                    else
                    {
                        this.examDisplay_data.Visible = false;
                        this.isDisplayExam_txt.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("创建失败！！");
                }
            }
            //}
            //else
            // {
            // MessageBox.Show("请选择题");
            // }
        }

        /// <summary>
        /// 删除考试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除考试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("确定删除" + this.examDisplay_data.SelectedRows[0].Cells[1].Value.ToString() + "！！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                if (dl.Dalete(static_SQL_CRUD.deleteExam(this.examDisplay_data.SelectedRows[0].Cells[0].Value.ToString())) > 0)
                {
                    MessageBox.Show("删除考试成功！！");
                    this.examDisplay_data.DataSource = dl.ShowInfo(static_SQL_CRUD.AllInfoOfExam).Tables["info"];
                    if (this.examDisplay_data.RowCount > 0)
                    {
                        this.examDisplay_data.Visible = true;
                        this.isDisplayExam_txt.Visible = false;
                    }
                    else
                    {
                        this.examDisplay_data.Visible = false;
                        this.isDisplayExam_txt.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("删除失败！！");
                }
            }
        }

        /// <summary>
        /// 修改考试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 修改考试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

           DataSet ds =  dl.ShowInfo(static_SQL_CRUD.SingleExaminfoTrue(this.examDisplay_data.SelectedRows[0].Cells[0].Value.ToString()));
           
            //存该考试的题号
            string[] questions = ds.Tables["info"].Rows[0][5].ToString().Split(',');

            UpdataExamAndQuestionsInfo exam = new UpdataExamAndQuestionsInfo(questions);
            exam.examID_txt.Text = ds.Tables["info"].Rows[0][0].ToString();
            exam.examName_txt.Text = this.examDisplay_data.SelectedRows[0].Cells[0].Value.ToString();
            exam.examSubject_com.Text = this.examDisplay_data.SelectedRows[0].Cells[1].Value.ToString();

            exam.examTime_dtp.Text = ds.Tables["info"].Rows[0][3].ToString();
            exam.examObject_com.Text = ds.Tables["info"].Rows[0][4].ToString();
            
            exam.questions_dataView.DataSource = this.questions_dataView.DataSource;





            //刷新
            if (exam.ShowDialog() == DialogResult.OK)
            {
                Baind();
            }




        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancel_btn_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("确定注销！！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                Lishushun.LoginFrm loginFrm = new Lishushun.LoginFrm();
                loginFrm.combType.Text = this.UserType_txt.Text;
                loginFrm.admintxt.Text = this.Name_txt.Text;
                loginFrm.pwdtxt.Text = this.password_txt.Text;

                loginFrm.Show();
                this.Close();
            }
        }

        /// <summary>
        /// 筛选科目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CourseChoose_cob_SelectedIndexChanged(object sender, EventArgs e)
        {
            staticModle.subjects = this.CourseChoose_cob.Text;
            this.questions_dataView.DataSource = dl.ShowInfo(static_SQL_CRUD.partOfQuestions()).Tables["info"];
        }



        /// <summary>
        /// 各个信息表的条件查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView tv = (TreeView)sender;

            //正则表达式
            Regex firstWord = new Regex("^[0-9]$");

            if (firstWord.IsMatch(tv.SelectedNode.Text.Substring(0, 1)))
            {
                staticModle.SearchContent = tv.SelectedNode.Text.Substring(0, 1);
            }
            else
            {
                staticModle.SearchContent = tv.SelectedNode.Text;
            }


            switch (tv.Name)
            {
                case "Student_treeView":
                    if (firstWord.IsMatch(tv.SelectedNode.Text.Substring(0, 1)))
                    {
                        this.Student_data.DataSource = dl.ShowInfo(static_SQL_CRUD.AgeStudentFuzzySearch()).Tables["info"];
                    }
                    else
                    {
                        this.Student_data.DataSource = dl.ShowInfo(static_SQL_CRUD.StudentFuzzySearch()).Tables["info"];
                    }

                    break;

                case "Teacher_treeView":
                    if (firstWord.IsMatch(tv.SelectedNode.Text.Substring(0, 1)))
                    {
                        this.Teacher_data.DataSource = dl.ShowInfo(static_SQL_CRUD.AgeTeacherFuzzySearch()).Tables["info"];
                    }
                    else
                    {
                        this.Teacher_data.DataSource = dl.ShowInfo(static_SQL_CRUD.TeacherFuzzySearch()).Tables["info"];
                    }

                    break;
            }


        }


        /// <summary>
        /// 创建考试筛选题的类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chooseQuestionsType_cob_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.chooseQuestionsType_cob.SelectedIndex != 0)
            {
                this.questions_dataView.DataSource = dl.ShowInfo(static_SQL_CRUD.QuestionsFuzzySearch(this.chooseQuestionsType_cob.Text, this.CourseChoose_cob.Text)).Tables["info"];
            }
            else
            {
                this.questions_dataView.DataSource = dl.ShowInfo(static_SQL_CRUD.partOfQuestions()).Tables["info"];
            }
        }




        /// <summary>
        /// 全选按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectAll_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                switch (cb.Name)
                {
                    case "SelectAllInfoOfStudent_checkBox":
                        for (int i = 0; i < this.Student_data.RowCount; i++)
                        {
                            this.Student_data.Rows[i].Cells[0].Value = true;
                        }
                        break;
                    case "SelectAllInfoOfTeacher_checkBox":
                        for (int i = 0; i < this.Teacher_data.RowCount; i++)
                        {
                            this.Teacher_data.Rows[i].Cells[0].Value = true;
                        }
                        break;
                    case "SelectAllInfoOfAdmin_checkBox":
                        for (int i = 0; i < this.Admin_data.RowCount; i++)
                        {
                            this.Admin_data.Rows[i].Cells[0].Value = true;
                        }
                        break;


                }

            }
            else
            {
                switch (cb.Name)
                {
                    case "SelectAllInfoOfStudent_checkBox":
                        for (int i = 0; i < this.Student_data.RowCount; i++)
                        {
                            this.Student_data.Rows[i].Cells[0].Value = false;
                        }
                        break;

                    case "SelectAllInfoOfTeacher_checkBox":
                        for (int i = 0; i < this.Teacher_data.RowCount; i++)
                        {
                            this.Teacher_data.Rows[i].Cells[0].Value = false;
                        }
                        break;
                    case "SelectAllInfoOfAdmin_checkBox":
                        for (int i = 0; i < this.Admin_data.RowCount; i++)
                        {
                            this.Admin_data.Rows[i].Cells[0].Value = false;
                        }
                        break;
                }
            }
        }

        

        



    }
}
