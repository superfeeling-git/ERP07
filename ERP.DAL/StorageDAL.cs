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
    public class StorageDAL : IStorageDAL<StorageModel>
    {
        public StorageDAL() { }

        #region Storage Interface Implement
        /// <summary>
        /// Add Storage
        /// </summary>
        /// <param name="model">Storage Model</param>
        /// <returns>True or False</returns>
        public bool Create(StorageModel model)
        {
            SqlParameter[] param = new SqlParameter[11];

            param[0] = new SqlParameter("@StorageTypeID", model.StorageTypeID);
            param[1] = new SqlParameter("@StorageCode", model.StorageCode);
            param[2] = new SqlParameter("@StorageName", model.StorageName);
            param[3] = new SqlParameter("@StorageStatus", model.StorageStatus);
            param[4] = new SqlParameter("@Province", model.Province);
            param[5] = new SqlParameter("@City", model.City);
            param[6] = new SqlParameter("@Area", model.Area);
            param[7] = new SqlParameter("@Address", model.Address);
            param[8] = new SqlParameter("@StorageLocation", model.StorageLocation);
            param[9] = new SqlParameter("@CreateTime", model.CreateTime);
            param[10] = new SqlParameter("@UserName", model.UserName);

            try
            {
                string sql = "INSERT INTO Storage (StorageTypeID,StorageCode,StorageName,StorageStatus,Province,City,Area,Address,StorageLocation,CreateTime,UserName) VALUES(@StorageTypeID,@StorageCode,@StorageName,@StorageStatus,@Province,@City,@Area,@Address,@StorageLocation,@CreateTime,@UserName)";
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
        /// Update Storage
        /// </summary>
        /// <param name="model">Storage Model</param>
        /// <returns>True or False</returns>
        public bool Update(StorageModel model)
        {
            SqlParameter[] param = new SqlParameter[12];

            param[0] = new SqlParameter("@StorageID", model.StorageID);
            param[1] = new SqlParameter("@StorageTypeID", model.StorageTypeID);
            param[2] = new SqlParameter("@StorageCode", model.StorageCode);
            param[3] = new SqlParameter("@StorageName", model.StorageName);
            param[4] = new SqlParameter("@StorageStatus", model.StorageStatus);
            param[5] = new SqlParameter("@Province", model.Province);
            param[6] = new SqlParameter("@City", model.City);
            param[7] = new SqlParameter("@Area", model.Area);
            param[8] = new SqlParameter("@Address", model.Address);
            param[9] = new SqlParameter("@StorageLocation", model.StorageLocation);
            param[10] = new SqlParameter("@CreateTime", model.CreateTime);
            param[11] = new SqlParameter("@UserName", model.UserName);
            try
            {
                string sql = "UPDATE Storage SET StorageTypeID = @StorageTypeID,StorageCode = @StorageCode,StorageName = @StorageName,StorageStatus = @StorageStatus,Province = @Province,City = @City,Area = @Area,Address = @Address,StorageLocation = @StorageLocation,CreateTime = @CreateTime,UserName = @UserName WHERE StorageID = @StorageID";
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
        /// Delete Storage By ID
        /// </summary>
        /// <param name="id">Storage ID</param>
        /// <returns>True or False</returns>
        public bool Delete(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@StorageID", id);
            try
            {
                string sql = "DELETE FROM Storage WHERE StorageID = @StorageID";
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
        /// BatchDelete Storage
        /// </summary>
        /// <param name="idList">idList</param>
        /// <returns>True or False</returns>
        public bool BatchDelete(int[] idList)
        {
            return BatchDelete(string.Join(",", idList));
        }

        /// <summary>
        /// BatchDelete Storage
        /// </summary>
        /// <param name="idList">idList</param>
        /// <returns>True or False</returns>
        public bool BatchDelete(string idList)
        {
            try
            {
                string sql = $"DELETE FROM Storage WHERE StorageID IN ({idList})";
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
        /// Get Storage By ID
        /// </summary>
        /// <param name="id">Storage ID</param>
        /// <returns>Storage Model</returns>
        public StorageModel GetModelByID(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@StorageID", id);

            return SqlHelper.ExecuteGetModel<StorageModel>("SELECT * FROM Storage WHERE StorageID = @StorageID", param);
        }

        /// <summary>
        /// Get Storage By Name
        /// </summary>
        /// <param name="name">Storage Name</param>
        /// <returns>Storage Model</returns>
        public StorageModel GetModelByName(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Storage List
        /// </summary>
        /// <returns>Storage List</returns>
        public IList<StorageModel> GetAll()
        {
            return SqlHelper.ExecuteList<StorageModel>("SELECT * FROM Storage ORDER BY StorageID");
        }

        /// <summary>
        /// Check If Storage Exist
        /// </summary>
        /// <param name="name">Storage Name</param>
        /// <returns>True or False</returns>
        public bool IsExist(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", id);
            return Convert.ToBoolean(SqlHelper.ExecuteScalar("SELECT * FROM Storage WHERE StorageID = @StorageID", param));
        }

        /// <summary>
        /// 获取最大编号
        /// </summary>
        /// <returns></returns>
        public string GetMaxCodeByID()
        {
            return SqlHelper.ExecuteScalar("SELECT TOP 1 StorageCode FROM Storage ORDER BY StorageID DESC").ToString();
        }

        public object GetMaxCode()
        {
            return SqlHelper.ExecuteScalar("SELECT TOP 1 StorageCode FROM Storage ORDER BY StorageID DESC");
        }

        public bool UpdateStatus(int StorageID)
        {
            try
            {
                SqlHelper.ExecuteNonQuery("update Storage SET StorageStatus=abs(StorageStatus-1) where StorageID=@StorageID;", new SqlParameter("@StorageID", StorageID));
                return true;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return false;
                throw;
            }
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Tuple<IList<StorageModel>, int> GetPage(string where, string order, int pageIndex = 1, int pageSize = 10)
        {
            return GetPage(where, "StorageID", order, pageIndex, pageSize);
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="where"></param>
        /// <param name="field">排序字段</param>
        /// <param name="order">排序方式</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Tuple<IList<StorageModel>, int> GetPage(string where, string field, string order, int pageIndex = 1, int pageSize = 10)
        {
            SqlParameter[] sqlParm = new SqlParameter[] {
                new SqlParameter("@table","View_Storage"),
                new SqlParameter("@where",where),
                new SqlParameter("@Order",order),
                new SqlParameter("@KeyField",field),
                new SqlParameter("@ShowField",'*'),
                new SqlParameter("@PageIndex",pageIndex),
                new SqlParameter("@PageSize",pageSize),
                new SqlParameter("@TotalCount",SqlDbType.Int){  Direction = ParameterDirection.Output},
                new SqlParameter("@PageCount",SqlDbType.Int){  Direction = ParameterDirection.Output},
            };

            IList<StorageModel> list = SqlHelper.ExecuteList<StorageModel>("p_pagedlist", CommandType.StoredProcedure, sqlParm);

            int TotalCount = Convert.ToInt32(sqlParm[6].Value);
            int PageCount = Convert.ToInt32(sqlParm[7].Value);
            return new Tuple<IList<StorageModel>, int>(list, TotalCount);
        }
        #endregion
    }
}
