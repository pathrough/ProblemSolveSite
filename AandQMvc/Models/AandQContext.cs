using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class AandQContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Question> Questions { get; set; }  
        public AandQContext()
            : base("name=AandQContext")
        {

        }
    }
}