using Escola.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Escola.Infra.Data.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Curso> Curso { get; set; }
    public DbSet<Matricula> Matricula { get; set; }
    public DbSet<Nota> Nota { get; set; }
    public DbSet<Turma> Turma { get; set; }
    public DbSet<Usuario> Usuario { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}