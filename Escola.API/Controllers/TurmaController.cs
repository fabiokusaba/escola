using Escola.Application.DTOs.Turma;
using Escola.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TurmaController(ITurmaService turmaService) : ControllerBase
{
    private readonly ITurmaService _turmaService = turmaService;
    
    [HttpPost]
    public async Task<IActionResult> CreateTurma(TurmaPostDTO turmaPostDto)
    {
        var turmaCriada = await _turmaService.AddAsync(turmaPostDto);

        if (turmaCriada is null) return BadRequest("Não foi possível criar a turma");
        
        return Ok(new { message = "Turma criada com sucesso!" });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTurma(TurmaPutDTO turmaPutDto)
    {
        var turmaAtualizada = await _turmaService.UpdateAsync(turmaPutDto);

        if (turmaAtualizada is null) return BadRequest("Ocorreu um erro ao atualizar a turma");
        
        return Ok(new { message = "Turma atualizada com sucesso!" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTurma(int id)
    {
        var turmaRemovida = await _turmaService.DeleteAsync(id);

        if (turmaRemovida is null) return BadRequest("Ocorreu um erro ao remover a turma");
        
        return Ok(new { message = "Turma removida com sucesso!" });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTurmaById(int id)
    {
        var turma = await _turmaService.GetByIdAsync(id);

        if (turma is null) return NotFound("Turma não encontrada");

        return Ok(turma);
    }

    [HttpGet]
    public async Task<IActionResult> GetTurmas()
    {
        var turmas = await _turmaService.GetAllAsync();
        
        return Ok(turmas);
    }
}