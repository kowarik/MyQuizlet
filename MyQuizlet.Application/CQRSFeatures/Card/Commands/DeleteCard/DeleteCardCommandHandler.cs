using MediatR;
using MyQuizlet.Application.Contracts.Repositories;
using MyQuizlet.Application.Exceptions;

namespace MyQuizlet.Application.CQRSFeatures.Card.Commands.DeleteCard
{
    public class DeleteCardCommandHandler : IRequestHandler<DeleteCardCommand, bool>
    {
        private readonly ICardsRepository _cardsRepository;
        public DeleteCardCommandHandler(ICardsRepository cardsRepository)
        {
            _cardsRepository = cardsRepository;
        }
        public async Task<bool> Handle(DeleteCardCommand request, CancellationToken cancellationToken)
        {
            var cardToDelete = await _cardsRepository.GetByIdAsync(request.Id);

            if (cardToDelete == null)
                throw new NotFoundException(nameof(Card), request);

            return await _cardsRepository.DeleteAsync(cardToDelete);
        }
    }
}
