using MediatR;

namespace MyQuizlet.Application.CQRSFeatures.Card.Commands.DeleteCard
{
    public record DeleteCardCommand(Guid Id) : IRequest<bool>;
}
