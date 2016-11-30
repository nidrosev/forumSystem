namespace ForumSystem.Common.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using AutoMapper;
    using Mapping;

    public class AutoMapperConfig
    {
        public static MapperConfiguration Configuration
        {
            get;
            private set;
        }

        public static void RegisterMappings()
        {
            Configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap(typeof(IMapFrom<>), typeof(IMapTo<>)).ReverseMap();
            });
        }
    }
}
