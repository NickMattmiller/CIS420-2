using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp.netmvc5.Models;

namespace asp.netmvc5.Controllers
{
    public class FileManagerController : Controller
    {
        // GET: FileManager
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Picture picture)
        {
            foreach (var file in picture.Files)
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                if (fileName != null)
                {
                    var path = Path.Combine(Server.MapPath("~/Files"), fileName);
                    file.SaveAs(path);
                }
            }
            return RedirectToAction("Index");
        }
    }
}