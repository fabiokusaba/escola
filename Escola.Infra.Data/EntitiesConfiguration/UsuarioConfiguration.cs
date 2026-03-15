using Escola.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Infra.Data.EntitiesConfiguration;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Nome)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(u => u.Perfil)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(u => u.PasswordHash)
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(u => u.PasswordSalt)
            .IsRequired()
            .HasMaxLength(255);
    }
}