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
    public DbSet<Looh.Domain.Entities.User> Users { get; set; } = null!;
    public DbSet<Establishment> Establishments { get; set; } = null!;
    public LoohDbContext(DbContextOptions<LoohDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LoohDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

}   
