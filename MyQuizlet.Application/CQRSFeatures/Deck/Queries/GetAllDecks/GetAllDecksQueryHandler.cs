﻿using AutoMapper;
using MediatR;
using MyQuizlet.Application.Contracts.Repositories;

namespace MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetAllDecks
{
    public class GetAllDecksQueryHandler : IRequestHandler<GetAllDecksQuery, List<GetAllDecksDto>?>
    {
        private readonly IMapper _mapper;
        private readonly IDecksRepository _decksRepository;
        public GetAllDecksQueryHandler(IMapper mapper, IDecksRepository decksRepository)
        {
            _mapper = mapper;
            _decksRepository = decksRepository;
        }
        public async Task<List<GetAllDecksDto>?> Handle(GetAllDecksQuery request, CancellationToken cancellationToken)
        {
            var allUserDecks = await _decksRepository.GetAllDecksByUserAsync();

            var allDecksDto = _mapper.Map<List<GetAllDecksDto>?>(allUserDecks);

            return allDecksDto;
        }
    }
}
