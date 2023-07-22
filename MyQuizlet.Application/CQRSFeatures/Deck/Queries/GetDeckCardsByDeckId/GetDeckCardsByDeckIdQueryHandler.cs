using AutoMapper;
using MediatR;
using MyQuizlet.Application.Contracts.Repositories;
using MyQuizlet.Application.CQRSFeatures.Card.Queries.GetAllCards;
using System.Reflection;

namespace MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetDeckCardsByDeckId
{
    public class GetDeckCardsByDeckIdQueryHandler : IRequestHandler<GetDeckCardsByDeckIdQuery, GetDeckCardsByDeckIdDto>
    {
        private readonly IMapper _mapper;
        private readonly IDecksRepository _decksRepository;
        public GetDeckCardsByDeckIdQueryHandler(IMapper mapper, IDecksRepository decksRepository)
        {
            _mapper = mapper;
            _decksRepository = decksRepository;
        }

        public async Task<GetDeckCardsByDeckIdDto> Handle(GetDeckCardsByDeckIdQuery request, CancellationToken cancellationToken)
        {
            var deckCards = await _decksRepository.GetDeckCardsByDeckIdAsync(request.Id);

            var deckCardsDto = _mapper.Map<GetDeckCardsByDeckIdDto>(deckCards);

            if (string.IsNullOrEmpty(request.SearchString) || request.SearchBy == null)
            {
                return deckCardsDto;
            }

            var propertyInfo = typeof(GetAllCardsDto).GetProperty(request.SearchBy, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            deckCardsDto.Cards = deckCardsDto.Cards?.Where(c => propertyInfo?.GetValue(c)?.ToString()?.ToLower().Contains(request.SearchString.Trim(), StringComparison.OrdinalIgnoreCase) == true).ToList();

            return deckCardsDto;
        }
    }
}
