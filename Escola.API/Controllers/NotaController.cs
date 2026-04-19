using Escola.Application.DTOs.Nota;
using Escola.Application.Interfaces;
using Escola.Infra.Ioc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotaController(INotaService notaService) : ControllerBase
{
    [HttpPost]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> CreateNota(NotaPostDTO notaPostDto)
    {
        await notaService.AddAsync(notaPostDto);
        return Ok(new { message = "Nota criada com sucesso!" });
    }

    [HttpPut]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> UpdateNota(NotaPutDTO notaPutDto)
    {
        await notaService.UpdateAsync(notaPutDto);
        return Ok(new { message = "Nota atualizada com sucesso!" });
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> DeleteNota(int id)
    {
        await notaService.DeleteAsync(id);
        return Ok(new { message = "Nota removida com sucesso!" });
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> GetNotaById(int id)
    {
        var nota = await notaService.GetByIdAsync(id);
        return Ok(nota);
    }

    [HttpGet]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> GetNotas()
    {
        var notas = await notaService.GetAllAsync();
        return Ok(notas);
    }

    [HttpGet("user/turma/{turmaId}")]
    [Authorize(Roles = "Aluno, Administrador")]
    public async Task<IActionResult> GetNotasByTurmaUsuario(int turmaId)
    {
        var usuarioId = User.GetUserId();
        var notas = await notaService.GetNotasByTurmaUsuario(turmaId, usuarioId);
        return Ok(notas);
    }
}