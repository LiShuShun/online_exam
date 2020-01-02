using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Online_examination_system.Liuyingjie
{
    public class StuDB
    {
        //Data Source =.; Initial Catalog = OnlineExamSys; Integrated Security = True
        string str = "Data Source=.;Initial Catalog=OnlineExamSys;Integrated Security=True";//连接数据源
        SqlConnection conn = null; //连接数据库
        SqlCommand comd = null;//执行操作
        SqlDataAdapter pter = null;//数据适配器
        DataSet ds = null; //数据集
        string sql = null;

        #region 考试信息类
        /// <summary>
        /// 考试信息类
        /// </summary>
        /// <returns></returns>
        public DataSet ExamInfo()
        {
            ds = new DataSet();
            conn = new SqlConnection(str);
            string sql = string.Format(@"select
                                         examId   考试ID,
                                         examname 考试类型,
                                         subjects 考试科目,
                                         examdate 考试时间,
                                         examObject 考试班级
                                        from Examination_list where examObject='{0}' and DATEPART(DD,GETDATE()) =DATEPART(DD,examdate)", UserInfo._StuClass);
            pter = new SqlDataAdapter(sql, conn);
            try
            {
                conn.Open();

                pter.Fill(ds, "Examination_list");
            }
            catch (Exception ex)
            {
                Console.WriteLine("异常！{0}", ex.Message);
            }
            finally { conn.Close(); conn.Dispose(); };
            return ds;
        }
        #endregion

        #region 试题答案类
        /// <summary>
        /// 试题答案类
        /// </summary>
        /// <returns></returns>
        public DataSet ExamScore()
        {
            ds = new DataSet();
            conn = new SqlConnection(str);
            sql = string.Format("select correctAnswer from TheQuestionBank");
            pter = new SqlDataAdapter(sql, conn);
            try
            {
                conn.Open();
                pter.Fill(ds, "TheQuestionBank");
            }
            catch (Exception ex)
            {
                Console.WriteLine("异常！{0}", ex.Message);
            }
            finally { conn.Close(); conn.Dispose(); };
            return ds;
        }
        /// <summary>
        /// 试题分值
        /// </summary>
        /// <returns></returns>
        public DataSet ExamQuestionScore()
        {
            ds = new DataSet();
            conn = new SqlConnection(str);
            sql = string.Format("select score 分值 from TheQuestionBank");
            pter = new SqlDataAdapter(sql, conn);
            try
            {
                conn.Open();
                pter.Fill(ds, "TheQuestionBank");
            }
            catch (Exception ex)
            {
                Console.WriteLine("异常！{0}", ex.Message);
            }
            finally { conn.Close(); conn.Dispose(); };
            return ds;

        }
        #endregion

        #region 学生个人信息类
        /// <summary>
        /// 学生个人信息类
        /// </summary>
        public void StuAllInfo()
        {
            sql = String.Format("select * from Student_list where stuid ='{0}'", UserInfo._LogId);
            using (conn = new SqlConnection(str))
            {
                try
                {
                    conn.Open();
                    comd = new SqlCommand(sql, conn);
                    SqlDataReader SDR = comd.ExecuteReader();
                    if (SDR.Read())//只读一条数据
                    {
                        UserInfo._StuName = SDR[1].ToString();
                        UserInfo._StuClass = SDR[2].ToString();
                        UserInfo._StuAge = SDR[3].ToString();
                        UserInfo._Major = SDR[4].ToString();
                        UserInfo._Dapartment = SDR[5].ToString();
                        UserInfo._Note = SDR[8].ToString();


                    }
                    SDR.Close();
                    SDR.Dispose();
                    conn.Close();
                    conn.Dispose();
                }

                catch (Exception)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
        #endregion

        #region 学生信息分数录入类

        /// <summary>
        /// 学生信息分数录入类
        /// </summary>
        public void StuExamGetInfo()
        {
            UserInfo._ExamStates = 0;

            conn = new SqlConnection(str);
            sql = string.Format(@"insert into EndExamSocre values
                                ('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}',{8},{9})"
                                 , UserInfo._LogId, UserInfo._StuName, UserInfo._StuClass
                                 , UserInfo._Dapartment, UserInfo._ExamId, UserInfo._Examtype
                                 , UserInfo._Examsuject, UserInfo._Examdate, UserInfo._Examscore, UserInfo._ExamStates);
            comd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                int result = comd.ExecuteNonQuery();

            }
            catch (Exception)
            {

            }
            finally { conn.Close(); conn.Dispose(); }
        }
        #endregion

        #region 学生分数查询类
        /// <summary>
        /// 学生分数查询类
        /// </summary>
        /// <returns></returns>
        public DataSet StuExamSelect()
        {
            ds = new DataSet();
            conn = new SqlConnection(str);
            sql = string.Format(@"select 
                                    name 考生姓名,
                                    class 考生班级,
                                    department  考生系别,
                                    examtype 考试类型,
                                    examsuject 考试科目,
                                    examdate 考试时间,
                                    examscore 考试分数
                                    from EndExamSocre where name='{0}' and statesId='1'", UserInfo._StuName);
            pter = new SqlDataAdapter(sql, conn);
            try
            {
                conn.Open();

                pter.Fill(ds, "EndExamSocre");
            }
            catch (Exception ex)
            {
                Console.WriteLine("异常！{0}", ex.Message);
            }
            finally { conn.Close(); conn.Dispose(); };
            return ds;
        }

        /// <summary>
        /// 查询学生成绩表
        /// </summary>
        /// <returns></returns>
        public DataSet EndExamCount()
        {
            ds = new DataSet();
            conn = new SqlConnection(str);
            sql = string.Format(@"select examId from EndExamSocre");
            pter = new SqlDataAdapter(sql, conn);
            try
            {
                conn.Open();

                pter.Fill(ds, "EndExamSocre");
            }
            catch (Exception ex)
            {
                Console.WriteLine("异常！{0}", ex.Message);
            }
            finally { conn.Close(); conn.Dispose(); };
            return ds;
        }
        #endregion

        #region 考试与试题信息关联
        /// <summary>
        /// 获取某张试卷的试题id
        /// </summary>
        /// <returns></returns>
        public DataSet ExamQuestionID()
        {
            ds = new DataSet();
            conn = new SqlConnection(str);
            string sql = string.Format("select questions from Examination_list where examId={0}", UserInfo._ExamId);
            pter = new SqlDataAdapter(sql, conn);
            try
            {
                conn.Open();

                pter.Fill(ds, "Examination_list");
            }
            catch (Exception ex)
            {
                Console.WriteLine("异常！{0}", ex.Message);
            }
            finally { conn.Close(); conn.Dispose(); };
            return ds;
        }

        /// <summary>
        /// 根据试题id获取试题详细信息
        /// </summary>
        /// <returns></returns>
        public DataSet ExamQuestions()
        {
            //利用数组筛选出sql里的试题详情
            string ids = "";
            for (int i = 0; i < UserInfo._ExamQuestion.Length; i++)
            {
                ids += UserInfo._ExamQuestion[i];
                if (i < UserInfo._ExamQuestion.Length - 1)
                {
                    ids += ",";
                }
            }

            ds = new DataSet();
            conn = new SqlConnection(str);
            string sql = string.Format(@"select * from TheQuestionBank where questionID in(" + ids + ")"
                                       , UserInfo._ExamQuestion[0], UserInfo._ExamQuestion[UserInfo._ExamQuestion.Length - 1]);
            pter = new SqlDataAdapter(sql, conn);
            try
            {
                conn.Open();

                pter.Fill(ds, "TheQuestionBank");
            }
            catch (Exception ex)
            {
                Console.WriteLine("异常！{0}", ex.Message);
            }
            finally { conn.Close(); conn.Dispose(); };
            return ds;

        }
        #endregion


    }

}
