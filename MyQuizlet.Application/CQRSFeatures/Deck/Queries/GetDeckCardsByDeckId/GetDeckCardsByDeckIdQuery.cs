using MediatR;

namespace MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetDeckCardsByDeckId
{
    public record GetDeckCardsByDeckIdQuery(Guid Id, string? SearchBy, string? SearchString) : IRequest<GetDeckCardsByDeckIdDto>;
}
