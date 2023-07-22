using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyQuizlet.Application.CQRSFeatures.Card.Commands.CreateCard;
using MyQuizlet.Application.CQRSFeatures.Card.Commands.DeleteCard;
using MyQuizlet.Application.CQRSFeatures.Card.Commands.UpdateCard;
using MyQuizlet.Application.CQRSFeatures.Card.Queries.GetAllCards;
using MyQuizlet.Application.CQRSFeatures.Card.Queries.GetCardById;

namespace MyQuizlet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CardsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetAllCardsDto>>> GetAllCards()
        {
            //var cards = await _mediator.Send(new GetAllCardsQuery());
            //return cards;
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<GetCardByIdDto>> GetCardById(Guid id)
        {
            var card = await _mediator.Send(new GetCardByIdQuery(id));
            return card;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<bool>> CreateCard(CreateCardCommand card)
        {
            var result = await _mediator.Send(card);
            return result;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<bool>> UpdateCard(Guid id, UpdateCardCommand card)
        {
            if (id != card.Id)
                return BadRequest();
            var result = await _mediator.Send(card);
            return result;
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<bool>> DeleteCard(Guid id)
        {
            var result = await _mediator.Send(new DeleteCardCommand(id));
            return result;
        }
    }
}