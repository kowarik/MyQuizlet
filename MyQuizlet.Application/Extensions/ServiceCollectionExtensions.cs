using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using MyQuizlet.Application.CQRSFeatures.Card.Shared;
using MyQuizlet.Application.CQRSFeatures.Deck.Shared;
using System.Reflection;

namespace MyQuizlet.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<BaseCardValidator>();
            services.AddValidatorsFromAssemblyContaining<BaseDeckValidator>();

            return services;
        }
    }
}
