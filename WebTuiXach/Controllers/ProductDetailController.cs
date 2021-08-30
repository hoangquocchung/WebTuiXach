using BLL.Method_client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTuiXach.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ViewCount(long id)
        {
            var model = new ProductView().Viewcount(id);
            return Json(new
            {
                data = model
            });
        }
    }
}