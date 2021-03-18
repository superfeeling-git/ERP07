using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace ERP.Common
{
    /// <summary>
    /// SQL帮助类
    /// </summary>
    public class SqlHelper
    {
        private static string ConnStr = ConfigurationManager.ConnectionStrings["DbContext"].ConnectionString;

        /// <summary>
        /// 预处理SQL参数
        /// </summary>
        /// <param name="sqlParms"></param>
        private static void PreProcess(SqlParameter[] sqlParms)
        {
            foreach (var item in sqlParms)
            {
                if(item.Value == null)
                {
                    item.Value = DBNull.Value;
                }
            }
        }

        public static int ExecuteNonQuery(string sql, CommandType commandType = CommandType.Text, params SqlParameter[] sqlParameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.CommandType = commandType;

                if(sqlParameters!=null)
                {
                    PreProcess(sqlParameters);

                    cmd.Parameters.AddRange(sqlParameters);
                }

                conn.Open();

                return cmd.ExecuteNonQuery();
            }
        }

        public static int ExecuteNonQuery(string sql, params SqlParameter[] sqlParameters)
        {
            return ExecuteNonQuery(sql, CommandType.Text, sqlParameters);
        }

        public static IList<T> ExecuteList<T>(string sql, CommandType commandType = CommandType.Text, params SqlParameter[] sqlParameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.CommandType = commandType;

                if (sqlParameters != null)
                {
                    PreProcess(sqlParameters);

                    cmd.Parameters.AddRange(sqlParameters);
                }

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                sda.Fill(dt);

                string json = JsonConvert.SerializeObject(dt);

                return JsonConvert.DeserializeObject<List<T>>(json);
            }
        }

        public static IList<T> ExecuteList<T>(string sql, params SqlParameter[] sqlParameters)
        {
            return ExecuteList<T>(sql, CommandType.Text, sqlParameters);
        }

        public static T ExecuteGetModel<T>(string sql, CommandType commandType = CommandType.Text, params SqlParameter[] sqlParameters)
        {
            return ExecuteList<T>(sql, commandType, sqlParameters).FirstOrDefault();
        }

        public static T ExecuteGetModel<T>(string sql, params SqlParameter[] sqlParameters)
        {
            return ExecuteList<T>(sql, CommandType.Text, sqlParameters).FirstOrDefault();
        }

        public static object ExecuteScalar(string sql, CommandType commandType = CommandType.Text, params SqlParameter[] sqlParameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.CommandType = commandType;

                if (sqlParameters != null)
                {
                    PreProcess(sqlParameters);

                    cmd.Parameters.AddRange(sqlParameters);
                }

                conn.Open();

                return cmd.ExecuteScalar();
            }
        }

        public static object ExecuteScalar(string sql, params SqlParameter[] sqlParameters)
        {
            return ExecuteScalar(sql, CommandType.Text, sqlParameters);
        }
    }
}
