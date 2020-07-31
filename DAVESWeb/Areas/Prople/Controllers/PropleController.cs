using BLL;
using DAVESWeb.App_Start;
using Microsoft.Ajax.Utilities;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace DAVESWeb.Areas.Prople.Controllers
{
    [LoginConfig]
    public class PropleController : Controller
    {
        // GET: Prople/Prople
        public ActionResult PropleIndex()
        {
            //省
            List<Sheng> sheng = new ShengManager().GetAll();
            Sheng she = new Sheng()
            {
                Id = 0,
                name = "---请选择---"
            };
            sheng.Insert(0, she);
            ViewBag.type1 = new SelectList(sheng, "Id", "name");
            //市
            List<Shi> shis = new List<Shi>();
            Shi shi = new Shi()
            {
                Id = 0,
                Name = "---请选择---"
            };
            shis.Insert(0, shi);
            ViewBag.type2 = new SelectList(shis, "Id", "Name");
            //区县
            List<QuXian> quxs = new List<QuXian>();
            QuXian qu = new QuXian()
            {
                Id = 0,
                Name = "---请选择---"
            };
            quxs.Insert(0, qu);
            ViewBag.type3 = new SelectList(quxs, "Id", "Name");

            User us = Session["USER"] as User;
            if(us==null){
                return Redirect("/Home/Index");
            }
            User newus = new UserManager().GetEntity(us.Id);
            return View(newus);
        }
        /*修改密码*/
        public ActionResult PropleUpterpass(string yuanpass,string UserPwd)
        {
            var us = Session["USER"] as User;
            if (us.UserPwd.Equals(yuanpass))
            {
                User olduser = new UserManager().GetEntitysWhereAsNoTracking(x => x.Id == us.Id).FirstOrDefault();
                olduser.UserPwd = UserPwd;
                if (new UserManager().Update(olduser))
                {
                    var info1 = new
                    {
                        msg = 1001
                    };
                    return Json(info1, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                var info1 = new
                {
                    msg = 1005
                };
                return Json(info1, JsonRequestBehavior.AllowGet);
            }
            return Json("",JsonRequestBehavior.AllowGet);
        }
        public ActionResult PropleSelect() {
            List<User> us = new UserManager().GetAll();
            return View(us);
        }
        [HttpPost]
        public ActionResult Sanjilando(int id,int cc) {
            if (cc == 1)
            {
                List<Shi> shi = new ShiManager().GetEntitysWhere(x => x.ShengId == id);
                Shi sh = new Shi()
                {
                    Id = 0,
                    Name = "---请选择---"
                };
                shi.Insert(0, sh);
                var listype2 = shi.Select(x => new {
                    id = x.Id,
                    Name = x.Name
                });
                return Json(listype2, JsonRequestBehavior.AllowGet);
            }
            else if(cc == 2)
            {
                List<QuXian> qus = new QuXianManager().GetEntitysWhere(x => x.ShiId == id);
                QuXian qu = new QuXian()
                {
                    Id = 0,
                    Name = "---请选择---"
                };
                qus.Insert(0, qu);
                var listype3 = qus.Select(x => new {
                    id = x.Id,
                    Name = x.Name
                });
                return Json(listype3, JsonRequestBehavior.AllowGet);
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }
        //地址查询
        public ActionResult SiteSelect() {
            var us = Session["USER"] as User;
            if (us != null)
            {
                var newUser = new UserManager().GetEntity(us.Id);

                var listsite = newUser.UserSite;
                var usEntity = listsite.Select(x => new
                {
                    id = x.Id,
                    SiteProName = x.SiteProName,
                    SiteDetail = x.QuXian.Shi.Sheng.name + x.QuXian.Shi.Name + x.QuXian.Name + x.SiteDetail,
                    SitePre = (x.SitePre == 1) ? "是" : "",
                    SitePhone = x.SitePhone
                });
                var info = new
                {
                    code = 0,
                    data = usEntity
                };

                return Json(info, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(1000, JsonRequestBehavior.AllowGet);
            }
        }
        //地址新增
        public ActionResult SiteAdd(UserSite info) {
            var user = Session["USER"] as User;
            info.UserId = user.Id;
            info.SitePre = 0;
            if (new UserSiteManager().Insert(info))
            {
                var info1 = new
                {
                    msg = 1001
                };
                return Json(info1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var info1 = new
                {
                    msg = 1000
                };
                return Json(info1, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// 新增地址页面
        /// </summary>
        /// <returns></returns>
        public ActionResult SiteAddIndex()
        {
            //省
            List<Sheng> sheng = new ShengManager().GetAll();
            Sheng she = new Sheng()
            {
                Id = 0,
                name = "---请选择---"
            };
            sheng.Insert(0, she);
            ViewBag.type1 = new SelectList(sheng, "Id", "name");
            //市
            List<Shi> shis = new List<Shi>();
            Shi shi = new Shi()
            {
                Id = 0,
                Name = "---请选择---"
            };
            shis.Insert(0, shi);
            ViewBag.type2 = new SelectList(shis, "Id", "Name");
            //区县
            List<QuXian> quxs = new List<QuXian>();
            QuXian qu = new QuXian()
            {
                Id = 0,
                Name = "---请选择---"
            };
            quxs.Insert(0, qu);
            ViewBag.type3 = new SelectList(quxs, "Id", "Name");
            return PartialView();
        }

        /// <summary>
        /// 删除用户地址
        /// </summary>
        /// <param name="Sites"></param>
        /// <returns></returns>
        public ActionResult SiteDel(List<UserSite> Sites) {
            try
            {
                foreach (var item in Sites)
                {
                    new UserSiteManager().Delete(item.Id);
                }
                return Json(1001, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(1000, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        public ActionResult Exit()
        {
            Session.Clear();
            return Json("",JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 修改页面
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public ActionResult SiteUpIndex(int Id)
        {
            UserSite newus = new UserSiteManager().GetEntity(Id);
            //省
            List<Sheng> sheng = new ShengManager().GetAll();
            sheng.Add(newus.QuXian.Shi.Sheng);
            ViewBag.type1 = new SelectList(sheng, "Id", "name");
            //市
            List<Shi> shi = new List<Shi>();
            shi.Add(newus.QuXian.Shi);
            ViewBag.type2 = new SelectList(shi, "Id", "Name");
            //区县
            List<QuXian> quxs = new List<QuXian>();
            quxs.Add(newus.QuXian);
            ViewBag.type3 = new SelectList(quxs, "Id", "Name");

            return PartialView(newus);
        }
        /// <summary>
        /// 修改地址
        /// </summary>
        /// <param name="usite"></param>
        /// <returns></returns>
        public ActionResult SiteUp(UserSite usite)
        {
            UserSite oldusite = new UserSiteManager().GetEntitysWhereAsNoTracking(x=>x.Id==usite.Id).FirstOrDefault();
            oldusite.QuXianId = usite.QuXianId;
            oldusite.SiteDetail = usite.SiteDetail;
            oldusite.SitePhone = usite.SitePhone;
            oldusite.SiteProName = usite.SiteProName;

            UserSite uspro = new UserSiteManager().GetEntitysWhereAsNoTracking(x => x.SitePre==1&x.Id==usite.Id).FirstOrDefault();
            if (uspro==null)
            {
                oldusite.SitePre = usite.SitePre;
            }

            if (new UserSiteManager().Update(oldusite))
            {
                if (oldusite.SitePre==1) {
                    UserSite us = new UserSiteManager().GetEntitysWhereAsNoTracking(x=>x.SitePre==1&x.Id!= oldusite.Id).FirstOrDefault();
                    if (us!=null)
                    {
                        us.SitePre = 0;
                        if (new UserSiteManager().Update(us))
                        {
                            return Json("1001", JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json("1000", JsonRequestBehavior.AllowGet);
                        }
                    }
                }
                return Json("1001", JsonRequestBehavior.AllowGet);
            }
            return Json("1000",JsonRequestBehavior.AllowGet);
        }
    }
}