using ErrorOr;
using Looh.Application.Authentication.Common;
using Looh.Application.Common.Interfaces.Authentication;
using Looh.Application.Common.Interfaces.Persistence;
using Looh.Domain.Common.Errors;
using MediatR;

namespace Looh.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;


        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await  Task.CompletedTask;
            //Check if user exists
            var user = _userRepository.GetUserByEmail(query.Email);

            if (user is null)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            //Check if password is correct
            if (user.Password != query.Password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            //Generate token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
