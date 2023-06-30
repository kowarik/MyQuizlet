using AutoMapper;
using MediatR;
using MyQuizlet.Application.Contracts.Repositories;

namespace MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetDeckById
{
    public class GetDeckByIdQueryHandler : IRequestHandler<GetDeckByIdQuery, GetDeckByIdDto>
    {
        private readonly IMapper _mapper;
        private readonly IDecksRepository _decksRepository;
        public GetDeckByIdQueryHandler(IMapper mapper, IDecksRepository decksRepository)
        {
            _mapper = mapper;
            _decksRepository = decksRepository;
        }

        public async Task<GetDeckByIdDto> Handle(GetDeckByIdQuery request, CancellationToken cancellationToken)
        {
            var deck = await _decksRepository.GetByIdAsync(request.Id);

            var deckDto = _mapper.Map<GetDeckByIdDto>(deck);

            return deckDto;
        }
    }
}
