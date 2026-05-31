using Escola.Application.DTOs.Curso;
using Escola.Domain.Pagination;

namespace Escola.Application.Interfaces;

public interface ICursoService
{
    Task<CursoGetDTO> GetByIdAsync(int id);
    Task<PagedList<CursoGetDTO>> GetAllAsync(int pageNumber, int pageSize);
    Task<CursoGetDTO> AddAsync(CursoPostDTO curso);
    Task<CursoGetDTO> UpdateAsync(CursoPutDTO curso);
    Task<CursoGetDTO> DeleteAsync(int id);
}