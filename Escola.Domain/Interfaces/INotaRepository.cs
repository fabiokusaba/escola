using Escola.Domain.Entities;

namespace Escola.Domain.Interfaces;

public interface INotaRepository
{
    Task<Nota> GetByIdAsync(int id);
    Task<List<Nota>> GetAllAsync();
    Task<Nota> AddAsync(Nota matricula);
    Task<Nota> UpdateAsync(Nota matricula);
    Task<Nota> DeleteAsync(int id);
}