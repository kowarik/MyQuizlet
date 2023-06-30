using AutoMapper;
using MediatR;
using MyQuizlet.Application.Contracts.Repositories;
using MyQuizlet.Application.Exceptions;

namespace MyQuizlet.Application.CQRSFeatures.Card.Commands.CreateCard
{
    public class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly ICardsRepository _cardsRepository;
        private readonly IDecksRepository _decksRepository;
        public CreateCardCommandHandler(IMapper mapper, ICardsRepository cardsRepository, IDecksRepository decksRepository)
        {
            _mapper = mapper;
            _cardsRepository = cardsRepository;
            _decksRepository = decksRepository;
        }
        public async Task<bool> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCardCommandValidator(_decksRepository, _cardsRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Card", validationResult);

            var cardToCreate = _mapper.Map<Domain.Entities.Card>(request);
            return await _cardsRepository.CreateAsync(cardToCreate);
        }
    }
}
