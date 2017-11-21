using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Model;

namespace WebApplication.Core.Interfaces.Shared
{
    public interface IUnitOfWork
    {
        System.Data.Entity.DbContext db { get; set; }

        void Save();
    }
}
