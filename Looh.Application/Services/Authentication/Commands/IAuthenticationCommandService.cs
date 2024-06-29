using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using Looh.Application.Services.Authentication.Common;

namespace Looh.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{

    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);

}
