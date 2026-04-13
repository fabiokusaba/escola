using System.Security.Cryptography;
using System.Text;
using Escola.Application.DTOs.Usuario;
using Escola.Application.Exceptions;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;

namespace Escola.Application.Services;

public class UsuarioService(IUsuarioRepository repository) : IUsuarioService
{
    public async Task<UsuarioGetDTO> GetByIdAsync(int id)
    {
        var usuario = await repository.GetByIdAsync(id);

        if (usuario is null) throw new NotFoundException("Usuário não encontrado");

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
        using var hmac = new HMACSHA512();
        byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Senha));
        byte[] passwordSalt = hmac.Key;
        
        var existeUsuario = await repository.ExisteUsuarioAsync();
        
        var usuario = new Usuario
        {
            Nome = dto.Nome,
            Email = dto.Email,
            Excluido = false,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Perfil = existeUsuario ? "Aluno" : "Administrador"
        };
        
        var usuarioCriado = await repository.AddAsync(usuario);

        if (usuarioCriado is null) throw new BadRequestException("Ocorreu um erro ao cadastrar o usuário");

        return new UsuarioGetDTO
        {
            Id = usuarioCriado.Id,
            Nome = usuarioCriado.Nome,
            Email = usuarioCriado.Email,
            Perfil = usuarioCriado.Perfil
        };
    }

    public async Task<UsuarioGetDTO> UpdateAsync(int usuarioId, UsuarioPutDTO dto)
    {
        var usuarioExiste = await repository.GetByIdAsync(usuarioId);
        
        if (usuarioExiste is null) throw new NotFoundException("Usuário não encontrado");

        usuarioExiste.Nome = dto.Nome;
        usuarioExiste.Email = dto.Email;
        
        var usuarioAtualizado = await repository.UpdateAsync(usuarioExiste);

        if (usuarioAtualizado is null) throw new BadRequestException("Ocorreu um erro ao atualizar o usuário");

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

        if (usuarioRemovido is null) throw new NotFoundException("Usuário não encontrado");

        return new UsuarioGetDTO
        {
            Id = usuarioRemovido.Id,
            Nome = usuarioRemovido.Nome,
            Email = usuarioRemovido.Email,
            Perfil = usuarioRemovido.Perfil
        };
    }

    public async Task<bool> ExisteUsuarioAsync()
    {
        return await repository.ExisteUsuarioAsync();
    }
}