using MediatR;

namespace MyQuizlet.Application.CQRSFeatures.Deck.Commands.DeleteDeck
{
    public record DeleteDeckCommand(Guid Id) : IRequest<bool>;
}
