using Escola.Application.DTOs.Matricula;
using Escola.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MatriculaController(IMatriculaService matriculaService) : ControllerBase
{
    private readonly  IMatriculaService _matriculaService = matriculaService;

    [HttpPost]
    public async Task<IActionResult> CreateMatricula(MatriculaPostDTO matriculaPostDto)
    {
        var matriculaCriada = await _matriculaService.AddAsync(matriculaPostDto);

        if (matriculaCriada is null) return BadRequest("Não foi possível criar a matrícula");

        return Ok(new { message = "Matrícula criada com sucesso!" });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateMatricula(MatriculaPutDTO matriculaPutDto)
    {
        var matriculaAtualizada = await _matriculaService.UpdateAsync(matriculaPutDto);

        if (matriculaAtualizada is null) return BadRequest("Ocorreu um erro ao atualizar a matrícula");
        
        return Ok(new { message = "Matricula atualizada com sucesso!" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMatricula(int id)
    {
        var matriculaRemovida = await _matriculaService.DeleteAsync(id);

        if (matriculaRemovida is null) return BadRequest("Ocorreu um erro ao remover a matrícula");
        
        return Ok(new { message = "Matricula removida com sucesso!" });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMatriculaById(int id)
    {
        var matricula = await _matriculaService.GetByIdAsync(id);

        if (matricula is null) return NotFound("Matrícula não encontrada");

        return Ok(matricula);
    }

    [HttpGet]
    public async Task<IActionResult> GetMatriculas()
    {
        var matriculas = await _matriculaService.GetAllAsync();

        return Ok(matriculas);
    }
}