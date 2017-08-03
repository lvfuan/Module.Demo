using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelpYou.Com.DB.Interface;

namespace HelpYou.Com.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMenu _menuServer;
        public HomeController(IMenu menu)
        {
            this._menuServer = menu;
        }
        public ActionResult Index()
        {
            _menuServer.GuidItem();
            var lst = _menuServer.QueryAll();
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}
