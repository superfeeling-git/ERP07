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
    }
}
