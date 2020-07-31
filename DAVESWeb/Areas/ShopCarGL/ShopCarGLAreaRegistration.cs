using System.Web.Mvc;

namespace DAVESWeb.Areas.ShopCarGL
{
    public class ShopCarGLAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ShopCarGL";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ShopCarGL_default",
                "ShopCarGL/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}