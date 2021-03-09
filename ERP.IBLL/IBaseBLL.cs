using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Model;

namespace ERP.IBLL
{
    public interface IBaseBLL<TModel>
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ReturnInfo Create(TModel model);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ReturnInfo Update(TModel model);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ReturnInfo Delete(int id);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        ReturnInfo BatchDelete(int[] idList);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        ReturnInfo BatchDelete(string idList);
        /// <summary>
        /// 根据ID返回单条实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TModel GetModelByID(int id);
        /// <summary>
        /// 根据字段名返回单条实体
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        TModel GetModelByName(string name);
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        IList<TModel> GetAll();
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Tuple<IList<SupplierModel>, int> GetPage<SearchModel>(string order, SearchModel where = null, int pageIndex = 1, int pageSize = 10)
            where SearchModel : class, new();
    }
}
