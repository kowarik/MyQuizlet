using MyQuizlet.Application.CQRSFeatures.Card.Shared;

namespace MyQuizlet.Application.CQRSFeatures.Card.Queries.GetAllCards
{
    public class GetAllCardsDto : BaseCardDto
    {
        public Guid Id { get; init; }
    }
}
