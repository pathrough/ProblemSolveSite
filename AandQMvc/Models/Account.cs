using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcApplication1.Models
{
    public class Account
    {
        [Key]
        public long AccountID { get; set; }
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "请输入正确的电子邮箱地址！")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}