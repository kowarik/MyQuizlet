namespace MyQuizlet.Application.CQRSFeatures.Card.Shared
{
    public abstract class BaseCardDto
    {
        public string Term { get; init; } = string.Empty;
        public string Definition { get; init; } = string.Empty;
        public string EnglishLevel { get; init; } = string.Empty;

        public Guid? DeckId { get; init; }
    }
}
