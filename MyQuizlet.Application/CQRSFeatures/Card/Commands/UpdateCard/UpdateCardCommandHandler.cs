using AutoMapper;
using MediatR;
using MyQuizlet.Application.Contracts.Repositories;
using MyQuizlet.Application.Exceptions;

namespace MyQuizlet.Application.CQRSFeatures.Card.Commands.UpdateCard
{
    public class UpdateCardCommandHandler : IRequestHandler<UpdateCardCommand, bool>
    {   
        private readonly IMapper _mapper;
        private readonly ICardsRepository _cardsRepository;
        private readonly IDecksRepository _decksRepository;
        public UpdateCardCommandHandler(IMapper mapper, ICardsRepository cardsRepository, IDecksRepository decksRepository)
        {
            _mapper = mapper;
            _cardsRepository = cardsRepository;
            _decksRepository = decksRepository;
        }
        public async Task<bool> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCardCommandValidator(_decksRepository, _cardsRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Card", validationResult);

            var cardToUpdate = await _cardsRepository.GetByIdAsync(request.Id);
            if(cardToUpdate == null)
                throw new NotFoundException(nameof(Card), request.Id);

            _mapper.Map(request, cardToUpdate);
                
            return await _cardsRepository.UpdateAsync(cardToUpdate);
        }
    }
}
