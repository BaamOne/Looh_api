using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Looh.Contracts.Establishment;

public record EstablishmentRequest(
     string Name,
     DateTime FundationDate,
     string Telephone,
     string Email,
     string Cnpj,
     string Cpf,
     WorkingHoursRequest WorkingHours,
     IntervalHoursRequest IntervalHours,
     List<string> WorkingDays
 );

public record WorkingHoursRequest(
    string Start,  // Ex: "08:00"
    string End     // Ex: "18:00"
);

public record IntervalHoursRequest(
    string Start,  // Ex: "12:00"
    string End     // Ex: "13:00"
);