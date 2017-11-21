using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.DTO;
using WebApplication.Core.Model;

namespace WebApplication.Business.MapperProfile
{
    public class CategoryProfile
    {
        public class ArticleProfile : AutoMapper.Profile
        {
            public ArticleProfile()
            {
                this.CreateMap<Category, CategoryDto>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id))
                    .ForMember(dest => dest.CategoryParent, opt => opt.MapFrom(c => c.CategoryParent))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.Name));
            }
        }
    }
}
