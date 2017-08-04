using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelpYou.Com.DB.Interface;

namespace HelpYou.Com.Controllers
{
    public class CustomController : Controller
    {
        private readonly ICustom _customServer;
        public CustomController(ICustom custom)
        {
            this._customServer = custom;
        }
        /// <summary>
        /// ��¼
        /// </summary>
        /// <returns></returns>
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(string email,string pw1,string pw2)
        {
            return View();
        }
        /// <summary>
        /// ע��
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }
        /// <summary>
        /// ��¼���
        /// </summary>
        /// <returns></returns>
        public ActionResult CheckSignIn()
        {
            return View();
        }
        /// <summary>
        /// �ǳ�
        /// </summary>
        /// <returns></returns>
        public ActionResult SignOut()
        {
            return View();
        }
    }
}