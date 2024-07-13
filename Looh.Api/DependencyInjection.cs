using Looh.Api.Common.Errors;
using Looh.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Looh.Api;

public static class DependencyInjection
{

    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, LoohProblemDatailsFactory>();
        services.AddMappings();
        return services;
    }



}
