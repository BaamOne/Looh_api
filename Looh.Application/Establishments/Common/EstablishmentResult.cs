
using Looh.Domain.Entities;

namespace Looh.Application.Establishments.Common
{
    public record class EstablishmentResult(HashSet<Establishment> Establishment);
}
