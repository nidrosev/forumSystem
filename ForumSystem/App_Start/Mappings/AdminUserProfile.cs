using AutoMapper;
using ForumSystem.Areas.Administration.ViewModels;
using ForumSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumSystem.App_Start.Mappings
{
    public class AdminUserProfile:Profile
    {
        protected override void Configure()
        {
            CreateMap<ApplicationUser, UserModifyViewModel>()
                .ForMember(dest => dest.UserRoles, opt => opt.MapFrom(src => src.Roles))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));
        }
    }
}