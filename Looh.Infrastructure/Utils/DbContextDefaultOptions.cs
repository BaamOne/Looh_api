using Looh.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Looh.Api.Common.Utils
{
    public static class DbContextDefaultOptions
    {
        public static DbContextOptionsBuilder GetDefaultOptions(ConfigurationManager configuration, DbContextOptionsBuilder? buildOptions)
        {
            if (buildOptions == null) { buildOptions = new DbContextOptionsBuilder<LoohDbContext>(); }
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 34));
            buildOptions = buildOptions
                .UseMySql(configuration.GetConnectionString("LOOH_DEFAULT"), serverVersion)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            return buildOptions;
        }
    }
}
