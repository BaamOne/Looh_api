using Looh.Application.Establishments.Commands.Register;
using Looh.Application.Establishments.Common;
using Looh.Contracts.Establishment;
using Mapster;

namespace Looh.Api.Common.Mapping
{
    public class EstablishmentMappingConfig :IRegister 
    {

        public void Register(TypeAdapterConfig config)
        {

            config.NewConfig<EstablishmentRegisterRequest, EstablishmentRegisterCommand>();
            config.NewConfig<EstablishmentResult, EstablishmentResponse>()
                .Map(dest => dest, src => src.Establishment);
        }


    }
}
