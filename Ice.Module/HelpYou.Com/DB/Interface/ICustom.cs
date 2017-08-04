using HelpYou.Com.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpYou.Com.DB.Interface
{
    public interface ICustom:IHelpYou<CustomModel>
    {
        void Add(CustomModel model);
        CustomModel Query(string loginId);
        bool IsExists();
    }
}
