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
            CreateMap<ApplicationUser, RegisterViewModel>().ReverseMap()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.UserRoles));
        }
    }
}