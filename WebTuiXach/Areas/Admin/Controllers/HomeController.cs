using BLL.Method;
using BLL.Method_client;
using Data.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTuiXach.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        MyDB db = new MyDB();
        // GET: Admin/Home
        public ActionResult Index()
        {
            var model = new OrderDao();
            ViewBag.Order = model.ListAll();
            ViewBag.SumOrder = model.SumOrrder();
            ViewBag.productview = new ProductDao().listAll();

            

            return View();
        }
        public ActionResult GetData()
        {
            //var data = db.OrderDetails.Include("OrderID").ToList();
            var query = db.OrderDetails.Include("ProductID").GroupBy(x => x.ProductID).Select(x => new { x.Key, count = x.Sum(w => w.Quantity) }).ToList(); ;
            return Json(query, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Logout()
        {
            Session[Common.CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }
    }
}