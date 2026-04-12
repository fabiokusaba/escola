using Escola.Application.DTOs.Turma;
using Escola.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TurmaController(ITurmaService turmaService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateTurma(TurmaPostDTO turmaPostDto)
    {
        await turmaService.AddAsync(turmaPostDto);
        return Ok(new { message = "Turma criada com sucesso!" });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTurma(TurmaPutDTO turmaPutDto)
    {
        await turmaService.UpdateAsync(turmaPutDto);
        return Ok(new { message = "Turma atualizada com sucesso!" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTurma(int id)
    {
        await turmaService.DeleteAsync(id);
        return Ok(new { message = "Turma removida com sucesso!" });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTurmaById(int id)
    {
        var turma = await turmaService.GetByIdAsync(id);
        return Ok(turma);
    }

    [HttpGet]
    public async Task<IActionResult> GetTurmas()
    {
        var turmas = await turmaService.GetAllAsync();
        return Ok(turmas);
    }
}