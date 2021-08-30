using BLL.Method;
using Data.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTuiXach.Controllers
{
    public class NewsController : Controller
    {
        MyDB db = new MyDB();
        // GET: News
        public ActionResult Index(string slugmenu = "",string slug = "")
        {
            if (slug == "")
            {

            }
            else
            {
                var url = db.Products.First();
                url.Metatitle = slugmenu;
                var Link = db.Links.Where(x => x.Slug == slugmenu);
                var model = db.Products.Where(x => x.Metatitle == slug);
                if (Link.Count() > 0)
                {
                    //lấy mẫu tin ra
                    //có slug trong link
                    var res = Link.First();
                    var menu = db.Links.Find(res.ID);
                    if (res.Type == "product")
                    {

                    }

                }
                else
                {
                    //không có slug trong link
                }

            }
            return null;
        }

        public ActionResult ListAllPost(string slug = "")
        {
            return View("ListAllPost");
        }
        public ActionResult ListPostCate(string slug = "")
        {
            return View("ListPostCate");
        }

        public ActionResult ProductDetail(long id)
        {
            var menu = new MenuUserDao().ViewDetail(id);
            ViewBag.menu = menu;
            var model = new ProductDao().ViewDetail(id);
            return View(model);
        }
    }
}