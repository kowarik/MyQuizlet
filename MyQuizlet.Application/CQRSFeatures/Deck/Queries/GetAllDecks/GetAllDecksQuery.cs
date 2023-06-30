using MediatR;

namespace MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetAllDecks
{
    public record GetAllDecksQuery : IRequest<List<GetAllDecksDto>>;
}
