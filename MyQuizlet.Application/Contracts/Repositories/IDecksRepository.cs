using MyQuizlet.Domain.Entities;

namespace MyQuizlet.Application.Contracts.Repositories
{
    public interface IDecksRepository : IGenericRepository<Deck>
    {
        Task<Deck?> GetDeckCardsByDeckId(Guid deckId);
        Task<List<Deck>?> GetDeckNamesAsync();
    }
}
