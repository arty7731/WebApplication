using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.DTO;

namespace WebApplication.Core.Interfaces.Business
{
    public interface ICategoryManager
    {
        IEnumerable<CategoryDto> GetAll();
    }
}
