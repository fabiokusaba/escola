using Escola.Application.DTOs.Nota;
using Escola.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotaController(INotaService notaService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateNota(NotaPostDTO notaPostDto)
    {
        await notaService.AddAsync(notaPostDto);
        return Ok(new { message = "Nota criada com sucesso!" });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateNota(NotaPutDTO notaPutDto)
    {
        await notaService.UpdateAsync(notaPutDto);
        return Ok(new { message = "Nota atualizada com sucesso!" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNota(int id)
    {
        await notaService.DeleteAsync(id);
        return Ok(new { message = "Nota removida com sucesso!" });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetNotaById(int id)
    {
        var nota = await notaService.GetByIdAsync(id);
        return Ok(nota);
    }

    [HttpGet]
    public async Task<IActionResult> GetNotas()
    {
        var notas = await notaService.GetAllAsync();
        return Ok(notas);
    }
}