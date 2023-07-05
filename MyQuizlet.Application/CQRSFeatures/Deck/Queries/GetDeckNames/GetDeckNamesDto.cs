namespace MyQuizlet.Application.CQRSFeatures.Deck.Queries.GetDeckNames
{
    public class GetDeckNamesDto
    {
        public Guid Id { get; init; }
        public string DeckName { get; init; } = string.Empty;
    }
}
