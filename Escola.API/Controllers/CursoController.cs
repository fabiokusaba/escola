using Escola.Application.DTOs.Curso;
using Escola.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CursoController(ICursoService cursoService) : ControllerBase
{
    private readonly ICursoService _cursoService = cursoService;

    [HttpPost]
    public async Task<IActionResult> CreateCurso(CursoPostDTO cursoPostDto)
    {
        var cursoCriado = await _cursoService.AddAsync(cursoPostDto);

        if (cursoCriado is null) return BadRequest("Não foi possível criar o curso");
        
        return Ok(new { message = "Curso criado com sucesso!" });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCurso(CursoPutDTO cursoPutDto)
    {
        var cursoAtualizado = await _cursoService.UpdateAsync(cursoPutDto);

        if (cursoAtualizado is null) return BadRequest("Ocorreu um erro ao atualizar o curso");
        
        return Ok(new { message = "Curso atualizado com sucesso!" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCurso(int id)
    {
        var cursoRemovido = await _cursoService.DeleteAsync(id);

        if (cursoRemovido is null) return BadRequest("Ocorreu um erro ao remover o curso");
        
        return Ok(new { message = "Curso removido com sucesso!" });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCursoById(int id)
    {
        var curso = await _cursoService.GetByIdAsync(id);

        if (curso is null) return NotFound("Curso não encontrado");
        
        return Ok(curso);
    }

    [HttpGet]
    public async Task<IActionResult> GetCursos()
    {
        var cursos = await _cursoService.GetAllAsync();

        return Ok(cursos);
    }
}