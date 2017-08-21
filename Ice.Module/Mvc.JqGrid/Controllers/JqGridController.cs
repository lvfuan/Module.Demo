using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Mvc.JqGrid.Controllers
{
    public class JqGridController : Controller
    {
        private readonly JqGridDbContext.DsbuyerShopEntities _dbcontext=new JqGridDbContext.DsbuyerShopEntities();
        ~JqGridController(){
            this._dbcontext.Dispose();
        }
        // GET: JqGrid
        public ActionResult Index()
        {        
            return View();
        }
        [HttpPost]
        public  JsonResult GetDemoDB()
        {
            var list = _dbcontext.Offer_ProductsDetail.ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Demo2()
        {
            return View();
        }
    }
}