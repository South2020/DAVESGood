using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAVESWeb.Areas.Commodity.Controllers
{
    public class HomeController : Controller
    {
        // GET: Commodity/Home
        static int Id1;
        public ActionResult Index(int Id)
        {
            Id1 = Id;
            return View();
        }
        public ActionResult selectcom()
        {
            var com = new ComManager().GetEntity(Id1);
            var us = this.Session["USER"] as User;
            string area;
            if (us != null)
            {
                var ussite = new UserSiteManager().GetEntitysWhereAsNoTracking(x => x.UserId == us.Id & x.SitePre == 1).FirstOrDefault();
                if (ussite!=null) {
                    area = ussite.QuXian.Shi.Sheng.name + ussite.QuXian.Shi.Name + ussite.QuXian.Name + ussite.SiteDetail;
                }
                area = "请添加地址";
            }
            else {
                area = "请登录";
            }
            var com1 = new
            {
                Id = com.Id,
                ComWeight = com.ComWeight,
                ComTypeId = com.ComTypeId,
                ComName = com.ComName,
                ComMoney = com.ComMoney,
                ComBz = com.ComBz,
                comImg=com.ComImg,
                Area = area,
                list = com.ComImg1.Select(x => new {
                    x.ImgName
                })
            };
            return Json(com1, JsonRequestBehavior.AllowGet);
        }


        public ActionResult insert(int num, int comid)
        {

            var us = Session["USER"] as User;

            if (us == null)
            {
                var info = new
                {
                    bm = "1005",
                    url = "/LoginReg/LoginReg/LoginIndex"
                };
                return Json(info, JsonRequestBehavior.AllowGet);
            }
            var list = new ShopCarManager().GetEntitysWhereAsNoTracking(x => x.ComId == comid & x.UserId == us.Id);
            ShopCar sc = list.FirstOrDefault();
            if (list.Count == 0)
            {
                sc = new ShopCar() {
                    UserId = us.Id,
                    CarNum = num,
                    ComId = comid
                };
                /*var kc = new ComManager().GetEntitysWhereAsNoTracking(x => x.Id == comid).FirstOrDefault();
                if (num > kc.ComInventNum)
                {
                    var info1 = new
                    {
                        bm = "1002",//库存不足
                        msg = "库存不够"
                    };
                    return Json(info1, JsonRequestBehavior.AllowGet);
                }*/
                var result = new ShopCarManager().Insert(sc);
                if (result)
                {
                    var info = new
                    {
                        bm = "1001",
                        msg = "加入成功"
                    };
                    return Json(info, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var info = new
                    {
                        bm = "1000",
                        msg = "加入失败"
                    };
                    return Json(info, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                sc.CarNum += num;
                /*var kc = new ComManager().GetEntitysWhereAsNoTracking(x => x.Id == comid).FirstOrDefault();
                if (sc.CarNum > kc.ComInventNum)
                {
                    var info1 = new
                    {
                        bm = "1002",//库存不足
                        msg = "库存不够"
                    };
                    return Json(info1, JsonRequestBehavior.AllowGet);
                }*/
                var res = new ShopCarManager().Update(sc);
                if (res)
                {
                    var info = new
                    {
                        bm = "1001",
                        msg = "加入成功"
                    };
                    return Json(info, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var info = new
                    {
                        bm = "1000",
                        msg = "加入失败"
                    };
                    return Json(info, JsonRequestBehavior.AllowGet);
                }
            }

        }
    }
}