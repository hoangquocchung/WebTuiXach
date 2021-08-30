using BLL.Method;
using Data.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using WebTuiXach.Areas.Admin.Models;

namespace WebTuiXach.Areas.Admin.Controllers
{
    public class bannerController : BaseController
    {
        // GET: Admin/banner
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            int totalRecord = 0;
            var model = new BannerDao().ListAllBanner(searchString, ref totalRecord, page, pageSize);
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
            var submenu = new MenuUserDao();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Banner entity)
        {
            if (ModelState.IsValid)
            {
                var model = new BannerDao().Create(entity);
                if (model > 0)
                {

                    SetAlert("Bạn đã thêm thành công", "success");
                    return RedirectToAction("Index", "Banner");
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
            var model = new BannerDao().ViewDetail(id);
            //LoadDistrict(model.ID);
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Banner entity)
        {
            var dao = new BannerDao();
            var res = dao.Edit(entity);
            if (res)
            {
                SetAlert("Cập nhật thành công", "success");
                return RedirectToAction("Index", "Banner");
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
            var model = new BannerDao().Delete(id);
            return Json(new
            {
                id = model
            });
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var model = new BannerDao().ChangeStatus(id);
            return Json(new
            {
                status = model
            });
        }
        public JsonResult LoadProvince()
        {
            var xmlDoc = XDocument.Load(Server.MapPath(@"~/Style/Admin/data/TypeOfBanner.xml"));
            var xElements = xmlDoc.Element("Root").Elements("Item").Where(x => x.Attribute("type").Value == "district");
            var list = new List<TypeOfBannerModel>();
            TypeOfBannerModel district = null;
            foreach (var item in xElements)
            {
                district = new TypeOfBannerModel();
                district.ID = int.Parse(item.Attribute("id").Value);
                district.Name = item.Attribute("value").Value;
                list.Add(district);

            }
            return Json(new
            {
                data = list,
                status = true
            });
        }
        public JsonResult LoadDistrict(long id,int? ids)
        {
            var model = new BannerDao().ViewDetail(id);
            var xmlDoc = XDocument.Load(Server.MapPath(@"~/Style/Admin/data/TypeOfBanner.xml"));

            var xElements = xmlDoc.Element("Root").Elements("Item")
                    .Where(x => x.Attribute("type").Value == "distric" && int.Parse(x.Attribute("id").Value) == model.TypeOfAdvID);
            var list = new List<TypeOfBannerModel>();
            TypeOfBannerModel district = null;
            foreach (var item in xElements)
            {
                district = new TypeOfBannerModel();
                district.ID = int.Parse(item.Attribute("id").Value);
                district.Name = item.Attribute("value").Value;
                list.Add(district);
            }
            return Json(new
            {
                data = list,
                status = true
            });
        }
    }
}