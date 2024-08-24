
using Looh.Domain.Entities;

namespace Looh.Application.Authentication.Common
{
    public record class AuthenticationResult(User User, string Token);
}
