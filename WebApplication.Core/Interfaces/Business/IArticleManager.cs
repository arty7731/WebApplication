using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.DTO;
using WebApplication.Core.Enums;

namespace WebApplication.Core.Interfaces.Business
{
    public interface IArticleManager
    {
        IEnumerable<ArticleDto> GetTopArticles(int countTop);
        ArticleDto GetArticleById(int Id);
        IEnumerable<ArticleDto> GetArticlesByStatus(ArticleType status);
        IEnumerable<ArticleDto> GetArticlesByCategory(int categoryId);
        void ChangeArticleStatus(int articleId, ArticleType status);
        int Create(ArticleDto article);
        int UpdateContent(int userId, int articleId, string header, string body, ArticleType status);
        void Delete(int id);

    }
}
