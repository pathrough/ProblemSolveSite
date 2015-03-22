using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcApplication1.Models
{
    public class Question
    {
        [Key]
        public long QuestionID { get; set; }
        public string Title { get; set; }
        public long AccountID { get; set; }

    }

    public class Answer
    {
        [Key]
        public long AnserID { get; set; }
        public string Content { get; set; }
        public long QuestionID { get; set; }
        public long AccountID { get; set; }
    }

}