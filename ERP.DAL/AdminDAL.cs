using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.IDAL;
using ERP.Model;
using ERP.Common;

namespace ERP.DAL
{
    public class AdminDAL : IAdminDAL<AdminModel>
    {
        public AdminDAL() { }

        #region Admin Interface Implement
        /// <summary>
        /// Add Admin
        /// </summary>
        /// <param name="model">Admin Model</param>
        /// <returns>True or False</returns>
        public bool Create(AdminModel model)
        {
            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@UserName", model.UserName);
            param[1] = new SqlParameter("@Password", model.Password);
            param[2] = new SqlParameter("@LastLoginTime", model.LastLoginTime);
            param[3] = new SqlParameter("@LastLoginIP", model.LastLoginIP);

            try
            {
                string sql = "INSERT INTO Admin (UserName,Password,LastLoginTime,LastLoginIP) VALUES(@UserName,@Password,@LastLoginTime,@LastLoginIP)";
                SqlHelper.ExecuteNonQuery(sql, default, param);
                return true;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return false;
            }
        }

        /// <summary>
        /// Update Admin
        /// </summary>
        /// <param name="model">Admin Model</param>
        /// <returns>True or False</returns>
        public bool Update(AdminModel model)
        {
            SqlParameter[] param = new SqlParameter[5];

            param[0] = new SqlParameter("@AdminID", model.AdminID);
            param[1] = new SqlParameter("@UserName", model.UserName);
            param[2] = new SqlParameter("@Password", model.Password);
            param[3] = new SqlParameter("@LastLoginTime", model.LastLoginTime);
            param[4] = new SqlParameter("@LastLoginIP", model.LastLoginIP);
            try
            {
                string sql = "UPDATE Admin SET UserName = @UserName,Password = @Password,LastLoginTime = @LastLoginTime,LastLoginIP = @LastLoginIP WHERE AdminID = @AdminID";
                SqlHelper.ExecuteNonQuery(sql, default, param);
                return true;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return false;
            }
        }

        /// <summary>
        /// Delete Admin By ID
        /// </summary>
        /// <param name="id">Admin ID</param>
        /// <returns>True or False</returns>
        public bool Delete(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@AdminID", id);
            try
            {
                string sql = "DELETE FROM Admin WHERE AdminID = @AdminID";
                SqlHelper.ExecuteNonQuery(sql, default, param);
                return true;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return false;
            }
        }



        /// <summary>
        /// BatchDelete Admin
        /// </summary>
        /// <param name="idList">idList</param>
        /// <returns>True or False</returns>
        public bool BatchDelete(int[] idList)
        {
            return BatchDelete(string.Join(",", idList));
        }

        /// <summary>
        /// BatchDelete Admin
        /// </summary>
        /// <param name="idList">idList</param>
        /// <returns>True or False</returns>
        public bool BatchDelete(string idList)
        {
            try
            {
                string sql = $"DELETE FROM Admin WHERE AdminID IN ({idList})";
                SqlHelper.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return false;
            }
        }


        /// <summary>
        /// Get Admin By ID
        /// </summary>
        /// <param name="id">Admin ID</param>
        /// <returns>Admin Model</returns>
        public AdminModel GetModelByID(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@AdminID", id);

            return SqlHelper.ExecuteGetModel<AdminModel>("SELECT * FROM Admin WHERE AdminID = @AdminID", new SqlParameter("@AdminID", id));
        }

        /// <summary>
        /// Get Admin By Name
        /// </summary>
        /// <param name="name">Admin Name</param>
        /// <returns>Admin Model</returns>
        public AdminModel GetModelByName(string name)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@UserName", name);

            return SqlHelper.ExecuteGetModel<AdminModel>("SELECT * FROM Admin WHERE UserName = @UserName", new SqlParameter("@UserName", name));
        }

        /// <summary>
        /// Get Admin List
        /// </summary>
        /// <returns>Admin List</returns>
        public IList<AdminModel> GetAll()
        {
            return SqlHelper.ExecuteList<AdminModel>("SELECT * FROM Admin ORDER BY AdminID");
        }

        /// <summary>
        /// Check If Admin Exist
        /// </summary>
        /// <param name="name">Admin Name</param>
        /// <returns>True or False</returns>
        public bool IsExist(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Tuple<List<AdminModel>, int> GetPage(string where, string order, int pageIndex = 1, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        Tuple<IList<AdminModel>, int> IBaseDAL<AdminModel>.GetPage(string where, string order, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
