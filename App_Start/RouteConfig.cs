using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QuanLyDoAn
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "HocKys", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DeTaiTheoMonHoc",
                url: "{controller}/{action}/{id}",
                new { controller = "DeTais", action = "Index", id = UrlParameter.Optional}
             );
        }
    }
}
