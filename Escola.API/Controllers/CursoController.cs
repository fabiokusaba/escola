using Escola.API.Extensions;
using Escola.API.Models;
using Escola.Application.DTOs.Curso;
using Escola.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Administrador")]
public class CursoController(ICursoService cursoService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateCurso(CursoPostDTO cursoPostDto)
    {
        await cursoService.AddAsync(cursoPostDto);
        return Ok(new { message = "Curso criado com sucesso!" });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCurso(CursoPutDTO cursoPutDto)
    {
        await cursoService.UpdateAsync(cursoPutDto);
        return Ok(new { message = "Curso atualizado com sucesso!" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCurso(int id)
    {
        await cursoService.DeleteAsync(id);
        return Ok(new { message = "Curso removido com sucesso!" });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCursoById(int id)
    {
        var curso = await cursoService.GetByIdAsync(id);
        return Ok(curso);
    }

    [HttpGet]
    public async Task<IActionResult> GetCursos([FromQuery] PaginationParams paginationParams)
    {
        var cursos = await cursoService
            .GetAllAsync(paginationParams.PageNumber, paginationParams.PageSize);
        Response.AddPaginationHeader(
            new PaginationHeader(paginationParams.PageNumber, 
                paginationParams.PageSize, cursos.TotalCount, cursos.TotalPages)
            );
        return Ok(cursos);
    }
}