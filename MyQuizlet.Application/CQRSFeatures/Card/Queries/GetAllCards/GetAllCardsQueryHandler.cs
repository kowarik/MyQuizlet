using AutoMapper;
using MediatR;
using MyQuizlet.Application.Contracts.Repositories;
using System.Reflection;

namespace MyQuizlet.Application.CQRSFeatures.Card.Queries.GetAllCards
{
    public class GetAllCardsQueryHandler : IRequestHandler<GetAllCardsQuery, List<GetAllCardsDto>?>
    {
        private readonly IMapper _mapper;
        private readonly ICardsRepository _cardsRepository;
        public GetAllCardsQueryHandler(IMapper mapper, ICardsRepository cardsRepository)
        {
            _mapper = mapper;
            _cardsRepository = cardsRepository;
        }
        public async Task<List<GetAllCardsDto>?> Handle(GetAllCardsQuery request, CancellationToken cancellationToken)
        {
            var allUserCards = await _cardsRepository.GetAllCardsByUserAsync();

            var allUserCardsDto = _mapper.Map<List<GetAllCardsDto>?>(allUserCards);

            if (string.IsNullOrEmpty(request.SearchString) || request.SearchBy == null)
            {
                return allUserCardsDto;
            }

            var propertyInfo = typeof(GetAllCardsDto).GetProperty(request.SearchBy, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            return allUserCardsDto?.Where(c => propertyInfo?.GetValue(c)?.ToString()?.ToLower().Contains(request.SearchString.Trim(), StringComparison.OrdinalIgnoreCase) == true).ToList();
        }
    }
}
