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
    #region 开始加载窗体
    public partial class loadFrm : Form
    {
        #region 窗口初始化
        public loadFrm()
        {
            InitializeComponent();
            timer1.Start();
        }
        private void loadFrm_Load(object sender, EventArgs e)
        {
        }
        #endregion

        #region 定时器
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Hide();
            LoginFrm sh = new LoginFrm();
            sh.Show();
        }
        #endregion

        #region 窗口拖动
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private Point mousePoint = new Point();
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                this.Top = Control.MousePosition.Y - mousePoint.Y;
                this.Left = Control.MousePosition.X - mousePoint.X;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
        #endregion
    }
    #endregion
}
