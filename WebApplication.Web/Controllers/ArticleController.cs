using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Core.DTO;
using WebApplication.Core.Enums;
using WebApplication.Core.Interfaces.Business;
using WebApplication.Web.Attributes;
using WebApplication.Web.Models.Article;
using WebApplication.Web.Models.Article.Request;
using WebApplication.Web.Models.Article.Response;

namespace WebApplication.Web.Controllers
{
    [ValidateInput(false), RoutePrefix("/article")]
    //[WebAuthorize]
    public class ArticleController : Controller
    {
        IMapper mapper;
        private readonly IArticleManager articleManager;
        private readonly ICommentManager commentManager;
        private readonly ICategoryManager categoryManager;
        private readonly IFileManager fileManager;

        public ArticleController(IMapper mapper,
            IArticleManager articleManager,
            ICommentManager commentManager,
            ICategoryManager categoryManager,
            IFileManager fileManager)
        {
            this.mapper = mapper;
            this.articleManager = articleManager;
            this.commentManager = commentManager;
            this.fileManager = fileManager;
            this.categoryManager = categoryManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewArticlesByCategory(int categoryId)
        {
            IEnumerable<ArticleDto> articles = this.articleManager.GetArticlesByCategory(categoryId);

            IEnumerable<ShortArticleViewModel> viewModel = this.mapper.Map<IEnumerable<ArticleDto>, IEnumerable<ShortArticleViewModel>>(articles);

            return View(viewModel);
        }

        public ActionResult ViewSandbox()
        {
            IEnumerable<ArticleDto> articles = this.articleManager.GetArticlesByStatus(ArticleType.Sandbox);

            IEnumerable<ShortArticleViewModel> result = this.mapper.Map< IEnumerable<ArticleDto>, IEnumerable<ShortArticleViewModel>>(articles);

            return View(result);
        }

        public ActionResult ViewTopArticles()
        {
            IEnumerable<ArticleDto> articles = this.articleManager.GetTopArticles(100);

            IEnumerable<ShortArticleViewModel> viewModel = this.mapper.Map<IEnumerable<ArticleDto>, IEnumerable<ShortArticleViewModel>>(articles);

            return View(viewModel);
        }

        [Route("{Id:int}")]
        public ActionResult ViewArticle(int Id)
        {
            ArticleDto article = this.articleManager.GetArticleById(Id);

            ArticleRequest request = this.mapper.Map<ArticleDto, ArticleRequest>(article);

            return View(request);
        }

        public ActionResult Verified(int id)
        {
            this.articleManager.ChangeArticleStatus(id, ArticleType.Comlete);

            ArticleDto article = this.articleManager.GetArticleById(id);

            ArticleRequest request = this.mapper.Map<ArticleDto, ArticleRequest>(article);

            return View("ViewArticle", request);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ArticleResponse article = new ArticleResponse();

            IEnumerable<CategoryDto> categories = this.categoryManager.GetAll();

            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            return View(article);
        }

        [HttpPost]
        public ActionResult Create(ArticleResponse article)
        {
            ActionResult result = null;
            ArticleDto newArticle = this.mapper.Map<ArticleResponse, ArticleDto>(article);

            newArticle.Author = new UserDto { Id = UserMng.Current.Id };

            int articleId = this.articleManager.Create(newArticle);

            if(articleId > 0)
            {
                HttpPostedFileBase file = article.Logo;

                if (file != null)
                {
                    this.fileManager.SaveImage(file.InputStream,
                        "image.png",
                        Server.MapPath($@"\Articles\{articleId}\"));
                }
                result = RedirectToAction("ViewArticle", new { Id = articleId});
            }
            else
            {
                ViewBag.ErrorMessage = "";
                result = View(article);
            }

            return result;
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ArticleDto article = this.articleManager.GetArticleById(id);

            ArticleResponse response = this.mapper.Map<ArticleDto, ArticleResponse>(article);

            return View(response);
        }

        [HttpPost]
        public ActionResult Edit(ArticleResponse article)
        {
            ActionResult result = null;

            int articleId = this.articleManager.UpdateContent(UserMng.Current.Id,
                article.Id,
                article.Header,
                article.Body,
                ArticleType.Sandbox);

            if (articleId > 0)
            {
                result = RedirectToAction("ViewArticle", new { Id = articleId });
            }
            else
            {
                ViewBag.ErrorMessage = "";
                result = View(article);
            }

            return result;
        }

        [Route("comments/{page:int}/{itemPerPage:int}")]
        public ActionResult ViewComment(int page, int itemPerPage)
        {


            return PartialView();
        }

        [HttpPost]
        public ActionResult AddComment(CommentResponse comment)
        {

            return PartialView();
        }

        [HttpPost]
        public ActionResult SaveImage(int id)
        {
            HttpPostedFileBase file = Request.Files[Request.Files.Keys[0]];

            if(file != null)
            {
                this.fileManager.SaveImage(file.InputStream,
                    "image.png",
                    Server.MapPath($@"\Articles\{id}\"));
            }

            return Json(new { Message = "Saved!" });
        }
    }
}