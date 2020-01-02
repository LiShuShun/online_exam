using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Online_examination_system.Lishushun.DataAccess
{
    public class Components
    {
        string str = @"Data Source=.;Initial Catalog=OnlineExamSys;Integrated Security=True";//连接数据源
        SqlConnection conn = null; //连接数据库
        SqlCommand comd = null;//执行操作
        SqlDataAdapter pter = null;//数据适配器
        DataSet ds = null; //数据集
        string sql = null;
        int result = 0;
        /// <summary>
        /// 位图转换为字节数组
        /// </summary>
        /// <param name="map">外界需要自己dispose</param>
        /// <returns></returns>
        public static byte[] convertBitmapToBytes(Bitmap map)
        {
            MemoryStream ms = new MemoryStream();
            map.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] bytes = ms.GetBuffer();  //byte[]   bytes=   ms.ToArray(); 这两句都可以，至于区别么，下面有解释
            ms.Close();
            return bytes;
        }

        #region  学生脸图Input
        public int stuInputFace(string isface, int stuId)
        {
            result = 0;
            conn = new SqlConnection(str);
            sql = string.Format(@"update Student_list set isFace = '{0}' where stuid = {1}", isface, stuId);
            comd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                result = comd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally { conn.Close(); }
            return result;
        }
        #endregion

        #region 教师脸图Input
        public int teaInputFace(string isface, int teaId)
        {
            result = 0;
            conn = new SqlConnection(str);
            sql = string.Format(@"Update Teacher_list set isFace = '{0}' where teacherid = {1}
", isface,teaId);
            comd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                result = comd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally { conn.Close(); }
            return result;
        }
        #endregion

        #region 管理员脸图Input
        public int admiInputFace(string isface, int adminId)
        {
            result = 0;
            conn = new SqlConnection(str);
            sql = string.Format(@"Update Administrator_list set isFace = '{0}' where adminid = {1}
", isface, adminId);
            comd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                result = comd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally { conn.Close(); }
            return result;
        }
        #endregion

        #region 学生脸部Identity
       public DataSet stuIdentity(int stuId)
        {
            ds = new DataSet();
            conn = new SqlConnection(str);
            sql = string.Format(@"select* from Student_list where stuid = {0} and isFace = '是'", stuId);
            pter = new SqlDataAdapter(sql, conn);
            try
            {
                conn.Open();
                pter.Fill(ds, "studentlist");
            }
            catch (Exception)
            {
            }
            finally { conn.Close(); }
            return ds;
        }
        #endregion

        #region 教师脸部Identity
        public DataSet teaIdentity(int teaId)
        {
            ds = new DataSet();
            conn = new SqlConnection(str);
            sql = string.Format(@"select* from Teacher_list where teacherid = {0} and isFace = '是'", teaId);
            pter = new SqlDataAdapter(sql, conn);
            try
            {
                conn.Open();
                pter.Fill(ds, "teacherlist");
            }
            catch (Exception)
            {
            }
            finally { conn.Close(); }
            return ds;
        }
        #endregion

        #region 管理员脸部Identity
        public DataSet admIdentity(int admId)
        {
            ds = new DataSet();
            conn = new SqlConnection(str);
            sql = string.Format(@"select* from Administrator_list where adminid = {0} and isFace = '是'", admId);
            pter = new SqlDataAdapter(sql, conn);
            try
            {
                conn.Open();
                pter.Fill(ds, "adminilist");
            }
            catch (Exception)
            {
            }
            finally { conn.Close(); }
            return ds;
        }
        #endregion
    }
}
