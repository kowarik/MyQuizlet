using MyQuizlet.Domain.Entities;

namespace MyQuizlet.Application.Contracts.Repositories
{
    public interface ICardsRepository : IGenericRepository<Card>
    {
        Task<bool> IsTermUniqueByUserAsync(string term);
        Task<Card?> GetCardByIdWithDeckAsync(Guid id);
        Task<List<Card>?> GetAllCardsByUserAsync();
    }
}
