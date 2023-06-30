using MediatR;

namespace MyQuizlet.Application.CQRSFeatures.Card.Queries.IsTermUnique
{
    public record IsTermUniqueQuery(string Term) : IRequest<bool>;
}
