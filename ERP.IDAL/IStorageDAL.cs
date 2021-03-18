using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.IDAL
{
    public interface IStorageDAL<TModel> : IBaseDAL<TModel>
    {
        /// <summary>
        /// 获取最大编号
        /// </summary>
        /// <returns></returns>
        object GetMaxCode();
        /// <summary>
        /// 更改状态
        /// </summary>
        /// <param name="StorageID"></param>
        /// <returns></returns>
        bool UpdateStatus(int StorageID);
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="where"></param>
        /// <param name="field"></param>
        /// <param name="order"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Tuple<IList<TModel>, int> GetPage(string where, string field, string order, int pageIndex = 1, int pageSize = 10);
    }
}
