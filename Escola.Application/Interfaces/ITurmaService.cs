using Escola.Application.DTOs.Turma;

namespace Escola.Application.Interfaces;

public interface ITurmaService
{
    Task<TurmaGetDTO> GetByIdAsync(int id);
    Task<List<TurmaGetDTO>> GetAllAsync();
    Task<TurmaGetDTO> AddAsync(TurmaPostDTO turma);
    Task<TurmaGetDTO> UpdateAsync(TurmaPutDTO turma);
    Task<TurmaGetDTO> DeleteAsync(int id);
}