using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;

namespace Looh.Domain.Common.Errors
{
    public static partial class Errors
    {

        public static class Establishment
        {

            public static Error DuplicateCnpj => Error.Conflict(code: "Establishment.DuplicateCnpj", description: "Cnpj is already in use.");

        }

    }
}
