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
            RuleFor(p => p.Term)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.Definition)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(q => q.DeckId)
                .MustAsync(DeckIsExists)
                .WithMessage("Deck doesn`t exist");

            RuleFor(q => q)
                .MustAsync(CardTermUnique)
                .WithMessage("Card term already exists");

            _cardsRepository = cardsRepository;
            _decksRepository = decksRepository;
        }

        private async Task<bool> CardTermUnique(BaseCardDto command, CancellationToken token)
        {
            return await _cardsRepository.IsTermUniqueAsync(command.Term);
        }
        private async Task<bool> DeckIsExists(Guid? deckId, CancellationToken token)
        {
            var deck = await _decksRepository.GetByIdAsync(deckId);
            return deck != null;
        }
    }
}
