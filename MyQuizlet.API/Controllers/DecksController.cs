using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyQuizlet.Application.CQRSFeatures.Deck.Commands.CreateDeck;
using MyQuizlet.Application.CQRSFeatures.Deck.Commands.DeleteDeck;
using MyQuizlet.Application.CQRSFeatures.Deck.Commands.UpdateDeck;
using MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetAllDecks;
using MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetDeckById;

namespace MyQuizlet.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class DecksController : ControllerBase
	{
		private readonly IMediator _mediator;

		public DecksController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<List<GetAllDecksDto>>> GetAllDecks()
		{
			//var decks = await _mediator.Send(new GetAllDecksQuery());
			//return decks;
			throw new NotImplementedException();
		}

		[HttpGet("{id}")]
		[ProducesResponseType(200)]
		public async Task<ActionResult<GetDeckByIdDto>> GetDeckById(Guid id)
		{
			var deck = await _mediator.Send(new GetDeckByIdQuery(id));
			return deck;
		}

		[HttpPost]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		public async Task<ActionResult<bool>> CreateDeck(CreateDeckCommand deck)
		{
			var result = await _mediator.Send(deck);
			return result;
		}

		[HttpPut("{id}")]
		[ProducesResponseType(200)]
		public async Task<ActionResult<bool>> UpdateDeck(Guid id, UpdateDeckCommand deck)
		{
			if (id != deck.Id)
				return BadRequest();
			var result = await _mediator.Send(deck);
			return result;
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<bool>> DeleteDeck(Guid id)
		{
			var result = await _mediator.Send(new DeleteDeckCommand(id));
			return result;
		}
	}
}
