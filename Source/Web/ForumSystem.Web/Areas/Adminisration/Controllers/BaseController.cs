using ForumSystem.Data;
using ForumSystem.Data.Models;
using System.Web.Mvc;

namespace ForumSystem.Web.Areas.Adminisration.Controllers
{
    public abstract class BaseController : Controller
    {
        public BaseController(IForumSystemData data)
        {
            this.Data = data;
        }

        protected IForumSystemData Data { get; set; }

        protected ApplicationUser CurrentUser { get; set; }
    }
}