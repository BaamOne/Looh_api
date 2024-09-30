using Looh.Domain.Entities;
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
        builder.ToTable("Establishments");

        // Define a chave primária
        builder.HasKey(x => x.Id);

        // Configura propriedades como obrigatórias
        builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(100);  // Exemplo de limite de caracteres

        builder.Property(x => x.FundationDate)
               .IsRequired();

        builder.Property(x => x.CreatedDate)
               .IsRequired();

        builder.Property(x => x.Telephone)
               .IsRequired()
               .HasMaxLength(15);

        builder.Property(x => x.Email)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(x => x.Cnpj)
               .IsRequired()
               .HasMaxLength(14);  // Exemplo de limite de caracteres para CNPJ

        builder.Property(x => x.Cpf)
               .IsRequired()
               .HasMaxLength(11);  // Exemplo de limite de caracteres para CPF

        builder.Property(x => x.WorkingHours)
               .IsRequired();

        builder.Property(x => x.IntervalHours)
               .IsRequired();

        builder.Property(x => x.WorkingDays)
               .IsRequired();

        // Configura a relação entre Establishment e User (muitos para um)
        builder.HasOne<Looh.Domain.Entities.User>()  // Define que um estabelecimento tem um usuário
               .WithMany()  // Um usuário pode ter muitos estabelecimentos
               .HasForeignKey(x => x.IdUser)  // Especifica que IdUser é a chave estrangeira
               .OnDelete(DeleteBehavior.Cascade);  // Define o comportamento ao excluir usuário

    }

}
