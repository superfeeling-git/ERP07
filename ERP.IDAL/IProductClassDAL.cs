using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Model;

namespace ERP.IDAL
{
    public interface IProductClassDAL<TModel> : IBaseDAL<TModel>
    {
        int GetSubNodeCount(int ClassId);
        /// <summary>
        /// 获取所有子分类
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        IList<ProductClassModel> getSubNodes(int ClassId);
        /// <summary>
        /// 移动分类
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        bool MoveClass(ProductClassModel productClassModel);
    }
}
