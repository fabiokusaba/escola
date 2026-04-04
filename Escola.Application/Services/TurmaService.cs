using Escola.Application.DTOs.Turma;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;

namespace Escola.Application.Services;

public class TurmaService(ITurmaRepository repository) : ITurmaService
{
    public async Task<TurmaGetDTO> GetByIdAsync(int id)
    {
        var turma = await repository.GetByIdAsync(id);

        if (turma is null) return null;

        return new TurmaGetDTO
        {
            Id = turma.Id,
            Nome = turma.Nome,
            Descricao = turma.Descricao,
            CursoId = turma.CursoId,
        };
    }

    public async Task<List<TurmaGetDTO>> GetAllAsync()
    {
        var turmas = await repository.GetAllAsync();

        return turmas
            .Select(turma => new TurmaGetDTO
            {
                Id = turma.Id,
                Nome = turma.Nome,
                Descricao = turma.Descricao,
                CursoId = turma.CursoId
            })
            .ToList();
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