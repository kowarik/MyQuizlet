using MediatR;
using MyQuizlet.Application.CQRSFeatures.Card.Queries.GetAllCards;
using MyQuizlet.Application.Enums;
using System.Reflection;

namespace MyQuizlet.Application.CQRSFeatures.Card.Queries.GetSortedCards
{
    public class GetSortedCardsQueryHandler : IRequestHandler<GetSortedCardsQuery, List<GetAllCardsDto>?>
    {
        public async Task<List<GetAllCardsDto>?> Handle(GetSortedCardsQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.SortBy) || request.SortBy == null)
            {
                return request.CardsList;
            }

            var propertyInfo = typeof(GetAllCardsDto).GetProperty(request.SortBy, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            return request.SortingOrder switch
            {
                Sorting.ASC => request.CardsList?.OrderBy(c => propertyInfo?.GetValue(c)).ToList(),
                Sorting.DESC => request.CardsList?.OrderByDescending(c => propertyInfo?.GetValue(c)).ToList(),
                _ => request.CardsList,
            };
        }
    }
}
