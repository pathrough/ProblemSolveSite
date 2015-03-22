using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AandQMvc.Models
{
    public abstract class BaseController : Controller
    {
        public BaseController()
        {
            _UserInfo = this.HttpContext.Session[UserConfig.SESSION_NAME] as UserInfo;
        }
        readonly UserInfo _UserInfo;
        protected UserInfo UserInfo
        {
            get 
            {
                return _UserInfo; 
            }
        } 

    }
}