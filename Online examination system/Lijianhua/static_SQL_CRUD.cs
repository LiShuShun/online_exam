using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_examination_system.Lijianhua
{
    public static class static_SQL_CRUD
    {
        



        //查看各个表全部信息
        public static string AllInfoOfStudent = string.Format("select stuid 学号,stuname 姓名,stuclass 班级,stuage 年龄,major 专业,dapartment 系别,password 密码,a.purviewname 身份,note 备注 from Student_list  s inner join authority_list a on a.purviewid = s.purviewwid ");//学生表
        public static string AllInfoOfTeacher = string.Format("select teacherid 编号,teaname 姓名,department 系别,teacherage 年龄,password 密码,Au.purviewname 职位,note 备注 from Teacher_list t inner join authority_list Au on Au.purviewid  = t.purviewid");//老师表
        public static string AllInfoOfAdmin = string.Format("select adminid 编号,adminname 姓名,password 密码,au.purviewname 身份 from Administrator_list ad inner join authority_list au on au.purviewid = ad.purviewid");//管理员表
        public static string AllInfoOfCourse = string.Format("select * from class_schedule");//课程表
        public static string AllInfoOfQuestionsBank = string.Format("select questionID 问题编号,subjectType 对应科目,questionType 题型,questionText 题干,correctAnswer 正确答案,wrongAnswer 错误答案, Convert(decimal(18,1),score) 分值 from TheQuestionBank");//题库表
        public static string AllInfoOfExam = string.Format("select examname 考试名称,subjects 科目,examdate 考试时间 from Examination_list");//考试表

        public static string SingleExaminfoTrue(string examName) {
            return string.Format("select * from Examination_list where examname = '{0}'", examName);//考试表
        } 



        //查看当前登录的管理员表的单个账户的所有信息
        public static string AdminId()
        {
           return string.Format("select * from Administrator_list where adminid = '{0}'",staticModle.currentAccount);

        } //管理员表的id






        //查看学生表和老师表里面单个账户的所以信息 赋给修改信息的页面
        public static string StudentInfoSingle()
        {
            return string.Format(@"select * from Student_list where stuid = '{0}'",staticModle.DU[0]);
        }
        public static string TeacherInfoSingle()
        {
            return string.Format(@"select * from Teacher_list where teacherid = '{0}'", staticModle.DU[0]);
        }
      



        #region 模糊搜索
        public static string StudentFuzzySearch() {

            //模糊搜索的字段为int类型时，需要把该字段转换为string类型 语法：cast(字段 as nvarchar(50)) like '%%'
            return string.Format(@"select stuid 学号,stuname 姓名,stuclass 班级,stuage 年龄,major 专业,dapartment 系别,password 密码,a.purviewname 身份,note 备注 from Student_list  s inner join authority_list a on a.purviewid = s.purviewwid
where stuid like '%{0}%' or stuname like '%{1}%' or stuclass like '%{2}%' or cast(stuage as nvarchar(50)) like '%{3}%'  or major like '%{4}%' or dapartment like '%{5}%' or password like '%{6}%' or a.purviewname like '%{7}%' or note like '%{8}%'",
                                                                 staticModle.SearchContent,
                                                                 staticModle.SearchContent,
                                                                 staticModle.SearchContent,
                                                                 staticModle.SearchContent,
                                                                 staticModle.SearchContent,
                                                                 staticModle.SearchContent,
                                                                 staticModle.SearchContent,
                                                                 staticModle.SearchContent,
                                                                 staticModle.SearchContent);
            
        }//学生表
        public static string TeacherFuzzySearch()
        {

            //模糊搜索的字段为int类型时，需要把该字段转换为string类型 语法：cast(字段 as nvarchar(50)) like '%%'
            return string.Format(@"select teacherid 编号,teaname 姓名,department 系别,teacherage 年龄,password 密码,Au.purviewname 职位,note 备注 from Teacher_list t inner join authority_list Au on Au.purviewid  = t.purviewid
where teacherid like '%{0}%' or teaname like '%{1}%' or department like '%{2}%' or teacherage like '%{3}%'  or password like '%{4}%' or Au.purviewname like '%{5}%' or note like '%{6}%' ",
                                                                 staticModle.SearchContent,
                                                                 staticModle.SearchContent,
                                                                 staticModle.SearchContent,
                                                                 staticModle.SearchContent,
                                                                 staticModle.SearchContent,
                                                                 staticModle.SearchContent,
                                                                 staticModle.SearchContent);

        }//老师表
        public static string AdminFuzzySearch = string.Format("");//管理员表  用户太少，不设定设置搜索功能
        public static string QuestionsFuzzySearch(string questionType,string subjecType)
        {
            return string.Format(@"select questionID 问题编号,subjectType 对应科目,questionType 题型,questionText 题干,correctAnswer 正确答案,wrongAnswer 错误答案,score 分值 from TheQuestionBank where 
                                       questionType = '{0}' and subjectType = '{1}'", questionType,subjecType);
        }




        public static string AgeStudentFuzzySearch()
        {

            //模糊搜索的字段为int类型时，需要把该字段转换为string类型 语法：cast(字段 as nvarchar(50)) like '%%'
            return string.Format(@"select stuid 学号,stuname 姓名,stuclass 班级,stuage 年龄,major 专业,dapartment 系别,password 密码,a.purviewname 身份,note 备注 from Student_list  s inner join authority_list a on a.purviewid = s.purviewwid
              where cast(stuage as nvarchar(50)) like '%{0}%'",staticModle.SearchContent);

        }//模糊搜索学生年龄
        public static string AgeTeacherFuzzySearch()
        {

            //模糊搜索的字段为int类型时，需要把该字段转换为string类型 语法：cast(字段 as nvarchar(50)) like '%%'
            return string.Format(@"select teacherid 编号,teaname 姓名,department 系别,teacherage 年龄,password 密码,Au.purviewname 职位,note 备注 from Teacher_list t inner join authority_list Au on Au.purviewid  = t.purviewid
            where teacherage like '%{0}%'  ",staticModle.SearchContent);

        }//模糊搜索老师年龄





        #endregion







        #region 删除信息
        public static string DeleteStudent(string DeleteKeys)
        {
            return string.Format("delete Student_list where stuid = '{0}'", DeleteKeys);//学生表
        }
        public static string DeleteTeacher(string DeleteKeys)
        {
            return string.Format("delete Teacher_list where teacherid = '{0}'", DeleteKeys);//老师表
        }
        public static string DeleteAdmin(string DeleteKeys)
        {
            return string.Format("delete Administrator_list where adminid = '{0}'", DeleteKeys);//管理员表
        } 
        #endregion


        #region 修改信息
        public static string UpdataStudent()
        {
             return string.Format(@"update Student_list set stuname = '{0}',stuclass ='{1}',stuage = {2},major = '{3}',dapartment ='{4}',password = '{5}',purviewwid = 1 ,note = '{6}' where stuid = '{7}'",
                                                                 staticModle.stuname,
                                                                 staticModle.stuclass,
                                                                 staticModle.stuage,
                                                                 staticModle.major,
                                                                 staticModle.dapartment,
                                                                 staticModle.password,
                                                                 staticModle.note,
                                                                 staticModle.stuid);
        }//学生表

        public static string UpdataTeacher()
        {
             return string.Format(@"update Teacher_list set teaname = '{0}',department ='{1}',teacherage = '{2}',password = '{3}',note ='{4}' where teacherid = '{5}'",
                                                                  staticModle.teaname,
                                                                 staticModle.department,
                                                                 staticModle.teacherage,
                                                                 staticModle.password,
                                                                 staticModle.note,
                                                                 staticModle.teacherid);
        }//老师表
        public static string UpdataAdmin()
        {
            return string.Format(@"update Administrator_list set adminname = '{0}',password = '{1}' where adminid = '{2}'",
                                                staticModle.adminname,
                                                staticModle.password,
                                                staticModle.adminid);
        }//管理员表
       
        
        
        
        
        
        
        
        #endregion


        #region 添加信息
        public static string AddStudenthInfo()
        {
            return string.Format(@"insert into dbo.Student_list values('{0}','{1}',{2},'{3}','{4}','{5}',1,'{6}') ",
                                                                 staticModle.stuname,
                                                                 staticModle.stuclass,
                                                                 staticModle.stuage,
                                                                 staticModle.major,
                                                                 staticModle.dapartment,
                                                                 staticModle.password,
                                                                 staticModle.note);

        }//学生表
        public static string AddTeacherInfo()
        {
            return string.Format(@"insert into dbo.Teacher_list  values('{0}','{1}','{2}','{3}',2,'{4}') ",
                                                                 staticModle.teaname,
                                                                 staticModle.department,
                                                                 staticModle.teacherage,
                                                                 staticModle.password,
                                                                 staticModle.note);

        }//老师表
        public static string AddAdminInfo()
        {
            return string.Format(@"insert into dbo.Administrator_list  values('{0}','{1}',3) ",
                                                                staticModle.adminname,
                                                                 staticModle.password);

        }//管理员表
        #endregion






        #region 添加题库
        public static string AddQuestions()
        {
            return string.Format(@"insert into TheQuestionBank values('{0}','{1}','{2}','{3}','{4}',{5})",
                                       staticModle.subject,
                                       staticModle.questiontype,
                                       staticModle.questionText,
                                       staticModle.correctAnswer,
                                       staticModle.wrongAnswer,
                                       staticModle.score);
        }
        #endregion

        #region 删除题库
        public static string deleteQuestions(int questionID)
        {
            return string.Format("delete TheQuestionBank where questionID = {0}",questionID);
        }
        #endregion


        #region 创建考试
        public static string createExamination()
        {
            return string.Format(@"insert into Examination_list values('{0}','{1}','{2}','{3}','{4}')",
                                  staticModle.examname,
                                  staticModle.subjects,
                                  staticModle.examdatet,
                                  staticModle.examObject,
                                  staticModle.questions);
        }
        #endregion


        #region 删除考试
        public static string deleteExam(string examname)
        {
            return string.Format(@"delete Examination_list where examname = '{0}'", examname);
        }
        #endregion


        #region 选择科目就显示题库相应的题
        public static string partOfQuestions()
        {
            return string.Format(@"select questionID 问题编号,subjectType 对应科目,questionType 题型,questionText 题干,correctAnswer 正确答案,wrongAnswer 错误答案,score 分值 from TheQuestionBank where subjectType = '{0}'",staticModle.subjects);
        }
        #endregion

        #region 修改试题信息
        public static string updataQuestions()
        {
            return string.Format(@"update TheQuestionBank set subjectType = '{0}',questionType ='{1}',questionText = '{2}',correctAnswer = '{3}',wrongAnswer ='{4}',score = {5} where questionID = {6}",
                                                                  staticModle.subject,
                                                         staticModle.questiontype,
                                               staticModle.questionText,
                                      staticModle.correctAnswer,
                            staticModle.wrongAnswer,
                   staticModle.score,
           staticModle.questionId);
        }
        #endregion

        #region 修改考试信息
        public static string updateExamInfo()
        {
            return string.Format(@"update Examination_list set examname = '{0}',subjects ='{1}',examdate = '{2}',examObject = '{3}',questions ='{4}' where examId = {5}",
                                                                  staticModle.examname,
                                                         staticModle.subjects,
                                               staticModle.examdatet,
                                      staticModle.examObject,
                            staticModle.questions,
                 staticModle.examId);
        }
        #endregion





    }

}
