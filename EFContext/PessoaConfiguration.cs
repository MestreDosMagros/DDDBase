using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFContext;

public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder.Property(p => p.Nome).HasMaxLength(150);
        builder.Property(p => p.Sobrenome).HasMaxLength(300);
        builder.Property(p => p.Documento).HasMaxLength(11);

        builder.HasIndex(p => p.Documento).IsUnique();
        builder.HasIndex(p => new { p.Nome, p.Sobrenome });
    }
}

public class BaseConfiguration<TKey> : IEntityTypeConfiguration<Base<TKey>>
{
    public void Configure(EntityTypeBuilder<Base<TKey>> builder)
    {
        builder.HasKey(prop => prop.Id);
    }
}

