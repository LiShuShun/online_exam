using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Drawing;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Threading;
using static Online_examination_system.Lishushun.frmFaceIdentify;

namespace Online_examination_system.Lishushun
{
    public partial class frmFaceInput : Form
    {

        FilterInfoCollection videoDevices;
        VideoCaptureDevice videoSource;
        public int selectedDeviceIndex = 0;
        bool isDetecting = false;

        //初始化
        public frmFaceInput()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载连接摄像头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmFaceInput_Load(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            selectedDeviceIndex = 0;
            videoSource = new VideoCaptureDevice(videoDevices[selectedDeviceIndex].MonikerString);//连接摄像头
            videoSource.VideoResolution = videoSource.VideoCapabilities[selectedDeviceIndex];
            vspInput.VideoSource = videoSource;
            vspInput.Start();

            FormClosing += handleFormClosingEvent;
        }

        /// <summary>
        /// 关闭form时清理摄像头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void handleFormClosingEvent(object sender, FormClosingEventArgs e)
        {
            if (videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();

                // 释放摄像头
                vspInput.SignalToStop();
                vspInput.WaitForStop();
            }
        }

        //录入按钮
        private void btnInput_Click(object sender, EventArgs e)
        {
            if (isDetecting)
            {
                return;
            }

            string name = txtUid.Text;
            if (name == "")
            {
                MessageBox.Show("请输入用户名！");
                return;
            }
            if (Check.IsChinese(name))
            {
                MessageBox.Show("请输入数字");
                return;
            }
            if (videoSource == null)
            {
                MessageBox.Show("请先连接摄像头 ！");
                return;
            }
            Bitmap bitmap = vspInput.GetCurrentVideoFrame();
            if (bitmap == null)
            {
                return;
            }

            isDetecting = true;
            // 图像识别耗时且走网络，应该考虑放到子线程执行
            new Thread(new ParameterizedThreadStart(t =>
            {
                string TF = "是";
                int result = FaceAdd.add(bitmap, name);
                DataAccess.Components fInput = new DataAccess.Components();
                bitmap.Dispose();
                // 从timer线程切换到主线程刷新UI
                this.BeginInvoke(new MethodInvoker(delegate
                {
                  // MessageBox.Show((result > 0 ? "录入失败!" : "录入成功！") + result);
                    if (result > 0)
                    {
                        isDetecting = false;
                    }
                    else if (fInput.stuInputFace(TF, Convert.ToInt32(name)) > 0)
                    {
                        MessageBox.Show("student");
                        this.Close();
                    }
                    else if (fInput.teaInputFace(TF, Convert.ToInt32(name)) > 0)
                    {
                        MessageBox.Show("teacher");
                        this.Close();
                    }
                    else if (fInput.admiInputFace(TF, Convert.ToInt32(name)) > 0)
                    {
                        MessageBox.Show("admin");
                        this.Close();
                    }
                }));
            })).Start("tryToDetectFace");
        }

        // vspInput
        private void vspInput_Click(object sender, EventArgs e)
        {

        }
        //用户ID
        private void txtUid_TextChanged(object sender, EventArgs e)
        {

        }

        //注册人脸
        public class FaceAdd
        {
            // 人脸注册
            public static int add(Bitmap image, string name)
            {
                if (AccessToken.getAccessToken() == "")
                {
                    return 1;
                }
                var jsonstring = AccessToken.getAccessToken();
                var jObject = JObject.Parse(jsonstring);
                string token = jObject["access_token"].ToString();
                string host = "https://aip.baidubce.com/rest/2.0/face/v3/faceset/user/add?access_token=" + token;
                Encoding encoding = Encoding.Default;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
                request.Method = "post";

                request.KeepAlive = true;
                var value = DataAccess.Components.convertBitmapToBytes(image);
                string imgData64 = Convert.ToBase64String(value);
                String str = "{\"image\":\"" + imgData64 + "\",\"image_type\":\"BASE64\",\"group_id\":\"fylm\",\"user_id\":\"" + name + "\"}";

                byte[] buffer = encoding.GetBytes(str);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                string result = reader.ReadToEnd();
                Console.WriteLine("人脸注册:");
                Console.WriteLine(result);
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                int error_code = Convert.ToInt32(jo["error_code"]);//返回error_code
                return error_code;
            }
        }

        //用户输入ID检测
        public class Check
        {
            /// <summary>
            /// 给定一个字符串，判断其是否只包含有汉字
            /// </summary>
            /// <param ></param>
            /// <returns></returns>
            public static bool IsChinese(string str)
            {
                //中文字符
                Regex rx = new Regex("^[\u4e00-\u9fa5]$");
                for (int i = 0; i < str.Length; i++)
                {
                    if (rx.IsMatch(str.Substring(i, 1)))
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;

            }
        }
    }
}
