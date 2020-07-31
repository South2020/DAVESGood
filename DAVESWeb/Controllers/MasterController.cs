using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAVESWeb.Controllers
{
    public class MasterController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                ComTypeManager com = new ComTypeManager();

                List<ComType> dht = com.GetEntitysWhere(x => x.ComTypeParId == 1);
                Session["qwe"] = dht;
                return PartialView();
            }
            catch (Exception e)
            {
                string msg = e.ToString();
                return PartialView(e.ToString());
            }
        }
    }
}