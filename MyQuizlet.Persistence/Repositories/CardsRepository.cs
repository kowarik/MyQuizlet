using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyQuizlet.Application.Contracts.Repositories;
using MyQuizlet.Domain.Entities;
using MyQuizlet.Persistence.DBContext;

namespace MyQuizlet.Persistence.Repositories
{
    public class CardsRepository : GenericRepository<Card>, ICardsRepository
    {
        public CardsRepository(MyQuizletDbContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
        {
        }

        public async Task<bool> IsTermUniqueByUserAsync(string term)
        {
            return await _dbSet.Where(c => c.Deck.ApplicationUserId == _userId).AnyAsync(c => c.Term == term) == false;
        }

        public async Task<Card?> GetCardByIdWithDeckAsync(Guid id)
        {
            return await _dbSet.AsNoTracking().Include(c => c.Deck).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Card>?> GetAllCardsByUserAsync()
        {
            return await _dbSet.Include(c => c.Deck).Where(d => d.Deck.ApplicationUserId == _userId).ToListAsync();
        }
    }
}
