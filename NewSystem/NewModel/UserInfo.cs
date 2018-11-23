using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewModel
{
  public  class UserInfo
    {
        //Id, UserName, UserPwd, UserMail, RegTime, IsAdmin
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string UserMail { get; set; }
        public DateTime RegTime { get; set; }
        public int IsAdmin { get; set; }
    }
}
