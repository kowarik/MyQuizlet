using MediatR;

namespace MyQuizlet.Application.CQRSFeatures.Card.Queries.GetCardById
{
    public record GetCardByIdQuery(Guid Id) : IRequest<GetCardByIdDto>;
}
