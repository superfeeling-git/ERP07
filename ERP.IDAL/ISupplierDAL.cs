using ERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.IDAL
{
    public interface ISupplierDAL<TModel> : IBaseDAL<TModel>
    {
        /// <summary>
        /// 获取最大编号
        /// </summary>
        /// <returns></returns>
        object GetMaxCode();
        new int Create(TModel model);
        /// <summary>
        /// 根据供应商ID获取所有的品牌
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<ProductClassModel> GetBrandBySupplierID(int id);
        /// <summary>
        /// 更新供应商状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool UpdateStatus(int[] SupplierID, string status);
    }
}
