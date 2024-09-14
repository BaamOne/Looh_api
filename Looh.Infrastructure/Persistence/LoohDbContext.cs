using Looh.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Looh.Infrastructure.Persistence;

public class LoohDbContext : DbContext
{
    public LoohDbContext(DbContextOptions<LoohDbContext> options) : base (options)
    { 
    
    }

    DbSet<Looh.Domain.Entities.User> Users { get; set; } = null!;

    DbSet<Establishment> Establishments { get; set; } = null!;

}   
