using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MvcApplication1.Models
{
    public static class Utility
    {
        public static bool IsEmail(this string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }
            else
            {
                return (Regex.IsMatch(email, @"^\w+@[a-zA-Z_]+?\.\w{2,5}$"));
            }
        }
    }
}