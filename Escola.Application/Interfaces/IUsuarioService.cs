using Escola.Application.DTOs.Usuario;

namespace Escola.Application.Interfaces;

public interface IUsuarioService
{
    Task<UsuarioGetDTO> GetByIdAsync(int id);
    Task<List<UsuarioGetDTO>> GetAllAsync();
    Task<UsuarioGetDTO> AddAsync(UsuarioPostDTO usuario);
    Task<UsuarioGetDTO> UpdateAsync(UsuarioPutDTO usuario);
    Task<UsuarioGetDTO> DeleteAsync(int id);
}