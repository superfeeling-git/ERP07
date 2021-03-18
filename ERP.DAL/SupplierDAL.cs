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
    public class SupplierDAL : ISupplierDAL<SupplierModel>
    {
        public SupplierDAL() { }

        #region Supplier Interface Implement
        /// <summary>
        /// Add Supplier
        /// </summary>
        /// <param name="model">Supplier Model</param>
        /// <returns>True or False</returns>
        public int Create(SupplierModel model)
        {
            SqlParameter[] param = new SqlParameter[14];

            param[0] = new SqlParameter("@SupplierCode", model.SupplierCode);
            param[1] = new SqlParameter("@SupplierLevel", model.SupplierLevel);
            param[2] = new SqlParameter("@SupplierName", model.SupplierName);
            param[3] = new SqlParameter("@Contact", model.Contact);
            param[4] = new SqlParameter("@TEL", model.TEL);
            param[5] = new SqlParameter("@Phone", model.Phone);
            param[6] = new SqlParameter("@Status", model.Status);
            param[7] = new SqlParameter("@PayType", model.PayType);
            param[8] = new SqlParameter("@Province", model.Province);
            param[9] = new SqlParameter("@City", model.City);
            param[10] = new SqlParameter("@Area", model.Area);
            param[11] = new SqlParameter("@Address", model.Address);
            param[12] = new SqlParameter("@Photo", model.Photo);
            param[13] = new SqlParameter("@AddTime", model.AddTime);

            string sql = "INSERT INTO Supplier (SupplierCode,SupplierLevel,SupplierName,Contact,TEL,Phone,Status,PayType,Province,City,Area,Address,Photo,AddTime) VALUES(@SupplierCode,@SupplierLevel,@SupplierName,@Contact,@TEL,@Phone,@Status,@PayType,@Province,@City,@Area,@Address,@Photo,@AddTime);select @@IDENTITY";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(sql, param));
        }

        /// <summary>
        /// Update Supplier
        /// </summary>
        /// <param name="model">Supplier Model</param>
        /// <returns>True or False</returns>
        public bool Update(SupplierModel model)
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@SupplierID", model.SupplierID);
            param[1] = new SqlParameter("@SupplierCode", model.SupplierCode);
            param[2] = new SqlParameter("@SupplierLevel", model.SupplierLevel);
            param[3] = new SqlParameter("@SupplierName", model.SupplierName);
            param[4] = new SqlParameter("@Contact", model.Contact);
            param[5] = new SqlParameter("@TEL", model.TEL);
            param[6] = new SqlParameter("@Phone", model.Phone);
            param[7] = new SqlParameter("@Status", model.Status);
            param[8] = new SqlParameter("@PayType", model.PayType);
            param[9] = new SqlParameter("@Province", model.Province);
            param[10] = new SqlParameter("@City", model.City);
            param[11] = new SqlParameter("@Area", model.Area);
            param[12] = new SqlParameter("@Address", model.Address);
            param[13] = new SqlParameter("@Photo", model.Photo);
            param[14] = new SqlParameter("@AddTime", model.AddTime);
            try
            {
                string sql = "UPDATE Supplier SET SupplierLevel = @SupplierLevel,SupplierName = @SupplierName,Contact = @Contact,TEL = @TEL,Phone = @Phone,Status = @Status,PayType = @PayType,Province = @Province,City = @City,Area = @Area,Address = @Address,Photo = @Photo,AddTime = @AddTime WHERE SupplierID = @SupplierID";
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
        /// Delete Supplier By ID
        /// </summary>
        /// <param name="id">Supplier ID</param>
        /// <returns>True or False</returns>
        public bool Delete(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@SupplierID", id);
            try
            {
                string sql = "DELETE FROM Supplier WHERE SupplierID = @SupplierID";
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
        /// BatchDelete Supplier
        /// </summary>
        /// <param name="idList">idList</param>
        /// <returns>True or False</returns>
        public bool BatchDelete(int[] idList)
        {
            return BatchDelete(string.Join(",", idList));
        }

        /// <summary>
        /// BatchDelete Supplier
        /// </summary>
        /// <param name="idList">idList</param>
        /// <returns>True or False</returns>
        public bool BatchDelete(string idList)
        {
            try
            {
                string sql = $"DELETE FROM Supplier WHERE SupplierID IN ({idList})";
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
        /// Get Supplier By ID
        /// </summary>
        /// <param name="id">Supplier ID</param>
        /// <returns>Supplier Model</returns>
        public SupplierModel GetModelByID(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@SupplierID", id);

            return SqlHelper.ExecuteGetModel<SupplierModel>("SELECT * FROM Supplier WHERE SupplierID = @SupplierID", param);
        }

        /// <summary>
        /// Get Supplier By Name
        /// </summary>
        /// <param name="name">Supplier Name</param>
        /// <returns>Supplier Model</returns>
        public SupplierModel GetModelByName(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Supplier List
        /// </summary>
        /// <returns>Supplier List</returns>
        public IList<SupplierModel> GetAll()
        {
            return SqlHelper.ExecuteList<SupplierModel>("SELECT * FROM Supplier ORDER BY SupplierID");
        }

        /// <summary>
        /// Check If Supplier Exist
        /// </summary>
        /// <param name="name">Supplier Name</param>
        /// <returns>True or False</returns>
        public bool IsExist(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", id);
            return Convert.ToBoolean(SqlHelper.ExecuteScalar("SELECT * FROM Supplier WHERE SupplierID = @SupplierID", param));
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Tuple<IList<SupplierModel>, int> GetPage(string where, string order, int pageIndex = 1, int pageSize = 10)
        {
            SqlParameter[] sqlParm = new SqlParameter[] {
                new SqlParameter("@table","Supplier"),
                new SqlParameter("@where",where),
                new SqlParameter("@KeyField","SupplierID"),
                new SqlParameter("@ShowField",'*'),
                new SqlParameter("@PageIndex",pageIndex),
                new SqlParameter("@PageSize",pageSize),
                new SqlParameter("@TotalCount",SqlDbType.Int){  Direction = ParameterDirection.Output},
                new SqlParameter("@PageCount",SqlDbType.Int){  Direction = ParameterDirection.Output},
            };

            IList<SupplierModel> list = SqlHelper.ExecuteList<SupplierModel>("p_pagedlist", CommandType.StoredProcedure, sqlParm);

            int TotalCount = Convert.ToInt32(sqlParm[6].Value);
            int PageCount = Convert.ToInt32(sqlParm[7].Value);
            return new Tuple<IList<SupplierModel>, int>(list, TotalCount);
        }

        /// <summary>
        /// 获取最大编号
        /// </summary>
        /// <returns></returns>
        public object GetMaxCode()
        {
            return SqlHelper.ExecuteScalar("SELECT TOP 1 SupplierCode FROM Supplier ORDER BY SupplierID DESC");
        }

        bool IBaseDAL<SupplierModel>.Create(SupplierModel model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据供应商ID获取所有的品牌
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<ProductClassModel> GetBrandBySupplierID(int id)
        {
            string sql = @"SELECT * FROM ProductClass WHERE ParentID IN
                            (
                            SELECT ProductClass.ClassID FROM Supplier
                            INNER JOIN Supplier_ProductClass ON Supplier.SupplierID = Supplier_ProductClass.SupplierID
                            INNER JOIN ProductClass ON Supplier_ProductClass.ClassID = ProductClass.ClassID
                            WHERE Supplier.SupplierID = @SupplierID AND Depth = 0
                            )";

            return SqlHelper.ExecuteList<ProductClassModel>(sql, new SqlParameter("@SupplierID", id));
        }

        public bool UpdateStatus(int[] SupplierID, string status)
        {
            try
            {
                foreach (var item in SupplierID)
                {
                    SqlHelper.ExecuteNonQuery
                        (
                        "UPDATE Supplier SET status = @status WHERE SupplierID = @SupplierID",
                        new SqlParameter("@SupplierID", item),
                        new SqlParameter("@status", status)
                        );
                }
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        #endregion
    }
}
