using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyQuizlet.Application.Enums;

namespace MyQuizlet.Web.Controllers
{
    [Controller]
    [Authorize(Roles = nameof(UserRoles.Admin))]
    public class AdminController : Controller
    {
        [Route("/adminpanel")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
