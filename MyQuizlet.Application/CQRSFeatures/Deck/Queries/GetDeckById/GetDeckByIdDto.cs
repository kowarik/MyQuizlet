using MyQuizlet.Application.CQRSFeatures.Deck.Shared;

namespace MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetDeckById
{
    public class GetDeckByIdDto : BaseDeckDto
    {
        public Guid Id { get; init; }
    }
}
