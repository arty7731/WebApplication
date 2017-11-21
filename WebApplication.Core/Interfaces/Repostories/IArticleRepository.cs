using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.DTO;
using WebApplication.Core.Enums;
using WebApplication.Core.Model;

namespace WebApplication.Core.Interfaces.Repostories
{
    public interface IArticleRepository : IBaseRepository<Article>
    {
        Article Get(int id, IEnumerable<Expression<Func<Article, object>>> includePath = null);
        IEnumerable<Article> GetTopArticles(int countTop, List<Expression<Func<Article, object>>> includePath);
        IEnumerable<Article> GetArticlesByStatus(ArticleType status, List<Expression<Func<Article, object>>> includePath);
        IEnumerable<Article> GetArticlesByCategory(int categoryId, List<Expression<Func<Article, object>>> includePath);
    }
}
