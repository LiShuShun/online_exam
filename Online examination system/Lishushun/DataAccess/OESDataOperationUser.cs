using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_examination_system.Lishushun.DataAccess
{
    /// <summary>
    /// 用户操作的API方法,基础数据库操作封装到内部，外界只需要调用公开的方法传入参数即可
    /// </summary>
    class OESDataOperationUser
    {
        public OESDataOperationUser getUserInfo(string account)
        {
            // TODO: 根据条件读取数据库数据到DataSet
            // 遍历数据集，创建相关对象数据，然后返回
            return null;
        }
    }
}
