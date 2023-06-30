using MediatR;
using MyQuizlet.Application.CQRSFeatures.Card.Shared;

namespace MyQuizlet.Application.CQRSFeatures.Card.Commands.CreateCard
{
    public class CreateCardCommand : BaseCardDto, IRequest<bool>
    {
    }
}
