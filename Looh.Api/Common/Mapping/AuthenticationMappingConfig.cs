using Looh.Application.Authentication.Commands.Register;
using Looh.Application.Authentication.Common;
using Looh.Application.Authentication.Queries.Login;
using Looh.Contracts.Authentication;
using Mapster;

namespace Looh.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery> ();
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, src => src.User);

        }
    }
}
