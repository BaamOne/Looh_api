using Looh.Application.Common.Interfaces.Persistence;
using Looh.Domain.Entities;

namespace Looh.Infrastructure.Persistence.Establishments.Repository
{
    internal class EstablishmentRepository : IEstablishmentRepository
    {

        private readonly LoohDbContext _dbContext;

        private static readonly HashSet<Establishment> _Establishments = new();

        public EstablishmentRepository(LoohDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Establishment establishment)
        {
            _dbContext.Add(establishment);
            _dbContext.SaveChanges();
        }

        public HashSet<Establishment>? GetEstablishmentByCnpj(string cnpj)
        {
            return  _dbContext.Establishments
                                   .Where(x => x.Cnpj == cnpj)
                                   .ToHashSet();
        }
    }
}
