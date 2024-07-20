using ErrorOr;
using Looh.Application.Authentication.Common;
using MediatR;


namespace Looh.Application.Authentication.Queries.Login
{
    public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
    