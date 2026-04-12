using Escola.Application.DTOs.Curso;
using Escola.Application.DTOs.Turma;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;

namespace Escola.Application.Services;

public class TurmaService(ITurmaRepository repository) : ITurmaService
{
    public async Task<TurmaGetDetailDTO> GetByIdAsync(int id)
    {
        var turma = await repository.GetByIdAsync(id);

        if (turma is null) return null;

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
        var turma = new Turma
        {
            Id = dto.Id,
            Nome = dto.Nome,
            Descricao = dto.Descricao,
            CursoId = dto.CursoId
        };

        var turmaAtualizada = await repository.UpdateAsync(turma);
        
        if (turmaAtualizada is null) return null;

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

        if (turmaRemovida is null) return null;

        return new TurmaGetDTO
        {
            Id = turmaRemovida.Id,
            Nome = turmaRemovida.Nome,
            Descricao = turmaRemovida.Descricao,
            CursoId = turmaRemovida.CursoId
        };
    }
}