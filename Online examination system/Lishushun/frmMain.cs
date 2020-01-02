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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        private void faceDetectCallback(object sender, string result)
        {
            MessageBox.Show((result == "" ? "人脸检测失败" : "人脸检测成功:") + result);
        }


        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnsExit_Click(object sender, EventArgs e)
        {
            //System.Environment.Exit(0);//强制退出线程
            this.Close();


        }

        /// <summary>
        /// 人脸录入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnsInput_Click(object sender, EventArgs e)
        {
            frmFaceInput ffi = new frmFaceInput();
            ffi.Show();
        }

        /// <summary>
        /// 人脸识别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnsIdentify_Click(object sender, EventArgs e)
        {
            frmFaceIdentify fi = new frmFaceIdentify();
            fi.Show();

            fi.FaceDetectCallback += faceDetectCallback;
        }
    }
}
