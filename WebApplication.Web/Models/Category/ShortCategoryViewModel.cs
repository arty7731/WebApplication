using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Web.Models.Category
{
    public class ShortCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryParent { get; set; }
    }
}