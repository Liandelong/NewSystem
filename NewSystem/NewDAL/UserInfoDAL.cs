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
  public  class UserInfoDAL
    {
        /// <summary>
        /// 根据用户名密码获取用户对象
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userPwd">密码</param>
        /// <returns></returns>
        public UserInfo GetUserInfo(string userName,string userPwd)
        {
            string sql = "select * from UserInfo where UserName=@UserName and UserPwd=@UserPwd";
            SqlParameter[] pars =
            {
                new SqlParameter("@UserName",SqlDbType.NVarChar,32),
                new SqlParameter("@UserPwd",SqlDbType.NVarChar,32)
            };
            pars[0].Value = userName;
            pars[1].Value = userPwd;
            DataTable table = SqlHelper.GetTable(sql, CommandType.Text, pars);
            UserInfo userInfo = null;
            if (table.Rows.Count > 0)
            {
                userInfo = new UserInfo();
                LoadEntity(table.Rows[0], userInfo);
            }
            return userInfo;
        }

        /// <summary>
        /// 初始化对象
        /// </summary>
        /// <param name="dataRow">表行</param>
        /// <param name="userInfo">对象</param>
        private void LoadEntity(DataRow dataRow, UserInfo userInfo)
        {
            userInfo.Id = Convert.ToInt32(dataRow["Id"]);
            userInfo.UserName = dataRow["UserName"]!=DBNull.Value?dataRow["UserName"].ToString():string.Empty;
            userInfo.UserPwd= dataRow["UserPwd"] != DBNull.Value ? dataRow["UserPwd"].ToString() : string.Empty;
            userInfo.UserMail = dataRow["UserMail"] != DBNull.Value ? dataRow["UserMail"].ToString() : string.Empty;
            userInfo.RegTime = Convert.ToDateTime(dataRow["RegTime"]);
            userInfo.IsAdmin = Convert.ToInt32(dataRow["IsAdmin"]);
        }
    }
}
