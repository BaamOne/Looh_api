using Looh.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Looh.Application.Services.Authentication.Common;


public record AuthenticationResult(
    User User,
    string Token);