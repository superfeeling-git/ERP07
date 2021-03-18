using ERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.IBLL
{
    public interface ISupplierBLL<TModel> : IBaseBLL<TModel>
    {
        IList<ProductClassModel> GetBrandBySupplierID(int id);
        /// <summary>
        /// 更新供应商状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool UpdateStatus(int[] SupplierID, string status);
    }
}
