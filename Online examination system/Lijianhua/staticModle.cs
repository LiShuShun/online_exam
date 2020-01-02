using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_examination_system.Lijianhua
{
    public static class staticModle
    {

        //当前登录的账号和密码
        public static string currentAccount { get; set; }
        public static string currentPwd { get; set; }




        

        //按此字段字段进行模糊查找
        public static string SearchContent { get; set; }

        //按此字段进行删
        public static List<string> DU { get; set; }



        #region 添加信息的属性

        //学生属性
        public static string stuid { get;set;}
        public static string stuname { get; set; }
        public static string stuclass { get; set; }
        public static int stuage { get; set; }
        public static string major { get; set; }
        public static string dapartment { get; set; }


        //老师属性
        public static string teacherid { get; set; }
        public static string teaname { get; set; }
        public static string department { get; set; }
        public static string teacherage { get; set; }



        //管理员字段
        public static string adminid { get; set; }
        public static string adminname { get; set; }



        //老师学生管理员的公共字段
        public static string password { get; set; }
        public static string note { get; set; }
        public static string purviewid { get; set; }


        #endregion





        #region 添加题库的字段
        public static int questionId { get; set; }
        public  static string subject { get; set; }
        public static string questiontype { get; set; }
        public static string questionText { get; set; }
        public static string correctAnswer { get; set; }
        public static string wrongAnswer { get; set; }
        public static double score { get; set; }
        #endregion


        #region 添加考试字段
        public static int examId { get; set; }
        public static string examname { get; set; }
        public static string subjects { get; set; }
        public static DateTime examdatet { get; set; }
        public static string examObject { get; set; }
        public static string questions { get; set; }
        #endregion


        

    }
}
