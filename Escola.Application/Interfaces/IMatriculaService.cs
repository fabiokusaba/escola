using Escola.Application.DTOs.Matricula;

namespace Escola.Application.Interfaces;

public interface IMatriculaService
{
    Task<MatriculaGetDTO> GetByIdAsync(int id);
    Task<List<MatriculaGetDTO>> GetAllAsync();
    Task<MatriculaGetDTO> AddAsync(MatriculaPostDTO matricula);
    Task<MatriculaGetDTO> UpdateAsync(MatriculaPutDTO matricula);
    Task<MatriculaGetDTO> DeleteAsync(int id);
}