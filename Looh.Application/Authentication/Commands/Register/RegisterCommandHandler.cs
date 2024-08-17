
using ErrorOr;
using Looh.Application.Authentication.Common;
using Looh.Application.Common.Interfaces.Authentication;
using Looh.Application.Common.Interfaces.Persistence;
using Looh.Domain.Common.Errors;
using Looh.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Looh.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly PasswordHasher<IdentityUser> _passwordHasher = new PasswordHasher<IdentityUser>();


        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        async Task<ErrorOr<AuthenticationResult>> IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>.Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            //Check if user already exists
            var existingUser = _userRepository.GetUserByEmail(command.Email);

            if (existingUser is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            var dummyUser = new IdentityUser(); // Usado apenas para o tipo genérico.
            var passwordHashed = _passwordHasher.HashPassword(dummyUser, command.Password);


            //Creat user (generate unique ID)

            var user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = passwordHashed
            };
            _userRepository.Add(user);

            //Generate token

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
