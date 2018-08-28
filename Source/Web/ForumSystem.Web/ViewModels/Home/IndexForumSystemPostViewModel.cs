using AutoMapper;
using ForumSystem.Data.Models;
using ForumSystem.Web.Infrastructure.Mapping;

namespace ForumSystem.Web.ViewModels.Home
{
    public class IndexForumSystemPostViewModel: IMapFrom<Post>
    {
        public string Title { get; set; }

        //public void CreateMappings(IMapperConfigurationExpression configuration)
        //{
        //    configuration.CreateMap<Post, IndexForumSystemPostViewModel>()
        //        .IncludeBase<Post, IndexForumSystemPostViewModel>();
        //}
    }
}