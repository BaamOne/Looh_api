using ErrorOr;
using Looh.Application.Authentication.Common;
using Looh.Application.Authentication.Queries.Login;
using Looh.Application.Common.Interfaces.Authentication;
using Looh.Application.Common.Interfaces.Persistence;
using Looh.Application.Establishments.Commands.Register;
using Looh.Application.Establishments.Common;
using Looh.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Looh.Application.Establishments.Queries.GetEstabishments
{
    public class GetEstablishmentQueryHandler : IRequestHandler<GetEstablishmentQuery, ErrorOr<EstablishmentResult>>
    {
        private readonly IEstablishmentRepository _establishmentRepository;

        public GetEstablishmentQueryHandler(IEstablishmentRepository establishmentRepository)
        {
            _establishmentRepository = establishmentRepository;
        }

        public async Task<ErrorOr<EstablishmentResult>> Handle(GetEstablishmentQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            HashSet<Establishment> establishment = _establishmentRepository.GetEstablishmentByCnpj(query.Cnpj);

            //if (establishment is not null)
            //{
            //    return Errors.Establishment.DuplicateCnpj;
            //}


            return new EstablishmentResult(establishment);

        }
    }
}
