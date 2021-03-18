using ERP.Common;
using ERP.IDAL;
using ERP.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class StorageTypeDAL : IStorageTypeDAL<StorageTypeModel>
    {
        public StorageTypeDAL() { }

        #region StorageType Interface Implement
        /// <summary>
        /// Add StorageType
        /// </summary>
        /// <param name="model">StorageType Model</param>
        /// <returns>True or False</returns>
        public bool Create(StorageTypeModel model)
        {
            SqlParameter[] param = new SqlParameter[5];

            param[0] = new SqlParameter("@StorageTypeCode", model.StorageTypeCode);
            param[1] = new SqlParameter("@StorageTypeName", model.StorageTypeName);
            param[2] = new SqlParameter("@Remark", model.Remark);
            param[3] = new SqlParameter("@LastEditTime", model.LastEditTime);
            param[4] = new SqlParameter("@UserName", model.UserName);

            try
            {
                string sql = "INSERT INTO StorageType (StorageTypeCode,StorageTypeName,Remark,LastEditTime,UserName) VALUES(@StorageTypeCode,@StorageTypeName,@Remark,@LastEditTime,@UserName)";
                SqlHelper.ExecuteNonQuery(sql, param);
                return true;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return false;
            }
        }

        /// <summary>
        /// Update StorageType
        /// </summary>
        /// <param name="model">StorageType Model</param>
        /// <returns>True or False</returns>
        public bool Update(StorageTypeModel model)
        {
            SqlParameter[] param = new SqlParameter[6];

            param[0] = new SqlParameter("@StorageTypeID", model.StorageTypeID);
            param[1] = new SqlParameter("@StorageTypeCode", model.StorageTypeCode);
            param[2] = new SqlParameter("@StorageTypeName", model.StorageTypeName);
            param[3] = new SqlParameter("@Remark", model.Remark);
            param[4] = new SqlParameter("@LastEditTime", model.LastEditTime);
            param[5] = new SqlParameter("@UserName", model.UserName);
            try
            {
                string sql = "UPDATE StorageType SET StorageTypeCode = @StorageTypeCode,StorageTypeName = @StorageTypeName,Remark = @Remark,LastEditTime = @LastEditTime,UserName = @UserName WHERE StorageTypeID = @StorageTypeID";
                SqlHelper.ExecuteNonQuery(sql, param);
                return true;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return false;
            }
        }

        /// <summary>
        /// Delete StorageType By ID
        /// </summary>
        /// <param name="id">StorageType ID</param>
        /// <returns>True or False</returns>
        public bool Delete(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@StorageTypeID", id);
            try
            {
                string sql = "DELETE FROM StorageType WHERE StorageTypeID = @StorageTypeID";
                SqlHelper.ExecuteNonQuery(sql, param);
                return true;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return false;
            }
        }



        /// <summary>
        /// BatchDelete StorageType
        /// </summary>
        /// <param name="idList">idList</param>
        /// <returns>True or False</returns>
        public bool BatchDelete(int[] idList)
        {
            return BatchDelete(string.Join(",", idList));
        }

        /// <summary>
        /// BatchDelete StorageType
        /// </summary>
        /// <param name="idList">idList</param>
        /// <returns>True or False</returns>
        public bool BatchDelete(string idList)
        {
            try
            {
                string sql = $"DELETE FROM StorageType WHERE StorageTypeID IN ({idList})";
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
        /// Get StorageType By ID
        /// </summary>
        /// <param name="id">StorageType ID</param>
        /// <returns>StorageType Model</returns>
        public StorageTypeModel GetModelByID(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@StorageTypeID", id);

            return SqlHelper.ExecuteGetModel<StorageTypeModel>("SELECT * FROM StorageType WHERE StorageTypeID = @StorageTypeID", param);
        }

        /// <summary>
        /// Get StorageType By Name
        /// </summary>
        /// <param name="name">StorageType Name</param>
        /// <returns>StorageType Model</returns>
        public StorageTypeModel GetModelByName(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get StorageType List
        /// </summary>
        /// <returns>StorageType List</returns>
        public IList<StorageTypeModel> GetAll()
        {
            return SqlHelper.ExecuteList<StorageTypeModel>("SELECT * FROM StorageType ORDER BY StorageTypeID");
        }

        /// <summary>
        /// Check If StorageType Exist
        /// </summary>
        /// <param name="name">StorageType Name</param>
        /// <returns>True or False</returns>
        public bool IsExist(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", id);
            return Convert.ToBoolean(SqlHelper.ExecuteScalar("SELECT * FROM StorageType WHERE StorageTypeID = @StorageTypeID", param));
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Tuple<IList<StorageTypeModel>, int> GetPage(string where, string order, int pageIndex = 1, int pageSize = 10)
        {
            SqlParameter[] sqlParm = new SqlParameter[] {
                new SqlParameter("@table","StorageType"),
                new SqlParameter("@where",where),
                new SqlParameter("@KeyField","StorageTypeID"),
                new SqlParameter("@ShowField",'*'),
                new SqlParameter("@PageIndex",pageIndex),
                new SqlParameter("@PageSize",pageSize),
                new SqlParameter("@TotalCount",SqlDbType.Int){  Direction = ParameterDirection.Output},
                new SqlParameter("@PageCount",SqlDbType.Int){  Direction = ParameterDirection.Output},
            };

            IList<StorageTypeModel> list = SqlHelper.ExecuteList<StorageTypeModel>("up_pagedlist", CommandType.StoredProcedure, sqlParm);

            int TotalCount = Convert.ToInt32(sqlParm[6].Value);
            int PageCount = Convert.ToInt32(sqlParm[7].Value);
            return new Tuple<IList<StorageTypeModel>, int>(list, TotalCount);
        }

        /// <summary>
        /// 获取最大编号
        /// </summary>
        /// <returns></returns>
        public string GetMaxCodeByID()
        {
            return SqlHelper.ExecuteScalar("SELECT TOP 1 StorageTypeCode FROM StorageType ORDER BY StorageTypeID DESC").ToString();
        }
        #endregion        
    }
}
