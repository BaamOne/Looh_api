using Looh.Api;
using Looh.Application;
using Looh.Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
           .AddApplication()
           .AddPresentation()
           .AddInfrastructure(builder.Configuration);

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "Looh API",
            Version = "v1",
            Description = "A simple example ASP.NET Core Web API",
            Contact = new Microsoft.OpenApi.Models.OpenApiContact
            {
                Name = "Looh API",
                Email = "looh@looh.com",
                Url = new Uri("https://your-url.com")
            }
        });

    });
}

var app = builder.Build();
{
    app.UseExceptionHandler("/unhandled/error");
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Looh API");
        c.RoutePrefix = string.Empty; // Exibe o Swagger UI na raiz (ex.: http://localhost:<port>/)
    });
    app.MapControllers();
    app.Run();
}
