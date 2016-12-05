using AutoMapper;
using ForumSystem.Models;
using ForumSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumSystem.App_Start.Mappings
{
    public class CommentProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Comment, CommentViewModel>().ReverseMap()
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(src => src.UpdatedOn))
                .ForMember(dest => dest.ThemeId, opt => opt.MapFrom(src => src.ThemeId))
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId));
        }
    }
}