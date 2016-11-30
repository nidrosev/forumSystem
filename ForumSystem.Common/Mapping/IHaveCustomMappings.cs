namespace ForumSystem.Common.Mapping
{
    using AutoMapper;

    public interface IHaveCustomMappings
    {
        void CreateMappings(MapperConfiguration configuration);
    }
}
