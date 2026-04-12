using Escola.Application.DTOs.Nota;
using Escola.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotaController(INotaService notaService) : ControllerBase
{
    private readonly INotaService _notaService = notaService;

    [HttpPost]
    public async Task<IActionResult> CreateNota(NotaPostDTO notaPostDto)
    {
        var notaCriada = await _notaService.AddAsync(notaPostDto);

        if (notaCriada is null) return BadRequest("Não foi possível criar a nota");

        return Ok(new { message = "Nota criada com sucesso!" });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateNota(NotaPutDTO notaPutDto)
    {
        var notaAtualizada = await _notaService.UpdateAsync(notaPutDto);

        if (notaAtualizada is null) return BadRequest("Ocorreu um erro ao atualizar a nota");
        
        return Ok(new { message = "Nota atualizada com sucesso!" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNota(int id)
    {
        var notaRemovida = await _notaService.DeleteAsync(id);

        if (notaRemovida is null) return BadRequest("Ocorreu um erro ao remover a nota");
        
        return Ok(new { message = "Nota removida com sucesso!" });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetNotaById(int id)
    {
        var nota = await _notaService.GetByIdAsync(id);

        if (nota is null) return NotFound("Nota não encontrada");

        return Ok(nota);
    }

    [HttpGet]
    public async Task<IActionResult> GetNotas()
    {
        var notas = await _notaService.GetAllAsync();
        
        return Ok(notas);
    }
}