using Looh.Api;
using Looh.Application;
using Looh.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
           .AddApplication()
           .AddPresentation()
           .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
