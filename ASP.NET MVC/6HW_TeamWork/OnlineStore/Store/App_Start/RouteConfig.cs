using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Store
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Products",
            //    url: "Products/{category}",
            //    defaults: new { controller = "Home", action = "Products", category = "" }
            //);

            routes.MapRoute(
                name: "Products",
                url: "Products/{action}/{id}",
                defaults: new { controller = "Products", id = UrlParameter.Optional },
                namespaces: new string[]{"Store.Controllers"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
