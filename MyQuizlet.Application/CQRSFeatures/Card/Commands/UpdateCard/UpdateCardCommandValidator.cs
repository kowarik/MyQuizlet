using FluentValidation;
using MyQuizlet.Application.Contracts.Repositories;
using MyQuizlet.Application.CQRSFeatures.Card.Shared;

namespace MyQuizlet.Application.CQRSFeatures.Card.Commands.UpdateCard
{
    public class UpdateCardCommandValidator : AbstractValidator<UpdateCardCommand>
    {
        private readonly IDecksRepository _decksRepository;
        private readonly ICardsRepository _cardsRepository;
        public UpdateCardCommandValidator(IDecksRepository decksRepository, ICardsRepository cardsRepository)
        {
            _decksRepository = decksRepository;
            _cardsRepository = cardsRepository;
            Include(new BaseCardValidator(_cardsRepository, _decksRepository));
        }
    }
}
