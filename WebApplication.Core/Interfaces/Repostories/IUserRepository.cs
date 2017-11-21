using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Model;

namespace WebApplication.Core.Interfaces.Repostories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetByEmail(string email, IEnumerable<Expression<Func<User, object>>> includePath = null);
        IEnumerable<User> GetAll(List<Expression<Func<User, object>>> includePath);
    }
}
