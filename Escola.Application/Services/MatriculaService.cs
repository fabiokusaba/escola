using Escola.Application.DTOs.Matricula;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;

namespace Escola.Application.Services;

public class MatriculaService(IMatriculaRepository repository) : IMatriculaService
{
    public async Task<MatriculaGetDTO> GetByIdAsync(int id)
    {
        var matricula = await repository.GetByIdAsync(id);

        if (matricula is null) return null;

        return new MatriculaGetDTO
        {
            Id = matricula.Id,
            UsuarioId = matricula.UsuarioId,
            TurmaId = matricula.TurmaId,
            Ativa = matricula.Ativa,
            DataMatricula = matricula.DataMatricula,
            DataExpiracao = matricula.DataExpiracao,
        };
    }

    public async Task<List<MatriculaGetDTO>> GetAllAsync()
    {
        var matriculas = await repository.GetAllAsync();
        
        return matriculas
            .Select(matricula => new MatriculaGetDTO
            {
                Id = matricula.Id, 
                TurmaId = matricula.TurmaId, 
                UsuarioId = matricula.UsuarioId, 
                Ativa = matricula.Ativa,
                DataMatricula = matricula.DataMatricula,
                DataExpiracao = matricula.DataExpiracao
            })
            .ToList();
    }

    public async Task<MatriculaGetDTO> AddAsync(MatriculaPostDTO dto)
    {
        var matricula = new Matricula
        {
            UsuarioId = dto.UsuarioId,
            TurmaId = dto.TurmaId,
            Ativa = dto.Ativa,
            DataMatricula = dto.DataMatricula,
            DataExpiracao = dto.DataExpiracao
        };
        
        var matriculaCriada = await repository.AddAsync(matricula);

        return new MatriculaGetDTO
        {
            Id = matriculaCriada.Id,
            UsuarioId = matriculaCriada.UsuarioId,
            TurmaId = matriculaCriada.TurmaId,
            Ativa = matriculaCriada.Ativa,
            DataMatricula = matriculaCriada.DataMatricula,
            DataExpiracao = matriculaCriada.DataExpiracao
        };
    }

    public async Task<MatriculaGetDTO> UpdateAsync(MatriculaPutDTO dto)
    {
        var matricula = new Matricula
        {
            Id = dto.Id,
            UsuarioId = dto.UsuarioId,
            TurmaId = dto.TurmaId,
            Ativa = dto.Ativa,
            DataMatricula = dto.DataMatricula,
            DataExpiracao = dto.DataExpiracao
        };
        
        var matriculaAtualizada = await repository.UpdateAsync(matricula);

        return new MatriculaGetDTO
        {
            Id = matriculaAtualizada.Id,
            UsuarioId = matriculaAtualizada.UsuarioId,
            TurmaId = matriculaAtualizada.TurmaId,
            Ativa = matriculaAtualizada.Ativa,
            DataMatricula = matriculaAtualizada.DataMatricula,
            DataExpiracao = matriculaAtualizada.DataExpiracao
        };
    }

    public async Task<MatriculaGetDTO> DeleteAsync(int id)
    {
        var matriculaRemovida = await repository.DeleteAsync(id);

        if (matriculaRemovida is null) return null;

        return new MatriculaGetDTO
        {
            Id = matriculaRemovida.Id,
            UsuarioId = matriculaRemovida.UsuarioId,
            TurmaId = matriculaRemovida.TurmaId,
            Ativa = matriculaRemovida.Ativa,
            DataMatricula = matriculaRemovida.DataMatricula,
            DataExpiracao = matriculaRemovida.DataExpiracao
        };
    }
}