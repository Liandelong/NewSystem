using NewCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewBLL;
using NewModel;
namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult ValidateCode()
        {
            ValidateCode validateCode = new ValidateCode();
            string code= validateCode.CreateValidateCode(4);
            Session["code"] = code;
            byte[] buffer= validateCode.CreateValidateGraphic(code);
            return File(buffer, "image/jpeg");
        }

        public ActionResult CheckLogin()
        {
            string validateCode = Session["code"] == null ? string.Empty : Session["code"].ToString();
            if (string.IsNullOrEmpty(validateCode))
            {
                return Content("no:验证码错误!");
            }
            Session["code"] = null;
            string requestCode = Request["vCode"];
            if (!requestCode.Equals(validateCode, StringComparison.InvariantCultureIgnoreCase))
            {
                return Content("no:验证码错误!!");
            }
            string userName = Request["LoginCode"];
            string userPwd = Request["LoginPwd"];
            UserInfoBLL userInfoBll = new UserInfoBLL();
            UserInfo userInfo = userInfoBll.GetUserInfo(userName,userPwd);
            if (userInfo != null)
            {
                Session["User"] = userInfo;
                return Content("ok:登录成功!!");

            }
            else
            {
                return Content("no:用户名密码错误");
            }

        }
    }
}