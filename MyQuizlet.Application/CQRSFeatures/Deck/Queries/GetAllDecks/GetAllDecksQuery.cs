using MediatR;

namespace MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetAllDecks
{
    public record GetAllDecksQuery(string? SearchBy, string? SearchString) : IRequest<List<GetAllDecksDto>?>;
}
