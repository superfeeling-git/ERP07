using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.IBLL
{
    public interface IStorageBLL<TModel> : IBaseBLL<TModel>
    {
        bool UpdateStatus(int StorageID);
        Tuple<IList<TModel>, int> GetPage<SearchModel>(string field, string order, SearchModel where = null, int pageIndex = 1, int pageSize = 10)
            where SearchModel : class, new();
    }
}
