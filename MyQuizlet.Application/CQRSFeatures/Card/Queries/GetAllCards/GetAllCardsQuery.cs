using MediatR;

namespace MyQuizlet.Application.CQRSFeatures.Card.Queries.GetAllCards
{
    public record GetAllCardsQuery(string? SearchBy, string? SearchString) : IRequest<List<GetAllCardsDto>?>;
}
