using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Interfaces.Shared;
using WebApplication.Core.Model;

namespace WebApplication.Data.Repositories.Shared
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public System.Data.Entity.DbContext db { get; set; }

        public UnitOfWork()
        {
            db = new System.Data.Entity.DbContext("forumEntities");
            //db = new forumEntities();
        }

        public void Save()
        {
            var errors = db.GetValidationErrors();
            
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
