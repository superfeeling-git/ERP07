using ERP.IBLL;
using ERP.IDAL;
using ERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace ERP.BLL
{
    public class SupplierBLL : ISupplierBLL<SupplierModel>
    {
        private ISupplierDAL<SupplierModel> supplierDAL;
        private ISupplier_ProductClassDAL<Supplier_ProductClassModel> supplier_ProductClassDAL;

        public SupplierBLL
            (
            ISupplierDAL<SupplierModel> _supplierDAL,
            ISupplier_ProductClassDAL<Supplier_ProductClassModel> supplier_ProductClassDAL
            )
        {
            this.supplierDAL = _supplierDAL;
            this.supplier_ProductClassDAL = supplier_ProductClassDAL;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public ReturnInfo BatchDelete(int[] idList)
        {
            supplierDAL.BatchDelete(idList);
            return new ReturnInfo { code = 0 };
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public ReturnInfo BatchDelete(string idList)
        {
            supplierDAL.BatchDelete(idList);
            return new ReturnInfo { code = 0 };
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnInfo Create(SupplierModel model)
        {
            //编号的生成
            object maxcode = supplierDAL.GetMaxCode();

            if (maxcode == null)
            {
                maxcode = "GYA001";
            }
            else
            {
                maxcode = "GY".GeneratorCode(maxcode.ToString().Replace("GY", ""));
            }

            model.SupplierCode = maxcode.ToString();

            model.AddTime = DateTime.Now;
            
            //中间表
            int newid = supplierDAL.Create(model);

            //批量插入中间表
            foreach (var item in model.ClassID)
            {
                supplier_ProductClassDAL.Create(new Supplier_ProductClassModel { SupplierID = newid, ClassID = item });
            }

            return new ReturnInfo { code = 0 };
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ReturnInfo Delete(int id)
        {
            supplierDAL.Delete(id);
            return new ReturnInfo { code = 0 };
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public IList<SupplierModel> GetAll()
        {
            return supplierDAL.GetAll();
        }

        /// <summary>
        /// 根据供应商ID获取所有的品牌
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<ProductClassModel> GetBrandBySupplierID(int id)
        {
            return supplierDAL.GetBrandBySupplierID(id);
        }

        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SupplierModel GetModelByID(int id)
        {
            SupplierModel supplierModel = supplierDAL.GetModelByID(id);
            supplierModel.ClassID = supplier_ProductClassDAL.GetClassIDBySupplierID(id).Select(m => m.ClassID).ToArray();
            return supplierModel;
        }

        /// <summary>
        /// 根据名称获得实体
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public SupplierModel GetModelByName(string name)
        {
            return supplierDAL.GetModelByName(name);
        }

        /// <summary>
        /// 返回分页数据
        /// </summary>
        /// <typeparam name="SearchModel">泛型</typeparam>
        /// <param name="order">反射</param>
        /// <param name="where"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns>元组</returns>
        public Tuple<IList<SupplierModel>, int> GetPage<SearchModel>(string order, SearchModel where = null, int pageIndex = 1, int pageSize = 10) 
            where SearchModel : class, new()
        {
            //存储查询条件
            List<string> condition = new List<string>();

            string condit = string.Empty;

            //如果查询条件非空
            if (where != null)
            {
                SupplierModel supplierModel = where as SupplierModel;
            
                if(!string.IsNullOrEmpty(supplierModel.SupplierName))
                {
                    condition.Add($"SupplierName LIKE '%{supplierModel.SupplierName}%' ");
                }

                if (!string.IsNullOrEmpty(supplierModel.Contact))
                {
                    condition.Add($"Contact LIKE '%{supplierModel.Contact}%' ");
                }

                if (!string.IsNullOrEmpty(supplierModel.Phone))
                {
                    condition.Add($"Phone LIKE '%{supplierModel.Phone}%' ");
                }

                if (!string.IsNullOrEmpty(supplierModel.Status))
                {
                    condition.Add($"Status = '{supplierModel.Status}' ");
                }

                condit = string.Join("", condition.Select(m => $" and {m} "));
            }

            return supplierDAL.GetPage(condit, ProperyHelper.GetKeyName<SupplierModel>(), pageIndex);
        }


        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnInfo Update(SupplierModel model)
        {
            //LastUpdateTime\\\CreateTime
            model.AddTime = DateTime.Now;

            //中间表
            int newid = supplierDAL.Create(model);

            //批量插入中间表
            foreach (var item in model.ClassID)
            {
                supplier_ProductClassDAL.Create(new Supplier_ProductClassModel { SupplierID = newid, ClassID = item });
            }

            return new ReturnInfo { code = 0 };
        }
    }
}
