namespace MyQuizlet.Application.CQRSFeatures.Deck.Shared
{
    public abstract class BaseDeckDto
    {
        public string DeckName { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
    }
}
