using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using MyQuizlet.Application.Contracts.Services;
using MyQuizlet.Application.CQRSFeatures.Card.Shared;
using MyQuizlet.Application.CQRSFeatures.Deck.Shared;
using MyQuizlet.Application.Services;
using System.Reflection;

namespace MyQuizlet.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<BaseCardValidator>();
            services.AddValidatorsFromAssemblyContaining<BaseDeckValidator>();
            services.AddHttpContextAccessor();

            return services;
        }
    }
}
