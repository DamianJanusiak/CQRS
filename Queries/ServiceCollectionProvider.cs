using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using Applicaction;

namespace Queries
{
    public static class ServiceCollectionProvider
    {
        public static IServiceCollection AddRequestHandlers(this IServiceCollection services)
        {
            services.AddMediatR(o =>
            {
                o.RegisterServicesFromAssembly(typeof(ServiceCollectionProvider).Assembly);
                o.AddOpenBehavior(typeof(ValidationBehavior<,>));
            })
            .AddValidatorsFromAssembly(typeof(ServiceCollectionProvider).Assembly);
            return services;
        }
    }
}
