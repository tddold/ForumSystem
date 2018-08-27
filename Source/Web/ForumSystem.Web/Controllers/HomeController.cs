using ForumSystem.Data;
using ForumSystem.Data.Common.Repository;
using ForumSystem.Data.Models;
using System.Web.Mvc;

namespace ForumSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Post> posts;

        // Poor man's DI
        public HomeController()
            : this(new GenericRepository<Post>(new ApplicationDbContext()))
        {

        }

        public HomeController(IRepository<Post> posts)
        {
            this.posts = posts;
        }
        public ActionResult Index()
        {
            var posts = this.posts.All();

            return View(posts);
        }
    }
}