using Looh.Application.Common.Interfaces.Authentication;
using Looh.Application.Persistence;
using Looh.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Looh.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }


    public AuthenticationResult Login(string email, string password)
    {
        //Check if user exists
        var user = _userRepository.GetUserByEmail(email);

        if (user is null)
        {
            throw new Exception("User or password is incorrect.");
        }

        //Check if password is correct
        if (user.Password != password)
        {
            throw new Exception("Password is incorrect.");
        }

        //Generate token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }


    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //Check if user already exists
        var existingUser = _userRepository.GetUserByEmail(email);

        if (existingUser is not null) { 
            throw new Exception("User with given e-mail already exists.");
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

