using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Core.Interfaces.Repostories
{
    public interface IBaseRepository<T> where T: class
    {
        DbSet<T> DbSet { get; }
        T Find(int Id);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Insert(T entity);
        void Delete(T entity);
    }
}
