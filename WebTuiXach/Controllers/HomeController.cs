using BLL.Method;
using BLL.Method_client;
using Data.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTuiXach.Models.Cart;

namespace WebTuiXach.Controllers
{
    public class HomeController : Controller
    {
        
        // GET: Home
        public ActionResult Index()
        {
            var product = new ProductView();
            var model = product.ListAllProdcut(12);

                ViewBag.menu = new MenuView().MenusLink();

            return View(model);
        }

        public JsonResult QandA(QandA entity)
        {
            var model = new QAndA().Create(entity);
            return Json(new
            {
                status = model
            }, JsonRequestBehavior.AllowGet);
        }

        [ChildActionOnly]
        public ActionResult MenuTop()
        {
            var model = new MenuView().ListAllMenu();
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult Footer()
        {
            var model = new MenuView().ListAllMenu();
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult BannerHome()
        {
            var model = new BannerView().ListAllBanner();
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult BannerClient(long id)
        {
            var link = new MenuUserDao().ViewDetail(id);
            ViewBag.link = link;
            var model = new BannerView().ListAllBanner();
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult Logotrademark()
        {
            var model = new BannerView().ListAllBanner();
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult _Cart()
        {
            var cart = Session[Common.CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }

    }
}