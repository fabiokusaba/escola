using Escola.Application.DTOs.Curso;
using Escola.Application.DTOs.Turma;
using Escola.Application.Exceptions;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;

namespace Escola.Application.Services;

public class TurmaService(ITurmaRepository repository, ICursoRepository cursoRepository) : ITurmaService
{
    public async Task<TurmaGetDetailDTO> GetByIdAsync(int id)
    {
        var turma = await repository.GetByIdAsync(id);

        if (turma is null) throw new NotFoundException("Turma não encontrada");

        return new TurmaGetDetailDTO
        {
            Id = turma.Id,
            Nome = turma.Nome,
            Descricao = turma.Descricao,
            Curso = new CursoGetDTO
            {
                Id = turma.Curso.Id,
                Nome = turma.Curso.Nome,
                Descricao = turma.Curso.Descricao,
            }
        };
    }

    public async Task<List<TurmaGetDetailDTO>> GetAllAsync()
    {
        var turmas = await repository.GetAllAsync();
        var turmaGetDetailDTO = new List<TurmaGetDetailDTO>();
        
        turmaGetDetailDTO.AddRange(turmas.Select(t => new TurmaGetDetailDTO
        {
            Id = t.Id,
            Nome = t.Nome,
            Descricao = t.Descricao,
            Curso = new CursoGetDTO
            {
                Id = t.Curso.Id,
                Nome = t.Curso.Nome,
                Descricao = t.Curso.Descricao,
            }
        }));
        
        return turmaGetDetailDTO;
    }

    public async Task<TurmaGetDTO> AddAsync(TurmaPostDTO dto)
    {
        var curso = await cursoRepository.GetByIdAsync(dto.CursoId);

        if (curso is null) throw new NotFoundException("Curso não  encontrado");
        
        var turma = new Turma
        {
            Nome = dto.Nome,
            Descricao = dto.Descricao,
            CursoId = dto.CursoId
        };
        
        var turmaCriada = await repository.AddAsync(turma);

        return new TurmaGetDTO
        {
            Id = turmaCriada.Id,
            Nome = turmaCriada.Nome,
            Descricao = turmaCriada.Descricao,
            CursoId = turmaCriada.CursoId
        };
    }

    public async Task<TurmaGetDTO> UpdateAsync(TurmaPutDTO dto)
    {
        var turma = await  repository.GetByIdAsync(dto.Id);

        if (turma is null) throw new NotFoundException("Turma não encontrada");
        
        var curso = await cursoRepository.GetByIdAsync(dto.CursoId);

        if (curso is null) throw new NotFoundException("Curso não encontrado");
        
        turma.Id = dto.Id;
        turma.Nome = dto.Nome;
        turma.Descricao = dto.Descricao;
        turma.CursoId = dto.CursoId;
        
        var turmaAtualizada = await repository.UpdateAsync(turma);
        
        if (turmaAtualizada is null) throw new BadRequestException("Ocorreu um erro ao atualizar a turma");

        return new TurmaGetDTO
        {
            Id = turmaAtualizada.Id,
            Nome = turmaAtualizada.Nome,
            Descricao = turmaAtualizada.Descricao,
            CursoId = turmaAtualizada.CursoId
        };
    }

    public async Task<TurmaGetDTO> DeleteAsync(int id)
    {
        var turmaRemovida = await repository.DeleteAsync(id);

        if (turmaRemovida is null) throw new NotFoundException("Turma não encontrada");

        return new TurmaGetDTO
        {
            Id = turmaRemovida.Id,
            Nome = turmaRemovida.Nome,
            Descricao = turmaRemovida.Descricao,
            CursoId = turmaRemovida.CursoId
        };
    }
}