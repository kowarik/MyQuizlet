using MediatR;

namespace MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetDeckById
{
    public record GetDeckByIdQuery(Guid Id) : IRequest<GetDeckByIdDto>;
}
