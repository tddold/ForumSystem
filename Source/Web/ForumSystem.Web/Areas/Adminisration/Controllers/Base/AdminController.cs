using System.Web.Mvc;
using ForumSystem.Data;

namespace ForumSystem.Web.Areas.Adminisration.Controllers.Base
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