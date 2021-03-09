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
    public class Supplier_ProductClassDAL : ISupplier_ProductClassDAL<Supplier_ProductClassModel>
    {
        public Supplier_ProductClassDAL() { }

        #region Supplier_ProductClass Interface Implement
        /// <summary>
        /// Add Supplier_ProductClass
        /// </summary>
        /// <param name="model">Supplier_ProductClass Model</param>
        /// <returns>True or False</returns>
        public bool Create(Supplier_ProductClassModel model)
        {
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@SupplierID", model.SupplierID);
            param[1] = new SqlParameter("@ClassID", model.ClassID);

            try
            {
                string sql = "INSERT INTO Supplier_ProductClass (SupplierID,ClassID) VALUES(@SupplierID,@ClassID)";
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
        /// Update Supplier_ProductClass
        /// </summary>
        /// <param name="model">Supplier_ProductClass Model</param>
        /// <returns>True or False</returns>
        public bool Update(Supplier_ProductClassModel model)
        {
            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@ID", model.ID);
            param[1] = new SqlParameter("@SupplierID", model.SupplierID);
            param[2] = new SqlParameter("@ClassID", model.ClassID);
            try
            {
                string sql = "UPDATE Supplier_ProductClass SET SupplierID = @SupplierID,ClassID = @ClassID WHERE ID = @ID";
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
        /// Delete Supplier_ProductClass By ID
        /// </summary>
        /// <param name="id">Supplier_ProductClass ID</param>
        /// <returns>True or False</returns>
        public bool Delete(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", id);
            try
            {
                string sql = "DELETE FROM Supplier_ProductClass WHERE ID = @ID";
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
        /// BatchDelete Supplier_ProductClass
        /// </summary>
        /// <param name="idList">idList</param>
        /// <returns>True or False</returns>
        public bool BatchDelete(int[] idList)
        {
            return BatchDelete(string.Join(",", idList));
        }

        /// <summary>
        /// BatchDelete Supplier_ProductClass
        /// </summary>
        /// <param name="idList">idList</param>
        /// <returns>True or False</returns>
        public bool BatchDelete(string idList)
        {
            try
            {
                string sql = $"DELETE FROM Supplier_ProductClass WHERE ID IN ({idList})";
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
        /// Get Supplier_ProductClass By ID
        /// </summary>
        /// <param name="id">Supplier_ProductClass ID</param>
        /// <returns>Supplier_ProductClass Model</returns>
        public Supplier_ProductClassModel GetModelByID(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", id);

            return SqlHelper.ExecuteGetModel<Supplier_ProductClassModel>("SELECT * FROM Supplier_ProductClass WHERE ID = @ID", param);
        }

        /// <summary>
        /// Get Supplier_ProductClass By Name
        /// </summary>
        /// <param name="name">Supplier_ProductClass Name</param>
        /// <returns>Supplier_ProductClass Model</returns>
        public Supplier_ProductClassModel GetModelByName(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Supplier_ProductClass List
        /// </summary>
        /// <returns>Supplier_ProductClass List</returns>
        public IList<Supplier_ProductClassModel> GetAll()
        {
            return SqlHelper.ExecuteList<Supplier_ProductClassModel>("SELECT * FROM Supplier_ProductClass ORDER BY ID");
        }

        /// <summary>
        /// Check If Supplier_ProductClass Exist
        /// </summary>
        /// <param name="name">Supplier_ProductClass Name</param>
        /// <returns>True or False</returns>
        public bool IsExist(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", id);
            return Convert.ToBoolean(SqlHelper.ExecuteScalar("SELECT * FROM Supplier_ProductClass WHERE ID = @ID", param));
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Tuple<IList<Supplier_ProductClassModel>, int> GetPage(string where, string order, int pageIndex = 1, int pageSize = 10)
        {
            SqlParameter[] sqlParm = new SqlParameter[] {
                new SqlParameter("@table","Supplier_ProductClass"),
                new SqlParameter("@where",where),
                new SqlParameter("@KeyField","ID"),
                new SqlParameter("@ShowField",'*'),
                new SqlParameter("@PageIndex",pageIndex),
                new SqlParameter("@PageSize",pageSize),
                new SqlParameter("@TotalCount",SqlDbType.Int){  Direction = ParameterDirection.Output},
                new SqlParameter("@PageCount",SqlDbType.Int){  Direction = ParameterDirection.Output},
            };

            IList<Supplier_ProductClassModel> list = SqlHelper.ExecuteList<Supplier_ProductClassModel>("up_pagedlist", CommandType.StoredProcedure, sqlParm);

            int TotalCount = Convert.ToInt32(sqlParm[6].Value);
            int PageCount = Convert.ToInt32(sqlParm[7].Value);
            return new Tuple<IList<Supplier_ProductClassModel>, int>(list, TotalCount);
        }

        /// <summary>
        /// 获取最大编号
        /// </summary>
        /// <returns></returns>
        public string GetMaxCodeByID()
        {
            return SqlHelper.ExecuteScalar("SELECT TOP 1 Supplier_ProductClassCode FROM Supplier_ProductClass ORDER BY ID DESC").ToString();
        }

        /// <summary>
        /// 根据供应商ID获取对应的分类ID(包含了顶级分类和品牌)——————中间表数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<Supplier_ProductClassModel> GetClassIDBySupplierID(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", id);

            return SqlHelper.ExecuteList<Supplier_ProductClassModel>("SELECT * FROM Supplier_ProductClass WHERE SupplierID = @ID", param);

        }
        #endregion
    }
}
