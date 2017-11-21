using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Web.Models.Article
{
    public class ShortArticleViewModel
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Author { get; set; }
    }
}