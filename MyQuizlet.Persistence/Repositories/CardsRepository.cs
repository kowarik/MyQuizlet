using Microsoft.EntityFrameworkCore;
using MyQuizlet.Application.Contracts.Repositories;
using MyQuizlet.Domain.Entities;
using MyQuizlet.Persistence.DBContext;

namespace MyQuizlet.Persistence.Repositories
{
    public class CardsRepository : GenericRepository<Card>, ICardsRepository
    {
        public CardsRepository(MyQuizletDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsTermUniqueAsync(string term)
        {
            return await _dbSet.AnyAsync(c => c.Term == term) == false;
        }

        public async Task<Card?> GetCardByIdWithDeckAsync(Guid id)
        {
            return await _dbSet.AsNoTracking().Include(c => c.Deck).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
