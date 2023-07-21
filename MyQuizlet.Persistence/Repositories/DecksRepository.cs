using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyQuizlet.Application.Contracts.Repositories;
using MyQuizlet.Domain.Entities;
using MyQuizlet.Persistence.DBContext;
using System.Security.Claims;

namespace MyQuizlet.Persistence.Repositories
{
    public class DecksRepository : GenericRepository<Deck>, IDecksRepository
    {
        public DecksRepository(MyQuizletDbContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
        {
        }

        public async Task<Deck?> GetDeckCardsByDeckIdAsync(Guid deckId)
        {
            return await _dbSet.Include(d => d.Cards).FirstOrDefaultAsync(d => d.Id == deckId);
        }

        public async Task<List<Deck>?> GetAllDecksByUserAsync()
        {
            return await _dbSet.Where(d => d.ApplicationUserId == _userId).ToListAsync();
        }
    }
}
