using Looh.Application.Establishments.Common;
using ErrorOr;
using MediatR;

namespace Looh.Application.Establishments.Queries.GetEstabishments
{
    public record GetEstablishmentQuery(string? Name,
        string? Cnpj,
        string? Cpf,
        DateTime? FundationDateStart,
        DateTime? FundationDateEnd,
        string? Telephone,
        string? Email,
       List<string>? WorkingDays,
        string? WorkingHoursStart,
        string? WorkingHoursEnd) : IRequest<ErrorOr<EstablishmentResult>>;
}
