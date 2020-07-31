using System.Web.Mvc;

namespace DAVESWeb.Areas.LoginReg
{
    public class LoginRegAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "LoginReg";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "LoginReg_default",
                "LoginReg/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}