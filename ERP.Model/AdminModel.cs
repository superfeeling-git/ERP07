using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Model
{
    public class AdminModel
    {
        #region 公共属性
        ///<Summary>
        /// 管理员ID
        ///</Summary>
        public int AdminID { get; set; }
        ///<Summary>
        /// 用户名
        ///</Summary>
        public string UserName { get; set; }
        ///<Summary>
        /// 密码
        ///</Summary>
        public string Password { get; set; }
        ///<Summary>
        /// 末次登录时间
        ///</Summary>
        public DateTime LastLoginTime { get; set; }
        ///<Summary>
        /// 末次登录IP
        ///</Summary>
        public string LastLoginIP { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string Code { get; set; }
        #endregion
    }
}
