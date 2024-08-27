using ErrorOr;
using Looh.Application.Establishments.Common;
using MediatR;


namespace Looh.Application.Establishments.Commands.Register
{
    public record EstablishmentRegisterCommand(
     string Name,
     DateTime FundationDate,
     string Telephone,
     string Email,
     string Cnpj,
     string Cpf,
     string WorkingHours,
     string IntervalHours,
     List<string> WorkingDays) : IRequest<ErrorOr<EstablishmentResult>>;
}
