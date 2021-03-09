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
        object GetMaxCode();
        new int Create(TModel model);
        /// <summary>
        /// 根据供应商ID获取所有的品牌
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<ProductClassModel> GetBrandBySupplierID(int id);
    }
}
