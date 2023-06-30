using FluentValidation;
using MyQuizlet.Application.Contracts.Repositories;
using MyQuizlet.Application.CQRSFeatures.Card.Shared;

namespace MyQuizlet.Application.CQRSFeatures.Card.Commands.CreateCard
{
    public class CreateCardCommandValidator : AbstractValidator<CreateCardCommand>
    {
        private readonly IDecksRepository _decksRepository;
        private readonly ICardsRepository _cardsRepository;
        public CreateCardCommandValidator(IDecksRepository decksRepository, ICardsRepository cardsRepository)
        {
            _decksRepository = decksRepository;
            _cardsRepository = cardsRepository;
            Include(new BaseCardValidator(_cardsRepository, _decksRepository));
        }
    }
}
