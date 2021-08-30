using BLL.Method;
using Common.common;
using Data.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTuiXach.Areas.Admin.Controllers
{
    public class ArticleController : BaseController
    {
        // GET: Admin/Article
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ContentDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;
            ViewBag.Prev = page - 1;
            return View(model);
        }

        [HttpGet]

        public ActionResult Create()
        {
            //setviewbag();
            var submenu = new MenuUserDao();
            ViewBag.submenu = submenu.ListAllSubmenu();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Content entity)
        {
            if (ModelState.IsValid)
            {
                var session = (UserLogin)Session[CommonConstants.USER_SESSION];
                entity.CreatedBy = session.UserName;
                var culture = Session[CommonConstants.CurrentCulture];
                entity.Language = culture.ToString();
                var model = new ContentDao().Create(entity);
                if (model > 0)
                {
                    SetAlert("Bạn đã thêm thành công", "success");
                    return RedirectToAction("Index", "Article");
                }
                else

                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            //setviewbag();
            return View("Create");
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var model = new ArticleDao().ViewDetail(id);
            var submenu = new MenuUserDao();
            ViewBag.submenu = submenu.ListAllSubmenu();
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Content entity)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            entity.CreatedBy = session.UserName;
            var culture = Session[CommonConstants.CurrentCulture];
            entity.Language = culture.ToString();
            var res = new ContentDao().Edit(entity);
            if (res)
            {
                SetAlert("Cập nhật thành công", "success");
                return RedirectToAction("Index", "Article");
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
            var model = new ArticleDao().Delete(id);
            return Json(new
            {
                id = model
            });
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var model = new ArticleDao().ChangeStatus(id);
            return Json(new
            {
                status = model
            });
        }
        public void setviewbag(long? id)
        {
            var model = new ArticleDao();
        }
    }
}