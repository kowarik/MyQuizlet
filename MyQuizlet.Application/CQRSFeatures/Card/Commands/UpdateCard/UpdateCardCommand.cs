using MediatR;
using MyQuizlet.Application.CQRSFeatures.Card.Shared;

namespace MyQuizlet.Application.CQRSFeatures.Card.Commands.UpdateCard
{
    public class UpdateCardCommand : BaseCardDto, IRequest<bool>
    {
        public Guid Id { get; init; }
    }
}
