using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebTuiXach
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "productfalse",
                url: "trang-chu",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }, namespaces: new[] { "WebTuiXach.Controllers" }
            );
            routes.MapRoute(
                name: "Search",
                url: "tim-kiem",
                defaults: new { controller = "Default", action = "Search", id = UrlParameter.Optional }, namespaces: new[] { "SHOPDONGHO.Controllers" }
            );
            routes.MapRoute(
                name: "Register",
                url: "dang-ky",
                defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional }, namespaces: new[] { "WebTuiXach.Controllers" }
            );
            routes.MapRoute(
                name: "Login",
                url: "dang-nhap",
                defaults: new { controller = "User", action = "LoginClient", id = UrlParameter.Optional }, namespaces: new[] { "WebTuiXach.Controllers" }
            );
            routes.MapRoute(
                name: "Cart",
                url: "gio-hang",
                defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional }, namespaces: new[] { "WebTuiXach.Controllers" }
            );
            routes.MapRoute(
                name: "Add Cart",
                url: "them-gio-hang",
                defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional }, namespaces: new[] { "WebTuiXach.Controllers" }
            );
            routes.MapRoute(
                name: "Payment Success",
                url: "hoan-thanh",
                defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional }, namespaces: new[] { "WebTuiXach.Controllers" }
            );

            routes.MapRoute(
                name: "producttrue",
                url: "{slug}",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional }, namespaces: new[] { "WebTuiXach.Controllers" }
            );
            //routes.MapRoute(
            //    name: "producttrue1",
            //    url: "{Metaitle}/{id}",
            //    defaults: new { controller = "Default", action = "ProductDetail", id = UrlParameter.Optional }, namespaces: new[] { "WebTuiXach.Controllers" }
            //);
            routes.MapRoute(
                name: "Post",
                url: "{sulgmenu}/{slug}-{id}",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional }, namespaces: new[] { "WebTuiXach.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },namespaces: new[] { "WebTuiXach.Controllers" }
            );
        }
    }
}
