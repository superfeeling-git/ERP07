using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Model
{
    public class ReturnInfo
    {
        /// <summary>
        /// Code:0 成功， 1:失败
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>
        public string message { get; set; }
    }
}
