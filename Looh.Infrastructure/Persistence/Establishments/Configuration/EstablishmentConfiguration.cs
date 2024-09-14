﻿using Looh.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Looh.Infrastructure.Persistence.Establishments.Configuration;

public class EstablishmentConfiguration : IEntityTypeConfiguration<Establishment>
{
    public void Configure(EntityTypeBuilder<Establishment> builder)
    {
        ConfigureTableEstablishment(builder);
    }

    public void ConfigureTableEstablishment(EntityTypeBuilder<Establishment> builder) 
    { 
        
    
    }

}
