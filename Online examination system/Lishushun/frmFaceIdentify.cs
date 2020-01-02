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
using AForge.Video;
using System.Threading;

namespace Online_examination_system.Lishushun
{
    /// <summary>
    /// 返回人脸识别结果
    /// </summary>
    /// <param name="sender">识别form</param>
    /// <param name="accountId">账号id</param>
    public delegate void FaceDetectResultEventHandler(object sender, string accountId);

    public partial class frmFaceIdentify : Form
    {
        public event FaceDetectResultEventHandler FaceDetectCallback;

        public int selectedDeviceIndex = 0;
        FilterInfoCollection videoDevices;
        VideoCaptureDevice videoSource;
        bool isDetecting = true;

        public frmFaceIdentify()
        {
            InitializeComponent();
            btnIdentify.Click += btnIdentify_Click;
            FormClosing += handleFormClosingEvent;
            CheckForIllegalCrossThreadCalls = true;
        }

        /// <summary>
        /// 窗体加载连接摄像头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmFaceIdentify_Load(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            selectedDeviceIndex = 0;
            videoSource = new VideoCaptureDevice(videoDevices[selectedDeviceIndex].MonikerString);//连接摄像头
            videoSource.VideoResolution = videoSource.VideoCapabilities[selectedDeviceIndex];
            videoSource.NewFrame += handleCameraFrameChanged;
            vspIdentify.VideoSource = videoSource;
            vspIdentify.Start();

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Enabled = true;
            timer.Interval = 3000; //执行间隔时间,单位为毫秒;
            timer.Start();
            timer.AutoReset = false;
            timer.Elapsed += delegate
            {
                isDetecting = false;
            };
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
                vspIdentify.SignalToStop();
                vspIdentify.WaitForStop();
            }
        }

        /// <summary>
        /// 相机采集到图片后回调，注意此方法在相机线程中回调的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void handleCameraFrameChanged(object sender, NewFrameEventArgs eventArgs)
        {
            if (isDetecting) return;
            handleImageDetecting();
        }

        /// <summary>
        /// 在收到相机通知可以读取图像时进行图像处理
        /// </summary>
        private void handleImageDetecting()
        {
            Bitmap bitmap = vspIdentify.GetCurrentVideoFrame();//识别
            if (bitmap == null) return;

            // 控制一次只能处理一张图片
            isDetecting = true;

            // 图像识别耗时且走网络，应该考虑放到子线程执行
            new Thread(new ParameterizedThreadStart(t =>
            {
                string[] result = FaceSearch.search(bitmap);
                bitmap.Dispose();
                double score = Convert.ToDouble(result[2]);
                if (score > 80)
                {
                    // 从timer线程切换到主线程刷新UI
                    this.BeginInvoke(new MethodInvoker(delegate
                    {
                        this.Close();
                        if (FaceDetectCallback != null)
                        {
                            FaceDetectCallback(this, result[1]);
                            DataAccess.Components identity = new DataAccess.Components();
                            DataSet ds = new DataSet();
                            string pwd = "";
                            int num, num1, num2;
                            ds = identity.stuIdentity(Convert.ToInt32(result[1]));
                            num = ds.Tables["studentlist"].Rows.Count;
                            ds = identity.teaIdentity(Convert.ToInt32(result[1]));
                            num1 = ds.Tables["teacherlist"].Rows.Count;
                            ds = identity.admIdentity(Convert.ToInt32(result[1]));
                            num2 = ds.Tables["adminilist"].Rows.Count;
                            if (num > 0)
                            {
                                Liuyingjie.Student_Frm stu = new Liuyingjie.Student_Frm();
                                stu.Show();
                            }
                            else if (num1 > 0)
                            {

                                Liaobingquan.FormTeacher tea = new Liaobingquan.FormTeacher();
                                tea.Show();
                            }
                            else if (num2 > 0)
                            {
                                Lijianhua.Admin adm = new Lijianhua.Admin(result[1],pwd);
                                adm.Show();
                            }
                        }
                    }));
                }
                else
                {
                    isDetecting = false;
                }
            })).Start("tryToDetectFace");
        }

        //vspIdentify
        private void vspIdentify_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 人脸识别按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIdentify_Click(object sender, EventArgs e)
        {
            if (videoSource == null)
            {
                return;
            }

            Bitmap bitmap = vspIdentify.GetCurrentVideoFrame();
            string[] result = FaceSearch.search(bitmap);
            bitmap.Dispose();
            txtGroup.Text = result[0];
            txtUid.Text = result[1];
            txtMatchingScore.Text = result[2];
        }

        public static class AccessToken
        {
            // 调用getAccessToken()获取的 access_token建议根据expires_in 时间 设置缓存
            // 返回token
            public static String TOKEN = "24.adda70c11b9786206253ddb70affdc46.2592000.1493524354.282335-1234567";

            // API Key 
            private static String clientId = "HtSzIhdj2UqfEu1XewhGWPXL";
            // Secret Key
            private static String clientSecret = "4pNesBWNYBkWzmzzQG13BTFni40TTe3W";

            public static String getAccessToken()
            {
                String authHost = "https://aip.baidubce.com/oauth/2.0/token";
                HttpClient client = new HttpClient();
                List<KeyValuePair<String, String>> paraList = new List<KeyValuePair<string, string>>();
                paraList.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
                paraList.Add(new KeyValuePair<string, string>("client_id", clientId));
                paraList.Add(new KeyValuePair<string, string>("client_secret", clientSecret));
                String result = "";
                try
                {
                    HttpResponseMessage response = client.PostAsync(authHost, new FormUrlEncodedContent(paraList)).Result;
                    result = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(result);
                    return result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("网络连接失败！请检查你的网络！");
                    Console.Write("异常：{0}", ex.Message);
                }
                return result;
            }
        }
        public class FaceSearch
        {
            /// <summary>
            /// 人脸搜索
            /// </summary>
            /// <param name="ch"></param>
            /// <returns></returns>
            public static string[] search(Bitmap image)
            {
                string[] strArr = new string[3];
                //网络连接失败为获取到AccessToken
                if (AccessToken.getAccessToken() == "")
                {
                    return strArr;
                }
                var jsonstring = AccessToken.getAccessToken();
                var jObject = JObject.Parse(jsonstring);
                string token = jObject["access_token"].ToString();
                string host = "https://aip.baidubce.com/rest/2.0/face/v3/search?access_token=" + token;
                Encoding encoding = Encoding.Default;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
                request.Method = "post";
                request.KeepAlive = true;
                var value = DataAccess.Components.convertBitmapToBytes(image);
                string imgData64 = Convert.ToBase64String(value);
                String str = "{\"image\":\"" + imgData64 + "\",\"image_type\":\"BASE64\",\"group_id_list\":\"fylm\"}";
                byte[] buffer = encoding.GetBytes(str);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                string result = reader.ReadToEnd();
                Console.WriteLine("人脸搜索:");
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                string val = "";
                try
                {
                    val = jo["result"]["user_list"].ToString();
                }
                catch (Exception ex)
                {
                    return strArr;
                }
                JArray ja = (JArray)JsonConvert.DeserializeObject(val);
                Double Score = Convert.ToDouble(ja[0]["score"].ToString());//匹配度
                string Uid = ja[0]["user_id"].ToString();//用户名
                string GroupId = ja[0]["group_id"].ToString();//组名
                strArr[0] = GroupId.ToString();
                strArr[1] = Uid.ToString();
                strArr[2] = Score.ToString();
                return strArr;
            }
        }
    }
}
