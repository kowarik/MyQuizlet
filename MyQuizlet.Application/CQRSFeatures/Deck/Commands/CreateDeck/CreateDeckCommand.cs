using MediatR;
using MyQuizlet.Application.CQRSFeatures.Deck.Shared;

namespace MyQuizlet.Application.CQRSFeatures.Deck.Commands.CreateDeck
{
    public class CreateDeckCommand : BaseDeckDto, IRequest<bool>
    {
    }
}
