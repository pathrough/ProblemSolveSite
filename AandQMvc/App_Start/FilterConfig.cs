using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace AandQMvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ExceptionFilter());
        }
    }

    public class ExceptionFilter:IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            //var ex = filterContext.Exception;
            
            //var realPath = filterContext.HttpContext.Server.MapPath("/App_Data");
            //string fileName = Path.Combine(realPath,"errorLog" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
            //if (File.Exists(fileName) == false)
            //{
            //    using (File.CreateText(fileName)) { } 
            //}
            //File.AppendAllLines(fileName, new string[] { ex.ToString(),"","","" });
            //filterContext.ExceptionHandled = true;
            //filterContext.HttpContext.Response.Write(ex.ToString());
        }
    }

    public enum UserType
    {
        Common,
        Admin
    }

    public class UserAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        public UserAuthorizeAttribute(UserType userType)
        {

        }
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var userInfo = filterContext.HttpContext.Session[UserConfig.SESSION_NAME];
            if (userInfo == null)
            {
                filterContext.Result = new HttpUnauthorizedResult(); //返回未授权Result 
                //跳转到登录页面 
                filterContext.HttpContext.Response.Redirect("/Account/Register");
            }
        }
    }
    public class UserConfig
    {
        public const string SESSION_NAME = "userInfo";
    }
}