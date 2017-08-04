using HelpYou.Com.DB.Context;
using HelpYou.Com.DB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpYou.Com.DB.Server
{
    public class HelpYouServe<T> : IHelpYou<T> where T : class, new()
    {
        //private readonly Guid _item;
        //public HelpYouServe()
        //{
        //    _item = Guid.NewGuid();
        //}
        //public Guid GuidItem()
        //{
        //    return _item;
        //}
        protected readonly HelpYouDbContext _dbContext = ContextFactory.GetInstanceContext();
        ~HelpYouServe()
        {
            this._dbContext.Dispose();
        } 
        protected void Submit()
        {
            this._dbContext.SaveChanges();
        }
    }
}
