using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Web.Models.Home.Request
{
    public class ShortArticleRequest
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Image { get; set; }
        public string ShortDescription { get; set; }
    }
}