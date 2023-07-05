using MyQuizlet.Application.CQRSFeatures.Card.Shared;
using MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetDeckById;

namespace MyQuizlet.Application.CQRSFeatures.Card.Queries.GetCardById
{
    public class GetCardByIdDto : BaseCardDto
    {
        public Guid Id { get; init; }
        public GetDeckByIdDto? Deck { get; init; }
    }
}
