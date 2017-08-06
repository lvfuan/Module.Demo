using helpyou.net.cn.DB.Interface;
using helpyou.net.cn.DB.Models;
using System;
using System.Linq;
using Framework.Dapper;

namespace helpyou.net.cn.DB.Server
{
    public class CustomServer : HelpYouServe<CustomModel>, ICustom
    {
        public int Add(CustomModel model)
        {
            try
            {
               return this.openSqlConnection.Execute($"INSERT INTO User_Custom(LoginId,Password,Email,Mobile,RealName,NickName,Gander,Age,CreateTime,CreateUser,UpdateTime,UpdateUser,State) " +
              $"VALUES({model.LoginId},{model.Password},{model.Email},{model.Mobile},{model.RealName},{model.NickName},{model.Gander},{model.Age},{model.CreateTime},{model.CreateUser},{model.UpdateTime},{model.UpdateUser},{model.State})");
            }
            catch (Exception e)
            {                

                throw new Exception(e.Message);
            }
          
        }

        public bool IsExists(CustomModel model)
        {
            return openSqlConnection.Query<CustomModel>($"SELECT * FROM  WHERE [LoginId]={model.LoginId} AND [Password]={model.Password}").Count()>0;
        }

        public CustomModel Query(string loginId)
        {
            return this.openSqlConnection.QueryFirst<CustomModel>($"SELECT * FROM  WHERE [LoginId]={loginId}");
        }
    }
}
