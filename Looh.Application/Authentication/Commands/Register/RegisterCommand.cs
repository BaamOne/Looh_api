using ErrorOr;
using Looh.Application.Authentication.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Looh.Application.Authentication.Commands.Register
{
    public record RegisterCommand(string Name, string Telephone, string Email, string Password, DateTime DateBirth) :IRequest<ErrorOr<AuthenticationResult>> ;
}
