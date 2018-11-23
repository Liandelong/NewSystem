using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Itcast.CMS.WebApp.Filter
{
    public class MyAction:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["User"] == null)
            {
                filterContext.HttpContext.Response.Redirect("/Login/Index");
            }
        }
    }
}