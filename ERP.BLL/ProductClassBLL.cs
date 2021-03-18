using ERP.IBLL;
using ERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.IDAL;

namespace ERP.BLL
{
    public class ProductClassBLL : IProductClassBLL<ProductClassModel>
    {
        private IProductClassDAL<ProductClassModel> productClassDAL;
        
        public ProductClassBLL(IProductClassDAL<ProductClassModel> _productClassDAL)
        {
            this.productClassDAL = _productClassDAL;
        }

        public ReturnInfo BatchDelete(int[] idList)
        {
            throw new NotImplementedException();
        }

        public ReturnInfo BatchDelete(string idList)
        {
            throw new NotImplementedException();
        }

        public ReturnInfo Create(ProductClassModel model)
        {
            if(model.ParentID == 0)
            {
                model.ParentID = 0;
                model.Depth = 0;
                model.ParentPath = "0";
            }
            else
            {
                var parentModel = productClassDAL.GetModelByID(model.ParentID);
                model.Depth = parentModel.Depth + 1;
                model.ParentPath = $"{parentModel.ParentPath},{parentModel.ClassID}";
            }

            return new ReturnInfo { code = Convert.ToInt32(!productClassDAL.Create(model)), message = "添加分类成功" };
        }

        /// <summary>
        /// id:要删除的分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ReturnInfo Delete(int id)
        {
            if(productClassDAL.GetAll().Any(m => m.ParentID == id))
            {
                return new ReturnInfo { code = 1, message = "当前分类还有子分类" };
            }

            productClassDAL.Delete(id);

            return new ReturnInfo { code = 0, message = "分类删除成功" };
        }

        /// <summary>
        /// 存储递归后的数据
        /// </summary>
        List<ProductClassModel> productClassModels = new List<ProductClassModel>();

        /// <summary>
        /// 获取递归后的全部数据
        /// </summary>
        /// <returns></returns>
        public IList<ProductClassModel> GetAll()
        {
            foreach (var item in productClassDAL.GetAll().Where(m => m.ParentID == 0))
            {
                productClassModels.Add(item);
                GetSubNode(item.ClassID);
            }

            return productClassModels;
        }

        /// <summary>
        /// 递归获取数据
        /// </summary>
        /// <param name="ClassID"></param>
        private void GetSubNode(int ClassID)
        {
            foreach (var item in productClassDAL.GetAll().Where(m=>m.ParentID == ClassID))
            {
                productClassModels.Add(item);
                GetSubNode(item.ClassID);
            }
        }

        public ProductClassModel GetModelByID(int id)
        {
            return productClassDAL.GetModelByID(id);
        }

        public ProductClassModel GetModelByName(string name)
        {
            throw new NotImplementedException();
        }

        public ReturnInfo Update(ProductClassModel model)
        {
            return new ReturnInfo { code = Convert.ToInt32(!productClassDAL.Update(model)), message = "更新分类成功" };
        }

        public ReturnInfo MoveClass(int ClassID, int TargetId)
        {
            //当前分类
            var currModel = productClassDAL.GetModelByID(ClassID);

            //目标分类
            var targetModel = productClassDAL.GetModelByID(TargetId);

            //1、判断，目标分类不能是当前分类的子分类
            if($",{targetModel.ParentPath},".Contains($",{ClassID},"))
            {
                return new ReturnInfo { code = 1, message = "目标分类不能是当前分类的子分类" };
            }

            //2、获取所有的分类，包括当前分类和所有子分类

            var subNodes = productClassDAL.getSubNodes(ClassID);

            //3、遍历处理每一个分类，更新Depth和ParentPath

            var DiffDepth = targetModel.Depth + 1 - currModel.Depth;

            foreach (var item in subNodes)
            {
                //更新Depth和ParentPath
                item.Depth = item.Depth + DiffDepth;
                item.ParentPath = $",{item.ParentPath}".Replace(",0", $"{targetModel.ParentPath},{targetModel.ClassID}");

                if(item.ClassID == ClassID)
                {
                    item.ParentID = TargetId;
                }

                productClassDAL.MoveClass(item);
            }

            return new ReturnInfo { code = 0, message = "移动分类成功" };
        }

        Tuple<IList<ProductClassModel>, int> IBaseBLL<ProductClassModel>.GetPage<SearchModel>(string order, SearchModel where, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
