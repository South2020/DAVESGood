using System.Web.Mvc;

namespace DAVESWeb.Areas.Commodity
{
    public class CommodityAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Commodity";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Commodity_default",
                "Commodity/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}