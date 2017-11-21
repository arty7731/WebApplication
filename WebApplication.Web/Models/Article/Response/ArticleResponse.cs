using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Core.DTO;
using WebApplication.Core.Enums;

namespace WebApplication.Web.Models.Article.Response
{
    public class ArticleResponse
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public float Rating { get; set; }
        public int CountRating { get; set; }
        public int CountView { get; set; }
        public string Image { get; set; }
        public UserDto Author { get; set; }
        public ArticleType Status { get; set; }
        public int CategoryId { get; set; }
        public HttpPostedFileBase Logo { get; set; }
    }
}