using AutoMapper;
using MediatR;
using MyQuizlet.Application.Contracts.Repositories;

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

            return deckCardsDto;
        }
    }
}
