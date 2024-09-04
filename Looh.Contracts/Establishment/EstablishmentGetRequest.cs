using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Looh.Contracts.Establishment;

    public record EstablishmentGetRequest(
        string? Name,
        string? Cnpj,
        string? Cpf,
        DateTime? FundationDateStart,
        DateTime? FundationDateEnd,
        string? Telephone,
        string? Email,
       List<string>? WorkingDays,
        string? WorkingHoursStart, 
        string? WorkingHoursEnd);

