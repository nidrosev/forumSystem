using AutoMapper;
using ForumSystem.Areas.Administration.ViewModels;
using ForumSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumSystem.App_Start.Mappings
{
    public class AdminUserProfileReverse : Profile
    {
        protected override void Configure()
        {
            CreateMap<ApplicationUser, UserModifyViewModel>().ReverseMap()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.UserRoles))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));
        }
    }
}