using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WebApplication.Core.Model;
using WebApplication.Core.DTO;
using WebApplication.Core.Enums;

namespace WebApplication.Business.MapperProfile
{
    public class ArticleProfile : AutoMapper.Profile
    {
        public ArticleProfile()
        {
            this.CreateMap<ArticleDto, Article>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(c => c.Author.Id))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(c => c.Image))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(c => c.Rating))
                .ForMember(dest => dest.Body, opt => opt.MapFrom(c => c.Body))
                .ForMember(dest => dest.CountRating, opt => opt.MapFrom(c => c.CountRating))
                .ForMember(dest => dest.CountView, opt => opt.MapFrom(c => c.CountView))
                .ForMember(dest => dest.Header, opt => opt.MapFrom(c => c.Header))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(c => c.CategoryId))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(c => (int)c.Status))
                ;


            this.CreateMap<Article, ArticleDto>()
             .ForMember(dest => dest.Author, opt => opt.Ignore())
             .ForMember(dest => dest.Image, opt => opt.MapFrom(c => c.Image))
             .ForMember(dest => dest.Rating, opt => opt.MapFrom(c => c.Rating))
             .ForMember(dest => dest.Body, opt => opt.MapFrom(c => c.Body))
             .ForMember(dest => dest.CountRating, opt => opt.MapFrom(c => c.CountRating))
             .ForMember(dest => dest.CountView, opt => opt.MapFrom(c => c.CountView))
             .ForMember(dest => dest.Status, opt => opt.MapFrom(c => (ArticleType)c.Status))
             .ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id))
             .ForMember(dest => dest.Header, opt => opt.MapFrom(c => c.Header))
             .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(c => c.CategoryId));

        }
    }
}
