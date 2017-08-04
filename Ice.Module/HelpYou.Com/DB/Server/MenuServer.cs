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
    public class MenuServer : HelpYouServe<MenuModel>, IMenu
    {
        public readonly HelpYouDbContext _dbContext = ContextFactory.GetInstanceContext();
        ~MenuServer()
        {
            this._dbContext.Dispose();
        }
        /// <summary>
        /// 根据父级Url查询子集
        /// </summary>
        /// <param name="parentUrl"></param>
        /// <returns></returns>
        public List<MenuModel> Query(string parentUrl)
        {
            return _dbContext.Menu.FromSql($"SELECT * FROM Com_Menu WHERE parentUrl={parentUrl}").ToList();
        }

        public List<MenuModel> Query(int level)
        {
            return _dbContext.Menu.FromSql($"SELECT * FROM Com_Menu WHERE LEVEL={level}").ToList();
        }

        /// <summary>
        /// 查询所有菜单
        /// </summary>
        /// <returns></returns>
        public List<MenuModel> QueryAll()
        {
                return _dbContext.Menu.FromSql("SELECT * FROM Com_Menu").ToList();
        }
    }
}
