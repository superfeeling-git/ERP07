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
    public class ProductClassDAL : IProductClassDAL<ProductClassModel>
    {
        public ProductClassDAL() { }

        #region ProductClass Interface Implement
        /// <summary>
        /// Add ProductClass
        /// </summary>
        /// <param name="model">ProductClass Model</param>
        /// <returns>True or False</returns>
        public bool Create(ProductClassModel model)
        {
            SqlParameter[] param = new SqlParameter[5];

            param[0] = new SqlParameter("@ClassName", model.ClassName);
            param[1] = new SqlParameter("@ClassIntro", model.ClassIntro);
            param[2] = new SqlParameter("@Depth", model.Depth);
            param[3] = new SqlParameter("@ParentID", model.ParentID);
            param[4] = new SqlParameter("@ParentPath", model.ParentPath);

            try
            {
                string sql = "INSERT INTO ProductClass (ClassName,ClassIntro,Depth,ParentID,ParentPath) VALUES(@ClassName,@ClassIntro,@Depth,@ParentID,@ParentPath)";
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
        /// Update ProductClass
        /// </summary>
        /// <param name="model">ProductClass Model</param>
        /// <returns>True or False</returns>
        public bool Update(ProductClassModel model)
        {
            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@ClassID", model.ClassID);
            param[1] = new SqlParameter("@ClassName", model.ClassName);
            param[2] = new SqlParameter("@ClassIntro", model.ClassIntro);
            try
            {
                string sql = "UPDATE ProductClass SET ClassName = @ClassName,ClassIntro = @ClassIntro WHERE ClassID = @ClassID";
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
        /// Update ProductClass
        /// </summary>
        /// <param name="model">ProductClass Model</param>
        /// <returns>True or False</returns>
        public bool MoveClass(ProductClassModel model)
        {
            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@ClassID", model.ClassID);
            param[1] = new SqlParameter("@Depth", model.Depth);
            param[2] = new SqlParameter("@ParentId", model.ParentID);
            param[3] = new SqlParameter("@ParentPath", model.ParentPath);
            try
            {
                string sql = "UPDATE ProductClass SET Depth = @Depth,ParentId = @ParentId,ParentPath = @ParentPath WHERE ClassID = @ClassID";
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
        /// Delete ProductClass By ID
        /// </summary>
        /// <param name="id">ProductClass ID</param>
        /// <returns>True or False</returns>
        public bool Delete(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ClassID", id);
            try
            {
                string sql = "DELETE FROM ProductClass WHERE ClassID = @ClassID";
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
        /// BatchDelete ProductClass
        /// </summary>
        /// <param name="idList">idList</param>
        /// <returns>True or False</returns>
        public bool BatchDelete(int[] idList)
        {
            return BatchDelete(string.Join(",", idList));
        }

        /// <summary>
        /// BatchDelete ProductClass
        /// </summary>
        /// <param name="idList">idList</param>
        /// <returns>True or False</returns>
        public bool BatchDelete(string idList)
        {
            try
            {
                string sql = $"DELETE FROM ProductClass WHERE ClassID IN ({idList})";
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
        /// Get ProductClass By ID
        /// </summary>
        /// <param name="id">ProductClass ID</param>
        /// <returns>ProductClass Model</returns>
        public ProductClassModel GetModelByID(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ClassID", id);

            return SqlHelper.ExecuteGetModel<ProductClassModel>("SELECT * FROM ProductClass WHERE ClassID = @ClassID", param);
        }

        /// <summary>
        /// Get ProductClass By Name
        /// </summary>
        /// <param name="name">ProductClass Name</param>
        /// <returns>ProductClass Model</returns>
        public ProductClassModel GetModelByName(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get ProductClass List
        /// </summary>
        /// <returns>ProductClass List</returns>
        public IList<ProductClassModel> GetAll()
        {
            return SqlHelper.ExecuteList<ProductClassModel>("SELECT * FROM ProductClass ORDER BY ClassID");
        }

        /// <summary>
        /// Check If ProductClass Exist
        /// </summary>
        /// <param name="name">ProductClass Name</param>
        /// <returns>True or False</returns>
        public bool IsExist(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", id);
            return Convert.ToBoolean(SqlHelper.ExecuteScalar("SELECT * FROM ProductClass WHERE ClassID = @ClassID", param));
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Tuple<IList<ProductClassModel>, int> GetPage(string where, string order, int pageIndex = 1, int pageSize = 10)
        {
            SqlParameter[] sqlParm = new SqlParameter[] {
                new SqlParameter("@table","ProductClass"),
                new SqlParameter("@where",where),
                new SqlParameter("@KeyField","ClassID"),
                new SqlParameter("@ShowField",'*'),
                new SqlParameter("@PageIndex",pageIndex),
                new SqlParameter("@PageSize",pageSize),
                new SqlParameter("@TotalCount",SqlDbType.Int){  Direction = ParameterDirection.Output},
                new SqlParameter("@PageCount",SqlDbType.Int){  Direction = ParameterDirection.Output},
            };

            IList<ProductClassModel> list = SqlHelper.ExecuteList<ProductClassModel>("up_pagedlist", CommandType.StoredProcedure, sqlParm);

            int TotalCount = Convert.ToInt32(sqlParm[6].Value);
            int PageCount = Convert.ToInt32(sqlParm[7].Value);
            return new Tuple<IList<ProductClassModel>, int>(list, TotalCount);
        }

        /// <summary>
        /// 获取最大编号
        /// </summary>
        /// <returns></returns>
        public string GetMaxCodeByID()
        {
            return SqlHelper.ExecuteScalar("SELECT TOP 1 ProductClassCode FROM ProductClass ORDER BY ClassID DESC").ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        public int GetSubNodeCount(int ClassId)
        {
            string sql = $"SELECT count(1) FROM ProductClass WHERE ',' + ParentPath + ',' like '%,{ClassId},%'";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(sql));
        }

        /// <summary>
        /// 获取所有子分类
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        public IList<ProductClassModel> getSubNodes(int ClassId)
        {
            string sql = $"SELECT * FROM ProductClass WHERE ',' + ParentPath + ',' LIKE '%,{ClassId},%' OR ClassID = {ClassId}";
            return SqlHelper.ExecuteList<ProductClassModel>(sql);
        }
        #endregion
    }
}
