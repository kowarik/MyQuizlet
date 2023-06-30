using FluentValidation;
using MyQuizlet.Application.CQRSFeatures.Deck.Shared;

namespace MyQuizlet.Application.CQRSFeatures.Deck.Commands.UpdateDeck
{
    public class UpdateDeckCommandValidator : AbstractValidator<UpdateDeckCommand>
    {
        public UpdateDeckCommandValidator()
        {
            Include(new BaseDeckValidator());
        }
    }
}
