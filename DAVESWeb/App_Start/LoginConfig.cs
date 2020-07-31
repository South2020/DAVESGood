using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace DAVESWeb.App_Start
{
    public class LoginConfig: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var User = filterContext.HttpContext.Session["USER"] as User;
            if (User==null) {
                filterContext.HttpContext.Response.Redirect("/Home/Index");
            }
        }
    }
}