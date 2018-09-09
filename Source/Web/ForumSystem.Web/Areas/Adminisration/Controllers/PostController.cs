using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForumSystem.Data;
using ForumSystem.Web.Areas.Adminisration.Controllers.Base;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using ForumSystem.Web.Areas.Adminisration.ViewModels.Posts;
using ForumSystem.Data.Models;
using ForumSystem.Web.Infrastructure;
using AutoMapper;

namespace ForumSystem.Web.Areas.Adminisration.Controllers
{
    public class PostController : AdminController
    {
        private readonly ISanitizer sanitizer;

        public PostController(IForumSystemData data, ISanitizer sanitizer)
            : base(data)
        {
            this.sanitizer = sanitizer;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var posts = this.Data
                .Posts
                .All()
                .ToDataSourceResult(request);

            return this.Json(posts);
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, PostViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {

                var dbModel = Mapper.Map<Post>(model);
                this.Data.Posts.Add(dbModel);
                this.Data.SaveChanges();
                model.Id = dbModel.Id;

                //var userId = this.Data.Users.GetById(Int32.Parse(model.UserId));

                //var post = new Post
                //{
                //    Title = model.Title,
                //    Content = sanitizer.Sanitize(model.Content),
                //    AuthorId = userId.ToString()
                //    // TODO Tags
                //};

                //this.Data.Posts.Add(post);

                //this.Data.SaveChanges();

            }

            return this.Json(new[] {model}.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, PostViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var post = this.Data.Posts.GetById(model.Id.Value);
                var userId = this.Data.Users.GetById(model.AuthorId);
                var dbModel = Mapper.Map(model, post);
                this.Data.SaveChanges();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }


        [HttpPost]
        public ActionResult Dastroy([DataSourceRequest]DataSourceRequest request, PostViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.Data.Posts.Delete(model.Id.Value);
                this.Data.SaveChanges();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}