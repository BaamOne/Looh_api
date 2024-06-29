
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace Looh.Application;

public static class DependencyInjection
{

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DependencyInjection).GetTypeInfo().Assembly));
        return services;
    }



}
