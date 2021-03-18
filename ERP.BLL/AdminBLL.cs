using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.IDAL;
using ERP.Model;
using ERP.IBLL;
using System.Web;
using System.Web.Security;
using ERP.Common;

namespace ERP.BLL
{
    public class AdminBLL : IAdminBLL<AdminModel>
    {
        public IAdminDAL<AdminModel> adminDAL;

        public AdminBLL(IAdminDAL<AdminModel> _adminDAL)
        {
            this.adminDAL = _adminDAL;
        }

        public ReturnInfo BatchDelete(int[] idList)
        {
            throw new NotImplementedException();
        }

        public ReturnInfo BatchDelete(string idList)
        {
            throw new NotImplementedException();
        }

        public ReturnInfo Create(AdminModel adminModel)
        {
            throw new NotImplementedException();
        }

        public ReturnInfo Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<AdminModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public AdminModel GetModelByID(int id)
        {
            throw new NotImplementedException();
        }

        public AdminModel GetModelByName(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="adminModel"></param>
        /// <returns></returns>
        public ReturnInfo Login(AdminModel adminModel)
        {
            //验证码
            if(adminModel.Code.ToLower() == HttpContext.Current.Session["validatecode"].ToString().ToLower())
            {
                AdminModel Admin = adminDAL.GetModelByName(adminModel.UserName);

                if(Admin == null)
                {
                    return new ReturnInfo { code = 2, message = "用户不存在" };
                }
                else
                {
                    if(adminModel.Password.MD5Encrypt() == Admin.Password)
                    {
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, adminModel.UserName, DateTime.Now, DateTime.Now.AddHours(1), true, "afas,df,as,dfasdf");

                        string FormData = FormsAuthentication.Encrypt(ticket);

                        HttpCookie httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormData);

                        httpCookie.HttpOnly = true;

                        httpCookie.Expires = DateTime.Now.AddHours(1);

                        //写入
                        HttpContext.Current.Response.Cookies.Add(httpCookie);

                        return new ReturnInfo { code = 0, message = "登录成功" };
                    }
                    else
                    {
                        return new ReturnInfo { code = 3, message = "密码错误" };
                    }
                }
            }
            else
            {
                return new ReturnInfo { code = 1, message = "验证码错误" };
            }
        }

        public ReturnInfo Update(AdminModel model)
        {
            throw new NotImplementedException();
        }

        Tuple<IList<AdminModel>, int> IBaseBLL<AdminModel>.GetPage<SearchModel>(string order, SearchModel where, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
