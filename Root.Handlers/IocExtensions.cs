using Microsoft.Extensions.DependencyInjection;

namespace Handlers
{
    public static class IocExtensions
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            return services;
        }
    }
}