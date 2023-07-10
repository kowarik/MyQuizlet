using MyQuizlet.Application.Enums;

namespace MyQuizlet.Web.ViewModel
{
    public class GetCardByOptionsViewModel
    {
        public Sorting Sorting { get; set; } = Sorting.ASC;
        public PositionAction PositionAction { get; set; } = PositionAction.Next;
        public Guid DeckId { get; set; }
        public Guid CardId { get; set; } = Guid.Empty;
    }
}
