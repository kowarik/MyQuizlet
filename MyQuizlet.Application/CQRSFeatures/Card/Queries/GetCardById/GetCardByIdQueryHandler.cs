using AutoMapper;
using MediatR;
using MyQuizlet.Application.Contracts.Repositories;

namespace MyQuizlet.Application.CQRSFeatures.Card.Queries.GetCardById
{
    public class GetCardByIdQueryHandler : IRequestHandler<GetCardByIdQuery, GetCardByIdDto>
    {
        private readonly IMapper _mapper;
        private readonly ICardsRepository _cardsRepository;
        public GetCardByIdQueryHandler(IMapper mapper, ICardsRepository cardsRepository)
        {
            _mapper = mapper;
            _cardsRepository = cardsRepository;
        }
        public async Task<GetCardByIdDto> Handle(GetCardByIdQuery request, CancellationToken cancellationToken)
        {
            var card = await _cardsRepository.GetCardByIdWithDeckAsync(request.Id);
            var cardDto = _mapper.Map<GetCardByIdDto>(card);

            return cardDto;
        }
    }
}
