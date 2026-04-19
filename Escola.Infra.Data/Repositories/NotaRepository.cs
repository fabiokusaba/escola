using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using Escola.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Escola.Infra.Data.Repositories;

public class NotaRepository(ApplicationDbContext context) : INotaRepository
{
    public async Task<List<Nota>> GetNotasByTurmaUsuario(int turmaId, int usuarioId)
    {
        return await context.Nota.Where(n =>
            n.Excluido == false && n.Matricula.TurmaId == turmaId && n.Matricula.UsuarioId == usuarioId)
            .ToListAsync();
    }

    public async Task<Nota> GetByIdAsync(int id)
    {
        return await context.Nota
            .Where(n => n.Excluido == false && n.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Nota>> GetAllAsync()
    {
        return await context.Nota
            .Where(n => n.Excluido == false)
            .ToListAsync();
    }

    public async Task<Nota> AddAsync(Nota nota)
    {
        context.Nota.Add(nota);
        await context.SaveChangesAsync();
        return nota;
    }

    public async Task<Nota> UpdateAsync(Nota nota)
    {
        context.Nota.Update(nota);
        await context.SaveChangesAsync();
        return nota;
    }

    public async Task<Nota> DeleteAsync(int id)
    {
        var nota = await context.Nota
            .Where(n => n.Excluido == false && n.Id == id)
            .FirstOrDefaultAsync();

        if (nota is null) return null;

        nota.Excluido = true;
        context.Nota.Update(nota);
        await context.SaveChangesAsync();
        return nota;
    }
}