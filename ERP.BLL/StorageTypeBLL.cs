using ERP.IBLL;
using ERP.IDAL;
using ERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BLL
{
    public class StorageTypeBLL : IStorageTypeBLL<StorageTypeModel>
    {
        public IStorageTypeDAL<StorageTypeModel> storagetypeDAL;

        public StorageTypeBLL(IStorageTypeDAL<StorageTypeModel> _storagetypeDAL)
        {
            this.storagetypeDAL = _storagetypeDAL;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public ReturnInfo BatchDelete(int[] idList)
        {
            storagetypeDAL.BatchDelete(idList);
            return new ReturnInfo { code = 0 };
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public ReturnInfo BatchDelete(string idList)
        {
            storagetypeDAL.BatchDelete(idList);
            return new ReturnInfo { code = 0 };
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnInfo Create(StorageTypeModel model)
        {
            storagetypeDAL.Create(model);
            return new ReturnInfo { code = 0 };
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ReturnInfo Delete(int id)
        {
            storagetypeDAL.Delete(id);
            return new ReturnInfo { code = 0 };
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public IList<StorageTypeModel> GetAll()
        {
            return storagetypeDAL.GetAll();
        }

        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StorageTypeModel GetModelByID(int id)
        {
            return storagetypeDAL.GetModelByID(id);
        }

        /// <summary>
        /// 根据名称获得实体
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public StorageTypeModel GetModelByName(string name)
        {
            return storagetypeDAL.GetModelByName(name);
        }

        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Tuple<IList<StorageTypeModel>, int> GetPage(string where, string order, int pageIndex = 1, int pageSize = 10)
        {
            return storagetypeDAL.GetPage(where, order, pageIndex, pageSize);
        }

        public Tuple<IList<StorageTypeModel>, int> GetPage<SearchModel>(string order, SearchModel where = null, int pageIndex = 1, int pageSize = 10) where SearchModel : class, new()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnInfo Update(StorageTypeModel model)
        {
            storagetypeDAL.Update(model);
            return new ReturnInfo { code = 0 };
        }
    }
}
