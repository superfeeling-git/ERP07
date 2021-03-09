using ERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.IDAL
{
    public interface ISupplier_ProductClassDAL<TModel> : IBaseDAL<TModel>
    {
        IList<Supplier_ProductClassModel> GetClassIDBySupplierID(int id);
    }
}
