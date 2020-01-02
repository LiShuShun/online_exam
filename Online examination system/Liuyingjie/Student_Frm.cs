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
using System.Data.SqlClient;

namespace Online_examination_system.Liuyingjie
{
    public partial class Student_Frm : Form
    {
        public Student_Frm()
        {
            InitializeComponent();
        }

        #region 窗口事件
        /// <summary>
        /// 窗口拖动事件
        /// </summary>
        /// <returns></returns>
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
        private void panel_head_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        /// <summary>
        /// 关闭窗口特效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AW_BLEND | AW_HIDE);
            Application.Exit();
            this.Dispose();
        }


        /// <summary>
        /// 最小化窗口点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btn_Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 最大化窗体点击事件
        /// </summary>
        bool isMax = true;//矢量变量
        private void btn_Max_Click(object sender, EventArgs e)
        {
            if (isMax)
            {
                this.WindowState = FormWindowState.Maximized;
                isMax = false;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                isMax = true;
            }

        }
        #endregion

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

        #region panel点击事件
        /// <summary>
        /// 点击按钮切换界面panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_click(object sender, EventArgs e)
        {
            //把本身点击的对象实例化出来
            Panel pal = (Panel)sender;
            // MessageBox.Show(this.nav_pal.Controls.Count.ToString());

            for (int i = 0; i < this.panel_Btn.Controls.Count; i++)
            {

                if (i != this.panel_Btn.Controls.IndexOf(pal))//这里的判断条件要写不是当前控件为真
                {
                    //判断不是当前点击pal控件的其他pal控件变色
                    this.panel_Btn.Controls[i].BackColor = Color.Transparent;
                    //不是对应的内容页面就不显示
                    this.panel_Content.Controls[i].Visible = false;
                }
                else
                {
                    //点击本身，本身就变色
                    this.panel_Btn.Controls[i].BackColor = Color.FromArgb(30, 39, 44);
                    //对应的内容页面就显示
                    this.panel_Content.Controls[i].Visible = true;
                }
            }

        }
        #endregion

        #region 数据库操作
        StuDB SDB = new StuDB();
        string str = "Data Source=.;Initial Catalog=OnlineExamSys;Integrated Security=True";//连接数据源
        SqlConnection conn = null; //连接数据库
        SqlCommand comd = null;//执行操作
        SqlDataAdapter pter = null;//数据适配器
        DataSet ds = null; //数据集
        string sql = null;

        /// <summary>
        /// 窗口加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Student_Frm_Load(object sender, EventArgs e)
        {
            //加载时调用个人信息类
            SDB.StuAllInfo();
            //登录用户参数传递
            txt_Purviewwid.Text = Online_examination_system.UserInfo._Power;
            txt_Stuid.Text = Online_examination_system.UserInfo._LogId;
            txt_Password.Text = Online_examination_system.UserInfo._Password;
            //登录后显示用户名
            StuInfo();

            //录入考试信息数据
            this.DGV_ExamInfo.Hide();
            this.label15.Hide();
            this.DGV_ExamInfo.DataSource = SDB.ExamInfo().Tables["Examination_list"];
            if (DGV_ExamInfo.RowCount > 0)
                this.DGV_ExamInfo.Show();
            else
                this.label15.Show();

            //录入成绩查询信息
            this.DGV_ExamResult.Hide();
            this.label13.Hide();
            this.DGV_ExamResult.DataSource = SDB.StuExamSelect().Tables["EndExamSocre"];
            if (DGV_ExamResult.RowCount > 0)
                this.DGV_ExamResult.Show();
            else
                this.label13.Show();

            //录入个人信息
            txt_StuName.Text = UserInfo._StuName;
            txt_StuClass.Text = UserInfo._StuClass;
            txt_StuAge.Text = UserInfo._StuAge;
            txt_Major.Text = UserInfo._Major;
            txt_Dapartment.Text = UserInfo._Dapartment;
            txt_Note.Text = UserInfo._Note;

            int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
        }

