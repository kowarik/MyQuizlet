using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using MyQuizlet.Application.CQRSFeatures.Card.Queries.GetAllCards;
using MyQuizlet.Application.CQRSFeatures.Card.Queries.GetSortedCards;
using MyQuizlet.Application.CQRSFeatures.Deck.Commands.CreateDeck;
using MyQuizlet.Application.CQRSFeatures.Deck.Commands.DeleteDeck;
using MyQuizlet.Application.CQRSFeatures.Deck.Commands.UpdateDeck;
using MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetAllDecks;
using MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetDeckById;
using MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetDeckCardsByDeckId;
using MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetSortedDecks;
using MyQuizlet.Application.Enums;
using MyQuizlet.Domain.Entities;
using System.Globalization;

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
        public async Task<IActionResult> GetAllDecks(string? searchBy, string? searchString, string? sortBy, Sorting? sortOrder)
        {
            ViewBag.SearchByProps = new List<SelectListItem>
            {
                new SelectListItem { Text = "Deck Name", Value = nameof(GetAllDecksDto.DeckName) },
                new SelectListItem { Text = "Description", Value = nameof(GetAllDecksDto.Description) },
            };

            var decks = await _mediator.Send(new GetAllDecksQuery(searchBy, searchString));

            decks = await _mediator.Send(new GetSortedDecksQuery(decks, sortBy, sortOrder));

            ViewBag.CurrentSortOrder = sortOrder;
            ViewBag.CurrentSortBy = sortBy;
            ViewBag.CurrentSearchBy = searchBy;
            ViewBag.CurrentSearchString = searchString;

            return View(decks);
        }

        [HttpGet("getbyid/{id:guid}")]
        public async Task<IActionResult> GetDeckById(Guid id)
        {
            var deck = await _mediator.Send(new GetDeckByIdQuery(id));

            return View(deck);
        }

        [HttpGet("getcardsbyid/{id:guid}")]
        public async Task<IActionResult> GetDeckCards(Guid id, string? searchBy, string? searchString, string? sortBy, Sorting? sortOrder)
        {
            ViewBag.SearchByProps = new List<SelectListItem>
            {
                new SelectListItem { Text = "Term", Value = nameof(GetAllCardsDto.Term) },
                new SelectListItem { Text = "Definition", Value = nameof(GetAllCardsDto.Definition) },
                new SelectListItem { Text = "EnglishLevel", Value = nameof(GetAllCardsDto.EnglishLevel) },
            };
            var deckCards = await _mediator.Send(new GetDeckCardsByDeckIdQuery(id, searchBy, searchString));
            
            deckCards.Cards = await _mediator.Send(new GetSortedCardsQuery(deckCards.Cards, sortBy, sortOrder));

            ViewBag.CurrentSortOrder = sortOrder;
            ViewBag.CurrentSortBy = sortBy;
            ViewBag.CurrentSearchBy = searchBy;
            ViewBag.CurrentSearchString = searchString;

            return View(deckCards);
        }

        [HttpGet("create")]
        public IActionResult CreateDeck()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateDeck(CreateDeckCommand deck)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _mediator.Send(deck);

            if (result == false)
                return BadRequest();

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
                return View();

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
