using ForumSystem.Data.Common.Repository;
using ForumSystem.Data.Models;
using ForumSystem.Web.InputModels.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForumSystem.Web.ViewModels.Questions;
using ForumSystem.Web.Infrastructure;
using Microsoft.AspNet.Identity;

namespace ForumSystem.Web.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IDeletableEntityRepository<Post> posts;
        private readonly ISanitizer sanitizer;

        public QuestionsController(IDeletableEntityRepository<Post> posts, ISanitizer sanitizer)
        {
            this.posts = posts;
            this.sanitizer = sanitizer;
        }
        // questions/32094525/morse-code-to-english-python3
        public ActionResult Display(int id, string url, int page = 1)
        {
            var postViewModel = this.posts.All()
                .Where(x => x.Id == id)
                .Select(p => new QuestionDisplayViewModel
                {
                    Title = p.Title,
                    Contet = p.Content
                })
                .FirstOrDefault();

            if (postViewModel == null)
            {
                return this.HttpNotFound("No suck post");
            }

            //var viewModel = new QuestionDisplayViewModel()
            //{
            //    Title = "",
            //    Contet = ""
            //};

            return View(postViewModel);
        }

        // questions/tagged/javascript
        public ActionResult GetByTag(string tag)
        {
            return Content($"tag = {tag}");
        }

        [HttpGet]
        [Authorize]
        public ActionResult Ask()
        {
            var model = new AskInputModel();
            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Ask(AskInputModel input)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();

                var post = new Post
                {
                    Title = input.Title,
                    Content = sanitizer.Sanitize(input.Content),
                    AuthorId = userId
                    // TODO Tags
                };

                this.posts.Add(post);

                this.posts.SaveChanges();
                return this.RedirectToAction("Display", new { id = post.Id, url = "new" });
            }

            return this.View(input);
        }
    }
}