using MyQuizlet.Domain.Entities;

namespace MyQuizlet.Application.Contracts.Repositories
{
    public interface ICardsRepository : IGenericRepository<Card>
    {
        Task<bool> IsTermUniqueAsync(string term);
        Task<Card?> GetCardByIdWithDeckAsync(Guid id);
    }
}
