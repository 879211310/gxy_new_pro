﻿using System.Web.Mvc;
using MyProject.Controllers.Account.ViewModels;
using MyProject.Tasks;
using MyProject.Services.Utility;
using System.Web;

namespace MyProject.Controllers.Account
{
    public class AccountController : Controller, System.Web.SessionState.IRequiresSessionState
    {
        HttpContext context = null;

        private readonly AdminUserTask _adminUserTask = new AdminUserTask();

       

        protected ActionResult AlertMsg(string msg, string returnUrl)
        {
            var script = string.Format("<script>alert('{0}');this.location.href='{1}';</script>", msg, returnUrl);
            Response.Write(script);
            Response.End();
            return new EmptyResult();
        }

        public ActionResult LogOn()
        {
            var model = new LogOnModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model)
        {
            if (ModelState.IsValid)
            {
                var userPassword = _adminUserTask.GetByUserName(model.UserName);
                if (userPassword == null)
                    return AlertMsg("账号不存在", Request.UrlReferrer.PathAndQuery);
                if (userPassword.Password != CryptTools.HashPassword(model.Password))
                    return AlertMsg("账号或密码不正确", Request.UrlReferrer.PathAndQuery);
                if (userPassword.IsLock)
                    return AlertMsg("对不起，您的账号被锁定", Request.UrlReferrer.PathAndQuery);
                if (model.ValidationCode != context.Session["code"].ToString())
                    return AlertMsg("验证码不正确",Request.UrlReferrer.PathAndQuery);
                FormsAuthService.SignIn(userPassword.UserName, false);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public ActionResult LogOut()
        {
            if (FormsAuthService.IsSignedIn())
                FormsAuthService.SignOut();
            return RedirectToAction("LogOn", "Account");
        }


        public ActionResult NewLogOn()
        {
            var model = new LogOnModel();
            return View(model);
        }
        
    }
}