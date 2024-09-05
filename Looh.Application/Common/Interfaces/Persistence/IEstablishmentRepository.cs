using Looh.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Looh.Application.Common.Interfaces.Persistence
{
    public interface IEstablishmentRepository
    {

        HashSet<Establishment>? GetEstablishmentByCnpj(string cnpj);
        
        void Add(Establishment establishment);

    }
}
