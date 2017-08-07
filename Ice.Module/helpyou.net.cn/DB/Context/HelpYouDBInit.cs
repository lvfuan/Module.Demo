using helpyou.net.cn.DB.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace helpyou.net.cn.DB.Context
{
    public class HelpYouDBInit : DropCreateDatabaseIfModelChanges<HelpYouDbContext>
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(HelpYouDbContext context)
        {
            List<MenuModel> menuList = new List<MenuModel>()
            {
              new MenuModel(){ Name="语言分类", Code="h001", ParentUrl="boot/h001", Level=0, State=true },
              new MenuModel(){ Name="ASP.NET" ,  Code="c001", ParentUrl="boot/h001/c001",Level=1, State=true},
              new MenuModel(){ Name="JAVA" ,  Code="c002", ParentUrl="boot/h001/c002",Level=1, State=true},
              new MenuModel(){ Name="PHP" ,  Code="c003",  ParentUrl="boot/h001c003",Level=1,State=true},
              new MenuModel(){ Name="C" ,  Code="c004", ParentUrl="boot/h001/c004", Level=1,State=true},
              new MenuModel(){ Name="C++" ,  Code="c005",ParentUrl="boot/h001/c005",Level=1, State=true},
              new MenuModel(){ Name="PYTHON" ,  Code="c006",ParentUrl="boot/h001/c006", Level=1,State=true},
              new MenuModel(){ Name="SqlServer" ,  Code="c007",ParentUrl="boot/h001/c007", Level=1,State=true},
              new MenuModel(){ Name="Objective-C" ,  Code="c008",ParentUrl="boot/h001/c008", Level=1,State=true},
              new MenuModel(){ Name="常见问题", Code="h002",ParentUrl="boot/h002",Level=0,State=true },
              new MenuModel(){ Name="联系我们", Code="h003", ParentUrl="boot/h003",Level=0,State=true}
            };
            menuList.ForEach(x => context.Menu.Add(x));
            context.SaveChanges();
        }
    }
}
