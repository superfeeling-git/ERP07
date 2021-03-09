using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Model
{
    public class DictModel
    {
        #region 公共属性
        ///<Summary>
        /// 字典ID
        ///</Summary>
        public int DictID { get; set; }
        ///<Summary>
        /// 字典名称
        ///</Summary>
        public string DictName { get; set; }
        ///<Summary>
        /// 字典排序
        ///</Summary>
        public int DictOrder { get; set; }
        ///<Summary>
        /// 字典类型
        ///</Summary>
        public int DictType { get; set; }
        #endregion
    }
}
