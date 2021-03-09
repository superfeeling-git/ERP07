using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Model
{
    public class ProductClassModel
    {
        #region 公共属性
        ///<Summary>
        /// 分类ID
        ///</Summary>
        public int ClassID { get; set; }
        ///<Summary>
        /// 分类名称
        ///</Summary>
        public string ClassName { get; set; }
        ///<Summary>
        /// 分类描述
        ///</Summary>
        public string ClassIntro { get; set; }
        ///<Summary>
        /// 分类级别
        ///</Summary>
        public int Depth { get; set; }
        ///<Summary>
        /// 父ID
        ///</Summary>
        public int ParentID { get; set; }
        ///<Summary>
        /// 分类路径
        ///</Summary>
        public string ParentPath { get; set; }
        #endregion
    }

    public class TreeModel
    {
        public string title { get; set; }
        public int id { get; set; }
        public List<TreeModel> children { get; set; } = new List<TreeModel>();
        public bool spread { get; set; } = true;
    }
}
