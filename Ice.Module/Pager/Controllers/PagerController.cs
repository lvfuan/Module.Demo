using Pager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pager.Controllers
{
    public class PagerController : Controller
    {
        // GET: Pager
        public ActionResult PagerDemo1()
        {
            var list = new InitPagerDate().GetPagerDate;
            ViewBag.TotalRecord = list.Count();//总记录
            ViewBag.PageCount = Math.Ceiling(list.Count*0.1 / 10)*10; //总页数
            //var page = list.OrderBy(x => x.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            //if (Request.IsAjaxRequest())
            //{         
            //    return PartialView("_Pager", page);
            //}
            return View(list);
        }
    }
}