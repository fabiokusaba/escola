using Escola.Application.DTOs.Usuario;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;

namespace Escola.Application.Services;

public class UsuarioService(IUsuarioRepository repository) : IUsuarioService
{
    public async Task<UsuarioGetDTO> GetByIdAsync(int id)
    {
        var usuario = await repository.GetByIdAsync(id);

        if (usuario is null) return null;

        return new UsuarioGetDTO
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Email = usuario.Email,
            Perfil = usuario.Perfil
        };
    }

    public async Task<List<UsuarioGetDTO>> GetAllAsync()
    {
        var usuarios = await repository.GetAllAsync();

        return usuarios
            .Select(usuario => new UsuarioGetDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Perfil = usuario.Perfil
            })
            .ToList();
    }

    public async Task<UsuarioGetDTO> AddAsync(UsuarioPostDTO dto)
    {
        var usuario = new Usuario
        {
            Nome = dto.Nome,
            Email = dto.Email,
            Perfil = dto.Perfil
        };
        
        var usuarioCriado = await repository.AddAsync(usuario);

        return new UsuarioGetDTO
        {
            Id = usuarioCriado.Id,
            Nome = usuarioCriado.Nome,
            Email = usuarioCriado.Email,
            Perfil = usuarioCriado.Perfil
        };
    }

    public async Task<UsuarioGetDTO> UpdateAsync(UsuarioPutDTO dto)
    {
        var usuario = new Usuario
        {
            Id = dto.Id,
            Nome = dto.Nome,
            Email = dto.Email,
            Perfil = dto.Perfil
        };
        
        var usuarioAtualizado = await repository.UpdateAsync(usuario);

        return new UsuarioGetDTO
        {
            Id = usuarioAtualizado.Id,
            Nome = usuarioAtualizado.Nome,
            Email = usuarioAtualizado.Email,
            Perfil = usuarioAtualizado.Perfil
        };
    }

    public async Task<UsuarioGetDTO> DeleteAsync(int id)
    {
        var usuarioRemovido = await repository.DeleteAsync(id);

        if (usuarioRemovido is null) return null;

        return new UsuarioGetDTO
        {
            Id = usuarioRemovido.Id,
            Nome = usuarioRemovido.Nome,
            Email = usuarioRemovido.Email,
            Perfil = usuarioRemovido.Perfil
        };
    }
}