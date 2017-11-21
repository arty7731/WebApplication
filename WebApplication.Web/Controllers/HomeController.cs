using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Business.Manager;
using WebApplication.Core.DTO;
using WebApplication.Core.Interfaces.Business;
using WebApplication.Web.Models.Home.Request;

namespace WebApplication.Web.Controllers
{
    public class HomeController : Controller
    {
        IArticleManager articleManager;
        IMapper mapper;

        public HomeController(IArticleManager articleManager,
            IMapper mapper)
        {
            this.articleManager = articleManager;
            this.mapper = mapper;
        }

        public ActionResult Index()
        {
            int countTop = 10;

            IEnumerable<ArticleDto> articles = this.articleManager.GetTopArticles(countTop);

            IEnumerable<ShortArticleRequest> request = this.mapper.Map<IEnumerable<ArticleDto>, IEnumerable<ShortArticleRequest>>(articles);

            return View(request);
        }
    }
}