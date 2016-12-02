﻿using AutoMapper;
using ForumSystem.Areas.Administration.ViewModels;
using ForumSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumSystem.App_Start.Mappings
{
    public class AdminThemeProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Theme, AdminThemeViewModel>().ReverseMap()
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(src => src.UpdatedOn))
                .ForMember(dest => dest.CategoryId, opt => opt.Ignore())
                .ForMember(dest => dest.AuthorId, opt => opt.Ignore())
                 .ForMember(dest => dest.Author, opt => opt.Ignore())
                 .ForMember(dest => dest.Comments, opt => opt.Ignore())
            ;
        }

    }
}