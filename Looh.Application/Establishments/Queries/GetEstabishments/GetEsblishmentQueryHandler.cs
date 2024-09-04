using ErrorOr;
using Looh.Application.Authentication.Common;
using Looh.Application.Authentication.Queries.Login;
using Looh.Application.Common.Interfaces.Authentication;
using Looh.Application.Common.Interfaces.Persistence;
using Looh.Application.Establishments.Commands.Register;
using Looh.Application.Establishments.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Looh.Application.Establishments.Queries.GetEstabishments
{
    public class GetEsblishmentQueryHandler : IRequestHandler<GetEsblishmentQuery, ErrorOr<ISet<EstablishmentResult>>>
    {
        private readonly IEstablishmentRepository _establishmentRepository;

        public GetEsblishmentQueryHandler(IEstablishmentRepository establishmentRepository)
        {
            _establishmentRepository = establishmentRepository;
        }

        public async Task<ErrorOr<ISet<EstablishmentResult>>> Handle(GetEsblishmentQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var establishment = _establishmentRepository.GetEstablishmentByCnpj(query.Cnpj);

            if (establishment is not null)
            {
                return Errors.Establishment.DuplicateCnpj;
            }

            establishment = new Establishment
            {
                Name = request.Name,
                FundationDate = request.FundationDate,
                Telephone = request.Telephone,
                Email = request.Email,
                Cnpj = request.Cnpj,
                Cpf = request.Cpf,
                WorkingHours = request.WorkingHours,
                IntervalHours = request.IntervalHours,
                WorkingDays = request.WorkingDays,
                CreatedDate = DateTime.Now
            };
            _establishmentRepository.Add(establishment);

            return new EstablishmentResult(establishment);

        }
    }
}
