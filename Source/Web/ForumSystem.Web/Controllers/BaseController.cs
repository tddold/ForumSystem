namespace ForumSystem.Web.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;
    using ForumSystem.Common.Mapping;
    using Infrastructure.Mapping;

    public abstract class BaseController : Controller
    {
        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.MapperConfiguration.CreateMapper();
            }
        }
    }
}
