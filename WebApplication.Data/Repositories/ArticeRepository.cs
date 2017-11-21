using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.DTO;
using WebApplication.Core.Enums;
using WebApplication.Core.Interfaces.Repostories;
using WebApplication.Core.Interfaces.Shared;
using WebApplication.Core.Model;

namespace WebApplication.Data.Repositories
{
    public class ArticeRepository : BaseRepository<Article>, IArticleRepository
    {
        public ArticeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public Article Get(int id, IEnumerable<Expression<Func<Article, object>>> includePath = null)
        {
            var query = this.DbSet.AsQueryable();

            if (includePath != null)
            {
                query = includePath.Aggregate(query, (entity, entityExpression) => entity.Include<Article, object>(entityExpression));
            }

            return query.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Article> GetArticlesByCategory(int categoryId, List<Expression<Func<Article, object>>> includePath)
        {
            var query = this.DbSet.AsQueryable();

            if (includePath != null)
            {
                query = includePath.Aggregate(query, (entity, entityExpression) => entity.Include<Article, object>(entityExpression));
            }

            return query.Where(u => u.CategoryId == categoryId && u.Status == (int)ArticleType.Comlete)
                .OrderBy(u => u.Header)
                .ToArray();
        }

        public IEnumerable<Article> GetArticlesByStatus(ArticleType status, List<Expression<Func<Article, object>>> includePath)
        {
            var query = this.DbSet.AsQueryable();

            if (includePath != null)
            {
                query = includePath.Aggregate(query, (entity, entityExpression) => entity.Include<Article, object>(entityExpression));
            }

            return query.Where(u => u.Status == (int)status)
                .OrderBy(u => u.Header)
                .ToArray();
        }

        public IEnumerable<Article> GetTopArticles(int countTop, List<Expression<Func<Article, object>>> includePath)
        {
            var query = this.DbSet.AsQueryable();

            if (includePath != null)
            {
                query = includePath.Aggregate(query, (entity, entityExpression) => entity.Include<Article, object>(entityExpression));
            }

            return query.Where(u => u.Status == (int)ArticleType.Comlete)
                .OrderBy(u => u.Rating).Take(countTop)
                .ToArray();
        }
    }
}
