using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Looh.Contracts.Establishment
{
    public record EstablishmentResponse(
        Guid Id,
        string Name,
        DateTime FundationDate,
        string Telephone,
        string Email,
        string Cnpj,
        string Cpf,
        string WorkingHours,
        string IntervalHours,
        List<string> WorkingDays);

}
