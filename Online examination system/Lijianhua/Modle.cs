using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_examination_system.Lijianhua
{
    public class Modle
    {

        //学生属性
        public string stuid { get; set; }
        public string stuname { get; set; }
        public string stuclass { get; set; }
        public string stuage { get; set; }
        public string major { get; set; }
        public string dapartment { get; set; }


        //老师属性
        public string teacherid { get; set; }
        public string teaname { get; set; }
        public string department { get; set; }
        public string teacherage { get; set; }



        //管理员字段
        public string adminid { get; set; }
        public string adminname { get; set; }



        //老师学生管理员的公共字段
        public string password { get; set; }
        public string note { get; set; }
        public string purviewid { get; set; }

















    }
}
