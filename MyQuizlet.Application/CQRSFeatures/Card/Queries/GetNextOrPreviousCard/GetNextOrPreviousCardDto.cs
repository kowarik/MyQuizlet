using MyQuizlet.Application.CQRSFeatures.Card.Shared;

namespace MyQuizlet.Application.CQRSFeatures.Card.Queries.GetNextOrPreviousCard
{
    public class GetNextOrPreviousCardDto : BaseCardDto
    {
        public Guid Id { get; set; }
    }
}
