using Escola.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Infra.Data.EntitiesConfiguration;

public class MatriculaConfiguration : IEntityTypeConfiguration<Matricula>
{
    public void Configure(EntityTypeBuilder<Matricula> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.UsuarioId)
            .IsRequired();
        builder.Property(m => m.TurmaId)
            .IsRequired();
        
        // Um usuário tem muitas matrículas
        builder.HasOne(u => u.Usuario)
            .WithMany(u => u.Matriculas)
            .HasForeignKey(u => u.UsuarioId)
            .OnDelete(DeleteBehavior.NoAction);
        
        // Uma turma tem muitas matrículas
        builder.HasOne(t => t.Turma)
            .WithMany(t => t.Matriculas)
            .HasForeignKey(t => t.TurmaId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}