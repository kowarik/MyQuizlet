using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MyQuizlet.Web.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("games")]
        public IActionResult GameManager()
        {
            return View();
        }

        [Route("manager")]
        public IActionResult CardsManager()
        {
            return View();
        }

        [Route("error")]
        public IActionResult Error()
        {
            IExceptionHandlerPathFeature? exHandler = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            if (exHandler != null && exHandler.Error != null)
            {
                ViewBag.ErrorMessage = exHandler.Error.Message;
            }
            return View();
        }
    }
}
