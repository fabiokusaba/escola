using Escola.Application.DTOs.Matricula;
using Escola.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MatriculaController(IMatriculaService matriculaService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateMatricula(MatriculaPostDTO matriculaPostDto)
    {
        await matriculaService.AddAsync(matriculaPostDto);
        return Ok(new { message = "Matrícula criada com sucesso!" });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateMatricula(MatriculaPutDTO matriculaPutDto)
    {
        await matriculaService.UpdateAsync(matriculaPutDto);
        return Ok(new { message = "Matricula atualizada com sucesso!" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMatricula(int id)
    {
        await matriculaService.DeleteAsync(id);
        return Ok(new { message = "Matricula removida com sucesso!" });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMatriculaById(int id)
    {
        var matricula = await matriculaService.GetByIdAsync(id);
        return Ok(matricula);
    }

    [HttpGet]
    public async Task<IActionResult> GetMatriculas()
    {
        var matriculas = await matriculaService.GetAllAsync();
        return Ok(matriculas);
    }
}