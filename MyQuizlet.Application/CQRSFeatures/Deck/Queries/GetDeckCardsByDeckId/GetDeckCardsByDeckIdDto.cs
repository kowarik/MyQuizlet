using MyQuizlet.Application.CQRSFeatures.Card.Queries.GetAllCards;

namespace MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetDeckCardsByDeckId
{
    public class GetDeckCardsByDeckIdDto
    {
        public Guid Id { get; set; }
        public List<GetAllCardsDto>? Cards { get; set; }
    }
}
