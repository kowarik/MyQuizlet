using MyQuizlet.Domain.Entities;

namespace MyQuizlet.Application.Contracts.Repositories
{
    public interface IDecksRepository : IGenericRepository<Deck>
    {
        Task<Deck?> GetDeckCardsByDeckIdAsync(Guid deckId);
        Task<List<Deck>?> GetAllDecksByUserAsync();
    }
}
