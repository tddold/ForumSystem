using ForumSystem.Data.Common.Repository;
using ForumSystem.Data.Models;
using ForumSystem.Web.InputModels.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumSystem.Web.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IDeletableEntityRepository<Post> posts;

        public QuestionsController(IDeletableEntityRepository<Post> posts)
        {
            this.posts = posts;
        }
        // questions/32094525/morse-code-to-english-python3
        public ActionResult Display(int id, string url, int page = 1)
        {
            return Content($"id = {id} / url = {url}");
        }

        // questions/tagged/javascript
        public ActionResult GetByTag(string tag)
        {
            return Content($"tag = {tag}");
        }

        [HttpGet]
        public ActionResult Ask()
        {
            var model = new AskInputModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Ask(AskInputModel input)
        {
            if (ModelState.IsValid)
            {
                var post = new Post
                {
                    Title = input.Title,
                    Content = input.Content
                    // TODO Tags
                    // TODO Author
                };

                this.posts.Add(post);

                this.posts.SaveChanges();
                return this.RedirectToAction("Display", new { id = post.Id, url = "new" });
            }

            return this.View(input);
        }
    }
}