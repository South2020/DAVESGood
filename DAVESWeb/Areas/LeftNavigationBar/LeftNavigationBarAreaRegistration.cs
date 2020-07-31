using System.Web.Mvc;

namespace DAVESWeb.Areas.LeftNavigationBar
{
    public class LeftNavigationBarAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "LeftNavigationBar";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "LeftNavigationBar_default",
                "LeftNavigationBar/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}