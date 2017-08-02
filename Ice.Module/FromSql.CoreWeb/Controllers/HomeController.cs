using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FromSql.CoreWeb.DB.Context;
using Microsoft.EntityFrameworkCore;
using FromSql.CoreWeb.DB.Models;

namespace FromSql.CoreWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<PeopleModel> lst = null;
            using (var dbcontext = new FromSqlDbContext())
            {
                lst= dbcontext.People.FromSql("select * from People").ToList();
            }
            return View(lst);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
