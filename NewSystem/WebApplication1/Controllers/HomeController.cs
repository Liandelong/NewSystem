using Itcast.CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Itcast.CMS.WebApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [Filter.MyAction]
        public ActionResult Index()
        {
            T_UserInfo userInfo = Session["User"] as T_UserInfo;
            ViewBag.user = userInfo.UserName;
            return View();
        }

    }
}
