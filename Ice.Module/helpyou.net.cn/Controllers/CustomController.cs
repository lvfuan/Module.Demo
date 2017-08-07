using Helper.Common;
using helpyou.net.cn.DB.Context;
using helpyou.net.cn.DB.Interface;
using helpyou.net.cn.DB.Models;
using System.Data.Entity;
using System.Web.Mvc;

namespace helpyou.net.cn.Controllers
{
    public class CustomController : Controller
    {
        private readonly ICustom _customServer;
        public CustomController(ICustom custom)
        {
            this._customServer = custom;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(string loginId, string pw1,string pw2,string type)
        {
            Database.SetInitializer<HelpYouDbContext>(new HelpYouDBInit());
            if (string.IsNullOrWhiteSpace(loginId) || string.IsNullOrWhiteSpace(pw1) || string.IsNullOrWhiteSpace(pw2))
                return Json(new ReturnResultOption(ReturnResultOptionType.ParamError, "参数错误"));
            if (!pw1.Equals(pw2)) return Json(new ReturnResultOption(ReturnResultOptionType.Warning, "两次密码输入不一致"));
            switch (type)
            {
                case "email":
                    this._customServer.Add(new CustomModel() { LoginId = loginId, Password = pw1 });
                    break;
                case "mobile":
                    break;
                default:
                    break;
            }
            return View();
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }
        /// <summary>
        /// 登录检查
        /// </summary>
        /// <returns></returns>
        public ActionResult CheckSignIn()
        {
            return View();
        }
        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        public ActionResult SignOut()
        {
            return View();
        }
    }
}