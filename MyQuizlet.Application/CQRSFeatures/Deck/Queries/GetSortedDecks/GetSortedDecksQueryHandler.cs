using MediatR;
using MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetAllDecks;
using MyQuizlet.Application.Enums;
using System.Reflection;

namespace MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetSortedDecks
{
    public class GetSortedDecksQueryHandler : IRequestHandler<GetSortedDecksQuery, List<GetAllDecksDto>?>
    {
        public async Task<List<GetAllDecksDto>?> Handle(GetSortedDecksQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.SortBy) || request.SortBy == null)
            {
                return request.DecksList;
            }

            var propertyInfo = typeof(GetAllDecksDto).GetProperty(request.SortBy, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            return request.SortingOrder switch
            {
                Sorting.ASC => request.DecksList?.OrderBy(c => propertyInfo?.GetValue(c)).ToList(),
                Sorting.DESC => request.DecksList?.OrderByDescending(c => propertyInfo?.GetValue(c)).ToList(),
                _ => request.DecksList,
            };
        }
    }
}
