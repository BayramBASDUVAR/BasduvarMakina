﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BasduvarMakina
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "About",
                url: "hakkimizda",
                defaults: new { controller = "About", action = "Index"}
            );

            routes.MapRoute(
              name: "Blog",
              url: "blog",
              defaults: new { controller = "Blog", action = "Index" }
          );

            routes.MapRoute(
             name: "Contact",
             url: "iletisim",
             defaults: new { controller = "Contact", action = "Index" }
         );
            routes.MapRoute(
             name: "Project",
             url: "admin",
             defaults: new { controller = "Admin", action = "Index" }
         );
            routes.MapRoute(
            name: "Admin",
            url: "projeler",
            defaults: new { controller = "Project", action = "Index" }
        );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
