using BLL.Method;
using Data.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTuiXach.Areas.Admin.Controllers
{
    public class AboutController : BaseController
    {
        // GET: Admin/About
        public ActionResult Index()
        {
            var model = new ContactDao().getView();
            return View(model);
        }
        public ActionResult Edit(long id)
        {
            var model = new ContactDao().view(id);
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Contact entity)
        {
            var dao = new ContactDao();
            var res = dao.Edit(entity);
            if (res)
            {
                SetAlert("Cập nhật thành công", "success");
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật không thành công");
            }
            return View("Edit");
        }
    }
}