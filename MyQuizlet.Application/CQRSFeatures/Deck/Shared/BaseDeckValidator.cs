using FluentValidation;

namespace MyQuizlet.Application.CQRSFeatures.Deck.Shared
{
    public class BaseDeckValidator : AbstractValidator<BaseDeckDto>
    {
        public BaseDeckValidator()
        {
            RuleFor(p => p.DeckName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");
        }
    }
}
