namespace ForumSystem.Web.Infrastructure.Mapping
{
    using AutoMapper;
    using AutoMapper.Configuration;

    public interface IHaveCustomMappings
    {
        //void CreateMappings(IConfiguration configuration);
        void CreateMappings(IConfigurationProvider configuration);
        void CreateMappings(IMapperConfigurationExpression conf);
    }
}
