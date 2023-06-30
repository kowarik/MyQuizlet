using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyQuizlet.Web.Controllers
{
    public class CardsController : Controller
    {
        private readonly IMediator _mediatR;

        public CardsController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        //[HttpGet]
        //public async Task<ActionResult<<List<Card>>>> GetAllCards()
        //{
        //    return await _mediator.Send(new GetAllPlayersQuery());
        //}
    }
}
