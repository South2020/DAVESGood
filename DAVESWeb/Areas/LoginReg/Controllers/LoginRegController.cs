using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAVESWeb.Areas.LoginReg.Controllers
{
    public class LoginRegController : Controller
    {
        /// <summary>
        /// 登录
        /// 《0代表程序报错
        /// 1000表示账号密码错误
        /// 1001登录成功》
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public ActionResult Login(User us)
        {
            var son = 0;
            List<User> lis = new UserManager().GetEntitysWhere(x => x.UserAcc == us.UserAcc & x.UserPwd == us.UserPwd);
            if (lis.Count == 0)
            {
                son = 1000;
            }
            else
            {
                son = 1001;
                Session["USER"] = lis.FirstOrDefault();
            }
            return Json(son, JsonRequestBehavior.AllowGet);
        }




        /// <summary>
        /// 登录页面
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginIndex()
        {

            return PartialView();
        }
        /// <summary>
        /// 注册页面
        /// </summary>
        /// <returns></returns>
        public ActionResult RegIndex()
        {
            return PartialView();
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public ActionResult Reg(User us)
        {
            bool bo = new UserManager().Insert(us);
            var info = "";
            if (bo)
            {
                info = "1001";
            }
            else
            {
                info = "1000";
            }
            return Json(info, JsonRequestBehavior.AllowGet);
        }
    }
}