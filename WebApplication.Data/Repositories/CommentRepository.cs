using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Interfaces.Repostories;
using WebApplication.Core.Interfaces.Shared;
using WebApplication.Core.Model;

namespace WebApplication.Data.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
