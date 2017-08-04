using HelpYou.Com.DB.Interface;
using HelpYou.Com.DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpYou.Com.DB.Server
{
    public class CustomServer : HelpYouServe<CustomModel>, ICustom
    {
        public void Add(CustomModel model)
        {
            try
            {
                this._dbContext.Custom.FromSql($"INSERT INTO User_Custom(LoginId,Password,Email,Mobile,RealName,NickName,Gander,Age,CreateTime,CreateUser,UpdateTime,UpdateUser,State) " +
              $"VALUES({model.LoginId},{model.Password},{model.Email},{model.Mobile},{model.RealName},{model.NickName},{model.Gander},{model.Age},{model.CreateTime},{model.CreateUser},{model.UpdateTime},{model.UpdateUser},{model.State})");
            }
            catch (Exception e)
            {                

                throw new Exception(e.Message);
            }
          
        }

        public bool IsExists()
        {
            throw new NotImplementedException();
        }

        public CustomModel Query(string loginId)
        {
            return this._dbContext.Custom.Where(x => x.LoginId.Contains(loginId)).FirstOrDefault();
        }
    }
}
