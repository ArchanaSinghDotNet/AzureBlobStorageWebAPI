using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using AzureBlobStorageWebAPI.Application.SeedWork.PipelineBehaviors;
using System.Reflection;

namespace AzureBlobStorageWebAPI.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
