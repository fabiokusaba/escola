using Escola.Application.DTOs.Turma;

namespace Escola.Application.Interfaces;

public interface ITurmaService
{
    Task<TurmaGetDetailDTO> GetByIdAsync(int id);
    Task<List<TurmaGetDTO>> GetAllAsync();
    Task<TurmaGetDTO> AddAsync(TurmaPostDTO turmaPostDto);
    Task<TurmaGetDTO> UpdateAsync(TurmaPutDTO turmaPutDto);
    Task<TurmaGetDTO> DeleteAsync(int id);
}