using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Model;
using WebApplication.Core.Interfaces.Shared;
using WebApplication.Data.Repositories.Shared;
using WebApplication.Core.Interfaces.Repostories;

namespace WebApplication.Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T: class 
    {
        private readonly DbContext db;
        public readonly IUnitOfWork unitOfWork;



        public DbSet<T> DbSet { get { return db.Set(typeof(T)).Cast<T>(); } }

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            db = unitOfWork.db;
        }

        public void Delete(T entity)
        {
            this.unitOfWork.db.Entry(entity).State = EntityState.Deleted;
        }

        public T Find(int Id)
        {
            return this.unitOfWork.db.Set(typeof(T)).Cast<T>().Find(Id);
        }

        public IEnumerable<T> GetAll()
        {
            return this.unitOfWork.db.Set(typeof(T)).Cast<T>().ToArray();
        }

        public void Insert(T entity)
        {
            var entitySet = this.unitOfWork.db.Set(entity.GetType());
            entitySet.Add(entity);
        }

        public void Update(T entity)
        {
            this.unitOfWork.db.Entry(entity).State = EntityState.Modified;
        }

    }
}
