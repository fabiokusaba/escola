using Escola.Application.DTOs.Curso;
using Escola.Application.Exceptions;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using Escola.Domain.Pagination;

namespace Escola.Application.Services;

public class CursoService(ICursoRepository repository) : ICursoService
{
    public async Task<CursoGetDTO> GetByIdAsync(int id)
    {
        var curso = await repository.GetByIdAsync(id);
        
        if (curso is null) throw new NotFoundException("Curso não encontrado");

        return new CursoGetDTO
        {
            Id = curso.Id,
            Nome = curso.Nome,
            Descricao = curso.Descricao
        };
    }

    public async Task<PagedList<CursoGetDTO>> GetAllAsync(int pageNumber, int pageSize)
    {
        var cursos = await repository.GetAllAsync(pageNumber, pageSize);
        var cursoGetDTOs = new List<CursoGetDTO>();
        cursoGetDTOs.AddRange(cursos.Select(c => new CursoGetDTO
        {
            Id = c.Id,
            Nome = c.Nome,
            Descricao = c.Descricao
        }));
        return new PagedList<CursoGetDTO>(cursoGetDTOs, cursos.TotalCount, cursos.CurrentPage, cursos.PageSize);
    }

    public async Task<CursoGetDTO> AddAsync(CursoPostDTO dto)
    {
        var curso = new Curso
        {
            Nome = dto.Nome,
            Descricao = dto.Descricao
        };

        var cursoCriado = await repository.AddAsync(curso);

        if (cursoCriado is null) throw new BadRequestException("Ocorreu um erro ao criar o curso");

        return new CursoGetDTO
        {
            Id = cursoCriado.Id,
            Nome = cursoCriado.Nome,
            Descricao = cursoCriado.Descricao
        };
    }

    public async Task<CursoGetDTO> UpdateAsync(CursoPutDTO dto)
    {
        var curso = await  repository.GetByIdAsync(dto.Id);

        if (curso is null) throw new NotFoundException("Curso não encontrado");
        
        curso.Id = dto.Id;
        curso.Nome = dto.Nome;
        curso.Descricao = dto.Descricao;
        
        var cursoAtualizado = await repository.UpdateAsync(curso);
        
        if (cursoAtualizado is null) throw new BadRequestException("Ocorreu um erro ao atualizar o curso");

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

        if (cursoRemovido is null) throw new NotFoundException("Curso não encontrado");

        return new CursoGetDTO
        {
            Id = cursoRemovido.Id,
            Nome = cursoRemovido.Nome,
            Descricao = cursoRemovido.Descricao
        };
    }
}