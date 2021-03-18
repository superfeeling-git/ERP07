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
    public class DictDAL : IDictDAL<DictModel>
    {
        public DictDAL() { }

        #region Dict Interface Implement
        /// <summary>
        /// Add Dict
        /// </summary>
        /// <param name="model">Dict Model</param>
        /// <returns>True or False</returns>
        public bool Create(DictModel model)
        {
            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@DictName", model.DictName);
            param[1] = new SqlParameter("@DictOrder", model.DictOrder);
            param[2] = new SqlParameter("@DictType", model.DictType);

            try
            {
                string sql = "INSERT INTO Dict (DictName,DictOrder,DictType) VALUES(@DictName,@DictOrder,@DictType)";
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
        /// Update Dict
        /// </summary>
        /// <param name="model">Dict Model</param>
        /// <returns>True or False</returns>
        public bool Update(DictModel model)
        {
            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@DictID", model.DictID);
            param[1] = new SqlParameter("@DictName", model.DictName);
            param[2] = new SqlParameter("@DictOrder", model.DictOrder);
            param[3] = new SqlParameter("@DictType", model.DictType);
            try
            {
                string sql = "UPDATE Dict SET DictName = @DictName,DictOrder = @DictOrder,DictType = @DictType WHERE DictID = @DictID";
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
        /// Delete Dict By ID
        /// </summary>
        /// <param name="id">Dict ID</param>
        /// <returns>True or False</returns>
        public bool Delete(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@DictID", id);
            try
            {
                string sql = "DELETE FROM Dict WHERE DictID = @DictID";
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
        /// BatchDelete Dict
        /// </summary>
        /// <param name="idList">idList</param>
        /// <returns>True or False</returns>
        public bool BatchDelete(int[] idList)
        {
            return BatchDelete(string.Join(",", idList));
        }

        /// <summary>
        /// BatchDelete Dict
        /// </summary>
        /// <param name="idList">idList</param>
        /// <returns>True or False</returns>
        public bool BatchDelete(string idList)
        {
            try
            {
                string sql = $"DELETE FROM Dict WHERE DictID IN ({idList})";
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
        /// Get Dict By ID
        /// </summary>
        /// <param name="id">Dict ID</param>
        /// <returns>Dict Model</returns>
        public DictModel GetModelByID(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@DictID", id);

            return SqlHelper.ExecuteGetModel<DictModel>("SELECT * FROM Dict WHERE DictID = @DictID", param);
        }

        /// <summary>
        /// Get Dict By Name
        /// </summary>
        /// <param name="name">Dict Name</param>
        /// <returns>Dict Model</returns>
        public DictModel GetModelByName(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Dict List
        /// </summary>
        /// <returns>Dict List</returns>
        public IList<DictModel> GetAll()
        {
            return SqlHelper.ExecuteList<DictModel>("SELECT * FROM Dict ORDER BY DictOrder");
        }

        /// <summary>
        /// Check If Dict Exist
        /// </summary>
        /// <param name="name">Dict Name</param>
        /// <returns>True or False</returns>
        public bool IsExist(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", id);
            return Convert.ToBoolean(SqlHelper.ExecuteScalar("SELECT * FROM Dict WHERE DictID = @DictID", param));
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Tuple<IList<DictModel>, int> GetPage(string where, string order, int pageIndex = 1, int pageSize = 10)
        {
            SqlParameter[] sqlParm = new SqlParameter[] {
                new SqlParameter("@table","Dict"),
                new SqlParameter("@where",where),
                new SqlParameter("@KeyField","DictID"),
                new SqlParameter("@ShowField",'*'),
                new SqlParameter("@PageIndex",pageIndex),
                new SqlParameter("@PageSize",pageSize),
                new SqlParameter("@TotalCount",SqlDbType.Int){  Direction = ParameterDirection.Output},
                new SqlParameter("@PageCount",SqlDbType.Int){  Direction = ParameterDirection.Output},
            };

            IList<DictModel> list = SqlHelper.ExecuteList<DictModel>("up_pagedlist", CommandType.StoredProcedure, sqlParm);

            int TotalCount = Convert.ToInt32(sqlParm[6].Value);
            int PageCount = Convert.ToInt32(sqlParm[7].Value);
            return new Tuple<IList<DictModel>, int>(list, TotalCount);
        }

        /// <summary>
        /// 获取最大编号
        /// </summary>
        /// <returns></returns>
        public string GetMaxCodeByID()
        {
            return SqlHelper.ExecuteScalar("SELECT TOP 1 DictCode FROM Dict ORDER BY DictID DESC").ToString();
        }
        #endregion        
    }
}
