using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WebApplication.Web.Models.User.Response;
using WebApplication.Core.DTO;
using WebApplication.Web.Models.Admin;

namespace WebApplication.Web.MapperProfile
{
    public class UserProfile : AutoMapper.Profile
    {
        public UserProfile()
        {
            this.CreateMap<SignUpResponse, SignUpDto>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(c => c.Email))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(c => c.FullName))
                .ForMember(dest => dest.Nickname, opt => opt.MapFrom(c => c.Nickname))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(c => c.Password))
                .ForMember(dest => dest.SessionId, opt => opt.MapFrom(c => c.SessionId))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(c => c.RoleId));

            this.CreateMap<UserDto, UserModelView>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(c => c.Email))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(dest => dest.Nickname, opt => opt.MapFrom(c => c.Nickname))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(c => c.RoleID));

        }
    }
}