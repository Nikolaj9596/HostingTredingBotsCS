using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using HostingTradingBots.Application.Common.Behaviors;

namespace HostingTradingBots.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
            ; return services;

        }
    }
}
