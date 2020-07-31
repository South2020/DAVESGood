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
        //黄子康第二次修改
        /*public ActionResult FaceToPay()
        {   //域名
            const string URL = "https://openapi.alipaydev.com/gateway.do";  //沙箱环境与正式环境不同 这里要用沙箱的 支付宝地址
            //	APPID即创建应用后生成
            const string APPID = "2016091500513966";
            //开发者应用私钥，由开发者自己生成  开发者私钥到底是什么玩意  原来开发者私钥就是商户应用私钥
            const string APP_PRIVATE_KEY = "MIIEowIBAAKCAQEArVWg55eFMf7rFLVpFAxGgMQfxGWd7swqxNkOu1Y/0Wt14HZik4+U0kycQuYtOFBbwael8vlr/Q+BaqtpwwI+g+yJVma+uLYkmVaWHqswh1XocX3gOfLWxFp1DwPcNesFpbZ9wndxrZL9+wWMtbiB4TV3jBAcFbAzOgLvH4+IveS88H6jjTTpHeogxJpZ0EU37Nucpsae2yiJJyACmgZDlY3qEABkFpiaD2Kc+EvGDPXyEKSufv8f+GxUTKgE25c0NhP9hSJPND1+reygiJy4sFIEuZ5960LRd/1kJgUIuW+JgA50AXI/SXEzHqBJO0ZvT9hZjSIbOtvGjbQp+d9azwIDAQABAoIBAHQjJn9l13nLKqmibzhejTKjtgE6cNpac+GW6bb9sB7aGI3/5EaocneBm0V7whq0RPZ5JMiq8/8Hz5ewKFnf/BEagF6i0vEiIV2YVVdRLl/PYMICLCXHnrzLOxmHZZm+0fbZUmPk8gbxsTjq2/+6E1PZJjNza83gVEJvStbjriRErp5LwMYCO3Qz3KDaPHFUaP5IRR6b+qJeLbrArFNv3zKV9b3TRe1loSIqrUfgSfW7Qh8rEjTub0BxjFqkOeVUrCPlrNz4NqTjOmPBf1tJ+xLFXsYlom4mGoaXKx9UIQgirLkh++HM+fHHrsICg3CA1tKBjf6OYXqLsvsXCd7T0okCgYEA4Yrrhzgmp9OWt1HS5HkAAlErYQoal6JrmfWd5cZOMwgp5YqmfXoV/QgwC0mbXun01JshgnOsmKy2GiOeUlsCRLhGJCm0piI/o9pSwiUyhe65AFLltyQJXmAVWsCeXjyEDDXSheZ1dL6akjVcs4dKSA+E3+lYs+m3mHBy7cXD8esCgYEAxL3bFNAe3iYqnt0/Ncv1SM7cxYJTZMjtEOiVp3sMvcgQCPPzl5CONkIuNKT5F4o8BCMQU0AzzDHxyxAuaspT4EcXQvCm5UIi5BioYnq0IEVVxuRa+AT6bHLxdyd0wsAzEhbrncUGe2ncQ1SKLuKy7UygCA3DBn++v0aqPrGX3a0CgYBPKtAZmqAW8LJKjrIT+FUEezFa0o0bBKv4Urql2MHCL+9k3xIpoRzuwFz82U1sN3r01a8hdzDyNk2FR1NfXQqizHvyXaFHX2YvQYcjFqNxV6YgcvinHEMdmWRlgo8UTPGcx5ep4IcB/5WKFKkBa0+rk6b0YZf9LuB+5Zmx1GU/GQKBgQCufahp7DAEXRtd7OJcBznTykx6DB2EfMPtRCs+8F6bj23RUvQPz9ChhM7QOCUIYLzb+nFHNOD70KwfqolQg4QinUqfPyr2mFKztL7bIPLS0EvEa9HWuSuVtdg9Esx20do5yARO2GjoWjpVqQwpizygRF6G5hW7lN8LbFQf6IjFvQKBgBdlb1h1rfJcPjkFGyIgr7B36eCrKdlRvNVsnMiqXi+3z5kbYXyePEiIfRYolg7UZI2tAAuHFZmxWwSFccREwKvs1rXSqWs0LqvaR7UizGxDq6AUdtz60jfsnkq6RAqwlA2m5ZW0Kf0QivElWxV1pM71ddU7evUNZTOgwL6qX1oG";
            //参数返回格式，只支持json
            const string FORMAT = "json";
            //请求和签名使用的字符编码格式，支持GBK和UTF-8
            const string CHARSET = "UTF-8";
            //支付宝公钥，由支付宝生成     到蚂蚁金服复制
            const string ALIPAY_PUBLIC_KEY = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEApdBe/PUjBBEwYM4/H9clg0yrD1f8KoFusXqgiL4OegnizB2M4lGq7kCkXgwTIxJcOnaLTq2PsE/f0DFNq9GW3xxuLeioh0pjUqG4KV7bFhNy2Wipeja6A+IX1wbhH1AcHYfoGBVjfqEPvqvNWJPCE2ClAZLkNv2pwbC1cKXG48jKX9iVcCmJBl/qgMAcYfgdm37zjcdcgsd/EfHGT8HtiYb08UR+olsxG6Pi7nfc+yLaqGNJyhu6L6lgnQBUxD+fjrFFwPrF6fE0MMm7dljWRO8HiZTTjt8ia4rs8Be05dkd3IDRCoWTcNAd9+tTxV62gcw6rMM92zXMWlzWePk4NQIDAQAB";

            IAopClient client = new DefaultAopClient(URL, APPID, APP_PRIVATE_KEY, FORMAT, "1.0", "RSA2", ALIPAY_PUBLIC_KEY, CHARSET, false);

            //实例化具体API对应的request类,类名称和接口名称对应,当前调用接口名称如：
            AlipayTradePrecreateRequest request = new AlipayTradePrecreateRequest();//创建API对应的request类


            //SDK已经封装掉了公共参数，这里只需要传入业务参数


            //此次只是参数展示，未进行字符串转义，实际情况下请转义
            request.BizContent = "{" +
                                "    \"out_trade_no\":\"20150320010101002\"," +
                                "    \"total_amount\":\"88.88\"," +
                                "    \"subject\":\"Iphone6 16G\"," +
                                "    \"store_id\":\"NJ_001\"," +
                                "    \"timeout_express\":\"90m\"}";
            AlipayTradePrecreateResponse response = client.Execute(request);
            //调用成功，则处理业务逻辑
            if (!response.IsError)
            {
                var res = new
                {
                    success = true,
                    out_trade_no = response.OutTradeNo,
                    qr_code = response.QrCode    //发现返回的是一个网址,后续需要用这个网址字符串创建二维码
                };
                return Json(res);
            }
            else
            {
                var res = new
                {
                    success = false,
                };
                return Json(res);
            }
        }*/

        

    }
}