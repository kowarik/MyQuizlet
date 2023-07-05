using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Deck>?> GetDeckNamesAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<Deck?> GetDeckCardsByDeckId(Guid deckId)
        {
            return await _dbSet.Include(d => d.Cards).FirstOrDefaultAsync(d => d.Id == deckId);
        }
    }
}
