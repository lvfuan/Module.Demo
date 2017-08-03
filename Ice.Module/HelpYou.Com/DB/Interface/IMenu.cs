using HelpYou.Com.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpYou.Com.DB.Interface
{
    public interface IMenu: IHelpYou
    {
        List<MenuModel> QueryAll();
    }
}
