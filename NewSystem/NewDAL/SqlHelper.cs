using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace NewDAL
{
  public static  class SqlHelper
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="type">存储过程类型</param>
        /// <param name="pars">参数</param>
        /// <returns></returns>
        public static DataTable GetTable(string sql,CommandType type,params SqlParameter[] pars)
        {
            using(SqlConnection con=new SqlConnection(connStr))
            {
                using(SqlDataAdapter adapter=new SqlDataAdapter(sql,con))
                {
                    adapter.SelectCommand.CommandType = type;
                    if (pars != null)
                    {
                        adapter.SelectCommand.Parameters.AddRange(pars);
                    }
                    con.Open();
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }

        /// <summary>
        /// 数据增删改查
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="type">存储过程类型</param>
        /// <param name="pars">参数</param>
        /// <returns></returns>
        public static int ExcuteNonQuery(string sql,CommandType type,params SqlParameter[] pars)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                using(SqlCommand com=new SqlCommand(sql, con))
                {
                    com.CommandType = type;
                    if (pars != null)
                    {
                        com.Parameters.AddRange(pars);
                    }
                    con.Open();
                    try
                    {
                        return com.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        con.Close();
                        con.Dispose();
                        throw;
                    }
                }
            }
        }


        /// <summary>
        ///返回查询第一条数据
        /// </summary>
        /// <param name="sql">SQl语句</param>
        /// <param name="type">存储过程类型</param>
        /// <param name="pars">参数</param>
        /// <returns></returns>
        public static object ExcuteScalar(string sql,CommandType type,params SqlParameter[] pars)
        {
            using(SqlConnection con=new SqlConnection(connStr))
            {
                using(SqlCommand com=new SqlCommand(sql, con))
                {
                    com.CommandType = type;
                    if (pars != null)
                    {
                        com.Parameters.AddRange(pars);
                    }
                    try
                    {
                        con.Open();
                        return com.ExecuteScalar();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }
    }
}
