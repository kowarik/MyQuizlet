using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyQuizlet.Application.CQRSFeatures.Deck.Commands.CreateDeck;
using MyQuizlet.Application.CQRSFeatures.Deck.Commands.DeleteDeck;
using MyQuizlet.Application.CQRSFeatures.Deck.Commands.UpdateDeck;
using MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetAllDecks;
using MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetDeckById;
using MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetDeckCardsByDeckId;

namespace MyQuizlet.Web.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class DecksController : Controller
    {
        private readonly IMediator _mediator;

        public DecksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllDecks()
        {
            var decks = await _mediator.Send(new GetAllDecksQuery());

            return View(decks);
        }

        [HttpGet("getbyid/{id:guid}")]
        public async Task<IActionResult> GetDeckById(Guid id)
        {
            var deck = await _mediator.Send(new GetDeckByIdQuery(id));

            return View(deck);
        }

        [HttpGet("getcardsbyid/{id:guid}")]
        public async Task<IActionResult> GetDeckCards(Guid id)
        {
            var deckCards = await _mediator.Send(new GetDeckCardsByDeckIdQuery(id));
            return View(deckCards);
        }

        [HttpGet("create")]
        public async Task<IActionResult> CreateDeck()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateDeck(CreateDeckCommand deck)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n", ModelState.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage));

                return BadRequest(errors);
            }

            var result = await _mediator.Send(deck);

            if (result == false)
                return View();

            return RedirectToAction("GetAllDecks");
        }

        [HttpGet("update/{id:guid}")]
        public async Task<IActionResult> UpdateDeck(Guid id)
        {
            var deck = await _mediator.Send(new GetDeckByIdQuery(id));
            ViewBag.Deck = deck;

            return View();
        }

        [HttpPost("update/{id:guid}")]
        public async Task<IActionResult> UpdateDeck(Guid id, UpdateDeckCommand deck)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n", ModelState.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage));
                return BadRequest(errors);
            }

            var result = await _mediator.Send(deck);

            if (result == false)
            {
                ViewBag.Deck = deck;
                return View();
            }
            return RedirectToAction("GetAllDecks");
        }

        [HttpGet("delete/{id:guid}")]
        public async Task<IActionResult> DeleteDeck(Guid id)
        {
            var deck = await _mediator.Send(new GetDeckByIdQuery(id));
            return View(deck);
        }

        [ActionName("DeleteDeck")]
        [HttpPost("delete/{id:guid}")]
        public async Task<IActionResult> DeleteDeckConfirmed(Guid id)
        {
            var result = await _mediator.Send(new DeleteDeckCommand(id));

            if (result == false)
            {
                var deck = await _mediator.Send(new GetDeckByIdQuery(id));
                return View(deck);
            }

            return RedirectToAction("GetAllDecks");
        }
    }
}
