using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Online_examination_system.Lijianhua
{
    class Dal
    {
        //连接数据库
        public string strConnect = "Data Source=.;Initial Catalog=OnlineExamSys;Integrated Security=True";
        //数据库对象
        SqlConnection conn = null;
        SqlCommand comd = null;






        /// <summary>
        /// 加载就Show信息到dataview里面
        /// </summary>
        /// <returns></returns>
        public DataSet ShowInfo(string sql)
        {
            DataSet ds = new DataSet();
            conn = new SqlConnection(strConnect);
            SqlDataAdapter pter = new SqlDataAdapter(sql, conn);
            try
            {
                conn.Open();
                pter.Fill(ds, "info");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }

        /// <summary>
        /// 返回查询的对象
        /// </summary>
        /// <returns></returns>
        public Modle showInfoSingle(string sql)
        {
            Modle model = new Modle();
            conn = new SqlConnection(strConnect);
            SqlCommand comd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                SqlDataReader dr = comd.ExecuteReader();
                while (dr.Read())
                {
                    //管理员信息
                    if (sql.Substring(0,15).Equals("select * from A"))
                    {
                        model.adminid = dr["adminid"].ToString();
                        model.adminname = dr["adminname"].ToString();
                       
                    }


                    //学生信息
                    if (sql.Substring(0, 15).Equals("select * from S"))
                    {
                        model.stuid = dr["stuid"].ToString();
                        model.stuname = dr["stuname"].ToString();
                        model.stuclass = dr["stuclass"].ToString();
                        model.stuage = dr["stuage"].ToString();
                        model.major = dr["major"].ToString();
                        model.dapartment = dr["dapartment"].ToString();
                        model.note = dr["note"].ToString();
                    }


                    //老师信息
                    if (sql.Substring(0, 15).Equals("select * from T"))
                    {
                        model.teacherid = dr["teacherid"].ToString();
                        model.teaname = dr["teaname"].ToString();
                        model.department = dr["department"].ToString();
                        model.teacherage = dr["teacherage"].ToString();
                        model.note = dr["note"].ToString();
                    }
                    //公共信息
                    model.password = dr["password"].ToString();
                   // model.purviewid = dr["purviewid"].ToString();



                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return model;
        }





        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Updta(string sql)
        {
            int result = 0;
            conn = new SqlConnection(strConnect);
            comd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                result = comd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }
            finally
            {
                conn.Close();
            }

            return result;
        }


        /// <summary>
        /// 删除信息
        /// </summary>
        /// <returns></returns>
        public int Dalete(string sql)
        {
            int result = 0;
            conn = new SqlConnection(strConnect);
            comd = new SqlCommand(sql, conn);

            try
            {
                conn.Open();

                //获取受影响的行数
                result = comd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }
            finally
            {
                conn.Close();
            }

            return result;
        }


        /// <summary>
        /// 添加信息
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int AddInfo(string sql)
        {
            int result = 0;
            conn = new SqlConnection(strConnect);
            comd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                result = comd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }




    }
}
