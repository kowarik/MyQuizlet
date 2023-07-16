using Microsoft.AspNetCore.Mvc;

namespace MyQuizlet.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
