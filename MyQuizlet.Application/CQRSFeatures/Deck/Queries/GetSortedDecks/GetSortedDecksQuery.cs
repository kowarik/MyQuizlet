using MediatR;
using MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetAllDecks;
using MyQuizlet.Application.Enums;

namespace MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetSortedDecks
{
    public record GetSortedDecksQuery(List<GetAllDecksDto>? DecksList, string? SortBy, Sorting? SortingOrder) : IRequest<List<GetAllDecksDto>?>;
}
