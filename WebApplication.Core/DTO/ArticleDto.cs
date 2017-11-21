using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Enums;

namespace WebApplication.Core.DTO
{
    public class ArticleDto
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public float Rating { get; set; }
        public int CountRating { get; set; }
        public int CountView { get; set; }
        public string Image { get; set; }
        public UserDto Author { get; set; }
        public ArticleType Status { get; set; }
        public CategoryDto Category { get; set; }
        public int CategoryId { get; set; }
        public int Id { get; set; }
    }
}
