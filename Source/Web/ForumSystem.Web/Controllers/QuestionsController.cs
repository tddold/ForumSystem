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
            return Content("{POST");
        }
    }
}