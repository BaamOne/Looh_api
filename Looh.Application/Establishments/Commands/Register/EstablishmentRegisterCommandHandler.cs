using ErrorOr;
using Looh.Application.Common.Interfaces.Persistence;
using Looh.Application.Establishments.Common;
using Looh.Domain.Entities;
using MediatR;
using Looh.Domain.Common.Errors;
using Looh.Application.Authentication.Common;
using System.Reflection.Metadata;

namespace Looh.Application.Establishments.Commands.Register
{
    public class EstablishmentRegisterCommandHandler : IRequestHandler<EstablishmentRegisterCommand, ErrorOr<EstablishmentResult>>
    {
        private readonly IEstablishmentRepository _establishmentRepository;

        public EstablishmentRegisterCommandHandler(IEstablishmentRepository establishmentRepository)
        {
            _establishmentRepository = establishmentRepository;
        }

        async Task<ErrorOr<EstablishmentResult>> IRequestHandler<EstablishmentRegisterCommand, ErrorOr<EstablishmentResult>> .Handle(EstablishmentRegisterCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var establishment = _establishmentRepository.GetEstablishmentByCnpj(request.Cnpj);

            if (establishment is not null && establishment.Count() > 0)
            {
                return Errors.Establishment.DuplicateCnpj;
            }

            Establishment establishmentCreate = new Establishment();
            establishmentCreate = new Establishment
            {
                Name  = request.Name,
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
            _establishmentRepository.Add(establishmentCreate);


            return new EstablishmentResult(new HashSet<Establishment> { establishmentCreate });

        }
    }
}
