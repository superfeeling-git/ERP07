using ERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.IBLL
{
    public interface IProductClassBLL<TModel> : IBaseBLL<TModel>
    {
        /// <summary>
        /// 移动分类
        /// </summary>
        /// <param name="ClassID"></param>
        /// <param name="TargetId"></param>
        /// <returns></returns>
        ReturnInfo MoveClass(int ClassID, int TargetId);
    }
}
