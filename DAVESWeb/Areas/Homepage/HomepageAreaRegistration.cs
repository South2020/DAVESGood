using System.Web.Http;
using System.Web.Mvc;

namespace DAVESWeb.Areas.Homepage
{
    public class HomepageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Homepage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.Routes.MapHttpRoute(
                name: "Default_Homepage_Api",
                routeTemplate: "Homepage/api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            context.MapRoute(
                "Homepage_default",
                "Homepage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}