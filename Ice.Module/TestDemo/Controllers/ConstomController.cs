using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestDemo.Controllers
{
    public class ConstomController:Controller
    {
        public ActionResult Index(string dynamicRoute)
        {
            string file = "/Views/" + dynamicRoute + ".cshtml";
            ViewBag.T = "Hello World";
            return View(file);
        }
    }
}