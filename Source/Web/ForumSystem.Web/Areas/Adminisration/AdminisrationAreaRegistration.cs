using System.Web.Mvc;

namespace ForumSystem.Web.Areas.Adminisration
{
    public class AdminisrationAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Adminisration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.LowercaseUrls = true;

            context.MapRoute(
                "Adminisration_default",
                "Adminisration/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}