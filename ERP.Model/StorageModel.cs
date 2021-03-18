using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ERP.Model
{
    public class StorageModel
    {
        #region 公共属性
        ///<Summary>
        /// 仓库ID
        ///</Summary>
        [Key]
        public int StorageID { get; set; }
        ///<Summary>
        /// 类型ID
        ///</Summary>
        public int StorageTypeID { get; set; }
        ///<Summary>
        /// 编号
        ///</Summary>
        public string StorageCode { get; set; }
        ///<Summary>
        /// 名称
        ///</Summary>
        public string StorageName { get; set; }
        ///<Summary>
        /// 状态
        ///</Summary>
        public bool StorageStatus { get; set; }
        ///<Summary>
        /// 省
        ///</Summary>
        public string Province { get; set; }
        ///<Summary>
        /// 市
        ///</Summary>
        public string City { get; set; }
        ///<Summary>
        /// 区
        ///</Summary>
        public string Area { get; set; }
        ///<Summary>
        /// 地址
        ///</Summary>
        public string Address { get; set; }
        ///<Summary>
        /// 库位
        ///</Summary>
        public string StorageLocation { get; set; }
        ///<Summary>
        /// 创建时间
        ///</Summary>
        public DateTime CreateTime { get; set; }
        ///<Summary>
        /// 创建人
        ///</Summary>
        public string UserName { get; set; }
        /// <summary>
        /// 仓库类型
        /// </summary>
        public string StorageTypeName { get; set; }

        #endregion
    }
}
