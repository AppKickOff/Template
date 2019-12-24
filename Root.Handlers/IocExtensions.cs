using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace Handlers
{
    public static class IocExtensions
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddTransient<ServiceFactory>(p => p.GetService);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddSingleton<IMediator, Mediator>();

            services.Scan(a => a.FromExecutingAssembly()
                .AddClasses(c => c.AssignableTo(typeof(IRequestHandler<>)))
                .AsMatchingInterface((t, f) => f.AssignableTo(typeof(IRequestHandler<>)))
                .WithSingletonLifetime()
                .AddClasses(c => c.AssignableTo(typeof(IPipelineBehavior<,>)))
                .AsMatchingInterface((t, f) => f.AssignableTo(typeof(IPipelineBehavior<,>)))
                .WithSingletonLifetime());

            return services;
        }
    }
}
