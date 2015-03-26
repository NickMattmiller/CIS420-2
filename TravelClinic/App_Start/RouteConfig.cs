using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace asp.netmvc5
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "DownloadGrantFile",
                url: "Files/Download/{id}/{FileName}",
                defaults: new
                {
                    controller = "GrantManagerModels",
                    action = "FileDownload",
                    id = UrlParameter.Optional,
                    FileName = UrlParameter.Optional
                });

            routes.MapRoute(
                name: "DeleteGrantFile",
                url: "Files/Delete/{id}/{FileName}",
                defaults: new
                {
                    controller = "GrantManagerModels",
                    action = "FileDelete",
                    id = UrlParameter.Optional,
                    FileName = UrlParameter.Optional
                });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        
        }
    }
}
