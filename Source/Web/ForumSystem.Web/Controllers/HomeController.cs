using ForumSystem.Data.Common.Repository;
using ForumSystem.Data.Models;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using ForumSystem.Web.ViewModels.Home;
using ForumSystem.Web.Infrastructure.Mapping;
using ForumSystem.Web.Infrastructure.Mapping.Contracts;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;

namespace ForumSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Post> posts;
        //private IMappingService mappingService;
        //private readonly IMapper mapper;

        public HomeController(IRepository<Post> posts)
        {
            this.posts = posts;
            //this.mapper = mapper;
            //this.mappingService = mappingService;
        }

     
       
       
        public ActionResult Index()
        {
            var postsAll = this.posts.All().ToArray();
            //var testPost = this.posts.All().Where(p => p.Title != null).Single();
            //var test = this.mapper.Map<Post, IndexForumSystemPostViewModel>(testPost);
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