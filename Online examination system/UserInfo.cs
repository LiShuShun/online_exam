using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_examination_system
{
    class UserInfo
    {
        //学生信息
        public static string _Power;
        public static string _LogId;
        public static string _Password;
        public static string _StuName;
        public static string _StuClass;
        public static string _StuAge;
        public static string _Major;
        public static string _Dapartment;
        public static string _Note;

        //考试信息
        public static int _ExamId;
        public static string _Examtype;
        public static string _Examsuject;
        public static string _Examdate;
        public static string[]_ExamQuestion = new string[100];
        public static int _Examscore;


        //当前考试获取字段
        public static int ExamName;

        //用户输入的填空题答案
        public static string[] _FillQES = new string[100];
        //用户输入的解答题答案
        public static string[] _AnswerQES = new string[100];

        //试卷是否批改    
        public static int _ExamStates;
    }
}
