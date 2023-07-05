using AutoMapper;
using MediatR;
using MyQuizlet.Application.Contracts.Repositories;
using MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetAllDecks;

namespace MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetDeckNames
{
    public class GetDeckNamesQueryHandler : IRequestHandler<GetDeckNamesQuery, List<GetDeckNamesDto>>
    {
        private readonly IMapper _mapper;
        private readonly IDecksRepository _decksRepository;
        public GetDeckNamesQueryHandler(IMapper mapper, IDecksRepository decksRepository)
        {
            _mapper = mapper;
            _decksRepository = decksRepository;
        }
        public async Task<List<GetDeckNamesDto>> Handle(GetDeckNamesQuery request, CancellationToken cancellationToken)
        {
            var deckNames = await _decksRepository.GetDeckNamesAsync();

            var deckNamesDto = _mapper.Map<List<GetDeckNamesDto>>(deckNames);

            return deckNamesDto;
        }
    }
}
