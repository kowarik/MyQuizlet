using AutoMapper;
using MediatR;
using MyQuizlet.Application.Contracts.Repositories;
using System.Reflection;

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

            var allUserDecksDto = _mapper.Map<List<GetAllDecksDto>?>(allUserDecks);

            if (string.IsNullOrEmpty(request.SearchString) || request.SearchBy == null)
            {
                return allUserDecksDto;
            }

            var propertyInfo = typeof(GetAllDecksDto).GetProperty(request.SearchBy, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            return allUserDecksDto?.Where(c => propertyInfo?.GetValue(c)?.ToString()?.ToLower().Contains(request.SearchString.Trim(), StringComparison.OrdinalIgnoreCase) == true).ToList();
        }
    }
}
