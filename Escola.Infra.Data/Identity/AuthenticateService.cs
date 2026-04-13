using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Escola.Domain.Account;
using Escola.Domain.Entities;
using Escola.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Escola.Infra.Data.Identity;

public class AuthenticateService(ApplicationDbContext dbContext, IConfiguration configuration) : IAuthenticate
{
    public string GenerateToken(int usuarioId, string email, string role)
    {
        var claims = new[]
        {
            new Claim("id", usuarioId.ToString()),
            new Claim("email", email.ToLower()),
            new Claim(ClaimTypes.Role, role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };
        
        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));
        var credentials = new  SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(
            issuer: configuration["JWT:Issuer"],
            audience: configuration["JWT:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials
        );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<Usuario> GetUsuarioByEmail(string email)
    {
        return await dbContext.Usuario
            .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower() && u.Excluido == false);
    }

    public async Task<bool> UsuarioExiste(string email)
    {
        return await dbContext.Usuario.AnyAsync(u => u.Email.ToLower() == email.ToLower() && u.Excluido == false);
    }

    public async Task<bool> AuthenticateAsync(string email, string senha)
    {
        var usuario =  await dbContext.Usuario
            .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower() && u.Excluido == false);

        if (usuario is null || usuario.Excluido) return false;

        using var hmac = new HMACSHA512(usuario.PasswordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
        
        return computedHash.SequenceEqual(usuario.PasswordHash);
    }
}