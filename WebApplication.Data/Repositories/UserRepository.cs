using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Interfaces.Repostories;
using WebApplication.Core.Interfaces.Shared;
using WebApplication.Core.Model;

namespace WebApplication.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork uow) 
            : base(uow)
        {
        }

        public IEnumerable<User> GetAll(List<Expression<Func<User, object>>> includePath)
        {
            var query = this.DbSet.AsQueryable();

            if (includePath != null)
            {
                query = includePath.Aggregate(query, (entity, entityExpression) => entity.Include<User, object>(entityExpression));
            }

            return query.ToArray();
        }

        public User GetByEmail(string email, IEnumerable<Expression<Func<User, object>>> includePath = null)
        {
            var query = this.DbSet.AsQueryable();

            if (includePath != null)
            {
                query = includePath.Aggregate(query, (entity, entityExpression) => entity.Include<User, object>(entityExpression));
            }

            return query.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
        }
    }
}
