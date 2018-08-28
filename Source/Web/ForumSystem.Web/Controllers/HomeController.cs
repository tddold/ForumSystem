using ForumSystem.Data.Common.Repository;
using ForumSystem.Data.Models;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using ForumSystem.Web.ViewModels.Home;
using ForumSystem.Web.Infrastructure.Mapping;

namespace ForumSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Post> posts;

        public HomeController(IRepository<Post> posts)
        {
            this.posts = posts;
        }

     
       
       
        public ActionResult Index()
        {
            var posts = this.posts.All();
            //var allPosts = this.mappingService.MapCollection<IndexForumSystemPostViewModel>(posts);

            return View(posts);
        }
    }
}