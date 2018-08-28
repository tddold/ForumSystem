using ForumSystem.Data.Common.Repository;
using ForumSystem.Data.Models;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using ForumSystem.Web.ViewModels.Home;
using AutoMapper;
using Ninject.Infrastructure.Language;
using System.Linq;
using ForumSystem.Web.Infrastructure.Mapping;
using System.Reflection;
using ForumSystem.Web.Infrastructure.Mapping.Contracts;
using System;
using System.Data.Entity.Infrastructure;
using AutoMapper.Configuration.Conventions;

namespace ForumSystem.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IRepository<Post> posts;
        //private readonly IMappingService mappingService;

        //public HomeController(IRepository<Post> posts, IMappingService mappingService)
        public HomeController(IRepository<Post> posts)
        {
            //if (mappingService == null)
            //{
            //    throw new ArgumentNullException(nameof(mappingService));
            //}

            this.posts = posts;
            //this.mappingService = mappingService;

        }

     
       
       
        public ActionResult Index()
        {
            var posts = this.posts.All();
            //var allPosts = this.mappingService.MapCollection<IndexForumSystemPostViewModel>(posts);

            return View(posts);
        }
    }
}