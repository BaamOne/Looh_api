using Looh.Application.Common.Interfaces.Services;

namespace Looh.Infrastructure.Services;

public class DateTimeProvider: IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
