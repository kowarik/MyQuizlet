using FluentValidation;
using MyQuizlet.Application.Contracts.Repositories;

namespace MyQuizlet.Application.CQRSFeatures.Card.Shared
{
    public class BaseCardValidator : AbstractValidator<BaseCardDto>
    {
        private readonly ICardsRepository _cardsRepository;
        private readonly IDecksRepository _decksRepository;

        public BaseCardValidator(ICardsRepository cardsRepository, IDecksRepository decksRepository)
        {
            RuleFor(c => c.Term)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                //.MustAsync(CardTermUnique).WithMessage("Card term already exists")
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters")
                .Matches("^[A-Za-zА-яа-я .]*$").WithMessage("{PropertyName} must have only alphabet characters, spaces, dots and commas");

            RuleFor(c => c.Definition)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters")
                .Matches("^[A-Za-zА-яа-я .]*$").WithMessage("{PropertyName} must have only alphabet characters, spaces, dots and commas");

            RuleFor(c => c.EnglishLevel)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(c => c.DeckId)
                .MustAsync(DeckIsExists)
                .WithMessage("Deck doesn`t exist");                

            _cardsRepository = cardsRepository;
            _decksRepository = decksRepository;
        }

        //private async Task<bool> CardTermUnique(string term, CancellationToken token)
        //{
        //    return await _cardsRepository.IsTermUniqueAsync(term);
        //}
        private async Task<bool> DeckIsExists(Guid? deckId, CancellationToken token)
        {
            var deck = await _decksRepository.GetByIdAsync(deckId);
            return deck != null;
        }
    }
}
