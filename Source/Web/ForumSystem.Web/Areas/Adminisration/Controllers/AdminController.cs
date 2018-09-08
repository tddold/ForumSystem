using System.Web.Mvc;
using ForumSystem.Data;

namespace ForumSystem.Web.Areas.Adminisration.Controllers
{
    // [Authorize(Roles = "Admin")]
    public abstract class AdminController : BaseController
    {
        public AdminController(IForumSystemData data)
            : base(data)
        {
        }
    }
}