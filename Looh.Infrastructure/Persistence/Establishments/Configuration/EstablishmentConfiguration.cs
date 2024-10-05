using Looh.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Looh.Infrastructure.Persistence.Establishments.Configuration;

public class EstablishmentConfiguration : IEntityTypeConfiguration<Establishment>
{
    public void Configure(EntityTypeBuilder<Establishment> builder)
    {
        ConfigureTableEstablishment(builder);
    }

    public void ConfigureTableEstablishment(EntityTypeBuilder<Establishment> builder) 
    {
        // Definindo a chave primária
        builder.HasKey(e => e.Id);

        // Definindo propriedades obrigatórias e tamanhos máximos
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.FundationDate)
            .IsRequired();

        builder.Property(e => e.CreatedDate)
            .IsRequired();

        builder.Property(e => e.Telephone)
            .HasMaxLength(15);

        builder.Property(e => e.Email)
            .HasMaxLength(100);

        builder.Property(e => e.Cnpj)
            .HasMaxLength(18);

        builder.Property(e => e.Cpf)
            .HasMaxLength(14);

        builder.Property(e => e.WorkingHours)
            .HasMaxLength(50);

        builder.Property(e => e.IntervalHours)
            .HasMaxLength(50);

        // Configurando a propriedade de lista de dias de trabalho
        builder.Property(e => e.WorkingDays)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
            );

    }

}
