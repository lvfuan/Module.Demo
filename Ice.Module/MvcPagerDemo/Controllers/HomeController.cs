﻿using MvcPagerDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPagerDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var list = new InitPagerDate().GetPagerDate;
            ViewBag.TotalRecord = list.Count();//总记录
            return View(list);
        }
    }
}