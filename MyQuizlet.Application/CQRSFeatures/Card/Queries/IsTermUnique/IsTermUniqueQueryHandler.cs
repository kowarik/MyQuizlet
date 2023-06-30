using MediatR;
using MyQuizlet.Application.Contracts.Repositories;

namespace MyQuizlet.Application.CQRSFeatures.Card.Queries.IsTermUnique
{
    public class IsTermUniqueQueryHandler : IRequestHandler<IsTermUniqueQuery, bool>
    {
        private readonly ICardsRepository _cardsRepository;
        public IsTermUniqueQueryHandler(ICardsRepository cardsRepository)
        {
            _cardsRepository = cardsRepository;
        }
        public async Task<bool> Handle(IsTermUniqueQuery request, CancellationToken cancellationToken)
        {
            var isUnique = await _cardsRepository.IsTermUniqueAsync(request.Term);

            return isUnique;
        }
    }
}
