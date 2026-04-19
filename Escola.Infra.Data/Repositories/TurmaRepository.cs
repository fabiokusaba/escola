using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using Escola.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Escola.Infra.Data.Repositories;

public class TurmaRepository(ApplicationDbContext context) : ITurmaRepository
{
    public async Task<List<Turma>> GetTurmasByUsuario(int usuarioId)
    {
        return await context.Turma
            .Include(t => t.Curso)
            .Where(t => t.Excluido == false && t.Matriculas.Any(m => m.UsuarioId == usuarioId))
            .ToListAsync();
    }

    public async Task<Turma> GetByIdAsync(int id)
    {
        return await context.Turma
            .Include(t => t.Curso)
            .Where(t =>t.Excluido == false && t.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Turma>> GetAllAsync()
    {
        return await context.Turma
            .Include(t => t.Curso)
            .Where(t => t.Excluido == false)
            .ToListAsync();
    }

    public async Task<Turma> AddAsync(Turma turma)
    {
        context.Turma.Add(turma);
        await context.SaveChangesAsync();
        return turma;
    }

    public async Task<Turma> UpdateAsync(Turma turma)
    {
        context.Turma.Update(turma);
        await context.SaveChangesAsync();
        return turma;
    }

    public async Task<Turma> DeleteAsync(int id)
    {
        var turma = await context.Turma
            .Where(t => t.Excluido == false && t.Id == id)
            .FirstOrDefaultAsync();

        if (turma is null) return null;

        turma.Excluido = true;
        context.Turma.Update(turma);
        await context.SaveChangesAsync();
        return turma;
    }
}