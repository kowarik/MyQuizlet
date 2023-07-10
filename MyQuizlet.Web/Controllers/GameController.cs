using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyQuizlet.Application.CQRSFeatures.Card.Queries.GetNextOrPreviousCard;
using MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetDeckNames;
using MyQuizlet.Web.ViewModel;

namespace MyQuizlet.Web.Controllers
{
    [Controller]
    [Route("games")]
    public class GameController : Controller
    {
        private readonly IMediator _mediator;
        public GameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("choosegamedetails")]
        public async Task<IActionResult> ChooseGameDetails()
        {
            var deckNames = await _mediator.Send(new GetDeckNamesQuery());
            ViewBag.DeckNames = new SelectList(deckNames, "Id", "DeckName");
            var gameOptionsVM = new GetCardByOptionsViewModel();

            return View(gameOptionsVM);
        }

        [HttpGet("play")]
        public async Task<IActionResult> PlayGame(GetCardByOptionsViewModel getCardVM)
        {
            var card = await _mediator.Send(new GetNextOrPreviousCardQuery(getCardVM.Sorting, getCardVM.PositionAction, getCardVM.DeckId, getCardVM.CardId));
            getCardVM.CardId = card.Id;
            ViewBag.Card = card;
            return View(getCardVM);
        }
    }
}
