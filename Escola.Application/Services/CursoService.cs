using Escola.Application.DTOs.Curso;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;

namespace Escola.Application.Services;

public class CursoService(ICursoRepository repository) : ICursoService
{
    public async Task<CursoGetDTO> GetByIdAsync(int id)
    {
        var curso = await repository.GetByIdAsync(id);
        
        if (curso is null) return null;

        return new CursoGetDTO
        {
            Id = curso.Id,
            Nome = curso.Nome,
            Descricao = curso.Descricao
        };
    }

    public async Task<List<CursoGetDTO>> GetAllAsync()
    {
        var cursos = await repository.GetAllAsync();

        return cursos
            .Select(curso => new CursoGetDTO { Id = curso.Id, Nome = curso.Nome, Descricao = curso.Descricao })
            .ToList();
    }

    public async Task<CursoGetDTO> AddAsync(CursoPostDTO dto)
    {
        var curso = new Curso
        {
            Nome = dto.Nome,
            Descricao = dto.Descricao
        };

        var cursoCriado = await repository.AddAsync(curso);

        return new CursoGetDTO
        {
            Id = cursoCriado.Id,
            Nome = cursoCriado.Nome,
            Descricao = cursoCriado.Descricao
        };
    }

    public async Task<CursoGetDTO> UpdateAsync(CursoPutDTO dto)
    {
        var curso = new Curso
        {
            Id = dto.Id,
            Nome = dto.Nome,
            Descricao = dto.Descricao
        };
        
        var cursoAtualizado = await repository.UpdateAsync(curso);
        
        if (cursoAtualizado is null) return null;

        return new CursoGetDTO
        {
            Id = cursoAtualizado.Id,
            Nome = cursoAtualizado.Nome,
            Descricao = cursoAtualizado.Descricao
        };
    }

    public async Task<CursoGetDTO> DeleteAsync(int id)
    {
        var cursoRemovido = await repository.DeleteAsync(id);

        if (cursoRemovido is null) return null;

        return new CursoGetDTO
        {
            Id = cursoRemovido.Id,
            Nome = cursoRemovido.Nome,
            Descricao = cursoRemovido.Descricao
        };
    }
}