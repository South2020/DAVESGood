using System.Web.Mvc;

namespace DAVESWeb.Areas.NavigationBar
{
    public class NavigationBarAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "NavigationBar";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "NavigationBar_default",
                "NavigationBar/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}