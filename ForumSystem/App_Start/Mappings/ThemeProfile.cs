using AutoMapper;
using ForumSystem.Models;
using ForumSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumSystem.App_Start.Mappings
{
    public class ThemeProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Theme, ThemeViewModel>()
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(src => src.UpdatedOn));
        }

    }
}