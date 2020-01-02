using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Online_examination_system.Lishushun
{
   #region 数据库操作类
    public class DBSet
    {
        string str = @"Data Source=.;Initial Catalog=OnlineExamSys;Integrated Security=True";//连接数据源
        SqlConnection conn = null; //连接数据库
        SqlCommand comd = null;//执行操作
        SqlDataAdapter pter = null;//数据适配器
        DataSet ds = null; //数据集
        string sql = null;
        int result = 0;
       
      
        #region 学生登录查询
        public DataSet StudentList(string id, string pwd, int type)
        {
            ds = new DataSet();
            conn = new SqlConnection(str);
            sql = String.Format(@"select s.stuid,s.password,s.purviewwid from 
                                Student_list s where s.stuid = '{0}' and s.password = '{1}' and s.purviewwid = {2}
", id, pwd, type);
            pter = new SqlDataAdapter(sql, conn);
            try
            {
                conn.Close();
                pter.Fill(ds, "studentlist");
            }
            catch (Exception)
            {
            }
            finally { conn.Close(); }
            return ds;
        }
        #endregion
       
        #region 教师查询
        public DataSet TeacherList(string id, string pwd, int type)
        {
            ds = new DataSet();
            conn = new SqlConnection(str);
            sql = String.Format(@"select  t.teacherid,t.password,t.purviewid 	from  
                                Teacher_list t where t.teacherid = '{0}' and t.password = '{1}' and t.purviewid = {2} 
", id, pwd, type);
            pter = new SqlDataAdapter(sql, conn);
            try
            {
                conn.Close();
                pter.Fill(ds, "teacherlist");
            }
            catch (Exception)
            {
            }
            finally { conn.Close(); }
            return ds;
        }
        #endregion
      
        #region 管理员登录查询
        public DataSet AdminList(string id, string pwd, int type)
        {
            ds = new DataSet();
            conn = new SqlConnection(str);
            sql = String.Format(@"select a.adminid,a.password,a.purviewid from 
                                Administrator_list a where a.adminid = '{0}' and a.password = '{1}' and a.purviewid = {2}
", id, pwd, type);
            pter = new SqlDataAdapter(sql, conn);
            try
            {
                conn.Close();
                pter.Fill(ds, "adminlist");
            }
            catch (Exception)
            {
            }
            finally { conn.Close(); }
            return ds;
        }
        #endregion
      
        #region 添加学生注册信息
        public int AddStudentInfo(string name, string Class, int age, string major, string department, string pwd, int jurisdictions, string note,string isFace)
        {
            result = 0;
            conn = new SqlConnection(str);
            sql = string.Format(@"insert into Student_list values('{0}','{1}',{2},'{3}','{4}','{5}',{6},'{7}','{8}')", name, Class, age, major, department, pwd, jurisdictions, note,isFace);
            comd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                result = comd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally { conn.Close();}
            return result;
        }
        #endregion
      
        #region 添加教师注册信息
        public int AddTeacherInfo(string name, string department, int age, string pwd, int type, string note)
        {
            result = 0;
            conn = new SqlConnection(str);
            sql = string.Format(@"insert into Teacher_list values('{0}','{1}',{2},{3},'{4}',{5})", name, department, age, pwd, type, note);
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
      
        #region 查询权限表 
        public DataSet authority()
        {
            ds = new DataSet();
            conn = new SqlConnection(str);
            sql = String.Format(@"select *from authority_list ");
            pter = new SqlDataAdapter(sql, conn);
            try
            {
                conn.Open();
                pter.Fill(ds, "authority");
            }
            catch (Exception)
            {
            }
            finally { conn.Close(); }
            return ds;
        }
        #endregion
      
        #region 修改学生密码
        public int UpStudentPwd(string stuPwd,int stuId)
        {
            result = 0;
            conn = new SqlConnection(str);
            sql = string.Format(@"update Student_list set password  = '{0}' where stuid = {1}
", stuPwd,stuId);
            comd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                result = comd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion

        #region 修改教师密码
        public int UpTeacherPwd( string teaPwd, int teaId)
        {
            result = 0;
            conn = new SqlConnection(str);
            sql = string.Format(@"update Teacher_list set password = '{0}' where teacherid = {1}
", teaPwd,teaId);
            comd = new SqlCommand(sql,conn);
            try
            {
                conn.Open();
                result = comd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion

        #region 修改管理员密码
        public int UpAdminPwd( string adminPwd,int adminId)
        {
            result = 0;
            conn = new SqlConnection(str);
            sql = string.Format(@"update Administrator_list set password = '{0}' where adminid = {1}
", adminId, adminPwd);
            comd = new SqlCommand(sql,conn);

            try
            {
                conn.Open();
                result = comd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion

        #region 查询学号
        public DataSet StuAllId()
        {
            ds = new DataSet();
            conn = new SqlConnection(str);
            sql = string.Format(@"select  stuid from Student_list order by stuid desc
");
            pter = new SqlDataAdapter(sql, conn);
            try
            {
                conn.Open();
                pter.Fill(ds, "stuaid");
            }
            catch (Exception)
            {
            }
            finally { conn.Close(); }
            return ds;
        }
        #endregion

        #region 查询教师号
        public DataSet TeaAllId()
        {
            ds = new DataSet();
            conn = new SqlConnection(str);
            sql = string.Format(@"select  teacherid from Teacher_list order by teacherid desc
");
            pter = new SqlDataAdapter(sql, conn);
            try
            {
                conn.Open();
                pter.Fill(ds, "teacherid");
            }
            catch (Exception)
            {
            }
            finally { conn.Close();}
            return ds;
        }
        #endregion

   


    }
    #endregion
}
