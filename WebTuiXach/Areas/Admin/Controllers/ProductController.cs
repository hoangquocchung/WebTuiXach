using BLL.Method;
using Data.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace WebTuiXach.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(string searchString, int page = 1, int pageSize = 3)
        {
            int totalRecord = 0;
            var model = new ProductDao().ListAllProduct(searchString, ref totalRecord, page, pageSize);
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
        [HttpGet]
        
        public ActionResult Create()
        {
            var submenu = new MenuUserDao();
            
            ViewBag.submenu = submenu.ListAllSubmenu();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Product entity)
        {
            if (ModelState.IsValid)
            {
                var model = new ProductDao().Create(entity);
                if (model > 0)
                {
                    
                    SetAlert("Bạn đã thêm thành công", "success");
                    return RedirectToAction("Index", "Product");
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
            var model = new ProductDao().ViewDetail(id);
            var submenu = new MenuUserDao();
            ViewBag.submenu = submenu.ListAllSubmenu();
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Product entity)
        {
            var dao = new ProductDao();
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

        [HttpPost]
        public JsonResult Delete(long id)
        {
            var model = new ProductDao().Delete(id);
            return Json(new
            {
                id = model
            });
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var model = new ProductDao().ChangeStatus(id);
            return Json(new
            {
                status = model
            });
        }

        public string UploadImage(HttpPostedFileBase file)
        {
            //vaildate 
            //xử lí upload
            file.SaveAs(Server.MapPath("~/Data/images/asd/" + file.FileName));// chỉ ra đường dẫn tương đối của nó
            return "/Data/images/asd/" + file.FileName;
        }

    }
}