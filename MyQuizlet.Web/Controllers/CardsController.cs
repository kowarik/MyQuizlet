using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyQuizlet.Application.CQRSFeatures.Card.Commands.CreateCard;
using MyQuizlet.Application.CQRSFeatures.Card.Commands.DeleteCard;
using MyQuizlet.Application.CQRSFeatures.Card.Commands.UpdateCard;
using MyQuizlet.Application.CQRSFeatures.Card.Queries.GetAllCards;
using MyQuizlet.Application.CQRSFeatures.Card.Queries.GetCardById;
using MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetDeckNames;

namespace MyQuizlet.Web.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class CardsController : Controller
    {
        private readonly IMediator _mediator;

        public CardsController(IMediator mediatR)
        {
            _mediator = mediatR;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllCards()
        {
            var cards = await _mediator.Send(new GetAllCardsQuery());

            return View(cards);
        }

        [HttpGet("getbyid/{id:guid}")]
        public async Task<IActionResult> GetCardById(Guid id)
        {
            var card = await _mediator.Send(new GetCardByIdQuery(id));
            
            return View(card);
        }

        [HttpGet("create")]
        public async Task<IActionResult> CreateCard()
        {
            var decks = await _mediator.Send(new GetDeckNamesQuery());
            ViewBag.Decks = new SelectList(decks, "Id", "DeckName");
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCard(CreateCardCommand card)
        {
            if (!ModelState.IsValid)
            {
                var decks = await _mediator.Send(new GetDeckNamesQuery());
                ViewBag.Decks = new SelectList(decks, "Id", "DeckName");

                return View();
            }

            var result = await _mediator.Send(card);

            if (result == false)
                return BadRequest(ModelState);

            return RedirectToAction("GetAllCards");
        }

        [HttpGet("update/{id:guid}")]
        public async Task<IActionResult> UpdateCard(Guid id)
        {
            var card = await _mediator.Send(new GetCardByIdQuery(id));
            ViewBag.Card = card;

            var decks = await _mediator.Send(new GetDeckNamesQuery());
            ViewBag.Decks = new SelectList(decks, "Id", "DeckName");

            return View();
        }

        [HttpPost("update/{id:guid}")]
        public async Task<IActionResult> UpdateCard(Guid id, UpdateCardCommand card)
        {
            //TODO попробовать добавить [FromBody], чтобы Id не добавлялось в URL
            if (!ModelState.IsValid)
                return View();

            var result = await _mediator.Send(card);

            if (result == false)
            {
                ViewBag.Card = card;

                var decks = await _mediator.Send(new GetDeckNamesQuery());
                ViewBag.Decks = new SelectList(decks, "Id", "DeckName");
                return View();
            }

            return RedirectToAction("GetAllCards");
        }

        [HttpGet("delete/{id:guid}")]
        public async Task<IActionResult> DeleteCard(Guid id)
        {
            var card = await _mediator.Send(new GetCardByIdQuery(id));

            return View(card);
        }

        [ActionName("DeleteCard")]
        [HttpPost("delete/{id:guid}")]
        public async Task<IActionResult> DeleteCardConfirmed(Guid id)
        {
            var result = await _mediator.Send(new DeleteCardCommand(id));

            if (result == false)
                return View();

            return RedirectToAction("GetAllCards");
        }
    }
}
