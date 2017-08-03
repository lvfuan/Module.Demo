using HelpYou.Com.DB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpYou.Com.DB.Server
{
    public class HelpYouServe:IHelpYou
    {
        private readonly Guid _item;
        public HelpYouServe()
        {
            _item = Guid.NewGuid();
        }
        public Guid GuidItem()
        {
            return _item;
        }
    }
}
