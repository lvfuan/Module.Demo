using HelpYou.Com.DB.Models;
using System.Collections.Generic;
using System.Linq;

namespace HelpYou.Com.DB.Context
{
    public class HelpYouDBInit
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(HelpYouDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Menu.Any())
            {
                return;
            }
            List<MenuModel> menuList = new List<MenuModel>()
            {
              new MenuModel(){ Name="语言分类", Code="h001", ParentUrl="/boot", Level=0, State=true },
              new MenuModel(){ Name="ASP.NET" ,  Code="c001", ParentUrl="/boot/h001",Level=1, State=true},
              new MenuModel(){ Name="JAVA" ,  Code="c002", ParentUrl="/boot/h001",Level=1, State=true},
              new MenuModel(){ Name="PHP" ,  Code="c003",  ParentUrl="/boot/h001",Level=1,State=true},
              new MenuModel(){ Name="C" ,  Code="c004", ParentUrl="/boot/h001", Level=1,State=true},
              new MenuModel(){ Name="C++" ,  Code="c005",ParentUrl="/boot/h001",Level=1, State=true},
              new MenuModel(){ Name="PYTHON" ,  Code="c006",ParentUrl="/boot/h001", Level=1,State=true},
              new MenuModel(){ Name="SqlServer" ,  Code="c007",ParentUrl="/boot/h001", Level=1,State=true},
              new MenuModel(){ Name="Objective-C" ,  Code="c008",ParentUrl="/boot/h001", Level=1,State=true},
              new MenuModel(){ Name="常见问题", Code="h002",ParentUrl="/boot",Level=0,State=true },
              new MenuModel(){ Name="联系我们", Code="h003", ParentUrl="/boot",Level=0,State=true}
            };
            menuList.ForEach(x => context.Add(x));
            context.SaveChanges();
        }
    }
}
