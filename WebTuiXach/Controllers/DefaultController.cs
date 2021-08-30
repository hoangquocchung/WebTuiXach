using BLL.Method_client;
using BLL.Method;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.FE;

namespace WebTuiXach.Controllers
{
    public class DefaultController : Controller
    {
        MyDB db = new MyDB();
        // GET: Default
        public ActionResult Index(long? id, string slug = "", string sulgmenu = "")
        {
            if (slug == "")
            {

            }
            else
            {

                var Link = db.Links.Where(x => x.Slug == slug);
                if (Link.Count() > 0)
                {
                    //lấy mẫu tin ra
                    //có slug trong link
                    var res = Link.First();
                    var menu = db.Links.Find(res.ID);
                    if (res.Type == "product")
                    {
                        if (menu.ID == 12)
                        {
                            return this.ListAllProduct(res.ID, slug);

                        }

                        else
                        {
                            return this.ListProductCate(res.ID, slug);
                        }

                    }
                    if(res.Type == "gioithieu")
                    {
                        return this.About();
                    }

                }
                else
                {
                    if (slug == "san-pham-noi-bat")
                    {
                        return this.ListProductIsHom(slug);
                    }
                    else if(slug == "san-pham-khuyen-mai")
                    {
                        return this.ListProductSell(slug);
                    }
                    else
                    {
                        long IDparam = 1;

                        var URL = db.MenuUsers.Where(x => x.Url == sulgmenu);
                        var r = URL.First();
                        IDparam = (long)id;
                        var pro = db.Products.Find(IDparam);
                        //không có slug trong link
                        return this.ProductDetail(pro.ID, slug, sulgmenu);
                    }

                }

            }
            return null;
        }

        [HttpGet]
        public ActionResult ListAllProduct(long id, string slug)
        {
            var menu = new MenuUserDao().ViewDetail(id);
            ViewBag.menu = menu;
            var product = new ProductView();
            var model = product.ListAllProdcut(15);
            return View("ListAllProduct", model);

        }

        public ActionResult ListProductCate(long id, string slug)
        {
            var menu = new MenuUserDao().ViewDetail(id);
            ViewBag.menu = menu;
            long totalRecord = 0;
            var model = new ProductView().ListByProductCate(id, ref totalRecord, 15);
            return View("ListProductCate", model);
        }
        public ActionResult ListProductIsHom(string slug)
        {
            var menu = new MenuView().MenusLink();
            ViewBag.menu = menu;
            long totalRecord = 0;
            var model = new ProductView().ListAllProdcut(15);
            return View("ListProductIsHom", model);
        }
        public ActionResult ListProductSell(string slug)
        {
            var menu = new MenuView().MenusLink();
            ViewBag.menu = menu;
            long totalRecord = 0;
            var model = new ProductView().ListAllProdcut(15);
            return View("ListProductSell", model);
        }

        public ActionResult ProductDetail(long id, string slug, string sulgmenu)
        {
            var menu = new MenuView().MenusLink(id);
            ViewBag.menu = menu;
            var product = new ProductView();
            var productrelate = product.productrelate(id, 10);
            ViewBag.productrelate = productrelate;

            var model = new ProductDao().ViewDetail(id);
            return View("ProductDetail", model);
        }

        public ActionResult About()
        {
            var model = new ContactDao().GetActiveContac();
            return View("About",model);
        }

        public ActionResult Search(string keyword, int page = 1, int pageSize = 1)
        {
            var menu = new MenuView().MenusLink();
            ViewBag.menu = menu;
            int totalRecord = 0;
            var model = new ProductDao().Search(keyword, ref totalRecord, page, pageSize);

            //var ProductCategory = new ProductCategoryDao().ViewDetail(id);
            //ViewBag.productCategory = ProductCategory;
            ViewBag.Total = totalRecord;
            ViewBag.Keyword = keyword;
            //ViewBag.Page = page;

            //int maxPage = 5;
            //int totalPage = 0;

            //totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));

            //ViewBag.TotalPage = totalPage;
            //ViewBag.MaxPage = maxPage;
            //ViewBag.First = 1;
            //ViewBag.Last = maxPage;
            //ViewBag.Next = page + 1;
            //ViewBag.Prev = page - 1;
            return View(model);
        }


    }
}