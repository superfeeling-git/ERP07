using ERP.Common;
using ERP.IBLL;
using ERP.IDAL;
using ERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace ERP.BLL
{
    public class StorageBLL : IStorageBLL<StorageModel>
    {
        public IStorageDAL<StorageModel> storageDAL;

        public StorageBLL(IStorageDAL<StorageModel> _storageDAL)
        {
            this.storageDAL = _storageDAL;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public ReturnInfo BatchDelete(int[] idList)
        {
            storageDAL.BatchDelete(idList);
            return new ReturnInfo { code = 0 };
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public ReturnInfo BatchDelete(string idList)
        {
            storageDAL.BatchDelete(idList);
            return new ReturnInfo { code = 0 };
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnInfo Create(StorageModel model)
        {
            model.CreateTime = DateTime.Now;

            //编号的生成
            object maxcode = storageDAL.GetMaxCode();

            if (maxcode == null)
            {
                maxcode = "GYA001";
            }
            else
            {
                maxcode = "GY".GeneratorCode(maxcode.ToString().Replace("GY", ""));
            }

            model.StorageCode = maxcode.ToString();

            //当前用户
            model.UserName = HttpContext.Current.User.Identity.Name;

            storageDAL.Create(model);
            return new ReturnInfo { code = 0 };
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ReturnInfo Delete(int id)
        {
            storageDAL.Delete(id);
            return new ReturnInfo { code = 0 };
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public IList<StorageModel> GetAll()
        {
            return storageDAL.GetAll();
        }

        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StorageModel GetModelByID(int id)
        {
            return storageDAL.GetModelByID(id);
        }

        /// <summary>
        /// 根据名称获得实体
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public StorageModel GetModelByName(string name)
        {
            return storageDAL.GetModelByName(name);
        }

        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Tuple<IList<StorageModel>, int> GetPage(string where, string order, int pageIndex = 1, int pageSize = 10)
        {
            return storageDAL.GetPage(where, order, pageIndex, pageSize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="SearchModel"></typeparam>
        /// <param name="field">排序字段</param>
        /// <param name="order"></param>
        /// <param name="where"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Tuple<IList<StorageModel>, int> GetPage<SearchModel>(string field, string order, SearchModel where = null, int pageIndex = 1, int pageSize = 10) 
            where SearchModel : class, new()
        {
            //存储查询条件
            List<string> condition = new List<string>();

            string condit = string.Empty;

            //如果查询条件非空
            if (where != null)
            {
                StorageModel searchModel = where as StorageModel;

                if (!string.IsNullOrEmpty(searchModel.StorageName))
                {
                    condition.Add($"StorageName LIKE '%{searchModel.StorageName}%' ");
                }

                if (!string.IsNullOrEmpty(searchModel.StorageTypeName))
                {
                    condition.Add($"StorageTypeName LIKE '%{searchModel.StorageTypeName}%' ");
                }

                condit = string.Join("", condition.Select(m => $" and {m} "));
            }

            string _field = ProperyHelper.GetKeyName<StorageModel>();

            if(!string.IsNullOrWhiteSpace(field))
            {
                _field = field;
            }

            return storageDAL.GetPage(condit, _field, order, pageIndex, pageSize);
        }

        public Tuple<IList<StorageModel>, int> GetPage<SearchModel>(string order, SearchModel where = null, int pageIndex = 1, int pageSize = 10) where SearchModel : class, new()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnInfo Update(StorageModel model)
        {
            //存储最后更新
            model.CreateTime = DateTime.Now;

            //当前用户
            model.UserName = HttpContext.Current.User.Identity.Name;

            storageDAL.Update(model);
            return new ReturnInfo { code = 0 };
        }

        /// <summary>
        /// 更新仓库状态
        /// </summary>
        /// <param name="StorageID"></param>
        /// <returns></returns>
        public bool UpdateStatus(int StorageID)
        {
            return storageDAL.UpdateStatus(StorageID);
        }
    }
}
