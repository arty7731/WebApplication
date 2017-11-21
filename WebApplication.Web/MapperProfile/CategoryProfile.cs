using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Core.DTO;
using WebApplication.Web.Models.Category;

namespace WebApplication.Web.MapperProfile
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            this.CreateMap<CategoryDto, ShortCategoryViewModel>();
            this.CreateMap<ShortCategoryViewModel, CategoryDto>();
        }
    }
}