using Looh.Application.Establishment.Commands.Register;
using Looh.Application.Establishment.Common;
using Looh.Contracts.Establishment;
using Mapster;

namespace Looh.Api.Common.Mapping
{
    public class EstablishmentMappingConfig :IRegister 
    {

        public void Register(TypeAdapterConfig config)
        {

            config.NewConfig<EstablishmentRequest, EstablishmentRegisterCommand>();
            //config.NewConfig<EstablishmentResult, EstablishmentResponse>()
            //    .Map(dest => dest, src => src.Establishment);
        }


    }
}
