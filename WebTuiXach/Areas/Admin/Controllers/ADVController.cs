using BLL.Method;
using Data.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTuiXach.Areas.Admin.Controllers
{
    public class ADVController : BaseController
    {
        // GET: Admin/ADV
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            int totalRecord = 0;
            var model = new AdvDao().ListAllADV(searchString, ref totalRecord, page, pageSize);
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

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ADV entity)
        {
            if (ModelState.IsValid)
            {
                var model = new AdvDao().Create(entity);
                if (model > 0)
                {

                    SetAlert("Bạn đã thêm thành công", "success");
                    return RedirectToAction("Index", "ADV");
                }
                else

                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            //SaveImages(entity.ID,images);
            return View("Create");
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var model = new AdvDao().ViewDetail(id);
            var submenu = new MenuUserDao();
            ViewBag.submenu = submenu.ListAllSubmenu();
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ADV entity)
        {
            var dao = new AdvDao();
            var res = dao.Edit(entity);
            if (res)
            {
                SetAlert("Cập nhật thành công", "success");
                return RedirectToAction("Index", "ADV");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật không thành công");
            }
            return View("Edit");
        }

        [HttpPost]
        public JsonResult Delete(long id)
        {
            var model = new AdvDao().Delete(id);
            return Json(new
            {
                id = model
            });
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var model = new AdvDao().ChangeStatus(id);
            return Json(new
            {
                status = model
            });
        }
    }
}