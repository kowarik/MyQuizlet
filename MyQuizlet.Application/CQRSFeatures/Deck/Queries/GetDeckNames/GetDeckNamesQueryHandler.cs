using AutoMapper;
using MediatR;
using MyQuizlet.Application.Contracts.Repositories;

namespace MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetDeckNames
{
    public class GetDeckNamesQueryHandler : IRequestHandler<GetDeckNamesQuery, List<GetDeckNamesDto>?>
    {
        private readonly IMapper _mapper;
        private readonly IDecksRepository _decksRepository;
        public GetDeckNamesQueryHandler(IMapper mapper, IDecksRepository decksRepository)
        {
            _mapper = mapper;
            _decksRepository = decksRepository;
        }
        public async Task<List<GetDeckNamesDto>?> Handle(GetDeckNamesQuery request, CancellationToken cancellationToken)
        {
            var decks = await _decksRepository.GetAllDecksByUserAsync();

            var deckNamesDto = _mapper.Map<List<GetDeckNamesDto>?>(decks);

            return deckNamesDto;
        }
    }
}
