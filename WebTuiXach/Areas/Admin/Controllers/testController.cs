using BLL.Method;
using Data.FE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace WebTuiXach.Areas.Admin.Controllers
{
    public class testController : Controller
    {
        // GET: Admin/test
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult save(Product entity, string images)
        {
            JavaScriptSerializer serialiez = new JavaScriptSerializer();
            var listImages = serialiez.Deserialize<List<string>>(images);
            XElement xElement = new XElement("Images");

            foreach (var item in listImages)
            {
                var subStringItem = item.Substring(21);
                xElement.Add(new XElement("Image", subStringItem));
            }
            ProductDao dao = new ProductDao();
            try
            {
                dao.UpdateImage(entity, xElement.ToString());

                return Json(new
                {
                    code = 200,msg="thêm thành công",
                    JsonRequestBehavior.AllowGet
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    code = 500,
                    msg = "thêm không thành công"+ ex.Message,
                    JsonRequestBehavior.AllowGet
                });
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Product entity)
        {
            if (ModelState.IsValid)
            {
                var model = new ProductDao().Create(entity);

            }
            //SaveImages(entity.ID,images);
            return View("Create");
        }
    }
}
