using AutoMapper;
using ForumSystem.Common.Mapping;
using ForumSystem.Data.Models;

namespace ForumSystem.Web.ViewModels.Home
{
    public class IndexForumSystemPostViewModel: IMapFrom<Post>
    {
        public string Title { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Post, IndexForumSystemPostViewModel>()
                .IncludeBase<Post, IndexForumSystemPostViewModel>();
        }
    }
}