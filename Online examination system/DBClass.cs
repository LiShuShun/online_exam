using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Online_examination_system
{
    public class DBClass
    {
        public static string str = @"Data Source=.;Initial Catalog=OnlineExamSys;Integrated Security=True";//连接数据源
        SqlConnection conn = null; //连接数据库
        SqlCommand cmd = null;//执行操作
        SqlDataAdapter pter = null;//数据适配器
        DataSet ds = null;//数据集

        public DataSet StuInfo()
        {
            ds = new DataSet();
            conn = new SqlConnection(str);
            pter = new SqlDataAdapter(@"select stuid 学号,
	                                               stuname 学生姓名,
	                                               stuclass 所在班级,
	                                               stuage 学生年龄,
	                                               major 专业名,
	                                               dapartment 系名,
	                                               password 密码,
	                                               purviewwid 权限,
	                                               note 备注	
                                                   from Student_list", conn);
            try
            {
                conn.Open();
                pter.Fill(ds, "Student_list");
            }
            catch (Exception) { }
            finally { conn.Close(); }
            return ds;
        }
    }
}
