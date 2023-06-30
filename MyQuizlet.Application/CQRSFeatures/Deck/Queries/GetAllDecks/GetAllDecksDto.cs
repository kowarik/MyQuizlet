using MyQuizlet.Application.CQRSFeatures.Deck.Shared;

namespace MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetAllDecks
{
    public class GetAllDecksDto : BaseDeckDto
    {
        public Guid Id { get; init; }
    }
}
