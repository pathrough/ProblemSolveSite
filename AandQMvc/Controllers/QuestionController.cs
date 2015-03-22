using AandQMvc.Models;
using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AandQMvc.Controllers
{
    public class QuestionController : BaseController
    {
        //
        // GET: /Question/

        public ActionResult List(long last,int count)
        {
            IEnumerable<Question> list;
            using (AandQContext db = new AandQContext())
            {
                list = db.Questions.Where(d => d.AccountID > last).Take(count).ToList();
            }
            return View(list);
        }

        public ActionResult Add(string question)
        {
            if (!string.IsNullOrWhiteSpace(question))
            {
                using (AandQContext db = new AandQContext())
                {
                    var entity = db.Questions.FirstOrDefault(d => d.Title == question);
                    if (entity == null)
                    {
                        entity = new Question();
                        entity.Title = question.Trim();
                        entity.AccountID = this.UserInfo.AccountID;
                    }
                    return Redirect("/Question/Mylist");
                }
            }
            else
            {
                return Content("问题不能为空！");
            }
        }
    }
}
