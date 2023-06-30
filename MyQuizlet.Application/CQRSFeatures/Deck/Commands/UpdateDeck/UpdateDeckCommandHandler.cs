using AutoMapper;
using MediatR;
using MyQuizlet.Application.Contracts.Repositories;
using MyQuizlet.Application.Exceptions;

namespace MyQuizlet.Application.CQRSFeatures.Deck.Commands.UpdateDeck
{
    public class UpdateDeckCommandHandler : IRequestHandler<UpdateDeckCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IDecksRepository _decksRepository;
        public UpdateDeckCommandHandler(IMapper mapper, IDecksRepository decksRepository)
        {
            _mapper = mapper;
            _decksRepository = decksRepository;
        }
        public async Task<bool> Handle(UpdateDeckCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDeckCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Deck", validationResult);

            var deckToUpdate = await _decksRepository.GetByIdAsync(request.Id);
            if (deckToUpdate == null)
                throw new NotFoundException(nameof(Deck), request.Id);

            _mapper.Map(request, deckToUpdate);

            return await _decksRepository.UpdateAsync(deckToUpdate);
        }
    }
}
