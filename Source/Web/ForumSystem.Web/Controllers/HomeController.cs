using ForumSystem.Data.Repository;
using ForumSystem.Data.Models;
using System.Web.Mvc;
using ForumSystem.Web.ViewModels.Home;
using System.Linq;
using System.Collections.Generic;
using ForumSystem.Web.Areas.Adminisration.Controllers;
using ForumSystem.Data;

namespace ForumSystem.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IForumSystemData posts;
        //private IMappingService mappingService;
        //private readonly IMapper mapper;

        public HomeController(IForumSystemData posts)
            : base(posts)
        {
            this.posts = posts;
            //this.mapper = mapper;
            //this.mappingService = mappingService;
        }


        public ActionResult Index()
        {
            //this.posts.ActualDelete(this.posts.GetById(5));
            //this.posts.SaveChanges();

            var postsAll = this.posts.Posts.All().ToArray();
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