using Looh.Application.Common.Interfaces.Authentication;
using ErrorOr;
using Looh.Domain.Common.Errors;
using Looh.Application.Services.Authentication.Common;
using Looh.Application.Common.Interfaces.Persistence;

namespace Looh.Application.Services.Authentication.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }


    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        //Check if user exists
        var user = _userRepository.GetUserByEmail(email);

        if (user is null)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        //Check if password is correct
        if (user.Password != password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        //Generate token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

  
}

