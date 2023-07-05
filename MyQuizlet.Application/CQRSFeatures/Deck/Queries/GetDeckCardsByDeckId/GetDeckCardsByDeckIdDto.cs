using MyQuizlet.Application.CQRSFeatures.Card.Queries.GetCardById;

namespace MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetDeckCardsByDeckId
{
    public class GetDeckCardsByDeckIdDto
    {
        public Guid Id { get; set; }
        public List<GetCardByIdDto>? Cards { get; set; }
    }
}
