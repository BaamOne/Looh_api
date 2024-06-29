using Looh.Application.Common.Interfaces.Authentication;
using Looh.Domain.Entities;
using ErrorOr;
using Looh.Domain.Common.Errors;
using Looh.Application.Services.Authentication.Common;
using Looh.Application.Common.Interfaces.Persistence;

namespace Looh.Application.Services.Authentication.Commands;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }


    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        //Check if user already exists
        var existingUser = _userRepository.GetUserByEmail(email);

        if (existingUser is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        //Creat user (generate unique ID)

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        _userRepository.Add(user);

        //Generate token

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }


}

