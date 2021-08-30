using BLL.Method;
using Data.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTuiXach.Areas.Admin.Controllers
{
    public class ProductCategoryController : BaseController
    {
        // GET: Admin/ProductCategory
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductCategory entity)
        {
            if (ModelState.IsValid)
            {
                var model = new ProductCategoryDao().Create(entity);
                if(model > 0)
                {
                    SetAlert("Bạn đã thêm thành công", "success");
                    return RedirectToAction("Index", "ProductCategory");
                }
                else

                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            return View("Create");
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var model = new ProductCategoryDao().ViewDetail(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ProductCategory entity)
        {
            var dao = new ProductCategoryDao();
            var res = dao.Edit(entity);
            if (res)
            {
                SetAlert("Cập nhật thành công", "success");
                return RedirectToAction("Index", "ProductCategory");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật không thành công");
            }
            return View("Edit");
        }

    }
}