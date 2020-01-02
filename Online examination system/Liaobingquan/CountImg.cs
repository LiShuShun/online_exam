using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_examination_system.Liaobingquan
{
    public partial class CountImg : Form
    {
        public CountImg()
        {
            InitializeComponent();
        }
        private void CreateImage()
        {
            string[] Class = new string[4] { "软件技术1班", "软件技术2班", "软件技术3班", "软件技术4班" };
            Bitmap bMap = new Bitmap(750, 750);
            float[] d = new float[4] { 10,20,30,40};
            Graphics gph = Graphics.FromImage(bMap);
            gph.Clear(Color.White);
            try
            {


                PointF cpt = new PointF(40, 420);
                //X轴三角形
                PointF[] xpt = new PointF[3] { new PointF(cpt.Y + 8, cpt.Y), new PointF(cpt.Y, cpt.Y - 4), new PointF(cpt.Y, cpt.Y + 4) };
                //Y轴三角形
                PointF[] ypt = new PointF[3] { new PointF(cpt.X, cpt.X - 8), new PointF(cpt.X - 4, cpt.X), new PointF(cpt.X + 4, cpt.X) };
                gph.DrawString("班级及格统计图", new Font("宋体", 14), Brushes.Black, new PointF(cpt.X + 60, cpt.X));

                //画X轴
                gph.DrawLine(Pens.Black, cpt.X, cpt.Y, cpt.Y, cpt.Y);
                gph.DrawPolygon(Pens.Black, xpt);
                gph.FillPolygon(new SolidBrush(Color.Black), xpt);
                gph.DrawString("班级", new Font("宋体", 12), Brushes.Black, new PointF(cpt.Y, cpt.Y + 10));
                //画Y轴
                gph.DrawLine(Pens.Black, cpt.X, cpt.Y, cpt.X, cpt.X);
                gph.DrawPolygon(Pens.Black, ypt);
                gph.FillPolygon(new SolidBrush(Color.Black), ypt);
                gph.DrawString("单位（个）", new Font("宋体", 12), Brushes.Black, new PointF(0, 7));

                for (int i = 1; i <= 4; i++)
                {
                    //画Y轴刻度
                    if (i < 3)
                    {

                        gph.DrawString((i * 25).ToString(), new Font("宋体", 11), Brushes.Black, new PointF(15, cpt.Y - i * 25 - 6));
                        gph.DrawLine(Pens.Black, cpt.X + 3, cpt.Y - i * 30, cpt.X, cpt.Y - i * 30);
                    }
                    //画X轴
                    gph.DrawString(Class[i - 1].Substring(0, 1), new Font("宋体", 11), Brushes.Black, new PointF(cpt.X + i * 30 - 5, cpt.Y + 5));
                    gph.DrawString(Class[i - 1].Substring(1, 1), new Font("宋体", 11), Brushes.Black, new PointF(cpt.X + i * 30 - 5, cpt.Y + 20));
                    if (Class[i - 1].Length > 2)
                    {
                        gph.DrawString(Class[i - 1].Substring(2, 1), new Font("宋体", 11), Brushes.Black, new PointF(cpt.X + i * 30 - 5, cpt.Y + 35));

                    }

                    //画点
                    gph.DrawEllipse(Pens.Black, cpt.X + i * 30 - 1.5F, cpt.Y - d[i - 1] * 3 - 1.5F, 3, 3);
                    gph.FillEllipse(new SolidBrush(Color.Black), cpt.X + i * 30 - 1.5F, cpt.Y - d[i - 1] * 3 - 1.5F, 3, 3);
                    //画数值
                    gph.DrawString(d[i - 1].ToString(), new Font("宋体", 11), Brushes.Black, new PointF(cpt.X + i * 30, cpt.Y - d[i - 1] * 3));
                    //画折线
                    if (i > 1)
                    {
                        gph.DrawLine(Pens.Red, cpt.X + (i - 1) * 30, cpt.Y - d[i - 2] * 3, cpt.X + i * 30, cpt.Y - d[i - 1] * 3);
                    }

                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    bMap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    /*
                     Asp.Net
                     image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                     Response.ClearContent();
                     Response.ContentType = "image/Jpeg";
                     */
                    pictureBox1.Image = new Bitmap(bMap);

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                gph.Dispose();
                bMap.Dispose();//释放bmp文件资源
            }

        }
        private void CountImg_Load(object sender, EventArgs e)
        {
            CreateImage();
        }
    }
}
