using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAVESWeb.Areas.LeftNavigationBar.Controllers
{
    public class HomeController : Controller
    {
        // GET: LeftNavigationBar/Home
        static int idd1;
        static int idd2;
        public ActionResult Index(int Id1, int Id2)
        {
            ViewBag.Id = Id1;
            idd1 = Id1;
            idd2 = Id2;
            return View();
        }
        public ActionResult selectType()
        {
            ComTypeManager cc = new ComTypeManager();
            var list = cc.GetEntitysWhere(x => x.ComTypeParId == idd1);
            var list1 = list.Select(x => new
            {
                x.Id,
                x.ComTypeName,
                x.ComTypeParId,
                list2 = x.ComType1.Select(y => new
                {
                    y.Id,
                    y.ComTypeName,
                    y.ComTypeParId
                })
            }); ;
            return Json(list1, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 根据类型ID查询商品
        /// </summary>
        /// <returns></returns>
        public ActionResult selectCom()
        {
            ComTypeManager cc = new ComTypeManager();
            var list = cc.GetEntitysWhere(x => x.Id == idd2);
            List<Com> com = new List<Com>();
            foreach (var item1 in list)
            {
                if (item1.ComTypeParId == 1)
                {
                    foreach (var item2 in item1.ComType1)
                    {
                        foreach (var item3 in item2.ComType1)
                        {
                            com.AddRange(item3.Com);
                        }
                    }
                }
                else if (item1.ComTypeParId != 1)
                {
                    List<ComType> com2 = cc.GetEntitysWhere(x => x.ComTypeParId == item1.Id);//用来判断是第二层还是第三层  集合为空就是第三层反之就是第二层
                    if (com2.Count != 0)
                    {
                        foreach (var item2 in item1.ComType1)
                        {
                            com.AddRange(item2.Com);
                        }
                    }
                    else
                    {
                        com.AddRange(item1.Com);
                    }


                }

            }
            return PartialView(com);
        }
    }
}