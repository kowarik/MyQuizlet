using AutoMapper;
using MediatR;
using MyQuizlet.Application.Contracts.Repositories;

namespace MyQuizlet.Application.CQRSFeatures.Card.Queries.GetAllCards
{
    public class GetAllCardsQueryHandler : IRequestHandler<GetAllCardsQuery, List<GetAllCardsDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICardsRepository _cardsRepository;
        public GetAllCardsQueryHandler(IMapper mapper, ICardsRepository cardsRepository)
        {
            _mapper = mapper;
            _cardsRepository = cardsRepository;
        }
        public async Task<List<GetAllCardsDto>> Handle(GetAllCardsQuery request, CancellationToken cancellationToken)
        {
            var allCards = await _cardsRepository.GetAllAsync();

            var allCardsDto = _mapper.Map<List<GetAllCardsDto>>(allCards);

            return allCardsDto;
        }
    }
}
