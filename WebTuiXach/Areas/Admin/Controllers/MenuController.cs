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
    public class MenuController : BaseController
    {
        MyDB db = new MyDB();
        // GET: Admin/Menu
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            
            int totalRecord = 0;
            var model = new MenuUserDao().ListAllMenuUser(searchString, ref totalRecord, page, pageSize);
            
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
            //SetViewBag();
            //ViewBag.submenu = new MenuUserDao().ListAllSubmenu();
            SetViewBag();

            return View();
        }
        [HttpPost]
        public ActionResult Create(MenuUser entity, Link slu)
        {
            var currentCulture = Session[CommonConstants.CurrentCulture];
            entity.Language = currentCulture.ToString();
            var model = new MenuUserDao().Create(entity);
            slu.ID = model;
            var link = new MenuUserDao().CreateLink(slu);
            
            //slu.TableId = entity.ID;
            //slu.Slug = entity.Url;
            //slu.Name = entity.Name;
            //slu.Type = "product";
            //db.Links.Add(slu);
            //db.SaveChanges();

            if (model > 0)
            {
                SetAlert("Bạn đã thêm thành công", "success");
                return RedirectToAction("Index", "Menu");
            }
            else

            {
                ModelState.AddModelError("", "Thêm không thành công");
            }

            SetViewBag();
            return View("Create");
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var model = new MenuUserDao().ViewDetail(id);
            if (model.ParentID == null)
            {
                SetViewBag();
            }
            else
            {
                SetViewBag(model.ID);
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(MenuUser entity,Link lik)
        {
            var dao = new MenuUserDao();
            var res = dao.Edit(entity,lik);
            if (res)
            {
                SetAlert("Cập nhật thành công", "success");
                return RedirectToAction("Index", "Menu");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật không thành công");
            }
            SetViewBag(entity.ID);
            return View("Edit");
        }

        [HttpPost]
        public JsonResult Delete(long id)
        {
            var model = new MenuUserDao().Delete(id);
            return Json(new
            {
                id = model
            });
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var res = new MenuUserDao().ChangeStatus(id);
            return Json(new
            {
                status = res
            });

        }

        public void SetViewBag(long? selectId = null)
        {
            var dao = new MenuUserDao();
            ViewBag.ProductCategoryID = new SelectList(dao.ListAllSubmenu(), "ID", "Name", selectId);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        public ActionResult MenuArticle(string searchString, int page = 1, int pageSize = 10)
        {
            int totalRecord = 0;
            var model = new MenuUserDao().ListAllMenuUser(searchString, ref totalRecord, page, pageSize);
            ViewBag.ChuoiTimKiem = searchString;
            ViewBag.Page = page;
            int maxPage = 10;
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
    }
}