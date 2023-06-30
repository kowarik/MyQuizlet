using MyQuizlet.Domain.Entities;

namespace MyQuizlet.Application.Contracts.Repositories
{
    public interface IDecksRepository : IGenericRepository<Deck>
    {
        //Task<List<Deck>?> GetDeckCardsByDeckId(Guid deckId);
    }
}
