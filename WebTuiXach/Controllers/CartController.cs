using BLL.Method;
using Common.common;
using Data.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebTuiXach.Models.Cart;
using System.Net.Mail;

namespace WebTuiXach.Controllers
{
    public class CartController : Controller
    {
        private const string CartSesion = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSesion];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public ActionResult AddItem(long productId, int quantity)
        {
            var product = new ProductDao().ViewDetail(productId);
            var cart = Session[CartSesion];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.product.ID == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.product.ID == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                Session[CartSesion] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartItem();
                item.product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                // gán vào session
                Session[CartSesion] = list;
            }
            return RedirectToAction("Index");
        }

        public JsonResult Update(string cartModel)
        {
            var jsoncart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSesion];
            foreach (var item in sessionCart)
            {
                var jsonItem = jsoncart.SingleOrDefault(x => x.product.ID == item.product.ID);
                var product = new ProductDao().ViewDetail(item.product.ID);
                if (jsoncart != null && product.Quantity >= jsonItem.Quantity)
                {
                    item.Quantity = jsonItem.Quantity;
                }

                else if(jsoncart != null && product.Quantity < jsonItem.Quantity)
                {
                    string mess = string.Empty;
                    mess = "Sản phẩm hiện không đủ hãy nhập số lượng ít hơn "+ product.Quantity;
                    TempData["AlertMessage"] = mess;
                    item.Quantity = item.Quantity;
                    
                }
            }
            Session[CartSesion] = sessionCart;
            return Json(new
            {
                status = true,
            });
        }
        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CartSesion]; // lấy ra danh sách giỏ hàng
            sessionCart.RemoveAll(x => x.product.ID == id); // remove những id được truyền vào
            Session[CartSesion] = sessionCart;
            return Json(new
            {
                status = true,
            });
        }
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CartSesion];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);

        }
        [HttpPost]
        public ActionResult Index(string shipName, string mobile, string address, string email, string textnote)
        {
            MyDB db = new MyDB();
            var order = new Order();
            order.ShipName = shipName;
            order.ShipMobile = mobile;
            order.ShipAddress = address;
            order.ShipEmail = email;
            order.ghichu = textnote;
            //try
            //{
                var id = new OrderDao().Insert(order);
                var cart = (List<CartItem>)Session[CartSesion];
                var detailDao = new OrderDetailDao();
                var qtt = new ProductDao();
                decimal total = 0;
                decimal tong = 0;
                foreach (var item in cart)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.ProductID = item.product.ID;
                    orderDetail.OrderID = id;

                    if (item.product.PromotionPrice == null)
                    {
                        total = (item.product.Price.GetValueOrDefault(0) * item.Quantity);
                        tong += (item.product.Price.GetValueOrDefault(0) * item.Quantity);
                        orderDetail.Price = total;
                    }
                    else
                    {
                        total = (item.product.PromotionPrice.GetValueOrDefault(0) * item.Quantity);
                        tong += (item.product.PromotionPrice.GetValueOrDefault(0) * item.Quantity);

                        orderDetail.Price = total;
                    }
                    orderDetail.Quantity = item.Quantity;
                    detailDao.Insert(orderDetail);
                    //t = item.product.Name;
                }
            string smtpUserName = "hoangchung0123456789@gmail.com";
            string smtpPassword = "95sangchung99";
            string smtpHost = "smtp.gmail.com";
            int smtpPort = 25;

            string emailTo = "hoangchung1339@gmail.com";
            string subject = "Chu de....";
            string body = string.Format("Bạn vừa nhận được liên hê từ: <b>{0}</b><br/>Email: {1}<br/>Nội dung: </br>",
               shipName, email);

            EmailService service = new EmailService();
            bool kq = service.Send(smtpUserName, smtpPassword, smtpHost, smtpPort, emailTo, subject, body);
            //string content = System.IO.File.ReadAllText(Server.MapPath("/Assets/Client/template/neworder.html"));

            //content = content.Replace("{{CustomerName}}", shipName);
            //content = content.Replace("{{Phone}}", mobile);
            //content = content.Replace("{{Email}}", email);
            //content = content.Replace("{{Address}}", address);
            //foreach (var tt in cart)
            //{
            //    t = tt.product.Name;
            //    sl = tt.Quantity;
            //    gia = tt.product.Price.GetValueOrDefault(0);
            //    content = content.Replace("{{product}}", t.ToString());
            //    content = content.Replace("{{Quantity}}", sl.ToString());
            //    content = content.Replace("{{Price}}", gia.ToString("N0"));

            //}

            //content = content.Replace("{{Total}}", tong.ToString("N0"));
            //var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
            //new MailHelper().SenMail(email, "Đơn hàng mới từ OnlineShop", content);
            //new MailHelper().SenMail(toEmail, "Đơn hàng mới từ OnlineShop", content);
            foreach (var Item in cart)
                {
                    var quantityProduct = new Product();
                    quantityProduct.ID = Item.product.ID;
                    var mode = db.Products.Find(quantityProduct.ID);

                    mode.Quantity = (Item.product.Quantity - Item.Quantity);
                    db.SaveChanges();
                }
            //}
            //catch
            //{
            //    return Redirect("/loi-thanh-toan");
            //}
            return Redirect("/hoan-thanh");
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}