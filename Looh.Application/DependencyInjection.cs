using Looh.Application.Services.Authentication.Commands;
using Looh.Application.Services.Authentication.Queries;
using Microsoft.Extensions.DependencyInjection;
namespace Looh.Application;

public static class DependencyInjection
{

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
        services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        return services;
    }



}
