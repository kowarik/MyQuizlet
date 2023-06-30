using AutoMapper;
using MediatR;
using MyQuizlet.Application.Contracts.Repositories;
using MyQuizlet.Application.Exceptions;

namespace MyQuizlet.Application.CQRSFeatures.Deck.Commands.CreateDeck
{
    public class CreateDeckCommandHandler : IRequestHandler<CreateDeckCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IDecksRepository _decksRepository;
        public CreateDeckCommandHandler(IMapper mapper, IDecksRepository decksRepository)
        {
            _mapper = mapper;
            _decksRepository = decksRepository;
        }
        public async Task<bool> Handle(CreateDeckCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateDeckCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Deck", validationResult);

            var deckToCreate = _mapper.Map<Domain.Entities.Deck>(request);
            return await _decksRepository.CreateAsync(deckToCreate);
        }
    }
}
