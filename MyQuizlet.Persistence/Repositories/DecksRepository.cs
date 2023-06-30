using MyQuizlet.Application.Contracts.Repositories;
using MyQuizlet.Domain.Entities;
using MyQuizlet.Persistence.DBContext;

namespace MyQuizlet.Persistence.Repositories
{
    public class DecksRepository : GenericRepository<Deck>, IDecksRepository
    {
        public DecksRepository(MyQuizletDbContext dbContext) : base(dbContext)
        {
        }

        //public async Task<List<Deck>?> GetDeckCardsByDeckId(Guid deckId)
        //{
        //    return _dbSet.Include(c => c.Cards).ToList();
        //}
    }
}
