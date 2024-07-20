
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using Looh.Application.Common.Behaviors;
using Looh.Application.Authentication.Commands.Register;
using ErrorOr;
using Looh.Application.Authentication.Common;
using FluentValidation;

namespace Looh.Application;

public static class DependencyInjection
{

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DependencyInjection).GetTypeInfo().Assembly));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).GetTypeInfo().Assembly);
        return services;
    }



}
