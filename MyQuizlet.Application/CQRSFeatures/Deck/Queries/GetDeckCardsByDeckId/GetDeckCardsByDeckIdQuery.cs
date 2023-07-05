using MediatR;

namespace MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetDeckCardsByDeckId
{
    public record GetDeckCardsByDeckIdQuery(Guid Id) : IRequest<GetDeckCardsByDeckIdDto>;
}