        /// <summary>
        /// 登录进去读取名字
        /// </summary>
        public void StuInfo()
        {
            //查询名字
            conn = new SqlConnection(str);
            sql = string.Format("select * from Student_list where stuid='{0}'", txt_Stuid.Text);
            comd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                SqlDataReader dr = comd.ExecuteReader();
                while (dr.Read())
                {
                    label16.Text = string.Format("欢迎您，{0}", dr["stuname"]);
                    label17.Text = string.Format("欢迎您，{0}", dr["stuname"]);
                }

            }
            catch (Exception)
            {
            }
            finally { conn.Close(); };
        }

        /// <summary>
        /// 点击个人信息按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDB_click(object sender, EventArgs e)
        {
            //把本身点击的对象实例化出来
            Panel pal = (Panel)sender;
            // MessageBox.Show(this.nav_pal.Controls.Count.ToString());
            for (int i = 0; i < this.panel_Btn.Controls.Count; i++)
            {

                if (i != this.panel_Btn.Controls.IndexOf(pal))//这里的判断条件要写不是当前控件为真
                {
                    //判断不是当前点击pal控件的其他pal控件变色
                    this.panel_Btn.Controls[i].BackColor = Color.Transparent;
                    //不是对应的内容页面就不显示
                    this.panel_Content.Controls[i].Visible = false;
                }
                else
                {
                    //点击本身，本身就变色
                    this.panel_Btn.Controls[i].BackColor = Color.FromArgb(30, 39, 44);
                    //对应的内容页面就显示
                    this.panel_Content.Controls[i].Visible = true;
                }
            }


        }

        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(str);
            sql = string.Format(@"update Student_list set stuage={0},password='{1}',note='{2}' where stuid='{3}'"
                                   , txt_StuAge.Text, txt_Password.Text, txt_Note.Text, txt_Stuid.Text);
            comd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                int reuslt = comd.ExecuteNonQuery();
                if (reuslt > 0)
                {
                    MessageBox.Show("修改成功！");
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
            }
            catch (Exception)
            {

            }
            finally { conn.Close(); }
        }

        /// <summary>
        /// datagridview事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGV_ExamInfo_CellPaintingD(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)

            {

                if (this.DGV_ExamInfo.Columns[e.ColumnIndex].HeaderText == "操作")

                {

                    StringFormat sf = StringFormat.GenericDefault.Clone() as StringFormat;//设置重绘入单元格的字体样式
                    sf.FormatFlags = StringFormatFlags.DisplayFormatControl;
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Trimming = StringTrimming.EllipsisCharacter;
                    e.PaintBackground(e.CellBounds, false);//重绘边框
                    //设置要写入字体的大小
                    System.Drawing.Font myFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    SizeF sizeDel = e.Graphics.MeasureString("进入考试", myFont);


                    float fDel = sizeDel.Width / (sizeDel.Width);

                    //设置每个“按钮的边界”
                    RectangleF rectDel = new RectangleF(e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Width * fDel, e.CellBounds.Height);
                    RectangleF rectMod = new RectangleF(rectDel.Right, e.CellBounds.Top, e.CellBounds.Width, e.CellBounds.Height);

                    e.Graphics.DrawString("进入考试", myFont, Brushes.Blue, rectDel, sf);

                    e.Handled = true;
                }

            }
        }
        private void DGV_ExamInfo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                Point curPosition = e.Location;//当前鼠标在当前单元格中的坐标
                if (this.DGV_ExamInfo.Columns[e.ColumnIndex].HeaderText == "操作")
                {
                    Graphics g = this.DGV_ExamInfo.CreateGraphics();
                    System.Drawing.Font myFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    SizeF sizeDel = g.MeasureString("进入考试", myFont);

                    float fDel = sizeDel.Width / (sizeDel.Width);

                    Rectangle rectTotal = new Rectangle(0, 0, this.DGV_ExamInfo.Columns[e.ColumnIndex].Width, this.DGV_ExamInfo.Rows[e.RowIndex].Height);
                    RectangleF rectDel = new RectangleF(rectTotal.Left, rectTotal.Top, rectTotal.Width * fDel, rectTotal.Height);

                    //判断当前鼠标在哪个“按钮”范围内

                    if (rectDel.Contains(curPosition))//编辑
                    {

                        int UID = Convert.ToInt32(DGV_ExamInfo.CurrentRow.Cells["Column5"].Value);
                        UserInfo._ExamId = UID;

                        DialogResult isok = MessageBox.Show("点击确认开始考试！确认后考试开始倒计时！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (isok == DialogResult.OK)
                        {

                            UserInfo.ExamName = DGV_ExamInfo.CurrentRow.Index;
                            //获取那张试卷的试题
                            DataSet ExamQuestionDS = SDB.ExamQuestionID();
                            //将试题分隔出来
                            string Questions = ExamQuestionDS.Tables["Examination_list"].Rows[0][0].ToString();
                            UserInfo._ExamQuestion = Questions.Split(',');

                            UserInfo._Examtype = DGV_ExamInfo.CurrentRow.Cells["Column1"].Value.ToString();
                            UserInfo._Examsuject = DGV_ExamInfo.CurrentRow.Cells["Column2"].Value.ToString();
                            UserInfo._Examdate = DGV_ExamInfo.CurrentRow.Cells["Column3"].Value.ToString();
                            UserInfo._StuClass = DGV_ExamInfo.CurrentRow.Cells["Column4"].Value.ToString();
                            //显示考试页面
                            Student_Test_Questions StuTest = new Student_Test_Questions();
                            StuTest.Show();
                        }
                        else { };

                    }
                }
            }

        }


        #endregion

        #region 动画特效
        /// <summary>
        /// 窗体动画函数
        /// </summary>
        /// <param name="hwnd">指定产生动画的窗口的句柄</param>
        /// <param name="dwTime">指定动画持续的时间</param>
        /// <param name="dwFlags">指定动画类型，可以是一个或多个标志的组合。</param>
        /// <returns></returns>
        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

        //下面是可用的常量，根据不同的动画效果声明自己需要的
        private const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志该标志
        private const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；否则向外扩展
        private const int AW_HIDE = 0x10000;//隐藏窗口
        private const int AW_ACTIVE = 0x20000;//激活窗口，在使用了AW_HIDE标志后不要使用这个标志
        private const int AW_BLEND = 0x80000;//使用淡入淡出效果


        #endregion


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            Lishushun.LoginFrm log = new Lishushun.LoginFrm();
            log.Show();
        }

        private void DGV_ExamInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

