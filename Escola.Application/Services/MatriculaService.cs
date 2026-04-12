using Escola.Application.DTOs.Matricula;
using Escola.Application.DTOs.Turma;
using Escola.Application.DTOs.Usuario;
using Escola.Application.Exceptions;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;

namespace Escola.Application.Services;

public class MatriculaService(IMatriculaRepository repository, ITurmaRepository turmaRepository, IUsuarioRepository usuarioRepository) : IMatriculaService
{
    public async Task<MatriculaGetDetailDTO> GetByIdAsync(int id)
    {
        var matricula = await repository.GetByIdAsync(id);

        if (matricula is null) throw new NotFoundException("Matrícula não encontrada");

        return new MatriculaGetDetailDTO
        {
            Id = matricula.Id,
            DataMatricula = matricula.DataMatricula,
            DataExpiracao = matricula.DataExpiracao,
            Ativa = matricula.Ativa,
            Usuario = new UsuarioGetDTO
            {
                Id = matricula.Usuario.Id,
                Nome = matricula.Usuario.Nome,
                Email = matricula.Usuario.Email
            },
            Turma = new TurmaGetDTO
            {
                Id = matricula.Turma.Id,
                Nome = matricula.Turma.Nome,
                Descricao = matricula.Turma.Descricao
            }
        };
    }

    public async Task<List<MatriculaGetDetailDTO>> GetAllAsync()
    {
        var matriculas = await repository.GetAllAsync();
        var matriculaGetDetailDTO = new List<MatriculaGetDetailDTO>();
        
        matriculaGetDetailDTO.AddRange(matriculas.Select(m => new MatriculaGetDetailDTO
        {
            Id = m.Id,
            DataMatricula = m.DataMatricula,
            DataExpiracao = m.DataExpiracao,
            Ativa = m.Ativa,
            Usuario = new UsuarioGetDTO
            {
                Id = m.Usuario.Id,
                Nome = m.Usuario.Nome,
                Email = m.Usuario.Email
            },
            Turma = new TurmaGetDTO
            {
                Id = m.Turma.Id,
                Nome = m.Turma.Nome,
                Descricao = m.Turma.Descricao
            }
        }));

        return matriculaGetDetailDTO;
    }

    public async Task<MatriculaGetDTO> AddAsync(MatriculaPostDTO dto)
    {
        var turma = await turmaRepository.GetByIdAsync(dto.TurmaId);

        if (turma is null) throw new NotFoundException("Turma não encontrada");

        var usuario = await usuarioRepository.GetByIdAsync(dto.UsuarioId);

        if (usuario is null) throw new NotFoundException("Usuário não encontrado");
        
        
        var matricula = new Matricula
        {
            UsuarioId = dto.UsuarioId,
            TurmaId = dto.TurmaId,
            Ativa = true,
            DataMatricula = DateTime.UtcNow,
            DataExpiracao = dto.DataExpiracao
        };
        
        var matriculaCriada = await repository.AddAsync(matricula);

        if (matriculaCriada is null) throw new BadRequestException("Ocorreu um erro ao criar a matrícula");

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
        var turma = await turmaRepository.GetByIdAsync(dto.TurmaId);

        if (turma is null) throw new NotFoundException("Turma não encontrado");
        
        var matricula = new Matricula
        {
            Id = dto.Id,
            TurmaId = dto.TurmaId,
            DataExpiracao = dto.DataExpiracao
        };
        
        var matriculaAtualizada = await repository.UpdateAsync(matricula);

        if (matriculaAtualizada is null) throw new BadRequestException("Ocorreu um erro ao atualizar a matrícula");

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

        if (matriculaRemovida is null) throw new NotFoundException("Matrícula não encontrada");

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