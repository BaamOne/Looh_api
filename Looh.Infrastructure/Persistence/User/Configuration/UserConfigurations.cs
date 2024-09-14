using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Looh.Infrastructure.Persistence.User.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<Looh.Domain.Entities.User>
{
    public void Configure(EntityTypeBuilder<Looh.Domain.Entities.User> builder)
    {
        ConfigureUsersTable(builder);
    }

    public void ConfigureUsersTable(EntityTypeBuilder<Looh.Domain.Entities.User> builder)
    {
        // Define o nome da tabela
        builder.ToTable("Users");

        // Define a chave primária
        builder.HasKey(x => x.Id);

        // Configura propriedades como obrigatórias
        builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(100);  // Exemplo de limite de caracteres

        builder.Property(x => x.Telephone)
               .IsRequired()
               .HasMaxLength(15);  // Exemplo de limite de caracteres

        builder.Property(x => x.Email)
               .IsRequired()
               .HasMaxLength(150); // Exemplo de limite de caracteres

        builder.Property(x => x.Password)
               .IsRequired();


    }


}