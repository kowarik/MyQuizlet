using FluentValidation;
using MyQuizlet.Application.CQRSFeatures.Deck.Shared;

namespace MyQuizlet.Application.CQRSFeatures.Deck.Commands.CreateDeck
{
    public class CreateDeckCommandValidator : AbstractValidator<CreateDeckCommand>
    {
        public CreateDeckCommandValidator()
        {
            Include(new BaseDeckValidator());
        }
    }
}
