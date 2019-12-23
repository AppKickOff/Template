using FluentValidation;
using Grpc.AspNetCore.FluentValidation;
using Grpc.AspNetCore.Server;
using Microsoft.Extensions.DependencyInjection;

namespace Root.Api.IoC
{
    public static class ValidationExtensions
    {
        public static IServiceCollection AddValidation(this IServiceCollection services)   
        {
            services.Scan(s => s.FromApplicationDependencies()
                .AddClasses(c => c.AssignableTo(typeof(IValidator<>)))
                .AsMatchingInterface((t, f) => f.AssignableTo(typeof(IValidator<>)))
                .WithSingletonLifetime());

            services.AddGrpcValidation();
            
            return services;
        }

        public static GrpcServiceOptions AddValidation(this GrpcServiceOptions options)
        {
            options.EnableMessageValidation();
            return options;
        }
    }
}
