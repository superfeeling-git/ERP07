using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Model;
using ERP.IBLL;

namespace ERP.IBLL
{
    public interface IAdminBLL<TModel> : IBaseBLL<TModel>
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="adminModel"></param>
        /// <returns></returns>
        ReturnInfo Login(AdminModel adminModel);
    }
}
