using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Model
{
    public class StorageTypeModel
    {
        #region 公共属性
        ///<Summary>
        /// 类型ID
        ///</Summary>
        public int StorageTypeID { get; set; }
        ///<Summary>
        /// 类型编号
        ///</Summary>
        public string StorageTypeCode { get; set; }
        ///<Summary>
        /// 名称
        ///</Summary>
        public string StorageTypeName { get; set; }
        ///<Summary>
        /// 备注
        ///</Summary>
        public string Remark { get; set; }
        ///<Summary>
        /// 最后编辑时间
        ///</Summary>
        public DateTime LastEditTime { get; set; }
        ///<Summary>
        /// 最后编辑人
        ///</Summary>
        public string UserName { get; set; }
        #endregion
    }
}
