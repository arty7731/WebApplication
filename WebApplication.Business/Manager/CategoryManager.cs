using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.DTO;
using WebApplication.Core.Interfaces.Business;
using WebApplication.Core.Interfaces.Repostories;
using WebApplication.Core.Interfaces.Shared;
using WebApplication.Core.Model;

namespace WebApplication.Business.Manager
{
    public class CategoryManager : ManagerBase, ICategoryManager
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CategoryManager(ICategoryRepository categoryRepository, 
            IUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            IEnumerable<Category> categories = this.categoryRepository.GetAll();
            IEnumerable<CategoryDto> result = this.mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(categories);

            return result;
        }
    }
}
