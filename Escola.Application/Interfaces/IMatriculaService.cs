using Escola.Application.DTOs.Matricula;

namespace Escola.Application.Interfaces;

public interface IMatriculaService
{
    Task<MatriculaGetDetailDTO> GetByIdAsync(int id);
    Task<List<MatriculaGetDetailDTO>> GetAllAsync();
    Task<MatriculaGetDTO> AddAsync(MatriculaPostDTO matriculaPostDto);
    Task<MatriculaGetDTO> UpdateAsync(MatriculaPutDTO matriculaPutDto);
    Task<MatriculaGetDTO> DeleteAsync(int id);
}