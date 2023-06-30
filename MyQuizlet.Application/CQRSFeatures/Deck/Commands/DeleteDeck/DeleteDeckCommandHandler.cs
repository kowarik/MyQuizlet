using MediatR;
using MyQuizlet.Application.Contracts.Repositories;
using MyQuizlet.Application.Exceptions;

namespace MyQuizlet.Application.CQRSFeatures.Deck.Commands.DeleteDeck
{
    public class DeleteDeckCommandHandler : IRequestHandler<DeleteDeckCommand, bool>
    {
        private readonly IDecksRepository _decksRepository;
        public DeleteDeckCommandHandler(IDecksRepository decksRepository)
        {
            _decksRepository = decksRepository;
        }
        public async Task<bool> Handle(DeleteDeckCommand request, CancellationToken cancellationToken)
        {
            var deckToDelete = await _decksRepository.GetByIdAsync(request.Id);

            if (deckToDelete == null)
                throw new NotFoundException(nameof(Deck), request);

            return await _decksRepository.DeleteAsync(deckToDelete);
        }
    }
}
