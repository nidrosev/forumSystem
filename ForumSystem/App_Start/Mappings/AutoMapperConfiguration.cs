using AutoMapper;
using ForumSystem.App_Start.Mappings;
using ForumSystem.Common.Mapping;
using ForumSystem.Models;
using ForumSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumSystem.App_Start
{
    public static class AutoMapperConfiguration
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new ThemeProfile());
            });


        }
         
    }
}
/* AutoMapper.Mapper.Initialize(config =>
 {
     config.CreateMap<Theme, ThemeViewModel>().ForMember(dest => dest.CreatedOn, opt=>opt.MapFrom(src=>src.CreatedOn));

 });*/
