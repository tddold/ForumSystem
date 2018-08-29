using ForumSystem.Data.Common.Repository;
using ForumSystem.Data.Models;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using ForumSystem.Web.ViewModels.Home;
using ForumSystem.Web.Infrastructure.Mapping;
using ForumSystem.Web.Infrastructure.Mapping.Contracts;
using System.Linq;
using System.Collections.Generic;

namespace ForumSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Post> posts;
        //private IMappingService mappingService;

        public HomeController(IRepository<Post> posts)
        {
            this.posts = posts;
            //this.mappingService = mappingService;
        }

     
       
       
        public ActionResult Index()
        {
            var postsAll = this.posts.All().ToArray();
            //var allPosts = this.mappingService.MapCollection<IndexForumSystemPostViewModel>(posts);


            List<IndexForumSystemPostViewModel> viewPosts = new List<IndexForumSystemPostViewModel>();
            foreach (var item in postsAll)
            {
                var viewPostTitle = new IndexForumSystemPostViewModel()
                {
                    Title = item.Title
                };

                viewPosts.Add(viewPostTitle);
            }

            



            return View(viewPosts);
        }
    }
}