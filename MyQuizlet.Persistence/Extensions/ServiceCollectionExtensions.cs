using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyQuizlet.Application.Contracts.Repositories;
using MyQuizlet.Persistence.DBContext;
using MyQuizlet.Persistence.Repositories;

namespace MyQuizlet.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddRepositories();

            return services;
        }

        private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyQuizletDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MyQuizletConnection"));
            });
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddScoped<ICardsRepository, CardsRepository>()
                .AddScoped<IDecksRepository, DecksRepository>();
        }
    }
}
