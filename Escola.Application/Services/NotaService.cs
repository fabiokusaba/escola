using Escola.Application.DTOs.Nota;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;

namespace Escola.Application.Services;

public class NotaService(INotaRepository repository) : INotaService
{
    public async Task<NotaGetDTO> GetByIdAsync(int id)
    {
        var nota = await repository.GetByIdAsync(id);

        if (nota is null) return null;

        return new NotaGetDTO
        {
            Id = nota.Id,
            MatriculaId = nota.MatriculaId,
            ValorNota = nota.ValorNota,
            Aprovado = nota.Aprovado,
            DataNota = nota.DataNota,
        };
    }

    public async Task<List<NotaGetDTO>> GetAllAsync()
    {
        var notas = await repository.GetAllAsync();

        return notas
            .Select(nota => new NotaGetDTO
            {
                Id = nota.Id,
                Aprovado = nota.Aprovado,
                DataNota = nota.DataNota,
                MatriculaId = nota.MatriculaId,
                ValorNota = nota.ValorNota
            })
            .ToList();
    }

    public async Task<NotaGetDTO> AddAsync(NotaPostDTO dto)
    {
        var nota = new Nota
        {
            MatriculaId = dto.MatriculaId,
            ValorNota = dto.ValorNota,
            Aprovado = dto.Aprovado,
            DataNota = dto.DataNota
        };

        var notaCriada = await repository.AddAsync(nota);

        return new NotaGetDTO
        {
            Id = notaCriada.Id,
            Aprovado = notaCriada.Aprovado,
            DataNota = notaCriada.DataNota,
            MatriculaId = nota.MatriculaId,
            ValorNota = notaCriada.ValorNota
        };
    }

    public async Task<NotaGetDTO> UpdateAsync(NotaPutDTO dto)
    {
        var nota = new Nota
        {
            Id = dto.Id,
            MatriculaId = dto.MatriculaId,
            ValorNota = dto.ValorNota,
            Aprovado = dto.Aprovado,
            DataNota = dto.DataNota
        };
        
        var notaAtualizada = await repository.UpdateAsync(nota);

        return new NotaGetDTO
        {
            Id = notaAtualizada.Id,
            Aprovado = notaAtualizada.Aprovado,
            DataNota = notaAtualizada.DataNota,
            MatriculaId = notaAtualizada.MatriculaId,
            ValorNota = notaAtualizada.ValorNota
        };
    }

    public async Task<NotaGetDTO> DeleteAsync(int id)
    {
        var notaRemovida = await repository.DeleteAsync(id);

        if (notaRemovida is null) return null;

        return new NotaGetDTO
        {
            Id = notaRemovida.Id,
            Aprovado = notaRemovida.Aprovado,
            DataNota = notaRemovida.DataNota,
            MatriculaId = notaRemovida.MatriculaId,
            ValorNota = notaRemovida.ValorNota
        };
    }
}