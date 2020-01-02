using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Online_examination_system.Liaobingquan
{
    public class DBset
    {

        string str = "Data Source=.;Initial Catalog=OnlineExamSys;Integrated Security=True";
        DataSet ds = null;
        SqlCommand comd = null;
        SqlConnection conn = null;
        SqlDataAdapter pter = null;
        Endexaminfo end = new Endexaminfo();

        //试卷管理
        public DataSet TestManger()
        {
            ds = new DataSet();
            conn = new SqlConnection(str);
            pter = new SqlDataAdapter(@" select e.examId 试卷编号,
                                               e.examname 试卷名称
                                               from Examination_list e", conn);
            try
            {
                conn.Open();
                pter.Fill(ds, "Examination_list");
            }
            catch (Exception)
            {


            }
            finally { conn.Close(); };
            return ds;

        }
        //搜索试卷按钮
        public DataSet TestSerch(string name)
        {

            ds = new DataSet();
            conn = new SqlConnection(str);
            pter = new SqlDataAdapter(String.Format(@"select examId 试卷编号,
                                                      examname 试卷名称
                                                      from Examination_list 
                                                      where examname like '{0}%'", name), conn);
            try
            {
                conn.Open();
                pter.Fill(ds, "Examination_list ");
            }
            catch (Exception)
            {

            }
            finally { conn.Close(); };
            return ds;

        }
        //个人信息
        public Teacher_list SelfInfo(string id)
        {
            Teacher_list t = new Teacher_list();
            conn = new SqlConnection(str);
            comd = new SqlCommand(String.Format(@"select teacherid,teaname,password from dbo.Teacher_list  where teacherid='{0}'", id), conn);
            try
            {
                conn.Open();
                SqlDataReader dr = comd.ExecuteReader();

                if (dr.Read())
                {
                    t.name = dr["teaname"].ToString();
                    t.id = dr["teacherid"].ToString();
                    t.pwd = dr["password"].ToString();

                }
                dr.Close();

            }
            finally
            {
                conn.Close();

            };
            return t;

        }
        public int UpdatePwd(string id, string pwd)
        {
            int res = 0;
            ds = new DataSet();
             conn = new SqlConnection(str);
            comd = new SqlCommand(String.Format(@"update dbo.Teacher_list  set password='{0}' where teacherid='{1}'", pwd, id), conn);

            try
            {
                conn.Open();
                res = comd.ExecuteNonQuery();
            }
            catch (Exception)
            {


            }
            finally { conn.Close(); };
            return res;

        }
        public int DeleteTest(string id)
        {
            int res = 0;
            ds = new DataSet();
            conn = new SqlConnection(str);
            comd = new SqlCommand(String.Format(@"delete  dbo.Examination_list where examId='{0}'", id), conn);

            try
            {
                conn.Open();
                res = comd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }

            return res;
        }
        public int Addtest( string name, string Subject, string Object, DateTime answertime, string QuestionId )
        {
            int res = 0;
            ds = new DataSet();

            conn = new SqlConnection(str);
            comd = new SqlCommand(String.Format(@"insert into Examination_list values('{0}','{1}','{2}','{3}','{4}')",
                                                              name, Subject, answertime, Object, QuestionId), conn);
            try
            {
                conn.Open();
                res = comd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }

            return res;
        }
        public DataSet TopicManger()
        {
            ds = new DataSet();
            conn = new SqlConnection(str);
            pter = new SqlDataAdapter(@"select q.questionid 题目编号,
                                         q.questionText  题目信息
                                          from  dbo.TheQuestionBank q", conn);
            try
            {
                conn.Open();
                pter.Fill(ds, "TheQuestionBank");
            }
            catch (Exception)
            {


            }
            finally { conn.Close(); };
            return ds;

        }
        public TheQuestionBank Redact(string id)
        {
            TheQuestionBank q = new TheQuestionBank();
            conn = new SqlConnection(str);
            comd = new SqlCommand(String.Format(@"select *from  dbo.TheQuestionBank q  where questionID ='{0}'", Convert.ToInt32(id)), conn);
            try
            {
                conn.Open();
                SqlDataReader dr = comd.ExecuteReader();

                if (dr.Read())
                {
                    q.questionText = dr["questionText"].ToString();
                    q.questionType = dr["questionType"].ToString();
                    q.subjectname = dr["subjectType"].ToString();
                    q.correctAnswer = dr["correctAnswer"].ToString();
                    q.sorce = Convert.ToDouble(dr["score"]);  



                }
                dr.Close();

            }
            finally
            {
                conn.Close();

            };
            return q;

        }
        public int DeleteTopic(string id)
        {
            int res = 0;
            ds = new DataSet();
            conn = new SqlConnection(str);
            comd = new SqlCommand(String.Format(@"delete TheQuestionBank where questionid='{0}'", id), conn);

            try
            {
                conn.Open();
                res = comd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }

            return res;
        }
        public int UpdateTopic(string subjectname, string questionType, string questionText, string correctAnswer, string remark,int sorce, int id)
        {
            int res = 0;
            ds = new DataSet();
            conn = new SqlConnection(str);
            comd = new SqlCommand(String.Format(@"update dbo.TheQuestionBank set subjectType ='{0}',questionType='{1}',
                                                              questionText ='{2}',correctAnswer='{3}', wrongAnswer='{4}',score={5}     
                                                              where questionID={6}", subjectname, questionType, questionText,
                                                                                             correctAnswer, remark,sorce, id), conn);

            try
            {
                conn.Open();
                res = comd.ExecuteNonQuery();
            }
            catch (Exception)
            {


            }
            finally { conn.Close(); };
            return res;

        }
        public int AddTopic(string subjectname, string questionType, string questionText, string correctAnswer, string wrongAnswer,double sorce)
        {
            int res = 0;
            ds = new DataSet();
            conn = new SqlConnection(str);
            comd = new SqlCommand(String.Format(@" insert into TheQuestionBank values ('{0}','{1}','{2}','{3}','{4}','{5}')", subjectname, questionType, questionText, correctAnswer, wrongAnswer,sorce), conn);

            try
            {
                conn.Open();
                res = comd.ExecuteNonQuery();
            }
            catch (Exception)
            {


            }
            finally { conn.Close(); };
            return res;
        }

        public int srchTopiccount(string name)
        {
            int res = 0;

            conn = new SqlConnection(str);
            comd = new SqlCommand(String.Format(@"select count(q.questionText)  from dbo.TheQuestionBank q  where q.questionText like '{0}%'", name), conn);

            try
            {
                conn.Open();
                res = (int)comd.ExecuteScalar();

            }
            catch (Exception)
            {


            }
            finally { conn.Close(); };

            return res;
        }
        public DataSet Redactt(string text)
        {
            DataSet ds = new DataSet();
            conn = new SqlConnection(str);
            pter = new SqlDataAdapter(String.Format(@"select questionText from  dbo.TheQuestionBank q  where questionText like '{0}%'", text), conn);
            try
            {
                conn.Open();
                pter.Fill(ds, "TheQuestionBank");
            }
            finally
            {
                conn.Close();

            };
            return ds;
        }

        public DataSet SerchTopic(string text)
        {
            DataSet ds = new DataSet();
            conn = new SqlConnection(str);
            pter = new SqlDataAdapter(String.Format(@"select q.questionid 题目编号,
                                         q.questionText  题目信息
                                          from  dbo.TheQuestionBank q where questionText like '{0}%'", text), conn);
            try
            {
                conn.Open();
                pter.Fill(ds, "TheQuestionBank");
            }
            finally
            {
                conn.Close();

            };
            return ds;
        }
        public DataSet DGvTopiclist()
        {
            DataSet ds = new DataSet();
            conn = new SqlConnection(str);
            pter = new SqlDataAdapter(@"select questionID,subjectType,questionType,questionText,score from dbo.TheQuestionBank ", conn);
            try
            {
                conn.Open();
                pter.Fill(ds, "TheQuestionBank");
            }
            finally
            {
                conn.Close();

            };
            return ds;
        }

        //成绩统计
        public DataSet StudentResult(string examname)
        {
            DataSet ds = new DataSet();
            conn = new SqlConnection(str);
            pter = new SqlDataAdapter(String.Format(@"select stuID,name,class,examscore from dbo.EndExamSocre where examtype like '{0}'", examname), conn);
            try
            {
                conn.Open();
                pter.Fill(ds, "EndExamSocre");
            }
            finally
            {
                conn.Close();

            };
            return ds;
        }
        public DataSet dgvtopicserch(string Subject)
        {
            DataSet ds = new DataSet();
            conn = new SqlConnection(str);
            pter = new SqlDataAdapter(String.Format(@"select questionID,subjectType,questionType,questionText,score from dbo.TheQuestionBank where subjectType='{0}'", Subject), conn);
            try
            {
                conn.Open();
                pter.Fill(ds, "TheQuestionBank");
            }
            finally
            {
                conn.Close();

            };
            return ds;
        }
        public DataSet CheckTestManger()
        {
            ds = new DataSet();
            conn = new SqlConnection(str);
            pter = new SqlDataAdapter(@"select a.examId 试卷编号,a.examtype 试卷名称,b.type 试卷状态 from EndExamSocre a
                        inner join dbo.statestype b on b.Id = a.statesId", conn);
            try
            {
                conn.Open();
                pter.Fill(ds, "EndExamSocre");
            }
            catch (Exception)
            {


            }
            finally { conn.Close(); };
            return ds;

        }

        public DataSet ExamQuestions()
        {
            int count = 0;
            for (int i = 0; i < UserInfo._ExamQuestion.Length; i++)
            {

                if (UserInfo._ExamQuestion[i]==null)
                {
                    count++;
                }
            }

            ds = new DataSet();
            conn = new SqlConnection(str);
            string sql = string.Format(@"select * from TheQuestionBank where  questionID between {0} and {1} and questionType='填空题'or questionType='解答题' "
                                       , UserInfo._ExamQuestion[0], UserInfo._ExamQuestion[UserInfo._ExamQuestion.Length - count-1]);
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
                                        from Examination_list");
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

        public int UpdateScore( int score)
        {
            int res = 0;
            ds = new DataSet();
            conn = new SqlConnection(str);
            comd = new SqlCommand(String.Format(@"update  dbo.EndExamSocre set examscore={0},statesId=1  where examId ='{1}'", score, Pass.EndexamnationId), conn);

            try
            {
                conn.Open();
                res = comd.ExecuteNonQuery();
            }
            catch (Exception)
            {


            }
            finally { conn.Close(); };
            return res;

        }
        public DataSet Subject()
        {
            ds = new DataSet();
            conn = new SqlConnection(str);
            string sql = string.Format(@"select coursename from dbo.class_schedule");
            pter = new SqlDataAdapter(sql, conn);
            try
            {
                conn.Open();

                pter.Fill(ds, "class_schedule");
            }
            catch (Exception ex)
            {
                Console.WriteLine("异常！{0}", ex.Message);
            }
            finally { conn.Close(); conn.Dispose(); };
            return ds;
        }

    }
}
