using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Model
{
    public class Supplier_ProductClassModel
    {
        #region 公共属性
        ///<Summary>
        /// ID
        ///</Summary>
        public int ID { get; set; }
        ///<Summary>
        /// 供应商ID
        ///</Summary>
        public int SupplierID { get; set; }
        ///<Summary>
        /// 分类ID
        ///</Summary>
        public int ClassID { get; set; }
        #endregion
    }
}
