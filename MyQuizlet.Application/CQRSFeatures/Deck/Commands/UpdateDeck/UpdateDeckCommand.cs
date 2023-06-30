using MediatR;
using MyQuizlet.Application.CQRSFeatures.Deck.Shared;

namespace MyQuizlet.Application.CQRSFeatures.Deck.Commands.UpdateDeck
{
    public class UpdateDeckCommand : BaseDeckDto, IRequest<bool>
    {
        public Guid Id { get; init; }
    }
}
