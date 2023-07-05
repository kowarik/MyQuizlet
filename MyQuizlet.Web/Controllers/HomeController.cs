using Microsoft.AspNetCore.Mvc;

namespace MyQuizlet.Web.Controllers
{
	[Controller]
    public class HomeController : Controller
	{
		[Route("/")]
		public IActionResult Index()
		{
			return View();
		}

        [Route("games")]
        public IActionResult ChooseGame()
        {
            //1 - choose deck
            //2 - choose how to play (cards/memorization/test/selection of terms)
            //3 - choose cards (all/only selected)
            //4 - choose game detail (в алфавитном порядке / рандом / ...)

            return View();
        }

        [Route("manager")]
        public IActionResult CardsManager()
        {
            return View();
        }
    }
}
