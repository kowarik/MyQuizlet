using MediatR;

namespace MyQuizlet.Application.CQRSFeatures.Card.Queries.GetAllCards
{
    public record GetAllCardsQuery : IRequest<List<GetAllCardsDto>?>;
}
