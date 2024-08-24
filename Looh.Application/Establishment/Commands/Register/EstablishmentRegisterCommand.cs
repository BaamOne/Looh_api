﻿using ErrorOr;
using Looh.Application.Authentication.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Looh.Application.Establishment.Commands.Register
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
     List<string> WorkingDays) : IRequest<ErrorOr<AuthenticationResult>>;
}
