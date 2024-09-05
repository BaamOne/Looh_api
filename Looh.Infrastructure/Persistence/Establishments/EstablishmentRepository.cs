using Looh.Application.Common.Interfaces.Persistence;
using Looh.Domain.Entities;

namespace Looh.Infrastructure.Persistence.Establishments
{
    internal class EstablishmentRepository : IEstablishmentRepository
    {
        private static readonly HashSet<Establishment> _Establishments = new();

        public void Add(Establishment establishment)
        {
            _Establishments.Add(establishment);
        }

        public HashSet<Establishment>? GetEstablishmentByCnpj(string cnpj)
        {
            return  _Establishments.Where(x => x.Cnpj == cnpj).ToHashSet();
        }
    }
}
