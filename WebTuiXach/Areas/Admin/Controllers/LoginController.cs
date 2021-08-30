using BLL.Method;
using Common.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTuiXach.Areas.Admin.Models;

namespace WebTuiXach.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            Session.Remove(CommonConstants.USER_SESSION);
            return View("Index");
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var res = dao.Login(model.UserName, MaHoaMd5.MD5Hash(model.PassWord), true);
                if (res == 1)
                {
                    var user = dao.GetByID(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.Username;
                    userSession.UserID = user.ID;
                    userSession.GroupID = user.Group;
                    var listCredentials = dao.GetListCredential(model.UserName);
                    Session.Add(CommonConstants.SESSION_CREFENTIALS, listCredentials);

                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (res == 0)
                {
                    ModelState.AddModelError("", "tài khoản không tồn tại");
                }
                else if (res == -1)
                {
                    ModelState.AddModelError("", "tài khoản đã bị khóa");
                }
                else if (res == -2)
                {
                    ModelState.AddModelError("", "tài khoản không đúng");
                }
                else if (res == -2)
                {
                    ModelState.AddModelError("", "tài khoản của bạn không có quyền đăng nhập");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công");
                }
            }
            return View("Index");
        }
    }
}