using Escola.Application.DTOs.Turma;
using Escola.Application.Interfaces;
using Escola.Infra.Ioc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TurmaController(ITurmaService turmaService) : ControllerBase
{
    [HttpPost]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> CreateTurma(TurmaPostDTO turmaPostDto)
    {
        await turmaService.AddAsync(turmaPostDto);
        return Ok(new { message = "Turma criada com sucesso!" });
    }

    [HttpPut]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> UpdateTurma(TurmaPutDTO turmaPutDto)
    {
        await turmaService.UpdateAsync(turmaPutDto);
        return Ok(new { message = "Turma atualizada com sucesso!" });
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> DeleteTurma(int id)
    {
        await turmaService.DeleteAsync(id);
        return Ok(new { message = "Turma removida com sucesso!" });
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> GetTurmaById(int id)
    {
        var turma = await turmaService.GetByIdAsync(id);
        return Ok(turma);
    }

    [HttpGet]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> GetTurmas()
    {
        var turmas = await turmaService.GetAllAsync();
        return Ok(turmas);
    }

    [HttpGet("user")]
    [Authorize(Roles = "Aluno, Administrador")]
    public async Task<IActionResult> GetAllTurmasByUsuario()
    {
        var usuarioId = User.GetUserId();
        var turmas = await turmaService.GetTurmasByUsuario(usuarioId);
        return Ok(turmas);
    }
    
}