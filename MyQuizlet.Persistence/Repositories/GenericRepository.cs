using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyQuizlet.Application.Contracts.Repositories;
using MyQuizlet.Domain.Entities;
using MyQuizlet.Persistence.DBContext;
using System.Security.Claims;

namespace MyQuizlet.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private protected readonly Guid _userId;
        protected readonly MyQuizletDbContext _dbContext;
        internal DbSet<T> _dbSet;

        public GenericRepository(MyQuizletDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();

            _userId = Guid.Parse(httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid? id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
