using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewBLL;
using NewModel;
namespace WebApp.Controllers
{
    public class AdminNewInfoController : Controller
    {
        NewInfoBLL newInfoBLL = new NewInfoBLL();
        // GET: AdminNewInfo
        public ActionResult Index()
        {
            int pageIndex = Request["pageIndex"] != null ?Convert.ToInt32(Request["pageIndex"]) :1;
            int pageSize = 5;
            int pageCount = newInfoBLL.GetPageCount(pageSize);
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            List <NewInfo> list= newInfoBLL.GetPageEntityList(pageIndex, pageSize);
            ViewData["pageList"] = list;
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageCount"] = pageCount;
            return View();
        }
    }
}