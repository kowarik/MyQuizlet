using MediatR;
using MyQuizlet.Application.CQRSFeatures.Card.Queries.GetAllCards;
using MyQuizlet.Application.Enums;

namespace MyQuizlet.Application.CQRSFeatures.Card.Queries.GetSortedCards
{
    public record GetSortedCardsQuery(List<GetAllCardsDto>? CardsList, string? SortBy, Sorting? SortingOrder) : IRequest<List<GetAllCardsDto>?>;
}
