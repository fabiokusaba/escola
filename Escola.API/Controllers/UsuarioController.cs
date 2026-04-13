using Escola.API.Models;
using Escola.Application.DTOs.Usuario;
using Escola.Application.Interfaces;
using Escola.Domain.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController(IUsuarioService usuarioService, IAuthenticate authenticate) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUsuario(UsuarioPostDTO usuarioPostDto)
    {
        var usuarioExiste = await authenticate.UsuarioExiste(usuarioPostDto.Email);

        if (usuarioExiste) return BadRequest("E-mail de usuário já cadastrado no banco");
        
        var usuario = await usuarioService.AddAsync(usuarioPostDto);
        
        var token = authenticate.GenerateToken(usuario.Id, usuario.Email.ToLower(), usuario.Perfil);
        
        return Ok(new { Nome = usuario.Nome, Token = token });
    }

    [HttpPost("login")]
    public async Task<IActionResult> GetTokenUsuario(UsuarioLogin usuarioLogin)
    {
        var usuario = await authenticate.GetUsuarioByEmail(usuarioLogin.Email);
        
        if (usuario is null) return BadRequest("Usuário ou senha inválidos");
        
        var usuarioValido = await authenticate.AuthenticateAsync(usuarioLogin.Email, usuarioLogin.Senha);

        if (!usuarioValido) return BadRequest("Usuário ou senha inválidos");
        
        var token = authenticate.GenerateToken(usuario.Id, usuario.Email.ToLower(), usuario.Perfil);
        return Ok(new { Nome = usuario.Nome, Token = token });
    }

    [HttpGet]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> GetUsuarios()
    {
        var usuarios = await usuarioService.GetAllAsync();
        return Ok(usuarios);
    }
}