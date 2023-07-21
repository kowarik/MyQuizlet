using AutoMapper;
using MediatR;
using MyQuizlet.Application.Contracts.Repositories;
using MyQuizlet.Application.Enums;
using MyQuizlet.Application.Exceptions;

namespace MyQuizlet.Application.CQRSFeatures.Card.Queries.GetNextOrPreviousCard
{
    public class GetNextOrPreviousCardQueryHandler : IRequestHandler<GetNextOrPreviousCardQuery, GetNextOrPreviousCardDto>
    {
        private readonly IMapper _mapper;
        private readonly IDecksRepository _decksRepository;
        public GetNextOrPreviousCardQueryHandler(IMapper mapper, IDecksRepository decksRepository)
        {
            _mapper = mapper;
            _decksRepository = decksRepository;
        }
        public async Task<GetNextOrPreviousCardDto> Handle(GetNextOrPreviousCardQuery request, CancellationToken cancellationToken)
        {
            //get deck cards
            var deckCards = await _decksRepository.GetDeckCardsByDeckIdAsync(request.DeckId);

            if (deckCards?.Cards.Count == 0)
            {
                throw new NotFoundException(nameof(deckCards.Cards));
            }

            //sort cards by selected sorting
            var sortedCards = request.Sorting switch
            {
                Sorting.ASC => deckCards.Cards.OrderBy(c => c.Term).ToList(),
                Sorting.DESC => deckCards.Cards.OrderByDescending(c => c.Term).ToList(),
                Sorting.Random => deckCards.Cards.OrderBy(c =>
                {
                    Random random = new Random();
                    return random.Next();
                }).ToList(),
                _ => deckCards.Cards
            };

            //find current index
            var currentIndex = sortedCards.FindIndex(c => c.Id == request.CardId);

            //find coming index depending on the CardsPositionAction
            var comingIndex = request.PositionAction switch
            {
                PositionAction.Next => currentIndex + 1,
                PositionAction.Previous => currentIndex - 1,
                _ => currentIndex
            };

            //conditions if card index does not exist
            if (comingIndex >= sortedCards.Count)
                comingIndex = 0;
            if (comingIndex < 0)
                comingIndex = sortedCards.Count - 1;

            return _mapper.Map<GetNextOrPreviousCardDto>(sortedCards[comingIndex]);
        }
    }
}
