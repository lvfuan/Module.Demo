using HelpYou.Com.DB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpYou.Com.DB.Models;
using HelpYou.Com.DB.Context;
using Microsoft.EntityFrameworkCore;

namespace HelpYou.Com.DB.Server
{
    public class MenuServer : HelpYouServe, IMenu
    {
        public List<MenuModel> QueryAll()
        {
            using (var dbContext=new HelpYouDbContext())
            {
                return dbContext.Menu.FromSql("SELECT * FROM Com_Menu").ToList();
            }
        }
    }
}
