using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WebApplication.Web.Models.User.Response;
using WebApplication.Core.DTO;
using WebApplication.Web.Models.Home.Request;
using WebApplication.Web.Models.Article.Request;
using WebApplication.Web.Models.Article.Response;
using WebApplication.Web.Models.Article;

namespace WebApplication.Web.MapperProfile
{
    public class ArticleProfile : AutoMapper.Profile
    {
        public ArticleProfile()
        {
            this.CreateMap<ArticleDto, ShortArticleRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(c => c.Image))
                .ForMember(dest => dest.ShortDescription, opt => opt.MapFrom(c => c.Body))
                .ForMember(dest => dest.Header, opt => opt.MapFrom(c => c.Header));

            this.CreateMap<ShortArticleViewModel, ArticleDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(dest => dest.Header, opt => opt.MapFrom(c => c.Header));

            this.CreateMap<ArticleDto, ShortArticleViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(c => c.Author.FullName))
                .ForMember(dest => dest.Header, opt => opt.MapFrom(c => c.Header));

            this.CreateMap<ArticleDto, ArticleRequest>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(c => c.Status));


            this.CreateMap<ArticleResponse, ArticleDto>();

            this.CreateMap<ArticleRequest, ArticleDto> ();

            this.CreateMap<ArticleDto, ArticleResponse>();
        }
    }
}