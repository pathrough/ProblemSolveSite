using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class JsonResultItem
    {
        //public JsonResultItem(string msg,int status) 
        //{
        //    this.Msg = msg;
        //    this.Status = status;
        //}
        public string Msg { get; set; }
        public int Status { get; set; }
    }

    public class JsonResultItem<T> : JsonResultItem
    {
        public T Data { get; set; }
    }
}