using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAVESWeb.Areas.ShopCarGL.Controllers
{
    public class HomeController : Controller
    {
        // GET: ShopCarGL/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult selectshopcar()
        {
            var us = Session["USER"] as User;
            if (us == null)
            {
                var info1 = new
                {
                    bm = "1005",
                    url = "/LoginReg/LoginReg/LoginIndex"
                };
                return Json(info1, JsonRequestBehavior.AllowGet);
            }
            var list = new ShopCarManager().GetEntitysWhere(x => x.UserId == us.Id);
            var list1 = list.Select(x => new {
                x.Id,x.ComId,
                x.Com.ComName,
                x.Com.ComWeight,
                x.Com.ComMoney,
                x.CarNum,x.Com.ComImg
            });
            var info = new
            {
                count = list1.Count(),
                list=list1
            };
            return Json(info, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ifNum(List<ShopCar> fo) {
            string msg = "";
            string bm = "";
            foreach (var item in fo) {
                var kc = new ComManager().GetEntitysWhereAsNoTracking(x => x.Id == item.ComId).FirstOrDefault();
                if (kc.ComInventNum<item.CarNum)
                {
                    bm = "1002";
                    msg += kc.ComName +",";
                }
            }
            var info = new
            {
                bm=bm,
                msg=msg + "的库存不足"
            };
            return Json(info,JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 生成订单
        /// </summary>
        /// <returns></returns>
        public ActionResult addOrder(string area) {
            Order order = new Order();
            var us = this.Session["USER"] as User;
            string year = DateTime.Now.ToString("yyyy");
            string mouth = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string shi = DateTime.Now.ToString("HH");
            string f = DateTime.Now.ToString("mm");
            string m = DateTime.Now.ToString("ss");
            string dd = year + mouth + day + shi + f + m;//获取时间转换订单编号
            DateTime time = DateTime.Now;
            order.OrderTime = time;
            order.OrderBH = dd;
            order.UserId = us.Id;
            order.UserSite = area;
            order.OrderState = 2;
            order.Id = 0;
            List<Order> oo = new List<Order>();
            oo.Add(order);
            var i = new OrderManager().Inserts(oo);//新增订单
            if (i)
            {
                Order or = new OrderManager().GetEntitysWhere(x=>x.OrderBH.Equals(dd)).FirstOrDefault();
                var info =new {
                    id=or.Id
                };
                return Json(info, JsonRequestBehavior.AllowGet);
            }
            else {
                return Json("1000", JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// 生成订单详细
        /// </summary>
        /// <param name="fo"></param>
        /// <returns></returns>
        public ActionResult addOrders(List<Orders> fo)
        {
            var oor = new OrdersManager().Inserts(fo);//新增订单详情
            if (oor)
            {
                return Json("1001", JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json("1000", JsonRequestBehavior.AllowGet);
            }
            /*var b = new ShopCarManager().Delete(spcarid);//删除购物车*/

        }
        public ActionResult del(List<ShopCar> spfo)
        {
            var a = true;
            foreach (var item in spfo)
            {
                var b = new ShopCarManager().Delete(item.Id);//删除购物车
                if (!b) {
                    a = false;
                }
            }
            if (a)
            {
                return Json(1001, JsonRequestBehavior.AllowGet);
            }
            return Json("", JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// 删除单个购物车
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult delId(int Id)
        {
            if (new ShopCarManager().Delete(Id))//删除购物车
            {
                return Json("1001", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("1000", JsonRequestBehavior.AllowGet);
            }

        }
        /// <summary>
        /// 批量删除购物车
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult delIds(List<ShopCar> ar)
        {
            foreach (var item in ar) {
                if (new ShopCarManager().Delete(item.Id))//删除购物车
                {
                }
                else
                {
                    return Json("1000", JsonRequestBehavior.AllowGet);
                }
            }
            return Json("1001", JsonRequestBehavior.AllowGet);

        }
        public ActionResult upshop(ShopCar info) {
            var shop = new ShopCarManager().GetEntitysWhereAsNoTracking(x=>x.Id== info.Id).FirstOrDefault();
            shop.CarNum = info.CarNum;
            if (new ShopCarManager().Update(shop))
            {
                var info1 = new
                {
                    msg = "1000"
                };
                return Json(info1, JsonRequestBehavior.AllowGet);
            }
            else {
                var info1 = new
                {
                    msg = "1001"
                };
                return Json(info1, JsonRequestBehavior.AllowGet);
            }

        }

       
        /// <summary>
        /// 查询地址
        /// </summary>
        /// <returns></returns>
        public ActionResult selectArea() {
            var us = this.Session["USER"] as User;
            var usit = new UserSiteManager().GetEntitysWhereAsNoTracking(x=>x.UserId==us.Id);
            var info1 = usit.Select(x => new
            {
                dz = x.QuXian.Shi.Sheng.name + x.QuXian.Shi.Name + x.QuXian.Name + x.SiteDetail
            }) ;
            return Json(info1,JsonRequestBehavior.AllowGet);
        }

        
        //打打我的

    }
}