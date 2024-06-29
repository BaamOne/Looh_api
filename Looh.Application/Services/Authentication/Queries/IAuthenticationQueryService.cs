using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using Looh.Application.Services.Authentication.Common;

namespace Looh.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{

    ErrorOr<AuthenticationResult> Login(string email, string password);


}
