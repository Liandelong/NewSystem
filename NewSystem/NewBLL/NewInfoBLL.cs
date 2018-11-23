using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewModel;
using NewDAL;
namespace NewBLL
{
  public  class NewInfoBLL
    {
        NewInfoDAL newInfoDAL = new NewInfoDAL();
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示数据记录数</param>
        /// <returns></returns>
        public List<NewInfo> GetPageEntityList(int pageIndex,int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            return newInfoDAL.GetPageEntityList(start, end);
        }

        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <returns></returns>
        public int GetPageCount(int pageSize)
        {
            int recordCount = newInfoDAL.GetRecordCount();
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }
    }
}
