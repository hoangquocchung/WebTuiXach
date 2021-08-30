using BLL.Method;
using Data.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTuiXach.Areas.Admin.Controllers
{
    
    public class OrderController : Controller
    {
        MyDB db = new MyDB();
        // GET: Admin/Order
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            int totalRecord = 0;
            var model = new OrderDao().ListAllOrder(searchString, ref totalRecord, page, pageSize);
            ViewBag.ChuoiTimKiem = searchString;
            ViewBag.Page = page;
            int maxPage = 100;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));

            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = maxPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }
        public ActionResult VanChuyen(string searchString, int page = 1, int pageSize = 5)
        {
            int totalRecord = 0;
            var model = new OrderDao().ListAllOrder(searchString, ref totalRecord, page, pageSize);
            ViewBag.ChuoiTimKiem = searchString;
            ViewBag.Page = page;
            int maxPage = 100;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));

            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = maxPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }
        public ActionResult Hoanhang(string searchString, int page = 1, int pageSize = 5)
        {
            int totalRecord = 0;
            var model = new OrderDao().ListAllOrder(searchString, ref totalRecord, page, pageSize);
            ViewBag.ChuoiTimKiem = searchString;
            ViewBag.Page = page;
            int maxPage = 100;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));

            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = maxPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }

        public JsonResult ChangeStatus(long id)
        {
            var model = new OrderDao().ChangeStatus(id);
            return Json(new
            {
                status = model,
            });
        }
        public JsonResult HienThi(long id)
        {
            var data = new OrderDao().ListOrdetail(id);
            return Json(new
            {
                data = data
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Huy(long id)
        {
            var model = new OrderDao().huy(id);
            return Json(new
            {
                status = model,
            });
        }
        public JsonResult Ship(long id)
        {
            var model = new OrderDao().nhan(id);
            return Json(new
            {
                status = model,
            });
        }
    }
}