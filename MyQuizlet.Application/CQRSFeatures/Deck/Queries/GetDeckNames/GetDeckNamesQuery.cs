using MediatR;

namespace MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetDeckNames
{
    public record GetDeckNamesQuery : IRequest<List<GetDeckNamesDto>?>;
}
