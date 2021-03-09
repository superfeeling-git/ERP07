using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Model
{
    public class SupplierModel
    {
        #region 公共属性
        ///<Summary>
        /// 供应商ID
        ///</Summary>
        [Key]
        public int SupplierID { get; set; }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string SupplierCode { get; set; }
        ///<Summary>
        /// 供应商等级
        ///</Summary>
        public string SupplierLevel { get; set; }
        ///<Summary>
        /// 名称
        ///</Summary>
        public string SupplierName { get; set; }
        ///<Summary>
        /// 联系人
        ///</Summary>
        public string Contact { get; set; }
        ///<Summary>
        /// 电话
        ///</Summary>
        public string TEL { get; set; }
        ///<Summary>
        /// 手机号
        ///</Summary>
        public string Phone { get; set; }
        ///<Summary>
        /// 供应商状态
        ///</Summary>
        public string Status { get; set; }
        ///<Summary>
        /// 付款类型
        ///</Summary>
        public string PayType { get; set; }
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
        /// 合同
        ///</Summary>
        public string Photo { get; set; }
        ///<Summary>
        /// 添加时间
        ///</Summary>
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 分类ID
        /// </summary>
        public int[] ClassID { get; set; }
        #endregion
    }
}
