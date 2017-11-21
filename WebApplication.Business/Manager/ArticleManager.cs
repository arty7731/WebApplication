using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.DTO;
using WebApplication.Core.Enums;
using WebApplication.Core.Interfaces.Business;
using WebApplication.Core.Interfaces.Repostories;
using WebApplication.Core.Interfaces.Shared;
using WebApplication.Core.Model;

namespace WebApplication.Business.Manager
{
    public class ArticleManager : ManagerBase, IArticleManager
    {
        private readonly IMapper mapper;
        private readonly IArticleRepository articleRepository;
        private readonly IUnitOfWork unitOfWork;

        public ArticleManager(IMapper mapper,
            IArticleRepository articleRepository,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.articleRepository = articleRepository;
            this.unitOfWork = unitOfWork;
        }

        public ArticleDto GetArticleById(int Id)
        {
            Article article = this.articleRepository.Get(Id,
                new List<Expression<Func<Article, object>>>
                {
                    a => a.User,
                    a => a.User.Profile,
                    a => a.Category
                });

            ArticleDto result = this.mapper.Map<Article, ArticleDto>(article);

            result.Author = this.mapper.Map<User, UserDto>(article.User);

            return result;            
        }

        public IEnumerable<ArticleDto> GetTopArticles(int countTop)
        {
             IEnumerable<Article> articles = this.articleRepository.GetTopArticles(countTop,
                new List<Expression<Func<Article, object>>>
                {
                    a => a.User,
                    a => a.User.Profile,
                    a => a.Category
                });

            return this.mapper.Map<IEnumerable<Article>, IEnumerable<ArticleDto>>(articles);
        }

        public IEnumerable<ArticleDto> GetArticlesByStatus(ArticleType status)
        {
            IEnumerable<Article> articles = this.articleRepository.GetArticlesByStatus(status,
               new List<Expression<Func<Article, object>>>
               {
                    a => a.User,
                    a => a.User.Profile,
                    a => a.Category
               });

            return this.mapper.Map<IEnumerable<Article>, IEnumerable<ArticleDto>>(articles);
        }

        public int Create(ArticleDto article)
        {
            Article newArticle = this.mapper.Map<ArticleDto, Article>(article);
            newArticle.Status = (int)ArticleType.Sandbox;
            this.articleRepository.Insert(newArticle);
            this.unitOfWork.Save();
            return newArticle.Id;
        }

        public int UpdateContent(int userId, int articleId, string header, string body, ArticleType status)
        {
            Article article = this.articleRepository.Find(articleId);

            if(article.Author.Value != userId)
            {
                //throw new NotImplementedException();
            }

            article.Header = header;
            article.Body = body;
            article.Status = (int)status;
            this.articleRepository.Update(article);
            this.unitOfWork.Save();
            return article.Id;
        }


        public void Delete(int id)
        {
            Article article = this.articleRepository.Find(id);
            if(article != null)
            {
                this.articleRepository.Delete(article);
                this.unitOfWork.Save();
            }
        }

        public void ChangeArticleStatus(int articleId, ArticleType status)
        {
            Article article = this.articleRepository.Find(articleId);

            article.Status = (int)status;
            this.articleRepository.Update(article);
            this.unitOfWork.Save();
        }

        public IEnumerable<ArticleDto> GetArticlesByCategory(int categoryId)
        {
            IEnumerable<Article> articles = this.articleRepository.GetArticlesByCategory(categoryId,
               new List<Expression<Func<Article, object>>>
               {
                                a => a.User,
                                a => a.User.Profile,
                                a => a.Category
               });

            return this.mapper.Map<IEnumerable<Article>, IEnumerable<ArticleDto>>(articles);
        }
    }
}
