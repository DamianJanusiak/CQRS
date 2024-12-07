using Aplication.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceCollectionProvider
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IBooksRepository, BooksRepository>();
            
            return services;
        }
    }
}
