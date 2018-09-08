using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForumSystem.Data;
using ForumSystem.Web.Areas.Adminisration.Controllers.Base;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace ForumSystem.Web.Areas.Adminisration.Controllers
{
    public class PostController : AdminController
    {
        public PostController(IForumSystemData data)
            : base(data)
        {
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
    }
}