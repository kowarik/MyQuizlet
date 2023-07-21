namespace MyQuizlet.Application.CQRSFeatures.Deck.Shared
{
    public abstract class BaseDeckDto
    {
        public string? DeckName { get; init; }
        public string? Description { get; init; }
    }
}
