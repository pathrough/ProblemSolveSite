using AandQMvc;
using AandQMvc.Models;
using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAccount(string email, string password,string name)
        {
            JsonResultItem result = new Models.JsonResultItem();
            //ModelState.IsValid
            if (email.IsEmail())
            {
                if (string.IsNullOrWhiteSpace(password) == false && password.Length >= 6)
                {
                    using (AandQContext db = new AandQContext())
                    {
                        var entity = db.Accounts.FirstOrDefault(d => d.Email == email);
                        if (entity == null)
                        {
                            entity = new Account();
                            entity.Email = email;
                            entity.Password = password;
                            entity.UserName = name.Trim();
                            db.Accounts.Add(entity);
                            db.SaveChanges();
                            result.Status = 0;
                            result.Msg = "注册成功！";
                        }
                        else
                        {
                            result.Status = 1;
                            result.Msg = "该邮箱已经被注册了！";
                        }
                    }
                }
                else
                {
                    result.Status = 3;
                    result.Msg = "密码长度不能小于6位！";
                }
            }
            else
            {
                result.Status = 2;
                result.Msg = "该邮箱格式错误！";
            }

            return Json(result);
        }

        [HttpPost]
        public ActionResult SignIn(string email, string password)
        {
            JsonResultItem result = new Models.JsonResultItem();
            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
            {
                using (AandQContext db = new AandQContext())
                {
                    var entity = db.Accounts.FirstOrDefault(d => d.Email == email && d.Password == password);
                    if (entity == null)
                    {
                        result.Status = 2;
                        result.Msg = "用户名或密码错误！";
                    }
                    else
                    {
                        this.HttpContext.Session[UserConfig.SESSION_NAME] = new UserInfo { UserName = entity.Email, Email = entity.Email };
                        result.Status = 0;
                        result.Msg = "登录成功！";
                    }
                }
            }
            else
            {
                result.Status = 1;
                result.Msg = "用户名或密码不能为空！";
            }
            return Json(result);
        }

        public ActionResult SignOut()
        {
            //JsonResultItem result = new Models.JsonResultItem();
            //this.HttpContext.Session[UserConfig.SESSION_NAME] = null;
            //return Json(result);
            this.HttpContext.Session[UserConfig.SESSION_NAME] = null;
            return Redirect("/");
        }

        [HttpPost]
        public ActionResult ExistEmail(string email)
        {
            JsonResultItem result = new Models.JsonResultItem();
            if (!string.IsNullOrWhiteSpace(email))
            {
                using (AandQContext db = new AandQContext())
                {
                    var entity = db.Accounts.FirstOrDefault(d => d.Email == email);
                    if (entity == null)
                    {
                        result.Status = 0;
                    }
                    else
                    {
                        result.Status = 1;
                    }
                }
            }
            else
            {
                result.Status = 2;
            }
            return Json(result);
        }
    }
}
