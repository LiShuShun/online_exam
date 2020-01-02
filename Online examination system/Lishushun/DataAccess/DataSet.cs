using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Online_examination_system.Lishushun
{
    public class DataSet
    {
        string str = @"Data Source=.;Initial Catalog=OnlineExamSys;Integrated Security=True";//连接数据源
        SqlConnection conn = null; //连接数据库
        SqlCommand cmd = null;//执行操作
        SqlDataAdapter pter = null;//数据适配器
        DataSet ds = null;//数据集

        public DataSet StudentInfo()
        {
            ds = new DataSet();

            return ds;
        }
        public DataSet TeacherInfo()
        {
            ds = new DataSet();

            return ds;
        }



    }
  
}
