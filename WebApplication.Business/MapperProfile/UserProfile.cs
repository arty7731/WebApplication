using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WebApplication.Core.Model;
using WebApplication.Core.DTO;

namespace WebApplication.Business.MapperProfile
{
    public class UserProfile : AutoMapper.Profile
    {
        public UserProfile()
        {
            this.CreateMap<User, UserDto>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(c => c.Email))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(c => c.Profile.FullName))
                .ForMember(dest => dest.Nickname, opt => opt.MapFrom(c => c.Profile.Nickname))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(dest => dest.RoleID, opt => opt.MapFrom(c => c.RoleId));
        }
    }
}
