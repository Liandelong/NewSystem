using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewModel;
using System.Data;
using System.Data.SqlClient;
namespace NewDAL
{
  public  class NewInfoDAL
    {
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="start">起始位置</param>
        /// <param name="end">终止位置</param>
        /// <returns></returns>
        public List<NewInfo> GetPageEntityList(int start,int end)
        {
            string sql = "select * from (select row_number() over(order by id) as num,* from News) as N where N.num between @start and @end";
            SqlParameter[] pars = {
                new SqlParameter("@start",DbType.Int32),
                new SqlParameter("@end",DbType.Int32)
            };
            pars[0].Value = start;
            pars[1].Value = end;
            DataTable table= SqlHelper.GetTable(sql, CommandType.Text, pars);
            List<NewInfo> list=null;
            if (table.Rows.Count > 0)
            {
                list = new List<NewInfo>();
                NewInfo newInfo = null;
                foreach (DataRow row in table.Rows)
                {
                    newInfo = new NewInfo();
                    LoadEntity(row,newInfo);
                    list.Add(newInfo);
                }
            }
            return list;
        }

        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="row">Table行</param>
        /// <param name="newInfo">新闻对象</param>
        private void LoadEntity(DataRow row, NewInfo newInfo)
        {
            newInfo.Author = row["Author"] != DBNull.Value ? row["Author"].ToString() : string.Empty;
            newInfo.Title= row["Title"] != DBNull.Value ? row["Title"].ToString() : string.Empty;
            newInfo.Msg = row["Msg"] != DBNull.Value ? row["Msg"].ToString() : string.Empty;
            newInfo.ImagePath = row["ImagePath"] != DBNull.Value ? row["ImagePath"].ToString() : string.Empty;
            newInfo.SubDateTime = Convert.ToDateTime(row["SubDateTime"]);
            newInfo.Id = Convert.ToInt32(row["Id"]);
            newInfo.TypeId = Convert.ToInt32(row["TypeId"]);
        }
        
        /// <summary>
        /// 获取新闻总条数
        /// </summary>
        /// <returns></returns>
        public int GetRecordCount()
        {
            string sql = "select count(*) from News";
            int count = Convert.ToInt32(SqlHelper.ExcuteScalar(sql, CommandType.Text));
            return count;
        }
    }
}
