﻿using ErrorOr;
using Looh.Application.Services.Authentication.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Looh.Application.Authentication.Queries.Login
{
    public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
    