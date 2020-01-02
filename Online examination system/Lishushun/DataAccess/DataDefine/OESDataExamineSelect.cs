using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_examination_system.Lishushun.DataAccess.DataDefine
{
    class OESDataExamineSelectOption
    {
        int id;
        string title;
    }

    /// <summary>
    /// 选择题对象
    /// </summary>
    class OESDataExamineSelect
    {
        int id;
        string title;
        private string _options;
        int[] options
        {
            get
            {
                if (_options != null)
                {
                   string[] temp = _options.Split(',');
                    List<int> ops = new List<int>();
                    for (int i = 0; i < temp.Length; i++)
                    {
                        ops.Add(Convert.ToInt32(temp[i]));
                    }
                }

                return null;
            }
        }
        // 内部用的答案
        private string _answer;
        // 将答案解析成数组
        int[] answer;
        int score;

        /// <summary>
        /// 将读取的数据集中的dataRow传入进来，初始化数据对象
        /// </summary>
        /// <returns></returns>
        public OESDataExamineSelect executeDataRow()
        {
            //OESDataExamineSelect sel = new OESDataExamineSelect();
            //sel.executeDataRow();
            return null;
        }
    }
}
